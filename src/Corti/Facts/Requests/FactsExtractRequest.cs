using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record FactsExtractRequest
{
    [JsonPropertyName("context")]
    public IEnumerable<CommonTextContext> Context { get; set; } = new List<CommonTextContext>();

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
