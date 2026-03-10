// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(AuthTokenRequestBody.JsonConverter))]
[Serializable]
public class AuthTokenRequestBody
{
    private AuthTokenRequestBody(string type, object? value)
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
    public static AuthTokenRequestBody FromAuthTokenRequestClientCredentials(
        Corti.AuthTokenRequestClientCredentials value
    ) => new("authTokenRequestClientCredentials", value);

    /// <summary>
    /// Factory method to create a union from a Corti.AuthTokenRequestAuthorizationCode value.
    /// </summary>
    public static AuthTokenRequestBody FromAuthTokenRequestAuthorizationCode(
        Corti.AuthTokenRequestAuthorizationCode value
    ) => new("authTokenRequestAuthorizationCode", value);

    /// <summary>
    /// Factory method to create a union from a Corti.AuthTokenRequestAuthorizationPkce value.
    /// </summary>
    public static AuthTokenRequestBody FromAuthTokenRequestAuthorizationPkce(
        Corti.AuthTokenRequestAuthorizationPkce value
    ) => new("authTokenRequestAuthorizationPkce", value);

    /// <summary>
    /// Factory method to create a union from a Corti.AuthTokenRequestRopc value.
    /// </summary>
    public static AuthTokenRequestBody FromAuthTokenRequestRopc(Corti.AuthTokenRequestRopc value) =>
        new("authTokenRequestRopc", value);

    /// <summary>
    /// Factory method to create a union from a Corti.AuthTokenRequestRefresh value.
    /// </summary>
    public static AuthTokenRequestBody FromAuthTokenRequestRefresh(
        Corti.AuthTokenRequestRefresh value
    ) => new("authTokenRequestRefresh", value);

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
    /// Returns true if <see cref="Type"/> is "authTokenRequestAuthorizationPkce"
    /// </summary>
    public bool IsAuthTokenRequestAuthorizationPkce() =>
        Type == "authTokenRequestAuthorizationPkce";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "authTokenRequestRopc"
    /// </summary>
    public bool IsAuthTokenRequestRopc() => Type == "authTokenRequestRopc";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "authTokenRequestRefresh"
    /// </summary>
    public bool IsAuthTokenRequestRefresh() => Type == "authTokenRequestRefresh";

