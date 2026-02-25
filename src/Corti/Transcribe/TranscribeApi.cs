using System.Net.WebSockets;
using System.Text.Json;
using Corti.Core;
using Corti.Core.Async;
using Corti.Core.Async.Events;
using Corti.Core.Async.Models;

namespace Corti;

public partial class TranscribeApi : AsyncApi<TranscribeApi.Options>
{
    /// <summary>
    /// Event handler for TranscribeConfigStatusMessage.
    /// Use TranscribeConfigStatusMessage.Subscribe(...) to receive messages.
    /// </summary>
    public readonly Event<TranscribeConfigStatusMessage> TranscribeConfigStatusMessage = new();

    /// <summary>
    /// Event handler for TranscribeUsageMessage.
    /// Use TranscribeUsageMessage.Subscribe(...) to receive messages.
    /// </summary>
    public readonly Event<TranscribeUsageMessage> TranscribeUsageMessage = new();

    /// <summary>
    /// Event handler for TranscribeFlushedMessage.
    /// Use TranscribeFlushedMessage.Subscribe(...) to receive messages.
    /// </summary>
    public readonly Event<TranscribeFlushedMessage> TranscribeFlushedMessage = new();

    /// <summary>
    /// Event handler for TranscribeEndedMessage.
    /// Use TranscribeEndedMessage.Subscribe(...) to receive messages.
    /// </summary>
    public readonly Event<TranscribeEndedMessage> TranscribeEndedMessage = new();

    /// <summary>
    /// Event handler for TranscribeErrorMessage.
    /// Use TranscribeErrorMessage.Subscribe(...) to receive messages.
    /// </summary>
    public readonly Event<TranscribeErrorMessage> TranscribeErrorMessage = new();

    /// <summary>
    /// Event handler for TranscribeTranscriptMessage.
    /// Use TranscribeTranscriptMessage.Subscribe(...) to receive messages.
    /// </summary>
    public readonly Event<TranscribeTranscriptMessage> TranscribeTranscriptMessage = new();

    /// <summary>
    /// Event handler for TranscribeCommandMessage.
    /// Use TranscribeCommandMessage.Subscribe(...) to receive messages.
    /// </summary>
    public readonly Event<TranscribeCommandMessage> TranscribeCommandMessage = new();

    /// <summary>
    /// Constructor with options
    /// </summary>
    public TranscribeApi(TranscribeApi.Options options)
        : base(options) { }

    /// <summary>
    /// Specifies the tenant context.
    /// </summary>
    public string TenantName
    {
        get => ApiOptions.TenantName;
        set =>
            NotifyIfPropertyChanged(
                EqualityComparer<string>.Default.Equals(ApiOptions.TenantName),
                ApiOptions.TenantName = value
            );
    }

    /// <summary>
    /// Bearer access token for authentication.
    /// </summary>
    public string Token
    {
        get => ApiOptions.Token;
        set =>
            NotifyIfPropertyChanged(
                EqualityComparer<string>.Default.Equals(ApiOptions.Token),
                ApiOptions.Token = value
            );
    }

    /// <summary>
    /// The Environment for the API connection.
    /// </summary>
    public string Environment
    {
        get => ApiOptions.Environment;
        set =>
            NotifyIfPropertyChanged(
                EqualityComparer<string>.Default.Equals(ApiOptions.Environment),
                ApiOptions.Environment = value
            );
    }

    /// <summary>
    /// Creates the Uri for the websocket connection from the BaseUrl and parameters
    /// </summary>
    protected override Uri CreateUri()
    {
        var uri = new UriBuilder(BaseUrl)
        {
            Query = new Query() { { "tenant-name", TenantName }, { "token", Token } },
        };
        uri.Path = $"{uri.Path.TrimEnd('/')}/transcribe";
        return uri.Uri;
    }

    protected override void SetConnectionOptions(ClientWebSocketOptions options) { }

