using System.ComponentModel;
using System.Text.Json;
using CortiApi.Core;
using CortiApi.Core.WebSockets;

namespace CortiApi;

public partial class StreamApi : IAsyncDisposable, IDisposable, INotifyPropertyChanged
{
    private readonly StreamApi.Options _options;

    private readonly WebSocketClient _client;

    /// <summary>
    /// Event that is raised when a property value changes.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged
    {
        add => _client.PropertyChanged += value;
        remove => _client.PropertyChanged -= value;
    }

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
    {
        _options = options;
        var uri = new UriBuilder(_options.BaseUrl)
        {
            Query = new CortiApi.Core.QueryStringBuilder.Builder(capacity: 2)
                .Add("tenant-name", _options.TenantName)
                .Add("token", _options.Token)
                .Build(),
        };
        uri.Path =
            $"{uri.Path.TrimEnd('/')}/interactions/{Uri.EscapeDataString(_options.Id)}/streams";
        _client = new WebSocketClient(uri.Uri, OnTextMessage);
    }

    /// <summary>
    /// Gets the current connection status of the WebSocket.
    /// </summary>
    public ConnectionStatus Status => _client.Status;

    /// <summary>
    /// Event that is raised when the WebSocket connection is established.
    /// </summary>
    public Event<Connected> Connected => _client.Connected;

    /// <summary>
    /// Event that is raised when the WebSocket connection is closed.
    /// </summary>
    public Event<Closed> Closed => _client.Closed;

    /// <summary>
    /// Event that is raised when an exception occurs during WebSocket operations.
    /// </summary>
    public Event<Exception> ExceptionOccurred => _client.ExceptionOccurred;

    /// <summary>
    /// Disposes of event subscriptions
    /// </summary>
    private void DisposeEvents()
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
    /// Dispatches incoming WebSocket messages
    /// </summary>
    private async Task OnTextMessage(Stream stream)
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
    /// Asynchronously establishes a WebSocket connection.
    /// </summary>
    public async Task ConnectAsync()
    {
        await _client.ConnectAsync().ConfigureAwait(false);
    }

    /// <summary>
    /// Asynchronously closes the WebSocket connection.
    /// </summary>
    public async Task CloseAsync()
    {
        await _client.CloseAsync().ConfigureAwait(false);
    }

    /// <summary>
    /// Asynchronously disposes the WebSocket client, closing any active connections and cleaning up resources.
    /// </summary>
    public async ValueTask DisposeAsync()
    {
        await _client.DisposeAsync();
        DisposeEvents();
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Synchronously disposes the WebSocket client, closing any active connections and cleaning up resources.
    /// </summary>
    public void Dispose()
    {
        _client.Dispose();
        DisposeEvents();
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Sends a StreamConfigMessage message to the server
    /// </summary>
    public async Task Send(StreamConfigMessage message)
    {
        await _client.SendInstant(JsonUtils.Serialize(message)).ConfigureAwait(false);
    }

    /// <summary>
    /// Sends a audio message to the server
    /// </summary>
    public async Task Send(byte[] message)
    {
        await _client.SendInstant(JsonUtils.Serialize(message)).ConfigureAwait(false);
    }

    /// <summary>
    /// Sends a StreamFlushMessage message to the server
    /// </summary>
    public async Task Send(StreamFlushMessage message)
    {
        await _client.SendInstant(JsonUtils.Serialize(message)).ConfigureAwait(false);
    }

    /// <summary>
    /// Sends a StreamEndMessage message to the server
    /// </summary>
    public async Task Send(StreamEndMessage message)
    {
        await _client.SendInstant(JsonUtils.Serialize(message)).ConfigureAwait(false);
    }

    /// <summary>
    /// Options for the API client
    /// </summary>
    public class Options
    {
        private string _baseUrl = "wss://api.eu.corti.app/audio-bridge/v2";

        /// <summary>
        /// The Websocket URL for the API connection.
        /// </summary>
        public string BaseUrl
        {
            get => StreamApi.Environments.getBaseUrl(_baseUrl);
            set => _baseUrl = value;
        }

        /// <summary>
        /// The Environment for the API connection.
        /// </summary>
        public string Environment
        {
            get => _baseUrl;
            set => _baseUrl = value;
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
