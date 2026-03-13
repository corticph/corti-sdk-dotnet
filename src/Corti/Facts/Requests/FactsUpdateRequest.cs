using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[Serializable]
public record FactsUpdateRequest
{
    /// <summary>
    /// The updated text of the fact.
    /// </summary>
    [JsonPropertyName("text")]
    public string? Text { get; set; }

    /// <summary>
    /// The updated group key for the fact.
    /// </summary>
    [JsonPropertyName("group")]
    public string? Group { get; set; }

    /// <summary>
    /// To track the updated source of the fact. Set to 'user' to indicate a change by an end-user.
    /// </summary>
    [JsonPropertyName("source")]
    public CommonSourceEnum? Source { get; set; }

    /// <summary>
    /// Set this to true if discarded by an end-user, then filter out from the document generation request.
    /// </summary>
    [JsonPropertyName("isDiscarded")]
    public bool? IsDiscarded { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
