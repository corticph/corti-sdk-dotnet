using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[Serializable]
public record QueryData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// For guidelines, a summary of the response.
    /// </summary>
    [JsonPropertyName("summary")]
    public string? Summary { get; set; }

    [JsonPropertyName("sources")]
    public IEnumerable<QueryDataSourcesItem>? Sources { get; set; }

    [JsonPropertyName("mentions")]
    public IEnumerable<QueryDataMentionsItem>? Mentions { get; set; }

    /// <summary>
    /// General chat response in markdown format.
    /// </summary>
    [JsonPropertyName("response")]
    public string? Response { get; set; }

    /// <summary>
    /// For document rewrites, the rewritten text in markdown format.
    /// </summary>
    [JsonPropertyName("rewrittenText")]
    public string? RewrittenText { get; set; }

    /// <summary>
    /// Related or follow-up queries.
    /// </summary>
    [JsonPropertyName("queries")]
    public IEnumerable<string>? Queries { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
