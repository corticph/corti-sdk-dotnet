using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

/// <summary>
/// OAuth 2.0 resource owner password credentials grant (ROPC).
/// </summary>
[Serializable]
public record AuthTokenRequestRopc : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Client identifier.
    /// </summary>
    [JsonPropertyName("client_id")]
    public required string ClientId { get; set; }

    [JsonRequired]
    [JsonPropertyName("grant_type")]
    public AuthTokenRequestRopc.GrantTypeLiteral GrantType { get;
#if NET5_0_OR_GREATER
        init;
#else
        set;
#endif
    } = new();

    /// <summary>
    /// Resource owner username.
    /// </summary>
    [JsonPropertyName("username")]
    public required string Username { get; set; }

    /// <summary>
    /// Resource owner password.
    /// </summary>
    [JsonPropertyName("password")]
    public required string Password { get; set; }

    /// <summary>
    /// Space-separated scopes. Optional.
    /// </summary>
    [JsonPropertyName("scope")]
    public string? Scope { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }

    [JsonConverter(typeof(GrantTypeLiteralConverter))]
    public readonly struct GrantTypeLiteral
    {
        public const string Value = "password";

        public static implicit operator string(GrantTypeLiteral _) => Value;

        public override string ToString() => Value;

        public override int GetHashCode() =>
            global::System.StringComparer.Ordinal.GetHashCode(Value);

        public override bool Equals(object? obj) => obj is GrantTypeLiteral;

        public static bool operator ==(GrantTypeLiteral _, GrantTypeLiteral __) => true;

        public static bool operator !=(GrantTypeLiteral _, GrantTypeLiteral __) => false;

        internal sealed class GrantTypeLiteralConverter : JsonConverter<GrantTypeLiteral>
        {
            public override GrantTypeLiteral Read(
                ref Utf8JsonReader reader,
                global::System.Type typeToConvert,
                JsonSerializerOptions options
            )
            {
                var value = reader.GetString();
                if (value != GrantTypeLiteral.Value)
                {
                    throw new JsonException(
                        "Expected \""
                            + GrantTypeLiteral.Value
                            + "\" for type discriminator but got \""
                            + value
                            + "\"."
                    );
                }
                return new GrantTypeLiteral();
            }

            public override void Write(
                Utf8JsonWriter writer,
                GrantTypeLiteral value,
                JsonSerializerOptions options
            ) => writer.WriteStringValue(GrantTypeLiteral.Value);

            public override GrantTypeLiteral ReadAsPropertyName(
                ref Utf8JsonReader reader,
                global::System.Type typeToConvert,
                JsonSerializerOptions options
            )
            {
                var value = reader.GetString();
                if (value != GrantTypeLiteral.Value)
                {
                    throw new JsonException(
                        "Expected \""
                            + GrantTypeLiteral.Value
                            + "\" for type discriminator but got \""
                            + value
                            + "\"."
                    );
                }
                return new GrantTypeLiteral();
            }

            public override void WriteAsPropertyName(
                Utf8JsonWriter writer,
                GrantTypeLiteral value,
                JsonSerializerOptions options
            ) => writer.WritePropertyName(GrantTypeLiteral.Value);
        }
    }
}
