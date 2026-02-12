using CortiApi.Core;

namespace CortiApi;

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
        clientOptions ??= new ClientOptions();
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
            new Dictionary<string, string>() { { "Tenant-Name", tenantName ?? "" } }
        );
        foreach (var header in authHeaders)
        {
            clientOptionsWithAuth.Headers[header.Key] = header.Value;
        }
        var tokenProvider = new OAuthTokenProvider(
            clientId,
            clientSecret,
            new OauthClient(new RawClient(clientOptions))
        );
        clientOptionsWithAuth.Headers["Authorization"] =
            new Func<global::System.Threading.Tasks.ValueTask<string>>(async () =>
                await tokenProvider.GetAccessTokenAsync().ConfigureAwait(false)
            );
        _client = new RawClient(clientOptionsWithAuth);
        Interactions = new InteractionsClient(_client);
        Recordings = new RecordingsClient(_client);
        Transcripts = new TranscriptsClient(_client);
        Facts = new FactsClient(_client);
        Documents = new DocumentsClient(_client);
        Templates = new TemplatesClient(_client);
        Codes = new CodesClient(_client);
        Auth = new AuthClient(_client);
        Oauth = new OauthClient(_client);
    }

    public IInteractionsClient Interactions { get; }

    public IRecordingsClient Recordings { get; }

    public ITranscriptsClient Transcripts { get; }

    public IFactsClient Facts { get; }

    public IDocumentsClient Documents { get; }

    public ITemplatesClient Templates { get; }

    public ICodesClient Codes { get; }

    public IAuthClient Auth { get; }

    public IOauthClient Oauth { get; }
}
