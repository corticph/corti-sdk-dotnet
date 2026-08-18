using global::System.Net.Http;
using global::System.Reflection;
using global::System.Text;
using global::System.Text.Json;
using NUnit.Framework;

namespace Corti.Test.Custom;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CortiClientAnalyticsTests
{
    private static readonly CortiClientEnvironment TestEnvironment = new()
    {
        Base = "https://api.test.example/v2",
        Wss = "wss://api.test.example/audio-bridge/v2",
        Login = "https://auth.test.example/realms",
        Agents = "https://api.test.example",
    };

    private sealed class CapturingHandler : HttpMessageHandler
    {
        public HttpRequestMessage? Request { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            Request = request;
            return Task.FromResult(
                new HttpResponseMessage(System.Net.HttpStatusCode.OK)
                {
                    RequestMessage = request,
                    Content = new StringContent(
                        """{"languages":{"en":{}}}""",
                        Encoding.UTF8,
                        "application/json"
                    ),
                }
            );
        }

        protected override void Dispose(bool disposing) { }
    }

    [Test]
    public async Task RestCall_AlwaysSendsReservedAnalyticsKeys()
    {
        var handler = new CapturingHandler();
        using var http = new HttpClient(handler);

        var client = new CortiClient(
            "test",
            TestEnvironment,
            new CortiClientAuth.Bearer("fake-token"),
            new CortiRequestOptions { HttpClient = http, MaxRetries = 0 }
        );

        await client.Languages.ListAsync(new LanguagesListRequest());

        Assert.That(handler.Request, Is.Not.Null);
        Assert.That(
            handler.Request!.Headers.TryGetValues(AnalyticsHelper.XCortiAnalytics, out var values),
            Is.True
        );
        var payload = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(values!.First())!;
        Assert.That(payload["sdk_version"].GetString(), Is.EqualTo(Version.Current));
        Assert.That(payload["sdk_type"].GetString(), Is.EqualTo("corti-sdk-dotnet"));
        Assert.That(payload.Count, Is.EqualTo(2));
    }

    [Test]
    public async Task RestCall_IncludesClientAnalyticsAndReservedKeys()
    {
        var handler = new CapturingHandler();
        using var http = new HttpClient(handler);

        var client = new CortiClient(
            "test",
            TestEnvironment,
            new CortiClientAuth.Bearer("fake-token"),
            new CortiRequestOptions
            {
                HttpClient = http,
                MaxRetries = 0,
                Analytics = new Dictionary<string, string>
                {
                    ["integration"] = "epic-hyperspace",
                    ["workflow"] = "ambient-scribe",
                    ["sdk_version"] = "hack",
                },
            }
        );

        await client.Languages.ListAsync(new LanguagesListRequest());

        Assert.That(handler.Request, Is.Not.Null);
        Assert.That(
            handler.Request!.Headers.TryGetValues(AnalyticsHelper.XCortiAnalytics, out var values),
            Is.True
        );
        var payload = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(values!.First())!;
        Assert.That(payload["integration"].GetString(), Is.EqualTo("epic-hyperspace"));
        Assert.That(payload["workflow"].GetString(), Is.EqualTo("ambient-scribe"));
        Assert.That(payload["sdk_version"].GetString(), Is.EqualTo(Version.Current));
        Assert.That(payload["sdk_type"].GetString(), Is.EqualTo("corti-sdk-dotnet"));
    }

    [Test]
    public async Task RestCall_MergesPerRequestAnalyticsOverlay()
    {
        var handler = new CapturingHandler();
        using var http = new HttpClient(handler);

        var client = new CortiClient(
            "test",
            TestEnvironment,
            new CortiClientAuth.Bearer("fake-token"),
            new CortiRequestOptions
            {
                HttpClient = http,
                MaxRetries = 0,
                Analytics = new Dictionary<string, string>
                {
                    ["integration"] = "epic-hyperspace",
                    ["workflow"] = "ambient-scribe",
                },
                AdditionalHeaders = new Dictionary<string, string?>
                {
                    ["X-Trace"] = "client",
                    ["x-corti-analytics"] = """{"source":"ehr","workflow":"from-headers"}""",
                },
            }
        );

        await client.Languages.ListAsync(
            new LanguagesListRequest(),
            new RequestOptions
            {
                AdditionalHeaders = new Dictionary<string, string?>
                {
                    ["x-corti-analytics"] =
                        """{"workflow":"progress-note","document_type":"progress-note"}""",
                },
            }
        );

        Assert.That(handler.Request, Is.Not.Null);
        Assert.That(
            handler.Request!.Headers.TryGetValues(AnalyticsHelper.XCortiAnalytics, out var values),
            Is.True
        );
        var payload = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(values!.First())!;
        Assert.That(handler.Request!.Headers.GetValues("X-Trace").Single(), Is.EqualTo("client"));
        Assert.That(payload["source"].GetString(), Is.EqualTo("ehr"));
        Assert.That(payload["integration"].GetString(), Is.EqualTo("epic-hyperspace"));
        Assert.That(payload["workflow"].GetString(), Is.EqualTo("progress-note"));
        Assert.That(payload["document_type"].GetString(), Is.EqualTo("progress-note"));
        Assert.That(payload["sdk_version"].GetString(), Is.EqualTo(Version.Current));
        Assert.That(payload["sdk_type"].GetString(), Is.EqualTo("corti-sdk-dotnet"));
    }

