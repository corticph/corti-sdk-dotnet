namespace CortiApi;

public partial interface ICortiClient
{
    public IInteractionsClient Interactions { get; }
    public IRecordingsClient Recordings { get; }
}
