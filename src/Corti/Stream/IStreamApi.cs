using Corti.Core.WebSockets;

namespace Corti;

public partial interface IStreamApi : IAsyncDisposable, IDisposable
{
    public Event<Connected> Connected { get; }
    public Event<Closed> Closed { get; }
    public Event<Exception> ExceptionOccurred { get; }
    public Event<ReconnectionInfo> Reconnecting { get; }
    public ConnectionStatus Status { get; }
    Task ConnectAsync(CancellationToken cancellationToken = default);

    Task Send(StreamConfigMessage message, CancellationToken cancellationToken = default);

    Task Send(byte[] message, CancellationToken cancellationToken = default);

    Task Send(StreamFlushMessage message, CancellationToken cancellationToken = default);

    Task Send(StreamEndMessage message, CancellationToken cancellationToken = default);

    Task CloseAsync(CancellationToken cancellationToken = default);
}
