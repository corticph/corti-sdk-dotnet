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
    public IAgentsClient Agents { get; }
    IStreamApi CreateStreamApi(StreamApi.Options options);
    ITranscribeApi CreateTranscribeApi(TranscribeApi.Options options);
}
