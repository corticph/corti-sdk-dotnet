namespace Corti.Agentic.Registry;

public partial interface IRegistryClient
{
    public IConnectorsClient Connectors { get; }
}
