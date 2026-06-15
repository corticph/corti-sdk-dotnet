namespace Corti;

public partial interface IStreamApi
{
    /// <summary>
    /// Connects and sends configuration, resolving only after CONFIG_ACCEPTED.
    /// </summary>
    public Task ConnectAsync(StreamConfig configuration, CancellationToken cancellationToken = default);
}
