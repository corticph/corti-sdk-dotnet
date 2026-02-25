using Corti.Core;

namespace Corti;

public partial class CortiClient
{
    private readonly RawClient _client;

    public CortiClient(
        string? token = null,
        string? tenantName = null,
        ClientOptions? clientOptions = null
    )
    {
        var defaultHeaders = new Headers(
            new Dictionary<string, string>()
            {
                { "Authorization", $"Bearer {token ?? ""}" },
                { "Tenant-Name", tenantName ?? "" },
                { "X-Fern-Language", "C#" },
                { "X-Fern-SDK-Name", "Corti" },
                { "X-Fern-SDK-Version", Version.Current },
            }
        );
        clientOptions ??= new ClientOptions();
        foreach (var header in defaultHeaders)
        {
            if (!clientOptions.Headers.ContainsKey(header.Key))
            {
                clientOptions.Headers[header.Key] = header.Value;
            }
        }
        _client = new RawClient(clientOptions);
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

    public AuthClient Auth { get; }

    public InteractionsClient Interactions { get; }

    public RecordingsClient Recordings { get; }

    public TranscriptsClient Transcripts { get; }

    public FactsClient Facts { get; }

    public DocumentsClient Documents { get; }

    public TemplatesClient Templates { get; }

    public CodesClient Codes { get; }

    public AgentsClient Agents { get; }

    public StreamApi CreateStreamApi(StreamApi.Options options)
    {
        return new StreamApi(options);
    }

    public TranscribeApi CreateTranscribeApi(TranscribeApi.Options options)
    {
        return new TranscribeApi(options);
    }
}
