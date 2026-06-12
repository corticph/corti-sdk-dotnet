using Corti.Core.WebSockets;
using global::System.Text.Json;

namespace Corti;

public partial interface ITranscribeApi : IAsyncDisposable, IDisposable
{
    public Event<Connected> Connected { get; }
    public Event<Closed> Closed { get; }
    public Event<Exception> ExceptionOccurred { get; }
    public Event<ReconnectionInfo> Reconnecting { get; }
    public Event<TranscribeUsageMessage> TranscribeUsageMessage { get; }
    public Event<TranscribeFlushedMessage> TranscribeFlushedMessage { get; }
    public Event<TranscribeDeltaUsageMessage> TranscribeDeltaUsageMessage { get; }
    public Event<TranscribeEndedMessage> TranscribeEndedMessage { get; }
    public Event<TranscribeErrorMessage> TranscribeErrorMessage { get; }
    public Event<TranscribeTranscriptMessage> TranscribeTranscriptMessage { get; }
    public Event<TranscribeCommandMessage> TranscribeCommandMessage { get; }
    public Event<TranscribeConfigStatusMessage> TranscribeConfigStatusMessage { get; }
    public Event<TranscribeAudioEventMessage> TranscribeAudioEventMessage { get; }
    public Event<JsonElement> UnknownMessage { get; }
    public ConnectionStatus Status { get; }
    Task ConnectAsync(CancellationToken cancellationToken = default);

    Task Send(TranscribeConfigMessage message, CancellationToken cancellationToken = default);

    Task Send(byte[] message, CancellationToken cancellationToken = default);

    Task Send(TranscribeFlushMessage message, CancellationToken cancellationToken = default);

    Task Send(TranscribeEndMessage message, CancellationToken cancellationToken = default);

    Task CloseAsync(CancellationToken cancellationToken = default);
}
