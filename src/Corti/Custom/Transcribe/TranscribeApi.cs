using System.Text.Json;
using Corti.Core.WebSockets;

namespace Corti;

public partial class TranscribeApi
{
    /// <summary>
    /// Connects and sends configuration, resolving only after CONFIG_ACCEPTED.
    /// Throws <see cref="InvalidOperationException"/> on CONFIG_DENIED / CONFIG_TIMEOUT /
    /// CONFIG_MISSING.
    /// </summary>
    public async Task ConnectAsync(
        TranscribeConfig configuration,
        CancellationToken cancellationToken = default)
    {
        await ConnectAsync(cancellationToken).ConfigureAwait(false);

        await ConnectWithConfigAckAsync(configuration, cancellationToken).ConfigureAwait(false);
    }

    private async Task ConnectWithConfigAckAsync(TranscribeConfig configuration, CancellationToken cancellationToken)
    {
        var tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

        Action<TranscribeConfigStatusMessage>? handler = null;
        handler = (msg) =>
        {
            if (
                msg.Type == TranscribeConfigStatusMessageType.ConfigAccepted
                || msg.Type == TranscribeConfigStatusMessageType.ConfigAlreadyReceived
            )
            {
                TranscribeConfigStatusMessage.Unsubscribe(handler!);
                tcs.TrySetResult(true);
            }
            else if (
                msg.Type == TranscribeConfigStatusMessageType.ConfigDenied ||
                msg.Type == TranscribeConfigStatusMessageType.ConfigTimeout ||
                msg.Type == TranscribeConfigStatusMessageType.ConfigMissing)
            {
                TranscribeConfigStatusMessage.Unsubscribe(handler!);
                tcs.TrySetException(new InvalidOperationException($"Config rejected: {msg.Type}"));
            }
        };

        TranscribeConfigStatusMessage.Subscribe(handler);

        await Send(new TranscribeConfigMessage { Configuration = configuration }, cancellationToken).ConfigureAwait(false);

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

    Event<TranscribeConfigStatusMessage> ITranscribeApi.TranscribeConfigStatusMessage => TranscribeConfigStatusMessage;
    Event<TranscribeUsageMessage> ITranscribeApi.TranscribeUsageMessage => TranscribeUsageMessage;
    Event<TranscribeFlushedMessage> ITranscribeApi.TranscribeFlushedMessage => TranscribeFlushedMessage;
    Event<TranscribeEndedMessage> ITranscribeApi.TranscribeEndedMessage => TranscribeEndedMessage;
    Event<TranscribeErrorMessage> ITranscribeApi.TranscribeErrorMessage => TranscribeErrorMessage;
    Event<TranscribeTranscriptMessage> ITranscribeApi.TranscribeTranscriptMessage => TranscribeTranscriptMessage;
    Event<TranscribeCommandMessage> ITranscribeApi.TranscribeCommandMessage => TranscribeCommandMessage;
    Event<JsonElement> ITranscribeApi.UnknownMessage => UnknownMessage;
}
