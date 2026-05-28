using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record GuidedSectionPolicy : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The UUID of the policy.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("kind")]
    public required GuidedTemplatePolicyKind Kind { get; set; }

    /// <summary>
    /// Present when `kind` is `customers`. Lists the customer tenant identifiers that have access.
    /// </summary>
    [JsonPropertyName("customerIds")]
    public IEnumerable<string>? CustomerIds { get; set; }

    /// <summary>
    /// The UUID of the section this policy belongs to.
    /// </summary>
    [JsonPropertyName("sectionId")]
    public required string SectionId { get; set; }

    /// <summary>
    /// The UUID of the user who created this policy.
    /// </summary>
    [JsonPropertyName("createdBy")]
    public required string CreatedBy { get; set; }

    /// <summary>
    /// Timestamp when the policy was created.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// Timestamp when the policy was last updated.
    /// </summary>
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
