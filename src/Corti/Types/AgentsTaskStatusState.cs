using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(AgentsTaskStatusState.AgentsTaskStatusStateSerializer))]
[Serializable]
public readonly record struct AgentsTaskStatusState : IStringEnum
{
    public static readonly AgentsTaskStatusState Submitted = new(Values.Submitted);

    public static readonly AgentsTaskStatusState Working = new(Values.Working);

    public static readonly AgentsTaskStatusState InputRequired = new(Values.InputRequired);

    public static readonly AgentsTaskStatusState Completed = new(Values.Completed);

    public static readonly AgentsTaskStatusState Canceled = new(Values.Canceled);

    public static readonly AgentsTaskStatusState Failed = new(Values.Failed);

    public static readonly AgentsTaskStatusState Rejected = new(Values.Rejected);

    public static readonly AgentsTaskStatusState AuthRequired = new(Values.AuthRequired);

    public static readonly AgentsTaskStatusState Unknown = new(Values.Unknown);

    public AgentsTaskStatusState(string value)
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
    public static AgentsTaskStatusState FromCustom(string value)
    {
        return new AgentsTaskStatusState(value);
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

    public static bool operator ==(AgentsTaskStatusState value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentsTaskStatusState value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentsTaskStatusState value) => value.Value;

    public static explicit operator AgentsTaskStatusState(string value) => new(value);

    internal class AgentsTaskStatusStateSerializer : JsonConverter<AgentsTaskStatusState>
    {
        public override AgentsTaskStatusState Read(
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
            return new AgentsTaskStatusState(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentsTaskStatusState value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Submitted = "submitted";

        public const string Working = "working";

        public const string InputRequired = "input-required";

        public const string Completed = "completed";

        public const string Canceled = "canceled";

        public const string Failed = "failed";

        public const string Rejected = "rejected";

        public const string AuthRequired = "auth-required";

        public const string Unknown = "unknown";
    }
}
