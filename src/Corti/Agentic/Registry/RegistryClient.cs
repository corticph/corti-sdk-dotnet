using Corti.Core;

namespace Corti.Agentic.Registry;

public partial class RegistryClient : IRegistryClient
{
    private readonly RawClient _client;

    internal RegistryClient(RawClient client)
    {
        try
        {
            _client = client;
            Connectors = new ConnectorsClient(_client);
        }
        catch (Exception ex)
        {
            client.Options.ExceptionHandler?.CaptureException(ex);
            throw;
        }
    }

    public IConnectorsClient Connectors { get; }
}
