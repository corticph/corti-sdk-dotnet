using System.ComponentModel;
using System.Text.Json;
using CortiApi.Core;
using CortiApi.Core.WebSockets;

namespace CortiApi;

public partial class TranscribeApi : IAsyncDisposable, IDisposable, INotifyPropertyChanged
{
    private readonly TranscribeApi.Options _options;

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
    {
        _options = options;
        var uri = new UriBuilder(_options.BaseUrl)
        {
            Query = new CortiApi.Core.QueryStringBuilder.Builder(capacity: 2)
                .Add("tenant-name", _options.TenantName)
                .Add("token", _options.Token)
                .Build(),
        };
        uri.Path = $"{uri.Path.TrimEnd('/')}/transcribe";
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
        TranscribeConfigStatusMessage.Dispose();
        TranscribeUsageMessage.Dispose();
        TranscribeFlushedMessage.Dispose();
        TranscribeEndedMessage.Dispose();
        TranscribeErrorMessage.Dispose();
        TranscribeTranscriptMessage.Dispose();
        TranscribeCommandMessage.Dispose();
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
    /// Sends a TranscribeConfigMessage message to the server
    /// </summary>
    public async Task Send(TranscribeConfigMessage message)
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
    /// Sends a TranscribeFlushMessage message to the server
    /// </summary>
    public async Task Send(TranscribeFlushMessage message)
    {
        await _client.SendInstant(JsonUtils.Serialize(message)).ConfigureAwait(false);
    }

    /// <summary>
    /// Sends a TranscribeEndMessage message to the server
    /// </summary>
    public async Task Send(TranscribeEndMessage message)
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
            get => TranscribeApi.Environments.getBaseUrl(_baseUrl);
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
