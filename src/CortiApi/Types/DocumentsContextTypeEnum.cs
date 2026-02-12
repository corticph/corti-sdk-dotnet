using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[JsonConverter(typeof(StringEnumSerializer<DocumentsContextTypeEnum>))]
[Serializable]
public readonly record struct DocumentsContextTypeEnum : IStringEnum
{
    public static readonly DocumentsContextTypeEnum Facts = new(Values.Facts);

    public static readonly DocumentsContextTypeEnum Transcript = new(Values.Transcript);

    public static readonly DocumentsContextTypeEnum String = new(Values.String);

    public DocumentsContextTypeEnum(string value)
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
    public static DocumentsContextTypeEnum FromCustom(string value)
    {
        return new DocumentsContextTypeEnum(value);
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

    public static bool operator ==(DocumentsContextTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DocumentsContextTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DocumentsContextTypeEnum value) => value.Value;

    public static explicit operator DocumentsContextTypeEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Facts = "facts";

        public const string Transcript = "transcript";

        public const string String = "string";
    }
}
