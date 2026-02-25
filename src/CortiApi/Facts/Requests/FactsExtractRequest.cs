using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[Serializable]
public record FactsExtractRequest
{
    [JsonPropertyName("context")]
    public IEnumerable<Text> Context { get; set; } = new List<Text>();

    /// <summary>
    /// The desired output language code for extracted facts. Check [languages page](/about/languages) for more.
    /// </summary>
    [JsonPropertyName("outputLanguage")]
    public required string OutputLanguage { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
