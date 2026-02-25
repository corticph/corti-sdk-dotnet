using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record CommonDocumentIdContext : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The type of context, always "documentId" in this context.
    /// </summary>
    [JsonPropertyName("type")]
    public required CommonDocumentIdContextType Type { get; set; }

    /// <summary>
    /// A referenced document ID to be used as input to the model.
    /// </summary>
    [JsonPropertyName("documentId")]
    public required string DocumentId { get; set; }

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
