using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(StringEnumSerializer<TranscriptsParticipantRoleEnum>))]
[Serializable]
public readonly record struct TranscriptsParticipantRoleEnum : IStringEnum
{
    public static readonly TranscriptsParticipantRoleEnum Doctor = new(Values.Doctor);

    public static readonly TranscriptsParticipantRoleEnum Patient = new(Values.Patient);

    public static readonly TranscriptsParticipantRoleEnum Multiple = new(Values.Multiple);

    public TranscriptsParticipantRoleEnum(string value)
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
    public static TranscriptsParticipantRoleEnum FromCustom(string value)
    {
        return new TranscriptsParticipantRoleEnum(value);
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

    public static bool operator ==(TranscriptsParticipantRoleEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TranscriptsParticipantRoleEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TranscriptsParticipantRoleEnum value) => value.Value;

    public static explicit operator TranscriptsParticipantRoleEnum(string value) => new(value);

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
