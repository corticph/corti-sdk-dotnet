using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(StringEnumSerializer<TranscribeCommandVariableType>))]
[Serializable]
public readonly record struct TranscribeCommandVariableType : IStringEnum
{
    public static readonly TranscribeCommandVariableType Enum = new(Values.Enum);

    public TranscribeCommandVariableType(string value)
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
    public static TranscribeCommandVariableType FromCustom(string value)
    {
        return new TranscribeCommandVariableType(value);
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

    public static bool operator ==(TranscribeCommandVariableType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TranscribeCommandVariableType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TranscribeCommandVariableType value) => value.Value;

    public static explicit operator TranscribeCommandVariableType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Enum = "enum";
    }
}
