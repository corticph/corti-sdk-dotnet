using Corti.Core;
using Corti.Core.WebSockets;

namespace Corti;

public partial class TranscribeApi
{
    /// <summary>
    /// Patch: stamp x-corti-analytics onto the WebSocket query, merged with extra parameters.
    /// </summary>
    public TranscribeApi(
        TranscribeApi.Options options,
        IEnumerable<KeyValuePair<string, string>>? additionalQueryParameters,
        Dictionary<string, string>? analytics)
    {
        _options = options;
        var uri = new UriBuilder(_options.BaseUrl)
        {
            Query = new QueryStringBuilder.Builder(capacity: 2)
                .Add("tenant-name", _options.TenantName)
                .Add("token", _options.Token)
                .MergeAdditional(AnalyticsHelper.WithAnalytics(analytics, additionalQueryParameters))
                .Build(),
        };
        uri.Path = $"{uri.Path.TrimEnd('/')}/transcribe";
        _client = new WebSocketClient(uri.Uri, OnTextMessage);
        _client.HttpInvoker = _options.HttpInvoker;
        _client.IsReconnectionEnabled = _options.IsReconnectionEnabled;
        _client.ReconnectTimeout = _options.ReconnectTimeout;
        _client.ErrorReconnectTimeout = _options.ErrorReconnectTimeout;
        _client.LostReconnectTimeout = _options.LostReconnectTimeout;
        _client.Backoff = _options.ReconnectBackoff;
    }

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
}