    /// <summary>
    /// Returns the value as a <see cref="Corti.AuthTokenRequestClientCredentials"/> if <see cref="Type"/> is 'authTokenRequestClientCredentials', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientBaseException">Thrown when <see cref="Type"/> is not 'authTokenRequestClientCredentials'.</exception>
    public Corti.AuthTokenRequestClientCredentials AsAuthTokenRequestClientCredentials() =>
        IsAuthTokenRequestClientCredentials()
            ? (Corti.AuthTokenRequestClientCredentials)Value!
            : throw new CortiClientBaseException(
                "Union type is not 'authTokenRequestClientCredentials'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Corti.AuthTokenRequestAuthorizationCode"/> if <see cref="Type"/> is 'authTokenRequestAuthorizationCode', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientBaseException">Thrown when <see cref="Type"/> is not 'authTokenRequestAuthorizationCode'.</exception>
    public Corti.AuthTokenRequestAuthorizationCode AsAuthTokenRequestAuthorizationCode() =>
        IsAuthTokenRequestAuthorizationCode()
            ? (Corti.AuthTokenRequestAuthorizationCode)Value!
            : throw new CortiClientBaseException(
                "Union type is not 'authTokenRequestAuthorizationCode'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Corti.AuthTokenRequestAuthorizationPkce"/> if <see cref="Type"/> is 'authTokenRequestAuthorizationPkce', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientBaseException">Thrown when <see cref="Type"/> is not 'authTokenRequestAuthorizationPkce'.</exception>
    public Corti.AuthTokenRequestAuthorizationPkce AsAuthTokenRequestAuthorizationPkce() =>
        IsAuthTokenRequestAuthorizationPkce()
            ? (Corti.AuthTokenRequestAuthorizationPkce)Value!
            : throw new CortiClientBaseException(
                "Union type is not 'authTokenRequestAuthorizationPkce'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Corti.AuthTokenRequestRopc"/> if <see cref="Type"/> is 'authTokenRequestRopc', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientBaseException">Thrown when <see cref="Type"/> is not 'authTokenRequestRopc'.</exception>
    public Corti.AuthTokenRequestRopc AsAuthTokenRequestRopc() =>
        IsAuthTokenRequestRopc()
            ? (Corti.AuthTokenRequestRopc)Value!
            : throw new CortiClientBaseException("Union type is not 'authTokenRequestRopc'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.AuthTokenRequestRefresh"/> if <see cref="Type"/> is 'authTokenRequestRefresh', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientBaseException">Thrown when <see cref="Type"/> is not 'authTokenRequestRefresh'.</exception>
    public Corti.AuthTokenRequestRefresh AsAuthTokenRequestRefresh() =>
        IsAuthTokenRequestRefresh()
            ? (Corti.AuthTokenRequestRefresh)Value!
            : throw new CortiClientBaseException("Union type is not 'authTokenRequestRefresh'");

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

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.AuthTokenRequestAuthorizationPkce"/> and returns true if successful.
    /// </summary>
    public bool TryGetAuthTokenRequestAuthorizationPkce(
        out Corti.AuthTokenRequestAuthorizationPkce? value
    )
    {
        if (Type == "authTokenRequestAuthorizationPkce")
        {
            value = (Corti.AuthTokenRequestAuthorizationPkce)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.AuthTokenRequestRopc"/> and returns true if successful.
    /// </summary>
    public bool TryGetAuthTokenRequestRopc(out Corti.AuthTokenRequestRopc? value)
    {
        if (Type == "authTokenRequestRopc")
        {
            value = (Corti.AuthTokenRequestRopc)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.AuthTokenRequestRefresh"/> and returns true if successful.
    /// </summary>
    public bool TryGetAuthTokenRequestRefresh(out Corti.AuthTokenRequestRefresh? value)
    {
        if (Type == "authTokenRequestRefresh")
        {
            value = (Corti.AuthTokenRequestRefresh)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Corti.AuthTokenRequestClientCredentials, T> onAuthTokenRequestClientCredentials,
        Func<Corti.AuthTokenRequestAuthorizationCode, T> onAuthTokenRequestAuthorizationCode,
        Func<Corti.AuthTokenRequestAuthorizationPkce, T> onAuthTokenRequestAuthorizationPkce,
        Func<Corti.AuthTokenRequestRopc, T> onAuthTokenRequestRopc,
        Func<Corti.AuthTokenRequestRefresh, T> onAuthTokenRequestRefresh
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
            "authTokenRequestAuthorizationPkce" => onAuthTokenRequestAuthorizationPkce(
                AsAuthTokenRequestAuthorizationPkce()
            ),
            "authTokenRequestRopc" => onAuthTokenRequestRopc(AsAuthTokenRequestRopc()),
            "authTokenRequestRefresh" => onAuthTokenRequestRefresh(AsAuthTokenRequestRefresh()),
            _ => throw new CortiClientBaseException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<Corti.AuthTokenRequestClientCredentials> onAuthTokenRequestClientCredentials,
        Action<Corti.AuthTokenRequestAuthorizationCode> onAuthTokenRequestAuthorizationCode,
        Action<Corti.AuthTokenRequestAuthorizationPkce> onAuthTokenRequestAuthorizationPkce,
        Action<Corti.AuthTokenRequestRopc> onAuthTokenRequestRopc,
        Action<Corti.AuthTokenRequestRefresh> onAuthTokenRequestRefresh
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
            case "authTokenRequestAuthorizationPkce":
                onAuthTokenRequestAuthorizationPkce(AsAuthTokenRequestAuthorizationPkce());
                break;
            case "authTokenRequestRopc":
                onAuthTokenRequestRopc(AsAuthTokenRequestRopc());
                break;
            case "authTokenRequestRefresh":
                onAuthTokenRequestRefresh(AsAuthTokenRequestRefresh());
                break;
            default:
                throw new CortiClientBaseException($"Unknown union type: {Type}");
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
        if (obj is not AuthTokenRequestBody other)
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

    public static implicit operator AuthTokenRequestBody(
        Corti.AuthTokenRequestClientCredentials value
    ) => new("authTokenRequestClientCredentials", value);

    public static implicit operator AuthTokenRequestBody(
        Corti.AuthTokenRequestAuthorizationCode value
    ) => new("authTokenRequestAuthorizationCode", value);

    public static implicit operator AuthTokenRequestBody(
        Corti.AuthTokenRequestAuthorizationPkce value
    ) => new("authTokenRequestAuthorizationPkce", value);

    public static implicit operator AuthTokenRequestBody(Corti.AuthTokenRequestRopc value) =>
        new("authTokenRequestRopc", value);

    public static implicit operator AuthTokenRequestBody(Corti.AuthTokenRequestRefresh value) =>
        new("authTokenRequestRefresh", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<AuthTokenRequestBody>
    {
        public override AuthTokenRequestBody? Read(
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
                    (
                        "authTokenRequestAuthorizationPkce",
                        typeof(Corti.AuthTokenRequestAuthorizationPkce)
                    ),
                    ("authTokenRequestRopc", typeof(Corti.AuthTokenRequestRopc)),
                    ("authTokenRequestRefresh", typeof(Corti.AuthTokenRequestRefresh)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            AuthTokenRequestBody result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into AuthTokenRequestBody"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            AuthTokenRequestBody value,
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
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override AuthTokenRequestBody ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            AuthTokenRequestBody result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AuthTokenRequestBody value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
