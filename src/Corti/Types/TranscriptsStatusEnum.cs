using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(StringEnumSerializer<TranscriptsStatusEnum>))]
[Serializable]
public readonly record struct TranscriptsStatusEnum : IStringEnum
{
    public static readonly TranscriptsStatusEnum Completed = new(Values.Completed);

    public static readonly TranscriptsStatusEnum Processing = new(Values.Processing);

    public static readonly TranscriptsStatusEnum Failed = new(Values.Failed);

    public TranscriptsStatusEnum(string value)
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
    public static TranscriptsStatusEnum FromCustom(string value)
    {
        return new TranscriptsStatusEnum(value);
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

    public static bool operator ==(TranscriptsStatusEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TranscriptsStatusEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TranscriptsStatusEnum value) => value.Value;

    public static explicit operator TranscriptsStatusEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Completed = "completed";

        public const string Processing = "processing";

        public const string Failed = "failed";
    }
}
