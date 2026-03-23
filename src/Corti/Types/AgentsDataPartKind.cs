using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(AgentsDataPartKind.AgentsDataPartKindSerializer))]
[Serializable]
public readonly record struct AgentsDataPartKind : IStringEnum
{
    public static readonly AgentsDataPartKind Data = new(Values.Data);

    public AgentsDataPartKind(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static AgentsDataPartKind FromCustom(string value)
    {
        return new AgentsDataPartKind(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(AgentsDataPartKind value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentsDataPartKind value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentsDataPartKind value) => value.Value;

    public static explicit operator AgentsDataPartKind(string value) => new(value);

    internal class AgentsDataPartKindSerializer : JsonConverter<AgentsDataPartKind>
    {
        public override AgentsDataPartKind Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new AgentsDataPartKind(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentsDataPartKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentsDataPartKind ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new AgentsDataPartKind(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentsDataPartKind value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Data = "data";
    }
}
