using System.Text.Json;
using Corti.Core.WebSockets;

namespace Corti;

public partial class StreamApi
{
    /// <summary>
    /// Connects and sends configuration, resolving only after CONFIG_ACCEPTED.
    /// Throws <see cref="InvalidOperationException"/> on CONFIG_DENIED / CONFIG_MISSING /
    /// CONFIG_TIMEOUT / CONFIG_NOT_PROVIDED.
    /// </summary>
    public async Task ConnectAsync(
        StreamConfig configuration,
        CancellationToken cancellationToken = default)
    {
        await ConnectAsync(cancellationToken).ConfigureAwait(false);

        await ConnectWithConfigAckAsync(configuration, cancellationToken).ConfigureAwait(false);
    }

    private async Task ConnectWithConfigAckAsync(StreamConfig configuration, CancellationToken cancellationToken)
    {
        var tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

        Action<StreamConfigStatusMessage>? handler = null;
        handler = (msg) =>
        {
            if (msg.Type == StreamConfigStatusMessageType.ConfigAccepted)
            {
                StreamConfigStatusMessage.Unsubscribe(handler!);
                tcs.TrySetResult(true);
            }
            else if (
                msg.Type == StreamConfigStatusMessageType.ConfigDenied ||
                msg.Type == StreamConfigStatusMessageType.ConfigMissing ||
                msg.Type == StreamConfigStatusMessageType.ConfigTimeout ||
                msg.Type == StreamConfigStatusMessageType.ConfigNotProvided)
            {
                StreamConfigStatusMessage.Unsubscribe(handler!);
                tcs.TrySetException(new InvalidOperationException($"Config rejected: {msg.Type}"));
            }
        };

        StreamConfigStatusMessage.Subscribe(handler);

        await Send(new StreamConfigMessage { Configuration = configuration }, cancellationToken).ConfigureAwait(false);

        try
        {
            await tcs.Task.ConfigureAwait(false);
        }
        catch
        {
            await CloseAsync(cancellationToken).ConfigureAwait(false);
            throw;
        }
    }

    Event<StreamConfigStatusMessage> IStreamApi.StreamConfigStatusMessage => StreamConfigStatusMessage;
    Event<StreamTranscriptMessage> IStreamApi.StreamTranscriptMessage => StreamTranscriptMessage;
    Event<StreamFactsMessage> IStreamApi.StreamFactsMessage => StreamFactsMessage;
    Event<StreamFlushedMessage> IStreamApi.StreamFlushedMessage => StreamFlushedMessage;
    Event<StreamEndedMessage> IStreamApi.StreamEndedMessage => StreamEndedMessage;
    Event<StreamUsageMessage> IStreamApi.StreamUsageMessage => StreamUsageMessage;
    Event<StreamErrorMessage> IStreamApi.StreamErrorMessage => StreamErrorMessage;
    Event<JsonElement> IStreamApi.UnknownMessage => UnknownMessage;
}
