using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

[Serializable]
public record AgentCardResponseSignaturesItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Base64url-encoded protected JWS header.
    /// </summary>
    [JsonPropertyName("protected")]
    public required string Protected { get; set; }

    /// <summary>
    /// Unprotected JWS header values.
    /// </summary>
    [JsonPropertyName("header")]
    public Dictionary<string, object?>? Header { get; set; }

    /// <summary>
    /// Base64url-encoded signature.
    /// </summary>
    [JsonPropertyName("signature")]
    public required string Signature { get; set; }

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
