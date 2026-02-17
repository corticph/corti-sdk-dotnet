using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[Serializable]
public record AgentsAgentCardSignature : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The protected header of the JWS, base64url-encoded.
    /// </summary>
    [JsonPropertyName("protected")]
    public required string Protected { get; set; }

    /// <summary>
    /// The JWS signature, base64url-encoded.
    /// </summary>
    [JsonPropertyName("signature")]
    public required string Signature { get; set; }

    /// <summary>
    /// The unprotected header of the JWS, if any.
    /// </summary>
    [JsonPropertyName("header")]
    public Dictionary<string, object?>? Header { get; set; }

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
