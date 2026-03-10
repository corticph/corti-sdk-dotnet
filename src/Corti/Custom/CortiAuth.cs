using Corti.Core;

namespace Corti;

/// <summary>
/// Patch: Extends AuthClient; GetTokenAsync calls the real tenant token endpoint (client_credentials), not fake-token.
/// Pre-call: ArgumentNullException for null request, InvalidOperationException when Tenant-Name is missing. API errors (4xx) come from base as CortiClientApiException / BadRequestError / UnauthorizedError.
/// </summary>
public sealed class CortiAuth : AuthClient
{
    private readonly RawClient _client;

    internal CortiAuth(RawClient client)
        : base(client)
    {
        _client = client;
    }

    /// <summary>
    /// Creates a CortiAuth instance for the given options and tenant. Use <see cref="GetTokenAsync"/> to exchange client credentials for an access token.
    /// </summary>
    public static CortiAuth Create(ClientOptions options, string tenantName)
    {
        var optionsWithTenant = options.Clone();
        optionsWithTenant.Headers["Tenant-Name"] = tenantName;
        return new CortiAuth(new RawClient(optionsWithTenant));
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

    private async Task<WithRawResponse<AuthTokenResponse>> GetTokenAsyncCore(
        AuthTokenRequestClientCredentials body,
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

    private static string BuildScopeString(IEnumerable<string>? scopes)
    {
        var all = new List<string> { "openid" };

        if (scopes != null)
            all.AddRange(scopes);

        return string.Join(" ", all.Distinct(StringComparer.Ordinal));
    }
}
