using CortiApi.Core;

namespace CortiApi;

public partial class CortiClient : ICortiClient
{
    private readonly RawClient _client;

    public CortiClient(string tenantName, string? token = null, ClientOptions? clientOptions = null)
    {
        try
        {
            clientOptions ??= new ClientOptions();
            clientOptions.ExceptionHandler = new ExceptionHandler(
                new CortiApiExceptionInterceptor(clientOptions)
            );
            var platformHeaders = new Headers(
                new Dictionary<string, string>()
                {
                    { "X-Fern-Language", "C#" },
                    { "X-Fern-SDK-Name", "CortiApi" },
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
                new Dictionary<string, string>()
                {
                    { "Tenant-Name", tenantName },
                    { "Authorization", $"Bearer {token ?? ""}" },
                }
            );
            foreach (var header in authHeaders)
            {
                clientOptionsWithAuth.Headers[header.Key] = header.Value;
            }
            _client = new RawClient(clientOptionsWithAuth);
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
            var interceptor = new CortiApiExceptionInterceptor(clientOptions);
            interceptor.Intercept(ex);
            throw;
        }
    }

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
