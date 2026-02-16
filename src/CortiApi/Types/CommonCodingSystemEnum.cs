using System.Text.Json.Serialization;
using CortiApi.Core;

namespace CortiApi;

[JsonConverter(typeof(StringEnumSerializer<CommonCodingSystemEnum>))]
[Serializable]
public readonly record struct CommonCodingSystemEnum : IStringEnum
{
    public static readonly CommonCodingSystemEnum Icd10Cm = new(Values.Icd10Cm);

    public static readonly CommonCodingSystemEnum Icd10Pcs = new(Values.Icd10Pcs);

    public static readonly CommonCodingSystemEnum Cpt = new(Values.Cpt);

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

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Icd10Cm = "icd10cm";

        public const string Icd10Pcs = "icd10pcs";

        public const string Cpt = "cpt";
    }
}
