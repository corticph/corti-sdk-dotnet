using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record TranscribeErrorMessageError : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier for the request, for support and debugging.
    /// </summary>
    [JsonPropertyName("requestid")]
    public string? Requestid { get; set; }

    /// <summary>
    /// Unique error identifier
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Error title
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// HTTP status code
    /// </summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>
    /// Detailed error description
    /// </summary>
    [JsonPropertyName("details")]
    public string? Details { get; set; }

    /// <summary>
    /// Link to documentation
    /// </summary>
    [JsonPropertyName("doc")]
    public string? Doc { get; set; }

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
