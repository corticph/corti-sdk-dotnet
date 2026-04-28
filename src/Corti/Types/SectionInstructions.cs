using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record SectionInstructions : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The content prompt instructs the model what to include for synthesis. For `documentationMode: routed_parallel` this impacts what facts to route to this section.
    /// </summary>
    [JsonPropertyName("contentPrompt")]
    public required string ContentPrompt { get; set; }

    /// <summary>
    /// The writingStyle prompt instructs the model in what tone and style to output.
    /// </summary>
    [JsonPropertyName("writingStylePrompt")]
    public required string WritingStylePrompt { get; set; }

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
