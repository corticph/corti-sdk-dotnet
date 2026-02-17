using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[JsonConverter(typeof(StringEnumSerializer<AgentsExpertReferenceType>))]
[Serializable]
public readonly record struct AgentsExpertReferenceType : IStringEnum
{
    public static readonly AgentsExpertReferenceType Reference = new(Values.Reference);

    public AgentsExpertReferenceType(string value)
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
    public static AgentsExpertReferenceType FromCustom(string value)
    {
        return new AgentsExpertReferenceType(value);
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

    public static bool operator ==(AgentsExpertReferenceType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentsExpertReferenceType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentsExpertReferenceType value) => value.Value;

    public static explicit operator AgentsExpertReferenceType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Reference = "reference";
    }
}
