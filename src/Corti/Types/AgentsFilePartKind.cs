using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(StringEnumSerializer<AgentsFilePartKind>))]
[Serializable]
public readonly record struct AgentsFilePartKind : IStringEnum
{
    public static readonly AgentsFilePartKind File = new(Values.File);

    public AgentsFilePartKind(string value)
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
    public static AgentsFilePartKind FromCustom(string value)
    {
        return new AgentsFilePartKind(value);
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

    public static bool operator ==(AgentsFilePartKind value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentsFilePartKind value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentsFilePartKind value) => value.Value;

    public static explicit operator AgentsFilePartKind(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string File = "file";
    }
}
