using System.Text.Json;
using Corti.Core.WebSockets;

namespace Corti;

public partial class TranscribeApi
{
    Event<TranscribeConfigStatusMessage> ITranscribeApi.TranscribeConfigStatusMessage => TranscribeConfigStatusMessage;
    Event<TranscribeUsageMessage> ITranscribeApi.TranscribeUsageMessage => TranscribeUsageMessage;
    Event<TranscribeFlushedMessage> ITranscribeApi.TranscribeFlushedMessage => TranscribeFlushedMessage;
    Event<TranscribeEndedMessage> ITranscribeApi.TranscribeEndedMessage => TranscribeEndedMessage;
    Event<TranscribeErrorMessage> ITranscribeApi.TranscribeErrorMessage => TranscribeErrorMessage;
    Event<TranscribeTranscriptMessage> ITranscribeApi.TranscribeTranscriptMessage => TranscribeTranscriptMessage;
    Event<TranscribeCommandMessage> ITranscribeApi.TranscribeCommandMessage => TranscribeCommandMessage;
    Event<JsonElement> ITranscribeApi.UnknownMessage => UnknownMessage;
}
