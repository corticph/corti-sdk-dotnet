using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[Serializable]
public record TemplatesGetRequest
{
    /// <summary>
    /// The key of the template
    /// </summary>
    [JsonIgnore]
    public required string Key { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
