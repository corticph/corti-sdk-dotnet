using Corti.Core.WebSockets;
using global::System.Text.Json;

namespace Corti;

public partial interface IStreamApi : IAsyncDisposable, IDisposable
{
    public Event<Connected> Connected { get; }
    public Event<Closed> Closed { get; }
    public Event<Exception> ExceptionOccurred { get; }
    public Event<ReconnectionInfo> Reconnecting { get; }
    public Event<StreamTranscriptMessage> StreamTranscriptMessage { get; }
    public Event<StreamFactsMessage> StreamFactsMessage { get; }
    public Event<StreamFlushedMessage> StreamFlushedMessage { get; }
    public Event<StreamDeltaUsageMessage> StreamDeltaUsageMessage { get; }
    public Event<StreamEndedMessage> StreamEndedMessage { get; }
    public Event<StreamUsageMessage> StreamUsageMessage { get; }
    public Event<StreamErrorMessage> StreamErrorMessage { get; }
    public Event<StreamAudioEventMessage> StreamAudioEventMessage { get; }
    public Event<StreamConfigStatusMessage> StreamConfigStatusMessage { get; }
    public Event<JsonElement> UnknownMessage { get; }
    public ConnectionStatus Status { get; }
    Task ConnectAsync(CancellationToken cancellationToken = default);

    Task Send(StreamConfigMessage message, CancellationToken cancellationToken = default);

    Task Send(byte[] message, CancellationToken cancellationToken = default);

    Task Send(StreamFlushMessage message, CancellationToken cancellationToken = default);

    Task Send(StreamEndMessage message, CancellationToken cancellationToken = default);

    Task CloseAsync(CancellationToken cancellationToken = default);
}
