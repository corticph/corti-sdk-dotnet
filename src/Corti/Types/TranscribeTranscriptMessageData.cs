// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

/// <summary>
/// The singular segment object, or a list of items when `wordLevel` is enabled: all word items finalized together in one message, or a one-element list carrying the in-progress segment for interim previews when `interimResults` is also enabled.
/// </summary>
[JsonConverter(typeof(TranscribeTranscriptMessageData.JsonConverter))]
[Serializable]
public class TranscribeTranscriptMessageData
{
    private TranscribeTranscriptMessageData(string type, object? value)
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
    /// Factory method to create a union from a Corti.TranscribeTranscriptData value.
    /// </summary>
    public static TranscribeTranscriptMessageData FromTranscribeTranscriptData(
        Corti.TranscribeTranscriptData value
    ) => new("transcribeTranscriptData", value);

    /// <summary>
    /// Factory method to create a union from a IEnumerable<TranscribeTranscriptData> value.
    /// </summary>
    public static TranscribeTranscriptMessageData FromListOfTranscribeTranscriptData(
        IEnumerable<TranscribeTranscriptData> value
    ) => new("list", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "transcribeTranscriptData"
    /// </summary>
    public bool IsTranscribeTranscriptData() => Type == "transcribeTranscriptData";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "list"
    /// </summary>
    public bool IsListOfTranscribeTranscriptData() => Type == "list";

    /// <summary>
    /// Returns the value as a <see cref="Corti.TranscribeTranscriptData"/> if <see cref="Type"/> is 'transcribeTranscriptData', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'transcribeTranscriptData'.</exception>
    public Corti.TranscribeTranscriptData AsTranscribeTranscriptData() =>
        IsTranscribeTranscriptData()
            ? (Corti.TranscribeTranscriptData)Value!
            : throw new CortiClientException("Union type is not 'transcribeTranscriptData'");

    /// <summary>
    /// Returns the value as a <see cref="IEnumerable<TranscribeTranscriptData>"/> if <see cref="Type"/> is 'list', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'list'.</exception>
    public IEnumerable<TranscribeTranscriptData> AsListOfTranscribeTranscriptData() =>
        IsListOfTranscribeTranscriptData()
            ? (IEnumerable<TranscribeTranscriptData>)Value!
            : throw new CortiClientException("Union type is not 'list'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.TranscribeTranscriptData"/> and returns true if successful.
    /// </summary>
    public bool TryGetTranscribeTranscriptData(out Corti.TranscribeTranscriptData? value)
    {
        if (Type == "transcribeTranscriptData")
        {
            value = (Corti.TranscribeTranscriptData)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="IEnumerable<TranscribeTranscriptData>"/> and returns true if successful.
    /// </summary>
    public bool TryGetListOfTranscribeTranscriptData(
        out IEnumerable<TranscribeTranscriptData>? value
    )
    {
        if (Type == "list")
        {
            value = (IEnumerable<TranscribeTranscriptData>)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Corti.TranscribeTranscriptData, T> onTranscribeTranscriptData,
        Func<IEnumerable<TranscribeTranscriptData>, T> onListOfTranscribeTranscriptData
    )
    {
        return Type switch
        {
            "transcribeTranscriptData" => onTranscribeTranscriptData(AsTranscribeTranscriptData()),
            "list" => onListOfTranscribeTranscriptData(AsListOfTranscribeTranscriptData()),
            _ => throw new CortiClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<Corti.TranscribeTranscriptData> onTranscribeTranscriptData,
        Action<IEnumerable<TranscribeTranscriptData>> onListOfTranscribeTranscriptData
    )
    {
        switch (Type)
        {
            case "transcribeTranscriptData":
                onTranscribeTranscriptData(AsTranscribeTranscriptData());
                break;
            case "list":
                onListOfTranscribeTranscriptData(AsListOfTranscribeTranscriptData());
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
        if (obj is not TranscribeTranscriptMessageData other)
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

    public static implicit operator TranscribeTranscriptMessageData(
        Corti.TranscribeTranscriptData value
    ) => new("transcribeTranscriptData", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<TranscribeTranscriptMessageData>
    {
        public override TranscribeTranscriptMessageData? Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonTokenType.StartArray)
            {
                var document = JsonDocument.ParseValue(ref reader);

                var types = new (string Key, System.Type Type)[]
                {
                    ("list", typeof(IEnumerable<TranscribeTranscriptData>)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            TranscribeTranscriptMessageData result = new(key, value);
                            return result;
                        }
                    }
                    catch (JsonException)
                    {
                        // Try next type;
                    }
                }
            }

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                var document = JsonDocument.ParseValue(ref reader);

                var types = new (string Key, System.Type Type)[]
                {
                    ("transcribeTranscriptData", typeof(Corti.TranscribeTranscriptData)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            TranscribeTranscriptMessageData result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into TranscribeTranscriptMessageData"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            TranscribeTranscriptMessageData value,
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

        public override TranscribeTranscriptMessageData ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            TranscribeTranscriptMessageData result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TranscribeTranscriptMessageData value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
