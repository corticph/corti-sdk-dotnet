using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// Single property/op/value filter clause for attribute-based code filtering.
/// </summary>
[Serializable]
public record CodesFilterCondition : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The attribute to filter on, e.g. `code` (matches the `code` field on predicted codes), or a system-specific attribute such as `semantic_tag`.
    /// </summary>
    [JsonPropertyName("property")]
    public required string Property { get; set; }

    /// <summary>
    /// Comparison operator: `=` (equal), `is-a` (code plus descendants), `descendent-of` (strict descendants), `exists` (has any value), `in` (membership).
    /// </summary>
    [JsonPropertyName("op")]
    public CodesFilterConditionOp? Op { get; set; }

    /// <summary>
    /// Comparison value; type depends on `op`.
    /// </summary>
    [JsonPropertyName("value")]
    public CodesFilterConditionValue? Value { get; set; }

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
