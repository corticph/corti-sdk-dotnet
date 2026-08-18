using Corti.Core;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// A single content part of a message or artifact.
/// </summary>
[Serializable]
public record CommonPart : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// The string content of the `text` part.
    /// </summary>
    [JsonPropertyName("text")]
    public string? Text { get; set; }

    /// <summary>
    /// Arbitrary structured `data` as a JSON value (object, array, string, number, boolean, or null).
    /// </summary>
    [JsonPropertyName("data")]
    public Dictionary<string, object?>? Data { get; set; }

    /// <summary>
    /// An optional `filename` for the file (e.g., `document.pdf`).
    /// </summary>
    [JsonPropertyName("filename")]
    public string? Filename { get; set; }

    /// <summary>
    /// The `media_type` (MIME type) of the part content (e.g., `text/plain`, `application/json`, `image/png`).
    /// </summary>
    [JsonPropertyName("mediaType")]
    public string? MediaType { get; set; }

    /// <summary>
    /// The `raw` byte content of a file. Encoded as a base64 string.
    /// </summary>
    [JsonPropertyName("raw")]
    public string? Raw { get; set; }

    /// <summary>
    /// A `url` pointing to the file's content.
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>
    /// Optional metadata associated with this part.
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, object?>? Metadata { get; set; }

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
