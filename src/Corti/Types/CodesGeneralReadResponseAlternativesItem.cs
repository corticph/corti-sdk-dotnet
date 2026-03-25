using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

/// <summary>
/// The alternative code
/// </summary>
[Serializable]
public record CodesGeneralReadResponseAlternativesItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The medical code
    /// </summary>
    [JsonPropertyName("code")]
    public required string Code { get; set; }

    /// <summary>
    /// Description of the medical code
    /// </summary>
    [JsonPropertyName("display")]
    public required string Display { get; set; }

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
