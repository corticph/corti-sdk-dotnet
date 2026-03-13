using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record FactsBatchUpdateInput : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The unique identifier of the fact to be updated.
    /// </summary>
    [JsonPropertyName("factId")]
    public required string FactId { get; set; }

    /// <summary>
    /// Set this to true for facts discarded by an end-user, then filter those out from the document generation request.
    /// </summary>
    [JsonPropertyName("isDiscarded")]
    public bool? IsDiscarded { get; set; }

    /// <summary>
    /// The updated text content of the fact.
    /// </summary>
    [JsonPropertyName("text")]
    public string? Text { get; set; }

    /// <summary>
    /// The updated group key for the fact.
    /// </summary>
    [JsonPropertyName("group")]
    public string? Group { get; set; }

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
