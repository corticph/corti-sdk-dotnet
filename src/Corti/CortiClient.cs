using Corti.Core;

namespace Corti;

public partial class CortiClient : ICortiClient
{
    private readonly RawClient _client;

    public CortiClient(
        string? clientId = null,
        string? clientSecret = null,
        string? tenantName = null,
        ClientOptions? clientOptions = null
    )
    {
        try
        {
            clientOptions ??= new ClientOptions();
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
                new Dictionary<string, string>() { { "Tenant-Name", tenantName ?? "" } }
            );
            foreach (var header in authHeaders)
            {
                clientOptionsWithAuth.Headers[header.Key] = header.Value;
            }
            var tokenProvider = new OAuthTokenProvider(
                clientId,
                clientSecret,
                new AuthClient(new RawClient(clientOptions))
            );
            clientOptionsWithAuth.Headers["Authorization"] =
                new Func<global::System.Threading.Tasks.ValueTask<string>>(async () =>
                    await tokenProvider.GetAccessTokenAsync().ConfigureAwait(false)
                );
            _client = new RawClient(clientOptionsWithAuth);
            Auth = new AuthClient(_client);
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

    public IAuthClient Auth { get; }

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
