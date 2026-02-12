using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[JsonConverter(typeof(StringEnumSerializer<StreamConfigParticipantRole>))]
[Serializable]
public readonly record struct StreamConfigParticipantRole : IStringEnum
{
    public static readonly StreamConfigParticipantRole Doctor = new(Values.Doctor);

    public static readonly StreamConfigParticipantRole Patient = new(Values.Patient);

    public static readonly StreamConfigParticipantRole Multiple = new(Values.Multiple);

    public StreamConfigParticipantRole(string value)
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
    public static StreamConfigParticipantRole FromCustom(string value)
    {
        return new StreamConfigParticipantRole(value);
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

    public static bool operator ==(StreamConfigParticipantRole value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(StreamConfigParticipantRole value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(StreamConfigParticipantRole value) => value.Value;

    public static explicit operator StreamConfigParticipantRole(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Doctor = "doctor";

        public const string Patient = "patient";

        public const string Multiple = "multiple";
    }
}
