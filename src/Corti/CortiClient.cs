using Corti.Core;

namespace Corti;

public partial class CortiClient : ICortiClient
{
    private readonly RawClient _client;

    public CortiClient(CortiClientOptions options)
    {
        var tenantName = options.TenantName ?? throw new ArgumentException("TenantName is required.", nameof(options));
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
            var authHeaders = new Headers(
                new Dictionary<string, string>() { { "Tenant-Name", tenantName } }
            );
            foreach (var header in authHeaders)
            {
                clientOptionsWithAuth.Headers[header.Key] = header.Value;
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

    private static IAuthTokenProvider CreateAuthTokenProvider(CortiClientAuth auth, ClientOptions authOptions)
    {
        if (auth == null)
            throw new ArgumentException("Auth is required.", nameof(auth));
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
        throw new ArgumentException("Auth must be ClientCredentials, Bearer, or Ropc.", nameof(auth));
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
