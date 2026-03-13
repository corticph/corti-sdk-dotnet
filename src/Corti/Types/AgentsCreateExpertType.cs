using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(StringEnumSerializer<AgentsCreateExpertType>))]
[Serializable]
public readonly record struct AgentsCreateExpertType : IStringEnum
{
    public static readonly AgentsCreateExpertType New = new(Values.New);

    public AgentsCreateExpertType(string value)
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
    public static AgentsCreateExpertType FromCustom(string value)
    {
        return new AgentsCreateExpertType(value);
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

    public static bool operator ==(AgentsCreateExpertType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentsCreateExpertType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentsCreateExpertType value) => value.Value;

    public static explicit operator AgentsCreateExpertType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string New = "new";
    }
}
