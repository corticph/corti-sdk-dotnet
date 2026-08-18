using Corti.Core;
using global::System.Text.Json;
using NUnit.Framework;

namespace Corti.Test.Custom;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class HeadersBuilderAnalyticsTests
{
    private static Dictionary<string, JsonElement> ParsePayload(Dictionary<string, string> headers)
    {
        return JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
            headers[AnalyticsHelper.XCortiAnalytics]
        )!;
    }

    [Test]
    public async Task BuildAsync_LastWriteWinsForOrdinaryHeaders()
    {
        var headers = await new HeadersBuilder.Builder()
            .Add("X-Foo", "a")
            .Add("X-Bar", "keep")
            .Add("x-foo", "b")
            .BuildAsync()
            .ConfigureAwait(false);

        Assert.That(headers["X-Foo"], Is.EqualTo("b"));
        Assert.That(headers["X-Bar"], Is.EqualTo("keep"));
        Assert.That(headers.ContainsKey(AnalyticsHelper.XCortiAnalytics), Is.False);
    }

    [Test]
    public async Task BuildAsync_OmitsAnalyticsHeaderWhenNoLayerIsPresent()
    {
        var headers = await new HeadersBuilder.Builder()
            .Add("X-Foo", "a")
            .BuildAsync()
            .ConfigureAwait(false);

        Assert.That(headers.ContainsKey(AnalyticsHelper.XCortiAnalytics), Is.False);
        Assert.That(headers["X-Foo"], Is.EqualTo("a"));
    }

    [Test]
    public async Task BuildAsync_DeepMergesAnalyticsJsonRegardlessOfCase()
    {
        var headers = await new HeadersBuilder.Builder()
            .Add("X-Corti-Analytics", """{"source":"web","env":"dev"}""")
            .Add("x-corti-analytics", """{"env":"prod","req":"abc"}""")
            .BuildAsync()
            .ConfigureAwait(false);

        var payload = ParsePayload(headers);
        Assert.That(payload["source"].GetString(), Is.EqualTo("web"));
        Assert.That(payload["env"].GetString(), Is.EqualTo("prod"));
        Assert.That(payload["req"].GetString(), Is.EqualTo("abc"));
        Assert.That(payload["sdk_version"].GetString(), Is.EqualTo(Version.Current));
        Assert.That(payload["sdk_type"].GetString(), Is.EqualTo("corti-sdk-dotnet"));
    }

    [Test]
    public async Task BuildAsync_StripsReservedKeysFromEveryAnalyticsLayer()
    {
        var headers = await new HeadersBuilder.Builder()
            .Add("x-corti-analytics", """{"sdk_version":"hack","source":"a"}""")
            .Add("X-CORTI-ANALYTICS", """{"sdk_type":"other","source":"b"}""")
            .BuildAsync()
            .ConfigureAwait(false);

        var payload = ParsePayload(headers);
        Assert.That(payload["sdk_version"].GetString(), Is.EqualTo(Version.Current));
        Assert.That(payload["sdk_type"].GetString(), Is.EqualTo("corti-sdk-dotnet"));
        Assert.That(payload["source"].GetString(), Is.EqualTo("b"));
    }

    [Test]
    public async Task BuildAsync_SerializesASingleAnalyticsJsonPayloadAndAppliesReservedKeys()
    {
        var headers = await new HeadersBuilder.Builder()
            .Add("X-Corti-Analytics", """{"source":"web"}""")
            .BuildAsync()
            .ConfigureAwait(false);

        var payload = ParsePayload(headers);
        Assert.That(payload["source"].GetString(), Is.EqualTo("web"));
        Assert.That(payload["sdk_version"].GetString(), Is.EqualTo(Version.Current));
        Assert.That(payload["sdk_type"].GetString(), Is.EqualTo("corti-sdk-dotnet"));
    }

    [Test]
    public async Task BuildAsync_LowercasesAnalyticsKeys()
    {
        var headers = await new HeadersBuilder.Builder()
            .Add("x-corti-analytics", """{"Source":"web","SDK_VERSION":"hack"}""")
            .BuildAsync()
            .ConfigureAwait(false);

        var payload = ParsePayload(headers);
        Assert.That(payload.ContainsKey("Source"), Is.False);
        Assert.That(payload.ContainsKey("SDK_VERSION"), Is.False);
        Assert.That(payload["source"].GetString(), Is.EqualTo("web"));
        Assert.That(payload["sdk_version"].GetString(), Is.EqualTo(Version.Current));
        Assert.That(payload["sdk_type"].GetString(), Is.EqualTo("corti-sdk-dotnet"));
        Assert.That(payload.Count, Is.EqualTo(3));
    }
}
