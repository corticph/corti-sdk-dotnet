using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record TemplatePolicy : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The kind of access policy. `project` means all users in the project can access, `customers` restricts to specific customer IDs.
    /// </summary>
    [JsonPropertyName("kind")]
    public required TemplatePolicyKind Kind { get; set; }

    /// <summary>
    /// Required when kind is `customers`. The list of customer IDs that can access this template.
    /// </summary>
    [JsonPropertyName("customerIds")]
    public IEnumerable<string>? CustomerIds { get; set; }

    [JsonPropertyName("templateId")]
    public required string TemplateId { get; set; }

    [JsonPropertyName("createdBy")]
    public required string CreatedBy { get; set; }

    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

    [JsonPropertyName("updatedAt")]
    public required DateTime UpdatedAt { get; set; }

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
