using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti;

[JsonConverter(typeof(CommonCodingSystemEnum.CommonCodingSystemEnumSerializer))]
[Serializable]
public readonly record struct CommonCodingSystemEnum : IStringEnum
{
    public static readonly CommonCodingSystemEnum Icd10CmInpatient = new(Values.Icd10CmInpatient);

    public static readonly CommonCodingSystemEnum Icd10CmOutpatient = new(Values.Icd10CmOutpatient);

    public static readonly CommonCodingSystemEnum Icd10Pcs = new(Values.Icd10Pcs);

    public static readonly CommonCodingSystemEnum Cpt = new(Values.Cpt);

    public static readonly CommonCodingSystemEnum Icd10IntInpatient = new(Values.Icd10IntInpatient);

    public static readonly CommonCodingSystemEnum Icd10IntOutpatient = new(
        Values.Icd10IntOutpatient
    );

    public static readonly CommonCodingSystemEnum Icd10UkInpatient = new(Values.Icd10UkInpatient);

    public static readonly CommonCodingSystemEnum Icd10UkOutpatient = new(Values.Icd10UkOutpatient);

    public CommonCodingSystemEnum(string value)
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
    public static CommonCodingSystemEnum FromCustom(string value)
    {
        return new CommonCodingSystemEnum(value);
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

    public static bool operator ==(CommonCodingSystemEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CommonCodingSystemEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CommonCodingSystemEnum value) => value.Value;

    public static explicit operator CommonCodingSystemEnum(string value) => new(value);

    internal class CommonCodingSystemEnumSerializer : JsonConverter<CommonCodingSystemEnum>
    {
        public override CommonCodingSystemEnum Read(
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
            return new CommonCodingSystemEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CommonCodingSystemEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CommonCodingSystemEnum ReadAsPropertyName(
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
            return new CommonCodingSystemEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CommonCodingSystemEnum value,
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
        public const string Icd10CmInpatient = "icd10cm-inpatient";

        public const string Icd10CmOutpatient = "icd10cm-outpatient";

        public const string Icd10Pcs = "icd10pcs";

        public const string Cpt = "cpt";

        public const string Icd10IntInpatient = "icd10int-inpatient";

        public const string Icd10IntOutpatient = "icd10int-outpatient";

        public const string Icd10UkInpatient = "icd10uk-inpatient";

        public const string Icd10UkOutpatient = "icd10uk-outpatient";
    }
}
