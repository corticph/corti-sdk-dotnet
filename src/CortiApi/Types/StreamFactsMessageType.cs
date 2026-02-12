using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[JsonConverter(typeof(StringEnumSerializer<StreamFactsMessageType>))]
[Serializable]
public readonly record struct StreamFactsMessageType : IStringEnum
{
    public static readonly StreamFactsMessageType Facts = new(Values.Facts);

    public StreamFactsMessageType(string value)
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
    public static StreamFactsMessageType FromCustom(string value)
    {
        return new StreamFactsMessageType(value);
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

    public static bool operator ==(StreamFactsMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(StreamFactsMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(StreamFactsMessageType value) => value.Value;

    public static explicit operator StreamFactsMessageType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Facts = "facts";
    }
}
