using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

/// <summary>
/// Generate a document from a fully inline template definition supplied in the request body. Sections and the wrapping template are created and immediately published as auto-generated resources.
/// </summary>
[Serializable]
public record GuidedDocumentByDynamic : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Single context object the model reasons over. Same shape as the `DocumentsContext` used by `POST /interactions/{id}/documents/`, but supplied as a single object — not an array.
    /// </summary>
    [JsonPropertyName("context")]
    public required DocumentsContext Context { get; set; }

    /// <summary>
    /// Fully inline template defined in the request body.
    /// </summary>
    [JsonPropertyName("dynamicTemplate")]
    public required GuidedDynamicRequest DynamicTemplate { get; set; }

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
