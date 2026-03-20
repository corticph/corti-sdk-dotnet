using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record AgentsValidationErrorResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("detail")]
    public IEnumerable<AgentsValidationError>? Detail { get; set; }

    /// <summary>
    /// A machine-readable error code that identifies the type of error.
    /// </summary>
    [JsonPropertyName("code")]
    public required string Code { get; set; }

    /// <summary>
    /// A human-readable description of the error, providing more context about what went wrong.
    /// </summary>
    [JsonPropertyName("description")]
    public required string Description { get; set; }

    /// <summary>
    /// A human-readable message describing how to fix the issue.
    /// </summary>
    [JsonPropertyName("howToFix")]
    public string? HowToFix { get; set; }

    /// <summary>
    /// An optional object containing additional details about the error.
    /// </summary>
    [JsonPropertyName("details")]
    public Dictionary<string, object?>? Details { get; set; }

    [JsonPropertyName("cause")]
    public AgentsErrorResponse? Cause { get; set; }

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
