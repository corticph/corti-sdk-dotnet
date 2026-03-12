using Corti.Core;

namespace Corti;

public partial class CortiClient : ICortiClient
{
    private readonly RawClient _client;

    /// <summary>
    /// Explicit tenant + environment: use for ClientCredentials, Ropc, or any Bearer variant when
    /// tenant and environment are already known.
    /// </summary>
    public CortiClient(
        string tenantName,
        CortiClientEnvironment environment,
        CortiClientAuth auth,
        CortiRequestOptions? requestOptions = null)
        : this(new CortiClientOptions
        {
            TenantName = tenantName,
            Environment = environment,
            Auth = auth,
            RequestOptions = requestOptions,
        }) { }

    /// <summary>
    /// Auto-derive: tenant and environment are decoded from the JWT inside the bearer token.
    /// Accepts <see cref="CortiClientAuth.Bearer"/> or <see cref="CortiClientAuth.BearerCustomRefresh"/>.
    /// </summary>
    public CortiClient(CortiClientBearerAuth auth, CortiRequestOptions? requestOptions = null)
        : this(ResolveFromBearer(auth, requestOptions)) { }

    /// <summary>
    /// Proxy / passthrough: custom environment URLs with no credentials and no tenant name.
    /// Every request is forwarded without an Authorization header — a 401 from the server is expected
    /// unless the caller supplies its own auth header via <see cref="CortiRequestOptions.AdditionalHeaders"/>.
    /// </summary>
    public CortiClient(CortiClientEnvironment environment, CortiRequestOptions? requestOptions = null)
        : this(new CortiClientOptions
        {
            Environment = environment,
            RequestOptions = requestOptions,
        }) { }

    private CortiClient(CortiClientOptions options)
    {
        // Patch: TenantName is only required when auth is present; proxy/passthrough mode (null auth) may omit it
        var tenantName = options.TenantName;
        if (tenantName == null && options.Auth != null)
            throw new ArgumentException("TenantName is required.", nameof(options));

        var clientOptions = BuildClientOptions(options);

        try
        {
            clientOptions.ExceptionHandler = new ExceptionHandler(
                new CortiExceptionInterceptor(clientOptions)
            );
            var platformHeaders = new Headers(
                new Dictionary<string, string>()
                {
                    { "X-Fern-Language", "C#" },
                    { "X-Fern-SDK-Name", "Corti" },
                    { "X-Fern-SDK-Version", Version.Current },
                }
            );
            foreach (var header in platformHeaders)
            {
                if (!clientOptions.Headers.ContainsKey(header.Key))
                {
                    clientOptions.Headers[header.Key] = header.Value;
                }
            }
            var clientOptionsWithAuth = clientOptions.Clone();
            // Patch: only set Tenant-Name header when tenantName is known (proxy mode may omit it)
            if (tenantName != null)
            {
                var authHeaders = new Headers(
                    new Dictionary<string, string>() { { "Tenant-Name", tenantName } }
                );
                foreach (var header in authHeaders)
                {
                    clientOptionsWithAuth.Headers[header.Key] = header.Value;
                }
            }
            // Patch: auth options without Authorization so token requests don't resolve the bearer delegate (avoids stack overflow)
            var authOptions = clientOptionsWithAuth.Clone();
            IAuthTokenProvider tokenProvider = CreateAuthTokenProvider(options.Auth, authOptions);
            clientOptionsWithAuth.Headers["Authorization"] =
                new Func<global::System.Threading.Tasks.ValueTask<string>>(async () =>
                    await tokenProvider.GetAccessTokenAsync().ConfigureAwait(false)
                );
            _client = new RawClient(clientOptionsWithAuth);
            // Patch: CustomAuthClient instead of AuthClient
            Auth = new CustomAuthClient(new RawClient(authOptions));
            Interactions = new InteractionsClient(_client);
            Recordings = new RecordingsClient(_client);
            Transcripts = new TranscriptsClient(_client);
            Facts = new FactsClient(_client);
            Documents = new DocumentsClient(_client);
            Templates = new TemplatesClient(_client);
            Codes = new CodesClient(_client);
            Agents = new AgentsClient(_client);
        }
        catch (Exception ex)
        {
            var interceptor = new CortiExceptionInterceptor(clientOptions);
            interceptor.Intercept(ex);
            throw;
        }
    }

