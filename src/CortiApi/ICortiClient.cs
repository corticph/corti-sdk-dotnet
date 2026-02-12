namespace CortiApi;

public partial interface ICortiClient
{
    public IInteractionsClient Interactions { get; }
    public IAuthClient Auth { get; }
    public IOauthClient Oauth { get; }
}
