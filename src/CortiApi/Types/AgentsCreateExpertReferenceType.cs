using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[JsonConverter(typeof(StringEnumSerializer<AgentsCreateExpertReferenceType>))]
[Serializable]
public readonly record struct AgentsCreateExpertReferenceType : IStringEnum
{
    public static readonly AgentsCreateExpertReferenceType Reference = new(Values.Reference);

    public AgentsCreateExpertReferenceType(string value)
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
    public static AgentsCreateExpertReferenceType FromCustom(string value)
    {
        return new AgentsCreateExpertReferenceType(value);
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

    public static bool operator ==(AgentsCreateExpertReferenceType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentsCreateExpertReferenceType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentsCreateExpertReferenceType value) => value.Value;

    public static explicit operator AgentsCreateExpertReferenceType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Reference = "reference";
    }
}