    private static CortiClientOptions ResolveFromBearer(CortiClientBearerAuth auth, CortiRequestOptions? requestOptions)
    {
        // Seed token: for BearerCustomRefresh without an initial AccessToken we must call the
        // delegate once anyway (to decode the JWT). Carry the result forward so
        // BearerWithRefreshTokenProvider doesn't call the delegate a second time on the first request.
        var resolvedAuth = (CortiClientAuth)auth;

        string? accessToken;

        if (auth is CortiClientAuth.Bearer b)
        {
            accessToken = b.AccessToken;
        }
        else if (auth is CortiClientAuth.BearerCustomRefresh bcr && bcr.AccessToken != null)
        {
            accessToken = bcr.AccessToken;
        }
        else
        {
            var bcr2 = (CortiClientAuth.BearerCustomRefresh)auth;
            var seedResult = bcr2.RefreshAccessToken(bcr2.RefreshToken, CancellationToken.None)
                                 .GetAwaiter().GetResult();
            accessToken = seedResult.AccessToken;
            // Seed the auth record so the provider starts with a pre-populated token
            resolvedAuth = bcr2 with { AccessToken = seedResult.AccessToken, ExpiresIn = seedResult.ExpiresIn ?? bcr2.ExpiresIn };
        }

        var decoded = TokenDecoder.Decode(accessToken);
        if (decoded == null)
            throw new ArgumentException(
                "TenantName and Environment could not be derived from the token. Provide them explicitly via the (tenantName, environment, auth) constructor.",
                nameof(auth));

        return new CortiClientOptions
        {
            TenantName = decoded.TenantName,
            Environment = decoded.Environment, // implicit string → CortiClientEnvironment
            Auth = resolvedAuth,
            RequestOptions = requestOptions,
        };
    }

    private static IAuthTokenProvider CreateAuthTokenProvider(CortiClientAuth? auth, ClientOptions authOptions)
    {
        // Patch: null auth — proxy/passthrough mode; no Authorization header is added
        if (auth == null)
            return new BearerTokenProvider(string.Empty);
        if (auth is CortiClientAuth.ClientCredentials cc)
            return new OAuthTokenProvider(cc.ClientId, cc.ClientSecret, new CustomAuthClient(new RawClient(authOptions)));
        if (auth is CortiClientAuth.Bearer b)
        {
            if (b.RefreshAccessToken != null || (b.RefreshToken != null && b.ClientId != null))
                return new BearerWithRefreshTokenProvider(
                    b.ClientId,
                    b.AccessToken,
                    b.RefreshToken,
                    b.ExpiresIn,
                    b.RefreshExpiresIn,
                    b.RefreshAccessToken,
                    new CustomAuthClient(new RawClient(authOptions))
                );
            return new BearerTokenProvider(b.AccessToken ?? string.Empty);
        }
        if (auth is CortiClientAuth.BearerCustomRefresh bcr)
        {
            return new BearerWithRefreshTokenProvider(
                clientId: null,
                bcr.AccessToken,
                bcr.RefreshToken,
                bcr.ExpiresIn,
                bcr.RefreshExpiresIn,
                bcr.RefreshAccessToken,
                new CustomAuthClient(new RawClient(authOptions))
            );
        }
        if (auth is CortiClientAuth.Ropc r)
            return new OAuthRopcTokenProvider(
                r.ClientId,
                r.Username,
                r.Password,
                new CustomAuthClient(new RawClient(authOptions))
            );
        throw new ArgumentException("Auth must be ClientCredentials, Bearer, BearerCustomRefresh, or Ropc.", nameof(auth));
    }

    private static ClientOptions BuildClientOptions(CortiClientOptions options)
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

    // Patch: type CustomAuthClient instead of IAuthClient
    public CustomAuthClient Auth { get; }

    public IInteractionsClient Interactions { get; }

    public IRecordingsClient Recordings { get; }

    public ITranscriptsClient Transcripts { get; }

    public IFactsClient Facts { get; }

    public IDocumentsClient Documents { get; }

    public ITemplatesClient Templates { get; }

    public ICodesClient Codes { get; }

    public IAgentsClient Agents { get; }

    public StreamApi CreateStreamApi(StreamApi.Options options)
    {
        return new StreamApi(options);
    }

    public TranscribeApi CreateTranscribeApi(TranscribeApi.Options options)
    {
        return new TranscribeApi(options);
    }
}
