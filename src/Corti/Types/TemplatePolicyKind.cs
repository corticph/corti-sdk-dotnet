using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(TemplatePolicyKind.TemplatePolicyKindSerializer))]
[Serializable]
public readonly record struct TemplatePolicyKind : IStringEnum
{
    public static readonly TemplatePolicyKind Project = new(Values.Project);

    public static readonly TemplatePolicyKind Customers = new(Values.Customers);

    public TemplatePolicyKind(string value)
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
    public static TemplatePolicyKind FromCustom(string value)
    {
        return new TemplatePolicyKind(value);
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

    public static bool operator ==(TemplatePolicyKind value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TemplatePolicyKind value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TemplatePolicyKind value) => value.Value;

    public static explicit operator TemplatePolicyKind(string value) => new(value);

    internal class TemplatePolicyKindSerializer : JsonConverter<TemplatePolicyKind>
    {
        public override TemplatePolicyKind Read(
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
            return new TemplatePolicyKind(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TemplatePolicyKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TemplatePolicyKind ReadAsPropertyName(
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
            return new TemplatePolicyKind(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TemplatePolicyKind value,
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
        public const string Project = "project";

        public const string Customers = "customers";
    }
}
