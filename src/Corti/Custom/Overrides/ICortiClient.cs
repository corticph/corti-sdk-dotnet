using IAgenticClient = Corti.Agentic.IAgenticClient;

namespace Corti;

public partial interface ICortiClient
{
    // Patch: CustomAuthClient instead of IAuthClient for stronger typing
    public CustomAuthClient Auth { get; }
    public IInteractionsClient Interactions { get; }
    public IRecordingsClient Recordings { get; }
    public ITranscriptsClient Transcripts { get; }
    public IFactsClient Facts { get; }
    public IDocumentsClient Documents { get; }
    public ITemplatesClient Templates { get; }
    public ICodesClient Codes { get; }
    public ILanguagesClient Languages { get; }
    public IAgentsClient Agents { get; }
    public IAgenticClient Agentic { get; }
    Task<IStreamApi> CreateStreamApiAsync(
        string interactionId,
        IEnumerable<KeyValuePair<string, string>>? additionalQueryParameters = null);
    Task<ITranscribeApi> CreateTranscribeApiAsync(
        IEnumerable<KeyValuePair<string, string>>? additionalQueryParameters = null);
}
