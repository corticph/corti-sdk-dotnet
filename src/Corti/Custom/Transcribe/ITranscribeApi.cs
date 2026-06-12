namespace Corti;

public partial interface ITranscribeApi
{
    /// <summary>
    /// Connects and sends configuration, resolving only after CONFIG_ACCEPTED.
    /// </summary>
    public Task ConnectAsync(TranscribeConfig configuration, CancellationToken cancellationToken = default);
}
