using System.Net.WebSockets;
using System.Text.Json;
using Corti.Core;
using Corti.Core.Async;
using Corti.Core.Async.Events;
using Corti.Core.Async.Models;

namespace Corti;

public partial class StreamApi : AsyncApi<StreamApi.Options>
{
    /// <summary>
    /// Event handler for StreamConfigStatusMessage.
    /// Use StreamConfigStatusMessage.Subscribe(...) to receive messages.
    /// </summary>
    public readonly Event<StreamConfigStatusMessage> StreamConfigStatusMessage = new();

    /// <summary>
    /// Event handler for StreamTranscriptMessage.
    /// Use StreamTranscriptMessage.Subscribe(...) to receive messages.
    /// </summary>
    public readonly Event<StreamTranscriptMessage> StreamTranscriptMessage = new();

    /// <summary>
    /// Event handler for StreamFactsMessage.
    /// Use StreamFactsMessage.Subscribe(...) to receive messages.
    /// </summary>
    public readonly Event<StreamFactsMessage> StreamFactsMessage = new();

    /// <summary>
    /// Event handler for StreamFlushedMessage.
    /// Use StreamFlushedMessage.Subscribe(...) to receive messages.
    /// </summary>
    public readonly Event<StreamFlushedMessage> StreamFlushedMessage = new();

    /// <summary>
    /// Event handler for StreamEndedMessage.
    /// Use StreamEndedMessage.Subscribe(...) to receive messages.
    /// </summary>
    public readonly Event<StreamEndedMessage> StreamEndedMessage = new();

    /// <summary>
    /// Event handler for StreamUsageMessage.
    /// Use StreamUsageMessage.Subscribe(...) to receive messages.
    /// </summary>
    public readonly Event<StreamUsageMessage> StreamUsageMessage = new();

    /// <summary>
    /// Event handler for StreamErrorMessage.
    /// Use StreamErrorMessage.Subscribe(...) to receive messages.
    /// </summary>
    public readonly Event<StreamErrorMessage> StreamErrorMessage = new();

    /// <summary>
    /// Constructor with options
    /// </summary>
    public StreamApi(StreamApi.Options options)
        : base(options) { }

    /// <summary>
    /// Unique identifier for the interaction session.
    /// </summary>
    public string Id
    {
        get => ApiOptions.Id;
        set =>
            NotifyIfPropertyChanged(
                EqualityComparer<string>.Default.Equals(ApiOptions.Id),
                ApiOptions.Id = value
            );
    }

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
        uri.Path = $"{uri.Path.TrimEnd('/')}/interactions/{Uri.EscapeDataString(Id)}/streams";
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
            if (JsonUtils.TryDeserialize(json, out StreamConfigStatusMessage? message))
            {
                await StreamConfigStatusMessage.RaiseEvent(message!).ConfigureAwait(false);
                return;
            }
        }

        {
            if (JsonUtils.TryDeserialize(json, out StreamTranscriptMessage? message))
            {
                await StreamTranscriptMessage.RaiseEvent(message!).ConfigureAwait(false);
                return;
            }
        }

        {
            if (JsonUtils.TryDeserialize(json, out StreamFactsMessage? message))
            {
                await StreamFactsMessage.RaiseEvent(message!).ConfigureAwait(false);
                return;
            }
        }

        {
            if (JsonUtils.TryDeserialize(json, out StreamFlushedMessage? message))
            {
                await StreamFlushedMessage.RaiseEvent(message!).ConfigureAwait(false);
                return;
            }
        }

        {
            if (JsonUtils.TryDeserialize(json, out StreamEndedMessage? message))
            {
                await StreamEndedMessage.RaiseEvent(message!).ConfigureAwait(false);
                return;
            }
        }

        {
            if (JsonUtils.TryDeserialize(json, out StreamUsageMessage? message))
            {
                await StreamUsageMessage.RaiseEvent(message!).ConfigureAwait(false);
                return;
            }
        }

        {
            if (JsonUtils.TryDeserialize(json, out StreamErrorMessage? message))
            {
                await StreamErrorMessage.RaiseEvent(message!).ConfigureAwait(false);
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
        StreamConfigStatusMessage.Dispose();
        StreamTranscriptMessage.Dispose();
        StreamFactsMessage.Dispose();
        StreamFlushedMessage.Dispose();
        StreamEndedMessage.Dispose();
        StreamUsageMessage.Dispose();
        StreamErrorMessage.Dispose();
    }

    /// <summary>
    /// Sends a StreamConfigMessage message to the server
    /// </summary>
    public async Task Send(StreamConfigMessage message)
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
    /// Sends a StreamFlushMessage message to the server
    /// </summary>
    public async Task Send(StreamFlushMessage message)
    {
        await SendInstant(JsonUtils.Serialize(message)).ConfigureAwait(false);
    }

    /// <summary>
    /// Sends a StreamEndMessage message to the server
    /// </summary>
    public async Task Send(StreamEndMessage message)
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
            get => StreamApi.Environments.getBaseUrl(base.BaseUrl);
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

        /// <summary>
        /// Unique identifier for the interaction session.
        /// </summary>
        public required string Id { get; set; }
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
