using System.Text.Json.Serialization;
using CortiApi.Core;
using OneOf;

namespace CortiApi;

[Serializable]
public record DocumentsCreateRequest
{
    /// <summary>
    /// The unique identifier of the interaction. Must be a valid UUID.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    [JsonIgnore]
    public required OneOf<
        DocumentsCreateRequestWithTemplateKey,
        DocumentsCreateRequestWithTemplate
    > Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
