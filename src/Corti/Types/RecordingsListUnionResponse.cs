// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// Recording IDs by default; recording objects with metadata when `full=true`.
/// </summary>
[JsonConverter(typeof(RecordingsListUnionResponse.JsonConverter))]
[Serializable]
public class RecordingsListUnionResponse
{
    private RecordingsListUnionResponse(string type, object? value)
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
    /// Factory method to create a union from a Corti.RecordingsListResponse value.
    /// </summary>
    public static RecordingsListUnionResponse FromRecordingsListResponse(
        Corti.RecordingsListResponse value
    ) => new("recordingsListResponse", value);

    /// <summary>
    /// Factory method to create a union from a Corti.RecordingsListFullResponse value.
    /// </summary>
    public static RecordingsListUnionResponse FromRecordingsListFullResponse(
        Corti.RecordingsListFullResponse value
    ) => new("recordingsListFullResponse", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "recordingsListResponse"
    /// </summary>
    public bool IsRecordingsListResponse() => Type == "recordingsListResponse";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "recordingsListFullResponse"
    /// </summary>
    public bool IsRecordingsListFullResponse() => Type == "recordingsListFullResponse";

    /// <summary>
    /// Returns the value as a <see cref="Corti.RecordingsListResponse"/> if <see cref="Type"/> is 'recordingsListResponse', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'recordingsListResponse'.</exception>
    public Corti.RecordingsListResponse AsRecordingsListResponse() =>
        IsRecordingsListResponse()
            ? (Corti.RecordingsListResponse)Value!
            : throw new CortiClientException("Union type is not 'recordingsListResponse'");

    /// <summary>
    /// Returns the value as a <see cref="Corti.RecordingsListFullResponse"/> if <see cref="Type"/> is 'recordingsListFullResponse', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'recordingsListFullResponse'.</exception>
    public Corti.RecordingsListFullResponse AsRecordingsListFullResponse() =>
        IsRecordingsListFullResponse()
            ? (Corti.RecordingsListFullResponse)Value!
            : throw new CortiClientException("Union type is not 'recordingsListFullResponse'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.RecordingsListResponse"/> and returns true if successful.
    /// </summary>
    public bool TryGetRecordingsListResponse(out Corti.RecordingsListResponse? value)
    {
        if (Type == "recordingsListResponse")
        {
            value = (Corti.RecordingsListResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.RecordingsListFullResponse"/> and returns true if successful.
    /// </summary>
    public bool TryGetRecordingsListFullResponse(out Corti.RecordingsListFullResponse? value)
    {
        if (Type == "recordingsListFullResponse")
        {
            value = (Corti.RecordingsListFullResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Corti.RecordingsListResponse, T> onRecordingsListResponse,
        Func<Corti.RecordingsListFullResponse, T> onRecordingsListFullResponse
    )
    {
        return Type switch
        {
            "recordingsListResponse" => onRecordingsListResponse(AsRecordingsListResponse()),
            "recordingsListFullResponse" => onRecordingsListFullResponse(
                AsRecordingsListFullResponse()
            ),
            _ => throw new CortiClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<Corti.RecordingsListResponse> onRecordingsListResponse,
        Action<Corti.RecordingsListFullResponse> onRecordingsListFullResponse
    )
    {
        switch (Type)
        {
            case "recordingsListResponse":
                onRecordingsListResponse(AsRecordingsListResponse());
                break;
            case "recordingsListFullResponse":
                onRecordingsListFullResponse(AsRecordingsListFullResponse());
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
        if (obj is not RecordingsListUnionResponse other)
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

    public static implicit operator RecordingsListUnionResponse(
        Corti.RecordingsListResponse value
    ) => new("recordingsListResponse", value);

    public static implicit operator RecordingsListUnionResponse(
        Corti.RecordingsListFullResponse value
    ) => new("recordingsListFullResponse", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<RecordingsListUnionResponse>
    {
        public override RecordingsListUnionResponse? Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
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
                    ("recordingsListResponse", typeof(Corti.RecordingsListResponse)),
                    ("recordingsListFullResponse", typeof(Corti.RecordingsListFullResponse)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            RecordingsListUnionResponse result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into RecordingsListUnionResponse"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            RecordingsListUnionResponse value,
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

        public override RecordingsListUnionResponse ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            RecordingsListUnionResponse result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RecordingsListUnionResponse value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
