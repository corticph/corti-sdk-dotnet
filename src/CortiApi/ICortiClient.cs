namespace CortiApi;

public partial interface ICortiClient
{
    public IInteractionsClient Interactions { get; }
    public IRecordingsClient Recordings { get; }
    public ITranscriptsClient Transcripts { get; }
    public IFactsClient Facts { get; }
    public IDocumentsClient Documents { get; }
    public ICodesClient Codes { get; }
}
