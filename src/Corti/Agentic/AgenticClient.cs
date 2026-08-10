using Corti.Agentic.Registry;
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
            Contexts = new ContextsClient(_client);
            Models = new ModelsClient(_client);
            Registry = new RegistryClient(_client);
        }
        catch (Exception ex)
        {
            client.Options.ExceptionHandler?.CaptureException(ex);
            throw;
        }
    }

    public IAgentsClient Agents { get; }

    public IContextsClient Contexts { get; }

    public IModelsClient Models { get; }

    public IRegistryClient Registry { get; }
}