    /// <summary>
    /// Dispatches incoming WebSocket messages
    /// </summary>
    protected async override Task OnTextMessage(Stream stream)
    {
        var json = await JsonSerializer.DeserializeAsync<JsonDocument>(stream);
        if (json == null)
        {
            await ExceptionOccurred
                .RaiseEvent(new Exception("Invalid message - Not valid JSON"))
                .ConfigureAwait(false);
            return;
        }

        // deserialize the message to find the correct event
        {
            if (JsonUtils.TryDeserialize(json, out TranscribeConfigStatusMessage? message))
            {
                await TranscribeConfigStatusMessage.RaiseEvent(message!).ConfigureAwait(false);
                return;
            }
        }

        {
            if (JsonUtils.TryDeserialize(json, out TranscribeUsageMessage? message))
            {
                await TranscribeUsageMessage.RaiseEvent(message!).ConfigureAwait(false);
                return;
            }
        }

        {
            if (JsonUtils.TryDeserialize(json, out TranscribeFlushedMessage? message))
            {
                await TranscribeFlushedMessage.RaiseEvent(message!).ConfigureAwait(false);
                return;
            }
        }

        {
            if (JsonUtils.TryDeserialize(json, out TranscribeEndedMessage? message))
            {
                await TranscribeEndedMessage.RaiseEvent(message!).ConfigureAwait(false);
                return;
            }
        }

        {
            if (JsonUtils.TryDeserialize(json, out TranscribeErrorMessage? message))
            {
                await TranscribeErrorMessage.RaiseEvent(message!).ConfigureAwait(false);
                return;
            }
        }

        {
            if (JsonUtils.TryDeserialize(json, out TranscribeTranscriptMessage? message))
            {
                await TranscribeTranscriptMessage.RaiseEvent(message!).ConfigureAwait(false);
                return;
            }
        }

        {
            if (JsonUtils.TryDeserialize(json, out TranscribeCommandMessage? message))
            {
                await TranscribeCommandMessage.RaiseEvent(message!).ConfigureAwait(false);
                return;
            }
        }

        await ExceptionOccurred
            .RaiseEvent(new Exception($"Unknown message: {json.ToString()}"))
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Disposes of event subscriptions
    /// </summary>
    protected override void DisposeEvents()
    {
        TranscribeConfigStatusMessage.Dispose();
        TranscribeUsageMessage.Dispose();
        TranscribeFlushedMessage.Dispose();
        TranscribeEndedMessage.Dispose();
        TranscribeErrorMessage.Dispose();
        TranscribeTranscriptMessage.Dispose();
        TranscribeCommandMessage.Dispose();
    }

    /// <summary>
    /// Sends a TranscribeConfigMessage message to the server
    /// </summary>
    public async Task Send(TranscribeConfigMessage message)
    {
        await SendInstant(JsonUtils.Serialize(message)).ConfigureAwait(false);
    }

    /// <summary>
    /// Sends a audio message to the server
    /// </summary>
    public async Task Send(byte[] message)
    {
        await SendInstant(JsonUtils.Serialize(message)).ConfigureAwait(false);
    }

    /// <summary>
    /// Sends a TranscribeFlushMessage message to the server
    /// </summary>
    public async Task Send(TranscribeFlushMessage message)
    {
        await SendInstant(JsonUtils.Serialize(message)).ConfigureAwait(false);
    }

    /// <summary>
    /// Sends a TranscribeEndMessage message to the server
    /// </summary>
    public async Task Send(TranscribeEndMessage message)
    {
        await SendInstant(JsonUtils.Serialize(message)).ConfigureAwait(false);
    }

    /// <summary>
    /// Options for the API client
    /// </summary>
    public class Options : AsyncApiOptions
    {
        /// <summary>
        /// The Websocket URL for the API connection.
        /// </summary>
        override public string BaseUrl
        {
            get => TranscribeApi.Environments.getBaseUrl(base.BaseUrl);
            set => base.BaseUrl = value;
        }

        /// <summary>
        /// The Environment for the API connection.
        /// </summary>
        public string Environment
        {
            get => base.BaseUrl;
            set => base.BaseUrl = value;
        }

        /// <summary>
        /// Specifies the tenant context.
        /// </summary>
        public required string TenantName { get; set; }

        /// <summary>
        /// Bearer access token for authentication.
        /// </summary>
        public required string Token { get; set; }
    }

    /// <summary>
    /// Selectable endpoint URLs for the API client
    /// </summary>
    public static class Environments
    {
        public static string EU { get; set; } = "wss://api.eu.corti.app/audio-bridge/v2";

        public static string US { get; set; } = "wss://api.us.corti.app/audio-bridge/v2";

        internal static string getBaseUrl(string environment)
        {
            switch (environment)
            {
                case "EU":
                    return EU;
                case "US":
                    return US;
                default:
                    return string.IsNullOrEmpty(environment)
                        ? "wss://api.eu.corti.app/audio-bridge/v2"
                        : environment;
            }
        }
    }
}
