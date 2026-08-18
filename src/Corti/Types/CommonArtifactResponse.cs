using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// A named output produced by a task.
/// </summary>
[Serializable]
public record CommonArtifactResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("artifactId")]
    public required string ArtifactId { get; set; }

    /// <summary>
    /// Optional artifact name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// A human-readable description of the artifact.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// URIs of extensions that contributed to this artifact.
    /// </summary>
    [JsonPropertyName("extensions")]
    public IEnumerable<string>? Extensions { get; set; }

    /// <summary>
    /// Optional metadata included with the artifact.
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, object?>? Metadata { get; set; }

    /// <summary>
    /// Content parts of the artifact.
    /// </summary>
    [JsonPropertyName("parts")]
    public IEnumerable<CommonPart> Parts { get; set; } = new List<CommonPart>();

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
