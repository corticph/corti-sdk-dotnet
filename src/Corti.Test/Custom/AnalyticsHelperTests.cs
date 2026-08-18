using global::System.Text.Json;
using NUnit.Framework;

namespace Corti.Test.Custom;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class AnalyticsHelperTests
{
    [Test]
    public void WithAnalytics_SetsThePayloadAndPreservesOtherFields()
    {
        var merged = AnalyticsHelper.WithAnalytics(
            new Dictionary<string, string> { ["source"] = "web" },
            new Dictionary<string, string> { ["foo"] = "bar", ["count"] = "3" }
        );

        Assert.That(merged["foo"], Is.EqualTo("bar"));
        Assert.That(merged["count"], Is.EqualTo("3"));
        var payload = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
            merged[AnalyticsHelper.XCortiAnalytics]
        )!;
        Assert.That(payload["source"].GetString(), Is.EqualTo("web"));
        Assert.That(payload["sdk_version"].GetString(), Is.EqualTo(Version.Current));
        Assert.That(payload["sdk_type"].GetString(), Is.EqualTo("corti-sdk-dotnet"));
    }

    [Test]
    public void WithAnalytics_OmitsRecordWhenNotPassed()
    {
        var merged = AnalyticsHelper.WithAnalytics(
            new Dictionary<string, string> { ["source"] = "web" }
        );

        Assert.That(merged.Keys, Is.EquivalentTo(new[] { AnalyticsHelper.XCortiAnalytics }));
    }

    [Test]
    public void WithAnalytics_HandlesUndefinedAnalytics()
    {
        var merged = AnalyticsHelper.WithAnalytics(
            null,
            new Dictionary<string, string> { ["foo"] = "bar" }
        );

        Assert.That(merged["foo"], Is.EqualTo("bar"));
        var payload = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
            merged[AnalyticsHelper.XCortiAnalytics]
        )!;
        Assert.That(payload["sdk_version"].GetString(), Is.EqualTo(Version.Current));
        Assert.That(payload["sdk_type"].GetString(), Is.EqualTo("corti-sdk-dotnet"));
        Assert.That(payload.Count, Is.EqualTo(2));
    }

    [Test]
    public void WithAnalytics_OverwritesReservedKeysFromTheCaller()
    {
        var merged = AnalyticsHelper.WithAnalytics(
            new Dictionary<string, string> { ["sdk_version"] = "hack", ["source"] = "web" }
        );
        var payload = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
            merged[AnalyticsHelper.XCortiAnalytics]
        )!;

        Assert.That(payload["sdk_version"].GetString(), Is.EqualTo(Version.Current));
        Assert.That(payload["sdk_type"].GetString(), Is.EqualTo("corti-sdk-dotnet"));
        Assert.That(payload["source"].GetString(), Is.EqualTo("web"));
    }

    [Test]
    public void WithAnalytics_MergesAnExistingAnalyticsValueOnTheRecordLaterKeysWin()
    {
        var merged = AnalyticsHelper.WithAnalytics(
            new Dictionary<string, string>
            {
                ["integration"] = "epic",
                ["visit_type"] = "outpatient",
            },
            new Dictionary<string, string>
            {
                ["foo"] = "bar",
                [AnalyticsHelper.XCortiAnalytics] = """{"visit_type":"inpatient"}""",
            }
        );
        var payload = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
            merged[AnalyticsHelper.XCortiAnalytics]
        )!;

        Assert.That(merged["foo"], Is.EqualTo("bar"));
        Assert.That(payload["integration"].GetString(), Is.EqualTo("epic"));
        Assert.That(payload["visit_type"].GetString(), Is.EqualTo("inpatient"));
        Assert.That(payload["sdk_version"].GetString(), Is.EqualTo(Version.Current));
    }

    [Test]
    public void WithAnalytics_OverwritesReservedKeysFromTheRecordOverlay()
    {
        var merged = AnalyticsHelper.WithAnalytics(
            null,
            new Dictionary<string, string>
            {
                [AnalyticsHelper.XCortiAnalytics] = """{"sdk_version":"hack","sdk_type":"other","source":"web"}""",
            }
        );
        var payload = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
            merged[AnalyticsHelper.XCortiAnalytics]
        )!;

        Assert.That(payload["source"].GetString(), Is.EqualTo("web"));
        Assert.That(payload["sdk_version"].GetString(), Is.EqualTo(Version.Current));
        Assert.That(payload["sdk_type"].GetString(), Is.EqualTo("corti-sdk-dotnet"));
    }

    [Test]
    public void WithAnalytics_IgnoresInvalidAnalyticsJsonOnTheRecord()
    {
        var merged = AnalyticsHelper.WithAnalytics(
            new Dictionary<string, string> { ["source"] = "web" },
            new Dictionary<string, string>
            {
                ["foo"] = "bar",
                [AnalyticsHelper.XCortiAnalytics] = "not-json",
            }
        );

        Assert.That(merged["foo"], Is.EqualTo("bar"));
        var payload = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
            merged[AnalyticsHelper.XCortiAnalytics]
        )!;
        Assert.That(payload["source"].GetString(), Is.EqualTo("web"));
        Assert.That(payload["sdk_version"].GetString(), Is.EqualTo(Version.Current));
        Assert.That(payload["sdk_type"].GetString(), Is.EqualTo("corti-sdk-dotnet"));
    }
}
