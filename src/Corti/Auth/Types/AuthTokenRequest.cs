// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(AuthTokenRequest.JsonConverter))]
[Serializable]
public class AuthTokenRequest
{
    private AuthTokenRequest(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Type discriminator
    /// </summary>
    [JsonIgnore]
    public string Type { get; internal set; }

    /// <summary>
    /// Union value
    /// </summary>
    [JsonIgnore]
    public object? Value { get; internal set; }

    /// <summary>
    /// Factory method to create a union from a Corti.AuthTokenRequestClientCredentials value.
    /// </summary>
    public static AuthTokenRequest FromAuthTokenRequestClientCredentials(
        Corti.AuthTokenRequestClientCredentials value
    ) => new("authTokenRequestClientCredentials", value);

    /// <summary>
    /// Factory method to create a union from a Corti.AuthTokenRequestAuthorizationCode value.
    /// </summary>
    public static AuthTokenRequest FromAuthTokenRequestAuthorizationCode(
        Corti.AuthTokenRequestAuthorizationCode value
    ) => new("authTokenRequestAuthorizationCode", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "authTokenRequestClientCredentials"
    /// </summary>
    public bool IsAuthTokenRequestClientCredentials() =>
        Type == "authTokenRequestClientCredentials";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "authTokenRequestAuthorizationCode"
    /// </summary>
    public bool IsAuthTokenRequestAuthorizationCode() =>
        Type == "authTokenRequestAuthorizationCode";

    /// <summary>
    /// Returns the value as a <see cref="Corti.AuthTokenRequestClientCredentials"/> if <see cref="Type"/> is 'authTokenRequestClientCredentials', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'authTokenRequestClientCredentials'.</exception>
    public Corti.AuthTokenRequestClientCredentials AsAuthTokenRequestClientCredentials() =>
        IsAuthTokenRequestClientCredentials()
            ? (Corti.AuthTokenRequestClientCredentials)Value!
            : throw new CortiClientException(
                "Union type is not 'authTokenRequestClientCredentials'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Corti.AuthTokenRequestAuthorizationCode"/> if <see cref="Type"/> is 'authTokenRequestAuthorizationCode', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'authTokenRequestAuthorizationCode'.</exception>
    public Corti.AuthTokenRequestAuthorizationCode AsAuthTokenRequestAuthorizationCode() =>
        IsAuthTokenRequestAuthorizationCode()
            ? (Corti.AuthTokenRequestAuthorizationCode)Value!
            : throw new CortiClientException(
                "Union type is not 'authTokenRequestAuthorizationCode'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.AuthTokenRequestClientCredentials"/> and returns true if successful.
    /// </summary>
    public bool TryGetAuthTokenRequestClientCredentials(
        out Corti.AuthTokenRequestClientCredentials? value
    )
    {
        if (Type == "authTokenRequestClientCredentials")
        {
            value = (Corti.AuthTokenRequestClientCredentials)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.AuthTokenRequestAuthorizationCode"/> and returns true if successful.
    /// </summary>
    public bool TryGetAuthTokenRequestAuthorizationCode(
        out Corti.AuthTokenRequestAuthorizationCode? value
    )
    {
        if (Type == "authTokenRequestAuthorizationCode")
        {
            value = (Corti.AuthTokenRequestAuthorizationCode)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Corti.AuthTokenRequestClientCredentials, T> onAuthTokenRequestClientCredentials,
        Func<Corti.AuthTokenRequestAuthorizationCode, T> onAuthTokenRequestAuthorizationCode
    )
    {
        return Type switch
        {
            "authTokenRequestClientCredentials" => onAuthTokenRequestClientCredentials(
                AsAuthTokenRequestClientCredentials()
            ),
            "authTokenRequestAuthorizationCode" => onAuthTokenRequestAuthorizationCode(
                AsAuthTokenRequestAuthorizationCode()
            ),
            _ => throw new CortiClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<Corti.AuthTokenRequestClientCredentials> onAuthTokenRequestClientCredentials,
        Action<Corti.AuthTokenRequestAuthorizationCode> onAuthTokenRequestAuthorizationCode
    )
    {
        switch (Type)
        {
            case "authTokenRequestClientCredentials":
                onAuthTokenRequestClientCredentials(AsAuthTokenRequestClientCredentials());
                break;
            case "authTokenRequestAuthorizationCode":
                onAuthTokenRequestAuthorizationCode(AsAuthTokenRequestAuthorizationCode());
                break;
            default:
                throw new CortiClientException($"Unknown union type: {Type}");
        }
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = Type.GetHashCode();
            if (Value != null)
            {
                hashCode = (hashCode * 397) ^ Value.GetHashCode();
            }
            return hashCode;
        }
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (obj is not AuthTokenRequest other)
            return false;

        // Compare type discriminators
        if (Type != other.Type)
            return false;

        // Compare values using EqualityComparer for deep comparison
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator AuthTokenRequest(
        Corti.AuthTokenRequestClientCredentials value
    ) => new("authTokenRequestClientCredentials", value);

    public static implicit operator AuthTokenRequest(
        Corti.AuthTokenRequestAuthorizationCode value
    ) => new("authTokenRequestAuthorizationCode", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<AuthTokenRequest>
    {
        public override AuthTokenRequest? Read(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                var document = JsonDocument.ParseValue(ref reader);

                var types = new (string Key, System.Type Type)[]
                {
                    (
                        "authTokenRequestClientCredentials",
                        typeof(Corti.AuthTokenRequestClientCredentials)
                    ),
                    (
                        "authTokenRequestAuthorizationCode",
                        typeof(Corti.AuthTokenRequestAuthorizationCode)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            AuthTokenRequest result = new(key, value);
                            return result;
                        }
                    }
                    catch (JsonException)
                    {
                        // Try next type;
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into AuthTokenRequest"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            AuthTokenRequest value,
            JsonSerializerOptions options
        )
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            value.Visit(
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override AuthTokenRequest ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            AuthTokenRequest result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AuthTokenRequest value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
