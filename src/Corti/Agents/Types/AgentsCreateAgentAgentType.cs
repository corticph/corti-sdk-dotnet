using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(StringEnumSerializer<AgentsCreateAgentAgentType>))]
[Serializable]
public readonly record struct AgentsCreateAgentAgentType : IStringEnum
{
    public static readonly AgentsCreateAgentAgentType Expert = new(Values.Expert);

    public static readonly AgentsCreateAgentAgentType Orchestrator = new(Values.Orchestrator);

    public static readonly AgentsCreateAgentAgentType InterviewingExpert = new(
        Values.InterviewingExpert
    );

    public AgentsCreateAgentAgentType(string value)
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
    public static AgentsCreateAgentAgentType FromCustom(string value)
    {
        return new AgentsCreateAgentAgentType(value);
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

    public static bool operator ==(AgentsCreateAgentAgentType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentsCreateAgentAgentType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentsCreateAgentAgentType value) => value.Value;

    public static explicit operator AgentsCreateAgentAgentType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Expert = "expert";

        public const string Orchestrator = "orchestrator";

        public const string InterviewingExpert = "interviewing-expert";
    }
}
