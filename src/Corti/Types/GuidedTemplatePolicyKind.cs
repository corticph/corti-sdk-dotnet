using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(GuidedTemplatePolicyKind.GuidedTemplatePolicyKindSerializer))]
[Serializable]
public readonly record struct GuidedTemplatePolicyKind : IStringEnum
{
    public static readonly GuidedTemplatePolicyKind Project = new(Values.Project);

    public static readonly GuidedTemplatePolicyKind Customers = new(Values.Customers);

    public GuidedTemplatePolicyKind(string value)
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
    public static GuidedTemplatePolicyKind FromCustom(string value)
    {
        return new GuidedTemplatePolicyKind(value);
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

    public static bool operator ==(GuidedTemplatePolicyKind value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GuidedTemplatePolicyKind value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GuidedTemplatePolicyKind value) => value.Value;

    public static explicit operator GuidedTemplatePolicyKind(string value) => new(value);

    internal class GuidedTemplatePolicyKindSerializer : JsonConverter<GuidedTemplatePolicyKind>
    {
        public override GuidedTemplatePolicyKind Read(
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
            return new GuidedTemplatePolicyKind(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GuidedTemplatePolicyKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GuidedTemplatePolicyKind ReadAsPropertyName(
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
            return new GuidedTemplatePolicyKind(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GuidedTemplatePolicyKind value,
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
