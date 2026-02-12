using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[JsonConverter(typeof(StringEnumSerializer<DocumentsCreateRequestXCortiRetentionPolicy>))]
[Serializable]
public readonly record struct DocumentsCreateRequestXCortiRetentionPolicy : IStringEnum
{
    public static readonly DocumentsCreateRequestXCortiRetentionPolicy None = new(Values.None);

    public DocumentsCreateRequestXCortiRetentionPolicy(string value)
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
    public static DocumentsCreateRequestXCortiRetentionPolicy FromCustom(string value)
    {
        return new DocumentsCreateRequestXCortiRetentionPolicy(value);
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

    public static bool operator ==(
        DocumentsCreateRequestXCortiRetentionPolicy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        DocumentsCreateRequestXCortiRetentionPolicy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(DocumentsCreateRequestXCortiRetentionPolicy value) =>
        value.Value;

    public static explicit operator DocumentsCreateRequestXCortiRetentionPolicy(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string None = "none";
    }
}
