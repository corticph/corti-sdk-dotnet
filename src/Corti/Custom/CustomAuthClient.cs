using Corti.Core;

namespace Corti;

/// <summary>
/// Patch: Extends AuthClient; GetTokenAsync calls the real tenant token endpoint (client_credentials), not fake-token.
/// Pre-call: ArgumentNullException for null request, InvalidOperationException when Tenant-Name is missing. API errors (4xx) come from base as CortiClientApiException / BadRequestError / UnauthorizedError.
/// </summary>
public sealed class CustomAuthClient : AuthClient
{
    private readonly RawClient _client;

    internal CustomAuthClient(RawClient client)
        : base(client)
    {
        _client = client;
    }

    /// <summary>
    /// Creates a CustomAuthClient instance from the same shape of options as CortiClient (tenant + environment, no auth). Use <see cref="GetTokenAsync"/> to exchange client credentials for an access token.
    /// </summary>
    public static CustomAuthClient Create(CortiAuthClientOptions options)
    {
        var clientOptions = BuildClientOptions(options);
        var optionsWithTenant = clientOptions.Clone();
        optionsWithTenant.Headers["Tenant-Name"] = options.TenantName;

        return new CustomAuthClient(new RawClient(optionsWithTenant));
    }

    private static ClientOptions BuildClientOptions(CortiAuthClientOptions options)
    {
        var ro = options.RequestOptions;
        return new ClientOptions
        {
            Environment = options.Environment,
            HttpClient = ro?.HttpClient ?? new HttpClient(),
            MaxRetries = ro?.MaxRetries ?? 2,
            Timeout = ro?.Timeout ?? TimeSpan.FromSeconds(30),
            AdditionalHeaders = ro?.AdditionalHeaders ?? [],
        };
    }

    /// <summary>
    /// Exchanges client credentials for a short-lived access token using the tenant token endpoint (client_credentials). Tenant name is taken from client options (Tenant-Name header). Use <see cref="OAuthTokenRequestWithScopes"/> to request optional scopes; "openid" is always included.
    /// </summary>
    public new WithRawResponseTask<AuthTokenResponse> GetTokenAsync(
        OAuthTokenRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var body = BuildTokenRequestBody(request);
        return new WithRawResponseTask<AuthTokenResponse>(
            GetTokenAsyncCore(body, options, cancellationToken)
        );
    }

    /// <summary>
    /// Exchanges ROPC credentials (clientId, username, password) for a short-lived access token using the tenant token endpoint (password grant). Use <see cref="OAuthRopcTokenRequestWithScopes"/> to request optional scopes; "openid" is always included.
    /// </summary>
    public WithRawResponseTask<AuthTokenResponse> GetTokenAsync(
        OAuthRopcTokenRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var body = BuildRopcTokenRequestBody(request);
        return new WithRawResponseTask<AuthTokenResponse>(
            GetTokenAsyncCore(AuthTokenRequestBody.FromAuthTokenRequestRopc(body), options, cancellationToken)
        );
    }

    /// <summary>
    /// Exchanges a refresh token for a new access token using the tenant token endpoint (refresh_token grant). Use <see cref="OAuthRefreshTokenRequestWithScopes"/> to request optional scopes; "openid" is always included.
    /// </summary>
    public WithRawResponseTask<AuthTokenResponse> GetTokenAsync(
        OAuthRefreshTokenRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var body = BuildRefreshTokenRequestBody(request);
        return new WithRawResponseTask<AuthTokenResponse>(
            GetTokenAsyncCore(AuthTokenRequestBody.FromAuthTokenRequestRefresh(body), options, cancellationToken)
        );
    }

    private async Task<WithRawResponse<AuthTokenResponse>> GetTokenAsyncCore(
        AuthTokenRequestBody body,
        RequestOptions? options,
        CancellationToken cancellationToken
    )
    {
        var tenantName = await GetTenantNameAsync(cancellationToken).ConfigureAwait(false);
        return await TokenAsync(tenantName, body, options, cancellationToken)
            .WithRawResponse()
            .ConfigureAwait(false);
    }

    private async ValueTask<string> GetTenantNameAsync(CancellationToken cancellationToken) =>
        await _client.Options.Headers["Tenant-Name"].ResolveAsync().ConfigureAwait(false);

    private static AuthTokenRequestClientCredentials BuildTokenRequestBody(
        OAuthTokenRequest request
    )
    {
        var scopeString =
            request is OAuthTokenRequestWithScopes withScopes
                ? BuildScopeString(withScopes.Scopes)
                : "openid";

        return new AuthTokenRequestClientCredentials
        {
            ClientId = request.ClientId,
            ClientSecret = request.ClientSecret,
            GrantType = "client_credentials",
            Scope = scopeString,
        };
    }

    private static AuthTokenRequestRopc BuildRopcTokenRequestBody(OAuthRopcTokenRequest request)
    {
        var scopeString =
            request is OAuthRopcTokenRequestWithScopes withScopes
                ? BuildScopeString(withScopes.Scopes)
                : "openid";

        return new AuthTokenRequestRopc
        {
            ClientId = request.ClientId,
            Username = request.Username,
            Password = request.Password,
            GrantType = "password",
            Scope = scopeString,
        };
    }

    private static AuthTokenRequestRefresh BuildRefreshTokenRequestBody(OAuthRefreshTokenRequest request)
    {
        var scopeString =
            request is OAuthRefreshTokenRequestWithScopes withScopes
                ? BuildScopeString(withScopes.Scopes)
                : "openid";

        return new AuthTokenRequestRefresh
        {
            ClientId = request.ClientId,
            RefreshToken = request.RefreshToken,
            ClientSecret = request.ClientSecret,
            GrantType = "refresh_token",
            Scope = scopeString,
        };
    }

    private static string BuildScopeString(IEnumerable<string>? scopes)
    {
        var all = new List<string> { "openid" };

        if (scopes != null)
            all.AddRange(scopes);

        return string.Join(" ", all.Distinct(StringComparer.Ordinal));
    }
}
