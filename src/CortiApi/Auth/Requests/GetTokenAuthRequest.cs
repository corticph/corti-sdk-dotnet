using System.Text.Json.Serialization;
using CortiApi.Core;
using OneOf;

namespace CortiApi;

[Serializable]
public record GetTokenAuthRequest
{
    /// <summary>
    /// Keycloak realm / tenant name. Must match the tenant used for API requests (same as Tenant-Name header).
    /// </summary>
    [JsonIgnore]
    public required string TenantName { get; set; }

    [JsonIgnore]
    public required OneOf<
        GetTokenRequestClientCredentials,
        GetTokenRequestAuthorizationCode,
        GetTokenRequestRefreshToken,
        GetTokenRequestPassword
    > Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
