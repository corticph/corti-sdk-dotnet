namespace CortiApi;

public partial interface ICortiApiClient
{
    public IInteractionsClient Interactions { get; }
    public IRecordingsClient Recordings { get; }
    public ITranscriptsClient Transcripts { get; }
    public IFactsClient Facts { get; }
    public IDocumentsClient Documents { get; }
    public ITemplatesClient Templates { get; }
    public ICodesClient Codes { get; }
    public IAuthClient Auth { get; }
    public IAgentsClient Agents { get; }
}
