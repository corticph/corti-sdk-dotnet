using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[JsonConverter(typeof(StringEnumSerializer<AgentsAgentReferenceType>))]
[Serializable]
public readonly record struct AgentsAgentReferenceType : IStringEnum
{
    public static readonly AgentsAgentReferenceType Reference = new(Values.Reference);

    public AgentsAgentReferenceType(string value)
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
    public static AgentsAgentReferenceType FromCustom(string value)
    {
        return new AgentsAgentReferenceType(value);
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

    public static bool operator ==(AgentsAgentReferenceType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentsAgentReferenceType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentsAgentReferenceType value) => value.Value;

    public static explicit operator AgentsAgentReferenceType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Reference = "reference";
    }
}
