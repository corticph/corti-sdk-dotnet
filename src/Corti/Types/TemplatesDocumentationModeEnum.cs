using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(StringEnumSerializer<TemplatesDocumentationModeEnum>))]
[Serializable]
public readonly record struct TemplatesDocumentationModeEnum : IStringEnum
{
    public static readonly TemplatesDocumentationModeEnum GlobalSequential = new(
        Values.GlobalSequential
    );

    public static readonly TemplatesDocumentationModeEnum RoutedParallel = new(
        Values.RoutedParallel
    );

    public TemplatesDocumentationModeEnum(string value)
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
    public static TemplatesDocumentationModeEnum FromCustom(string value)
    {
        return new TemplatesDocumentationModeEnum(value);
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

    public static bool operator ==(TemplatesDocumentationModeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TemplatesDocumentationModeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TemplatesDocumentationModeEnum value) => value.Value;

    public static explicit operator TemplatesDocumentationModeEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string GlobalSequential = "global_sequential";

        public const string RoutedParallel = "routed_parallel";
    }
}
