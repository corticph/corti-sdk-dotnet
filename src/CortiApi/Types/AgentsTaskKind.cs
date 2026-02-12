using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[JsonConverter(typeof(StringEnumSerializer<AgentsTaskKind>))]
[Serializable]
public readonly record struct AgentsTaskKind : IStringEnum
{
    public static readonly AgentsTaskKind Task = new(Values.Task);

    public AgentsTaskKind(string value)
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
    public static AgentsTaskKind FromCustom(string value)
    {
        return new AgentsTaskKind(value);
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

    public static bool operator ==(AgentsTaskKind value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentsTaskKind value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentsTaskKind value) => value.Value;

    public static explicit operator AgentsTaskKind(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Task = "task";
    }
}
