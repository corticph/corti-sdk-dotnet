using System.Text.Json;
using Corti.Core.WebSockets;

namespace Corti;

public partial interface ITranscribeApi
{
    public Event<TranscribeConfigStatusMessage> TranscribeConfigStatusMessage { get; }
    public Event<TranscribeUsageMessage> TranscribeUsageMessage { get; }
    public Event<TranscribeFlushedMessage> TranscribeFlushedMessage { get; }
    public Event<TranscribeEndedMessage> TranscribeEndedMessage { get; }
    public Event<TranscribeErrorMessage> TranscribeErrorMessage { get; }
    public Event<TranscribeTranscriptMessage> TranscribeTranscriptMessage { get; }
    public Event<TranscribeCommandMessage> TranscribeCommandMessage { get; }
    public Event<JsonElement> UnknownMessage { get; }
}
