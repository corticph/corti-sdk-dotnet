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

    /// <summary>
    /// With the optional header `X-Corti-Retention-Policy:none` the API will generate and return the document as expected, but the generated document will not be saved to the database. The response will include the header `X-Corti-Retention-Policy:acknowledged` to confirm that your retention preference was respected. If the header is omitted or set to any other value, the default retention policy will apply, and the document will be stored in the database.
    /// </summary>
    [JsonIgnore]
    public DocumentsCreateRequestXCortiRetentionPolicy? CortiRetentionPolicy { get; set; }

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
