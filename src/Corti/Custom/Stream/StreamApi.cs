using System.Text.Json;
using Corti.Core.WebSockets;

namespace Corti;

public partial class StreamApi
{
    Event<StreamConfigStatusMessage> IStreamApi.StreamConfigStatusMessage => StreamConfigStatusMessage;
    Event<StreamTranscriptMessage> IStreamApi.StreamTranscriptMessage => StreamTranscriptMessage;
    Event<StreamFactsMessage> IStreamApi.StreamFactsMessage => StreamFactsMessage;
    Event<StreamFlushedMessage> IStreamApi.StreamFlushedMessage => StreamFlushedMessage;
    Event<StreamEndedMessage> IStreamApi.StreamEndedMessage => StreamEndedMessage;
    Event<StreamUsageMessage> IStreamApi.StreamUsageMessage => StreamUsageMessage;
    Event<StreamErrorMessage> IStreamApi.StreamErrorMessage => StreamErrorMessage;
    Event<JsonElement> IStreamApi.UnknownMessage => UnknownMessage;
}
