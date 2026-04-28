using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record CreateSectionVersionRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The title of this section. Passed to the LLM and also returned in the response.
    /// </summary>
    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [JsonPropertyName("instructions")]
    public required SectionInstructions Instructions { get; set; }

    [JsonPropertyName("outputSchema")]
    public OutputSchema? OutputSchema { get; set; }

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
