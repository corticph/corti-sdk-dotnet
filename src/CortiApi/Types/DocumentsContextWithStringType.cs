using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[JsonConverter(typeof(StringEnumSerializer<DocumentsContextWithStringType>))]
[Serializable]
public readonly record struct DocumentsContextWithStringType : IStringEnum
{
    public static readonly DocumentsContextWithStringType String = new(Values.String);

    public DocumentsContextWithStringType(string value)
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
    public static DocumentsContextWithStringType FromCustom(string value)
    {
        return new DocumentsContextWithStringType(value);
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

    public static bool operator ==(DocumentsContextWithStringType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DocumentsContextWithStringType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DocumentsContextWithStringType value) => value.Value;

    public static explicit operator DocumentsContextWithStringType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string String = "string";
    }
}
