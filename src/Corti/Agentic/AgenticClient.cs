using Corti.Core;

namespace Corti.Agentic;

public partial class AgenticClient : IAgenticClient
{
    private readonly RawClient _client;

    internal AgenticClient(RawClient client)
    {
        try
        {
            _client = client;
            Agents = new AgentsClient(_client);
            Models = new ModelsClient(_client);
        }
        catch (Exception ex)
        {
            client.Options.ExceptionHandler?.CaptureException(ex);
            throw;
        }
    }

    public IAgentsClient Agents { get; }

    public IModelsClient Models { get; }
}
