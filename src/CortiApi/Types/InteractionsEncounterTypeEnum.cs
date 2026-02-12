using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[JsonConverter(typeof(StringEnumSerializer<InteractionsEncounterTypeEnum>))]
[Serializable]
public readonly record struct InteractionsEncounterTypeEnum : IStringEnum
{
    public static readonly InteractionsEncounterTypeEnum FirstConsultation = new(
        Values.FirstConsultation
    );

    public static readonly InteractionsEncounterTypeEnum Consultation = new(Values.Consultation);

    public static readonly InteractionsEncounterTypeEnum Emergency = new(Values.Emergency);

    public static readonly InteractionsEncounterTypeEnum Inpatient = new(Values.Inpatient);

    public static readonly InteractionsEncounterTypeEnum Outpatient = new(Values.Outpatient);

    public InteractionsEncounterTypeEnum(string value)
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
    public static InteractionsEncounterTypeEnum FromCustom(string value)
    {
        return new InteractionsEncounterTypeEnum(value);
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

    public static bool operator ==(InteractionsEncounterTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(InteractionsEncounterTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(InteractionsEncounterTypeEnum value) => value.Value;

    public static explicit operator InteractionsEncounterTypeEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string FirstConsultation = "first_consultation";

        public const string Consultation = "consultation";

        public const string Emergency = "emergency";

        public const string Inpatient = "inpatient";

        public const string Outpatient = "outpatient";
    }
}
