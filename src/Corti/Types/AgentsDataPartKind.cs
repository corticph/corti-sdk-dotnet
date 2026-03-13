using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(StringEnumSerializer<AgentsDataPartKind>))]
[Serializable]
public readonly record struct AgentsDataPartKind : IStringEnum
{
    public static readonly AgentsDataPartKind Data = new(Values.Data);

    public AgentsDataPartKind(string value)
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
    public static AgentsDataPartKind FromCustom(string value)
    {
        return new AgentsDataPartKind(value);
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

    public static bool operator ==(AgentsDataPartKind value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentsDataPartKind value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentsDataPartKind value) => value.Value;

    public static explicit operator AgentsDataPartKind(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Data = "data";
    }
}
