using System.Text.Json;
using Corti.Core.WebSockets;

namespace Corti;

public partial interface IStreamApi
{
    public Event<StreamConfigStatusMessage> StreamConfigStatusMessage { get; }
    public Event<StreamTranscriptMessage> StreamTranscriptMessage { get; }
    public Event<StreamFactsMessage> StreamFactsMessage { get; }
    public Event<StreamFlushedMessage> StreamFlushedMessage { get; }
    public Event<StreamEndedMessage> StreamEndedMessage { get; }
    public Event<StreamUsageMessage> StreamUsageMessage { get; }
    public Event<StreamErrorMessage> StreamErrorMessage { get; }
    public Event<JsonElement> UnknownMessage { get; }
}
