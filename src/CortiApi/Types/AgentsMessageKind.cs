using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[JsonConverter(typeof(StringEnumSerializer<AgentsMessageKind>))]
[Serializable]
public readonly record struct AgentsMessageKind : IStringEnum
{
    public static readonly AgentsMessageKind Message = new(Values.Message);

    public AgentsMessageKind(string value)
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
    public static AgentsMessageKind FromCustom(string value)
    {
        return new AgentsMessageKind(value);
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

    public static bool operator ==(AgentsMessageKind value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentsMessageKind value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentsMessageKind value) => value.Value;

    public static explicit operator AgentsMessageKind(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Message = "message";
    }
}
