using Corti.Agentic.Registry;

namespace Corti.Agentic;

public partial interface IAgenticClient
{
    public IAgentsClient Agents { get; }
    public IContextsClient Contexts { get; }
    public IModelsClient Models { get; }
    public IRegistryClient Registry { get; }
}
