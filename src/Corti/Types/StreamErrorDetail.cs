using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record StreamErrorDetail : IJsonOnDeserialized
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
    /// Error identifier
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Error title
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// HTTP status code or similar error code
    /// </summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>
    /// Detailed error message
    /// </summary>
    [JsonPropertyName("details")]
    public string? Details { get; set; }

    /// <summary>
    /// Link to documentation or further information
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
