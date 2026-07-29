using Corti.Core;
using global::System.Text.Json.Serialization;

namespace Corti;

[Serializable]
public record LanguagesListRequest
{
    /// <summary>
    /// Field used to filter languages that supported specific endpoint.
    /// </summary>
    [JsonIgnore]
    public LanguagesListRequestEndpoint? Endpoint { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
