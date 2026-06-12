using NUnit.Framework;

namespace Corti.Test.Custom.Stream;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class StreamApiMessageRoutingTests
{
    internal const string ObservedPartialRuntimeErrorJson =
        """{"type":"error","error":{"requestid":"559ed5e9-a501-4527-ab67-807d9f2fa0a6","details":"Provided audio is invalid or corrupted. Please check the audio format and try again."}}""";

    private const string SpecTranscriptJson =
        """{"type":"transcript","data":[{"id":"00000000-0000-0000-0000-000000000001","transcript":"hello world","final":true,"speakerId":0,"participant":{"channel":0},"time":{"start":0,"end":1.2}}]}""";

    private const string SpecFactsJson =
        """{"type":"facts","fact":[{"id":"fact-1","text":"Patient reports headache","group":"symptoms","groupId":"group-1","isDiscarded":false,"source":"core","createdAt":"2024-01-15T10:30:00Z"}]}""";

    private const string SpecFlushedJson = """{"type":"flushed"}""";

    private const string SpecDeltaUsageJson = """{"type":"delta_usage","credits":1.5}""";

    private const string SpecEndedJson = """{"type":"ENDED"}""";

    private const string SpecUsageJson = """{"type":"usage","credits":2.0}""";

    private const string SpecFullErrorJson =
        """{"type":"error","error":{"requestid":"req-full","id":"audio-invalid","title":"Invalid audio","status":400,"details":"Audio validation failed","doc":"https://docs.corti.ai"}}""";

    private const string SpecConfigAcceptedJson =
        """{"type":"CONFIG_ACCEPTED","configuration":{"transcription":{"primaryLanguage":"en","participants":[{"channel":0,"role":"doctor"}]},"mode":{"type":"transcription"}}}""";

    private const string SpecConfigDeniedJson =
        """{"type":"CONFIG_DENIED","reason":"language unavailable"}""";

    private const string SpecConfigMissingJson = """{"type":"CONFIG_MISSING"}""";

    private const string SpecConfigNotProvidedJson = """{"type":"CONFIG_NOT_PROVIDED"}""";

    private const string SpecConfigAlreadyReceivedJson = """{"type":"CONFIG_ALREADY_RECEIVED"}""";

    private const string SpecAudioEventJson =
        """{"type":"audioEvent","data":{"event":"longSilenceDetected","channel":0,"startTimeMs":1500}}""";

    private const string SpecUnknownJson = """{"unexpected":"payload"}""";

    private static StreamApi CreateApi()
    {
        return new StreamApi(
            new StreamApi.Options
            {
                TenantName = "test-tenant",
                Token = "test-token",
                Id = "00000000-0000-0000-0000-000000000001",
            }
        );
    }

    public static IEnumerable<TestCaseData> SpecServerMessages()
    {
        yield return Case("transcript", SpecTranscriptJson, nameof(StreamApi.StreamTranscriptMessage));
        yield return Case("facts", SpecFactsJson, nameof(StreamApi.StreamFactsMessage));
        yield return Case("flushed", SpecFlushedJson, nameof(StreamApi.StreamFlushedMessage));
        yield return Case("delta_usage", SpecDeltaUsageJson, nameof(StreamApi.StreamDeltaUsageMessage));
        yield return Case("ENDED", SpecEndedJson, nameof(StreamApi.StreamEndedMessage));
        yield return Case("usage", SpecUsageJson, nameof(StreamApi.StreamUsageMessage));
        yield return Case("error_full", SpecFullErrorJson, nameof(StreamApi.StreamErrorMessage));
        yield return Case(
            "error_observed_partial_runtime",
            ObservedPartialRuntimeErrorJson,
            nameof(StreamApi.StreamErrorMessage)
        );
        yield return Case(
            "CONFIG_ACCEPTED",
            SpecConfigAcceptedJson,
            nameof(StreamApi.StreamConfigStatusMessage)
        );
        yield return Case(
            "CONFIG_DENIED",
            SpecConfigDeniedJson,
            nameof(StreamApi.StreamConfigStatusMessage)
        );
        yield return Case(
            "CONFIG_MISSING",
            SpecConfigMissingJson,
            nameof(StreamApi.StreamConfigStatusMessage)
        );
        yield return Case(
            "CONFIG_NOT_PROVIDED",
            SpecConfigNotProvidedJson,
            nameof(StreamApi.StreamConfigStatusMessage)
        );
        yield return Case(
            "CONFIG_ALREADY_RECEIVED",
            SpecConfigAlreadyReceivedJson,
            nameof(StreamApi.StreamConfigStatusMessage)
        );
        yield return Case("audioEvent", SpecAudioEventJson, nameof(StreamApi.StreamAudioEventMessage));
        yield return Case("unknown", SpecUnknownJson, nameof(StreamApi.UnknownMessage));
    }

    [TestCaseSource(nameof(SpecServerMessages))]
    public async Task InjectTestMessage_RoutesSpecPayloadToExpectedEvent(
        string _,
        string json,
        string expectedEvent
    )
    {
        using var api = CreateApi();
        using var capture = new MessageRoutingCapture(api);

        await api.InjectTestMessage(json);

        Assert.That(
            capture.ReceivedEvents,
            Is.EqualTo(new[] { expectedEvent }),
            $"Expected {expectedEvent} but received [{string.Join(", ", capture.ReceivedEvents)}] for payload: {json}"
        );
    }

    private static TestCaseData Case(string name, string json, string expectedEvent)
    {
        return new TestCaseData(name, json, expectedEvent).SetName(name);
    }

    private sealed class MessageRoutingCapture : IDisposable
    {
        private readonly StreamApi _api;
        private readonly List<string> _receivedEvents = new();

        public MessageRoutingCapture(StreamApi api)
        {
            _api = api;
            _api.StreamTranscriptMessage.Subscribe(_ => Record(nameof(StreamApi.StreamTranscriptMessage)));
            _api.StreamFactsMessage.Subscribe(_ => Record(nameof(StreamApi.StreamFactsMessage)));
            _api.StreamFlushedMessage.Subscribe(_ => Record(nameof(StreamApi.StreamFlushedMessage)));
            _api.StreamDeltaUsageMessage.Subscribe(_ => Record(nameof(StreamApi.StreamDeltaUsageMessage)));
            _api.StreamEndedMessage.Subscribe(_ => Record(nameof(StreamApi.StreamEndedMessage)));
            _api.StreamUsageMessage.Subscribe(_ => Record(nameof(StreamApi.StreamUsageMessage)));
            _api.StreamErrorMessage.Subscribe(_ => Record(nameof(StreamApi.StreamErrorMessage)));
            _api.StreamConfigStatusMessage.Subscribe(_ =>
                Record(nameof(StreamApi.StreamConfigStatusMessage))
            );
            _api.StreamAudioEventMessage.Subscribe(_ =>
                Record(nameof(StreamApi.StreamAudioEventMessage))
            );
            _api.UnknownMessage.Subscribe(_ => Record(nameof(StreamApi.UnknownMessage)));
        }

        public IReadOnlyList<string> ReceivedEvents => _receivedEvents;

        private void Record(string eventName)
        {
            _receivedEvents.Add(eventName);
        }

        public void Dispose()
        {
            _api.Dispose();
        }
    }
}
