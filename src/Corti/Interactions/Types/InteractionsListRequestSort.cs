using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(InteractionsListRequestSort.InteractionsListRequestSortSerializer))]
[Serializable]
public readonly record struct InteractionsListRequestSort : IStringEnum
{
    public static readonly InteractionsListRequestSort Id = new(Values.Id);

    public static readonly InteractionsListRequestSort AssignedUserId = new(Values.AssignedUserId);

    public static readonly InteractionsListRequestSort Patient = new(Values.Patient);

    public static readonly InteractionsListRequestSort CreatedAt = new(Values.CreatedAt);

    public static readonly InteractionsListRequestSort EndedAt = new(Values.EndedAt);

    public static readonly InteractionsListRequestSort UpdatedAt = new(Values.UpdatedAt);

    public InteractionsListRequestSort(string value)
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
    public static InteractionsListRequestSort FromCustom(string value)
    {
        return new InteractionsListRequestSort(value);
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

    public static bool operator ==(InteractionsListRequestSort value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(InteractionsListRequestSort value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(InteractionsListRequestSort value) => value.Value;

    public static explicit operator InteractionsListRequestSort(string value) => new(value);

    internal class InteractionsListRequestSortSerializer
        : JsonConverter<InteractionsListRequestSort>
    {
        public override InteractionsListRequestSort Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new InteractionsListRequestSort(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            InteractionsListRequestSort value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override InteractionsListRequestSort ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new InteractionsListRequestSort(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            InteractionsListRequestSort value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Id = "id";

        public const string AssignedUserId = "assignedUserId";

        public const string Patient = "patient";

        public const string CreatedAt = "createdAt";

        public const string EndedAt = "endedAt";

        public const string UpdatedAt = "updatedAt";
    }
}
