using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[JsonConverter(typeof(StringEnumSerializer<CodesContextTypeEnum>))]
[Serializable]
public readonly record struct CodesContextTypeEnum : IStringEnum
{
    public static readonly CodesContextTypeEnum String = new(Values.String);

    public static readonly CodesContextTypeEnum DocumentId = new(Values.DocumentId);

    public CodesContextTypeEnum(string value)
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
    public static CodesContextTypeEnum FromCustom(string value)
    {
        return new CodesContextTypeEnum(value);
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

    public static bool operator ==(CodesContextTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CodesContextTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CodesContextTypeEnum value) => value.Value;

    public static explicit operator CodesContextTypeEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string String = "string";

        public const string DocumentId = "documentId";
    }
}
