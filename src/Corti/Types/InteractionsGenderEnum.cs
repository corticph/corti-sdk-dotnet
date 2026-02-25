using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(StringEnumSerializer<InteractionsGenderEnum>))]
[Serializable]
public readonly record struct InteractionsGenderEnum : IStringEnum
{
    public static readonly InteractionsGenderEnum Male = new(Values.Male);

    public static readonly InteractionsGenderEnum Female = new(Values.Female);

    public static readonly InteractionsGenderEnum Unknown = new(Values.Unknown);

    public static readonly InteractionsGenderEnum Other = new(Values.Other);

    public InteractionsGenderEnum(string value)
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
    public static InteractionsGenderEnum FromCustom(string value)
    {
        return new InteractionsGenderEnum(value);
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

    public static bool operator ==(InteractionsGenderEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(InteractionsGenderEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(InteractionsGenderEnum value) => value.Value;

    public static explicit operator InteractionsGenderEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Male = "male";

        public const string Female = "female";

        public const string Unknown = "unknown";

        public const string Other = "other";
    }
}
