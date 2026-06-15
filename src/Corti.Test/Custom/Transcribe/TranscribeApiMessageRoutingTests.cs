using NUnit.Framework;

namespace Corti.Test.Custom.Transcribe;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class TranscribeApiMessageRoutingTests
{
    private const string ObservedPartialRuntimeErrorJson =
        Stream.StreamApiMessageRoutingTests.ObservedPartialRuntimeErrorJson;

    private const string SpecUsageJson = """{"type":"usage","credits":2.0}""";

    private const string SpecFlushedJson = """{"type":"flushed"}""";

    private const string SpecDeltaUsageJson = """{"type":"delta_usage","credits":1.5}""";

    private const string SpecEndedJson = """{"type":"ended"}""";

    private const string SpecFullErrorJson =
        """{"type":"error","error":{"requestid":"req-full","id":"audio-invalid","title":"Invalid audio","status":400,"details":"Audio validation failed","doc":"https://docs.corti.ai"}}""";

    private const string SpecTranscriptJson =
        """{"type":"transcript","data":{"text":"hello world","rawTranscriptText":"hello world","start":0,"end":1.2,"isFinal":true}}""";

    private const string SpecCommandJson =
        """{"type":"command","data":{"id":"cmd-1","rawTranscriptText":"select all","start":0,"end":1.2,"variables":{"selection":"all"}}}""";

    private const string SpecConfigAcceptedJson =
        """{"type":"CONFIG_ACCEPTED","sessionId":"00000000-0000-0000-0000-000000000002","configuration":{"primaryLanguage":"en"}}""";

    private const string SpecConfigDeniedJson =
        """{"type":"CONFIG_DENIED","reason":"invalid config"}""";

    private const string SpecConfigTimeoutJson = """{"type":"CONFIG_TIMEOUT"}""";

    private const string SpecConfigMissingJson = """{"type":"CONFIG_MISSING"}""";

    private const string SpecConfigAlreadyReceivedJson = """{"type":"CONFIG_ALREADY_RECEIVED"}""";

    private const string SpecAudioEventJson =
        """{"type":"audioEvent","data":{"event":"speechQualityIssueDetected","channel":0,"startTimeMs":500}}""";

    private const string SpecUnknownJson = """{"unexpected":"payload"}""";

    private static TranscribeApi CreateApi()
    {
        return new TranscribeApi(
            new TranscribeApi.Options { TenantName = "test-tenant", Token = "test-token" }
        );
    }

    public static IEnumerable<TestCaseData> SpecServerMessages()
    {
        yield return Case("usage", SpecUsageJson, nameof(TranscribeApi.TranscribeUsageMessage));
        yield return Case("flushed", SpecFlushedJson, nameof(TranscribeApi.TranscribeFlushedMessage));
        yield return Case(
            "delta_usage",
            SpecDeltaUsageJson,
            nameof(TranscribeApi.TranscribeDeltaUsageMessage)
        );
        yield return Case("ended", SpecEndedJson, nameof(TranscribeApi.TranscribeEndedMessage));
        yield return Case("error_full", SpecFullErrorJson, nameof(TranscribeApi.TranscribeErrorMessage));
        yield return Case(
            "error_observed_partial_runtime",
            ObservedPartialRuntimeErrorJson,
            nameof(TranscribeApi.TranscribeErrorMessage)
        );
        yield return Case(
            "transcript",
            SpecTranscriptJson,
            nameof(TranscribeApi.TranscribeTranscriptMessage)
        );
        yield return Case("command", SpecCommandJson, nameof(TranscribeApi.TranscribeCommandMessage));
        yield return Case(
            "CONFIG_ACCEPTED",
            SpecConfigAcceptedJson,
            nameof(TranscribeApi.TranscribeConfigStatusMessage)
        );
        yield return Case(
            "CONFIG_DENIED",
            SpecConfigDeniedJson,
            nameof(TranscribeApi.TranscribeConfigStatusMessage)
        );
        yield return Case(
            "CONFIG_TIMEOUT",
            SpecConfigTimeoutJson,
            nameof(TranscribeApi.TranscribeConfigStatusMessage)
        );
        yield return Case(
            "CONFIG_MISSING",
            SpecConfigMissingJson,
            nameof(TranscribeApi.TranscribeConfigStatusMessage)
        );
        yield return Case(
            "CONFIG_ALREADY_RECEIVED",
            SpecConfigAlreadyReceivedJson,
            nameof(TranscribeApi.TranscribeConfigStatusMessage)
        );
        yield return Case(
            "audioEvent",
            SpecAudioEventJson,
            nameof(TranscribeApi.TranscribeAudioEventMessage)
        );
        yield return Case("unknown", SpecUnknownJson, nameof(TranscribeApi.UnknownMessage));
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
        private readonly TranscribeApi _api;
        private readonly List<string> _receivedEvents = new();

        public MessageRoutingCapture(TranscribeApi api)
        {
            _api = api;
            _api.TranscribeUsageMessage.Subscribe(_ =>
                Record(nameof(TranscribeApi.TranscribeUsageMessage))
            );
            _api.TranscribeFlushedMessage.Subscribe(_ =>
                Record(nameof(TranscribeApi.TranscribeFlushedMessage))
            );
            _api.TranscribeDeltaUsageMessage.Subscribe(_ =>
                Record(nameof(TranscribeApi.TranscribeDeltaUsageMessage))
            );
            _api.TranscribeEndedMessage.Subscribe(_ =>
                Record(nameof(TranscribeApi.TranscribeEndedMessage))
            );
            _api.TranscribeErrorMessage.Subscribe(_ =>
                Record(nameof(TranscribeApi.TranscribeErrorMessage))
            );
            _api.TranscribeTranscriptMessage.Subscribe(_ =>
                Record(nameof(TranscribeApi.TranscribeTranscriptMessage))
            );
            _api.TranscribeCommandMessage.Subscribe(_ =>
                Record(nameof(TranscribeApi.TranscribeCommandMessage))
            );
            _api.TranscribeConfigStatusMessage.Subscribe(_ =>
                Record(nameof(TranscribeApi.TranscribeConfigStatusMessage))
            );
            _api.TranscribeAudioEventMessage.Subscribe(_ =>
                Record(nameof(TranscribeApi.TranscribeAudioEventMessage))
            );
            _api.UnknownMessage.Subscribe(_ => Record(nameof(TranscribeApi.UnknownMessage)));
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