    private static Uri GetWebSocketUri(object api)
    {
        var clientField =
            api.GetType().GetField("_client", BindingFlags.NonPublic | BindingFlags.Instance)
            ?? throw new InvalidOperationException("_client field not found");
        var webSocketClient =
            clientField.GetValue(api) ?? throw new InvalidOperationException("_client is null");
        var uriField =
            webSocketClient
                .GetType()
                .GetField("_uri", BindingFlags.NonPublic | BindingFlags.Instance)
            ?? throw new InvalidOperationException("_uri field not found");
        return (Uri)(
            uriField.GetValue(webSocketClient)
            ?? throw new InvalidOperationException("_uri is null")
        );
    }

    [Test]
    public async Task StreamConnect_PutsClientAnalyticsOnQueryAndKeepsExtraParams()
    {
        var client = new CortiClient(
            "test",
            TestEnvironment,
            new CortiClientAuth.Bearer("fake-token"),
            new CortiRequestOptions
            {
                MaxRetries = 0,
                Analytics = new Dictionary<string, string>
                {
                    ["integration"] = "epic-hyperspace",
                    ["visit_type"] = "outpatient",
                },
            }
        );

        using var api = (StreamApi)
            await client.CreateStreamApiAsync(
                "00000000-0000-0000-0000-000000000001",
                new Dictionary<string, string>
                {
                    ["extra"] = "keep",
                    ["x-corti-analytics"] = """{"visit_type":"inpatient"}""",
                }
            );

        var query = System.Web.HttpUtility.ParseQueryString(GetWebSocketUri(api).Query);
        Assert.That(query["extra"], Is.EqualTo("keep"));
        var payload = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
            query[AnalyticsHelper.XCortiAnalytics] ?? "{}"
        )!;
        Assert.That(payload["integration"].GetString(), Is.EqualTo("epic-hyperspace"));
        Assert.That(payload["visit_type"].GetString(), Is.EqualTo("inpatient"));
        Assert.That(payload["sdk_version"].GetString(), Is.EqualTo(Version.Current));
        Assert.That(payload["sdk_type"].GetString(), Is.EqualTo("corti-sdk-dotnet"));
    }

    [Test]
    public async Task TranscribeConnect_PutsClientAnalyticsOnQueryAndKeepsExtraParams()
    {
        var client = new CortiClient(
            "test",
            TestEnvironment,
            new CortiClientAuth.Bearer("fake-token"),
            new CortiRequestOptions
            {
                MaxRetries = 0,
                Analytics = new Dictionary<string, string>
                {
                    ["integration"] = "epic-hyperspace",
                    ["visit_type"] = "outpatient",
                },
            }
        );

        using var api = (TranscribeApi)
            await client.CreateTranscribeApiAsync(
                new Dictionary<string, string>
                {
                    ["extra"] = "keep",
                    ["x-corti-analytics"] = """{"visit_type":"inpatient"}""",
                }
            );

        var query = System.Web.HttpUtility.ParseQueryString(GetWebSocketUri(api).Query);
        Assert.That(query["extra"], Is.EqualTo("keep"));
        var payload = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
            query[AnalyticsHelper.XCortiAnalytics] ?? "{}"
        )!;
        Assert.That(payload["integration"].GetString(), Is.EqualTo("epic-hyperspace"));
        Assert.That(payload["visit_type"].GetString(), Is.EqualTo("inpatient"));
        Assert.That(payload["sdk_version"].GetString(), Is.EqualTo(Version.Current));
        Assert.That(payload["sdk_type"].GetString(), Is.EqualTo("corti-sdk-dotnet"));
    }

    [Test]
    public async Task StreamConnect_AlwaysSetsReservedAnalyticsKeys()
    {
        var client = new CortiClient(
            "test",
            TestEnvironment,
            new CortiClientAuth.Bearer("fake-token"),
            new CortiRequestOptions { MaxRetries = 0 }
        );

        using var api = (StreamApi)
            await client.CreateStreamApiAsync("00000000-0000-0000-0000-000000000001");

        var payload = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
            System.Web.HttpUtility.ParseQueryString(GetWebSocketUri(api).Query)[
                AnalyticsHelper.XCortiAnalytics
            ] ?? "{}"
        )!;
        Assert.That(payload["sdk_version"].GetString(), Is.EqualTo(Version.Current));
        Assert.That(payload["sdk_type"].GetString(), Is.EqualTo("corti-sdk-dotnet"));
        Assert.That(payload.Count, Is.EqualTo(2));
    }

    [Test]
    public async Task TranscribeConnect_AlwaysSetsReservedAnalyticsKeys()
    {
        var client = new CortiClient(
            "test",
            TestEnvironment,
            new CortiClientAuth.Bearer("fake-token"),
            new CortiRequestOptions { MaxRetries = 0 }
        );

        using var api = (TranscribeApi)await client.CreateTranscribeApiAsync();

        var payload = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
            System.Web.HttpUtility.ParseQueryString(GetWebSocketUri(api).Query)[
                AnalyticsHelper.XCortiAnalytics
            ] ?? "{}"
        )!;
        Assert.That(payload["sdk_version"].GetString(), Is.EqualTo(Version.Current));
        Assert.That(payload["sdk_type"].GetString(), Is.EqualTo("corti-sdk-dotnet"));
        Assert.That(payload.Count, Is.EqualTo(2));
    }

    [Test]
    public async Task StreamConnect_PutsQueryAnalyticsWhenClientAnalyticsIsAbsent()
    {
        var client = new CortiClient(
            "test",
            TestEnvironment,
            new CortiClientAuth.Bearer("fake-token"),
            new CortiRequestOptions { MaxRetries = 0 }
        );

        using var api = (StreamApi)
            await client.CreateStreamApiAsync(
                "00000000-0000-0000-0000-000000000001",
                new Dictionary<string, string>
                {
                    ["extra"] = "keep",
                    ["x-corti-analytics"] = """{"visit_type":"inpatient","sdk_version":"hack"}""",
                }
            );

        var query = System.Web.HttpUtility.ParseQueryString(GetWebSocketUri(api).Query);
        Assert.That(query["extra"], Is.EqualTo("keep"));
        var payload = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
            query[AnalyticsHelper.XCortiAnalytics] ?? "{}"
        )!;
        Assert.That(payload["visit_type"].GetString(), Is.EqualTo("inpatient"));
        Assert.That(payload["sdk_version"].GetString(), Is.EqualTo(Version.Current));
        Assert.That(payload["sdk_type"].GetString(), Is.EqualTo("corti-sdk-dotnet"));
    }

    [Test]
    public async Task TranscribeConnect_PutsQueryAnalyticsWhenClientAnalyticsIsAbsent()
    {
        var client = new CortiClient(
            "test",
            TestEnvironment,
            new CortiClientAuth.Bearer("fake-token"),
            new CortiRequestOptions { MaxRetries = 0 }
        );

        using var api = (TranscribeApi)
            await client.CreateTranscribeApiAsync(
                new Dictionary<string, string>
                {
                    ["extra"] = "keep",
                    ["x-corti-analytics"] = """{"visit_type":"inpatient","sdk_version":"hack"}""",
                }
            );

        var query = System.Web.HttpUtility.ParseQueryString(GetWebSocketUri(api).Query);
        Assert.That(query["extra"], Is.EqualTo("keep"));
        var payload = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
            query[AnalyticsHelper.XCortiAnalytics] ?? "{}"
        )!;
        Assert.That(payload["visit_type"].GetString(), Is.EqualTo("inpatient"));
        Assert.That(payload["sdk_version"].GetString(), Is.EqualTo(Version.Current));
        Assert.That(payload["sdk_type"].GetString(), Is.EqualTo("corti-sdk-dotnet"));
    }
}
