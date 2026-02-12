using System.Text.Json;
using System.Text.Json.Serialization;
using CortiApi.Core;
using OneOf;

namespace CortiApi;

[Serializable]
public record AgentsArtifact : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier for the artifact.
    /// </summary>
    [JsonPropertyName("artifactId")]
    public required string ArtifactId { get; set; }

    /// <summary>
    /// Name of the artifact.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Description of the artifact.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The content of the artifact.
    /// </summary>
    [JsonPropertyName("parts")]
    public IEnumerable<OneOf<AgentsTextPart, AgentsFilePart, AgentsDataPart>> Parts { get; set; } =
        new List<OneOf<AgentsTextPart, AgentsFilePart, AgentsDataPart>>();

    /// <summary>
    /// Additional metadata for the artifact.
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, object?>? Metadata { get; set; }

    /// <summary>
    /// Extensions for the artifact.
    /// </summary>
    [JsonPropertyName("extensions")]
    public IEnumerable<string>? Extensions { get; set; }

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
