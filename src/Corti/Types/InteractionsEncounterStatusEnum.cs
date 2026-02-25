using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(StringEnumSerializer<InteractionsEncounterStatusEnum>))]
[Serializable]
public readonly record struct InteractionsEncounterStatusEnum : IStringEnum
{
    public static readonly InteractionsEncounterStatusEnum Planned = new(Values.Planned);

    public static readonly InteractionsEncounterStatusEnum InProgress = new(Values.InProgress);

    public static readonly InteractionsEncounterStatusEnum OnHold = new(Values.OnHold);

    public static readonly InteractionsEncounterStatusEnum Completed = new(Values.Completed);

    public static readonly InteractionsEncounterStatusEnum Cancelled = new(Values.Cancelled);

    public static readonly InteractionsEncounterStatusEnum Deleted = new(Values.Deleted);

    public InteractionsEncounterStatusEnum(string value)
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
    public static InteractionsEncounterStatusEnum FromCustom(string value)
    {
        return new InteractionsEncounterStatusEnum(value);
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

    public static bool operator ==(InteractionsEncounterStatusEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(InteractionsEncounterStatusEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(InteractionsEncounterStatusEnum value) => value.Value;

    public static explicit operator InteractionsEncounterStatusEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Planned = "planned";

        public const string InProgress = "in-progress";

        public const string OnHold = "on-hold";

        public const string Completed = "completed";

        public const string Cancelled = "cancelled";

        public const string Deleted = "deleted";
    }
}
