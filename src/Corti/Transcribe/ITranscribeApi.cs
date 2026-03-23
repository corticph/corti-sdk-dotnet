using Corti.Core.WebSockets;

namespace Corti;

public partial interface ITranscribeApi : IAsyncDisposable, IDisposable
{
    public Event<Connected> Connected { get; }
    public Event<Closed> Closed { get; }
    public Event<Exception> ExceptionOccurred { get; }
    public Event<ReconnectionInfo> Reconnecting { get; }
    public ConnectionStatus Status { get; }
    Task ConnectAsync(CancellationToken cancellationToken = default);

    Task Send(TranscribeConfigMessage message, CancellationToken cancellationToken = default);

    Task Send(byte[] message, CancellationToken cancellationToken = default);

    Task Send(TranscribeFlushMessage message, CancellationToken cancellationToken = default);

    Task Send(TranscribeEndMessage message, CancellationToken cancellationToken = default);

    Task CloseAsync(CancellationToken cancellationToken = default);
}
