using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// A group of conditions combined with AND or OR logic, used in `include` and `exclude` filters. Maximum nesting depth: 3.
/// </summary>
[Serializable]
public record CodesConditionGroup : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// `all` ANDs conditions (every condition must match). `any` ORs them (at least one must match). Omit when `conditions` has a single element.
    /// </summary>
    [JsonPropertyName("match")]
    public CodesConditionGroupMatch? Match { get; set; }

    /// <summary>
    /// Conditions or nested groups combined per `match`. Maximum nesting depth: 3.
    /// </summary>
    [JsonPropertyName("conditions")]
    public IEnumerable<CodesConditionGroupConditionsItem>? Conditions { get; set; }

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
