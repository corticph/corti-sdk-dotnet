using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(CommonCodingSystemEnumSerializer))]
public enum CommonCodingSystemEnum
{
    [EnumMember(Value = "icd10cm-inpatient")]
    Icd10CmInpatient,

    [EnumMember(Value = "icd10cm-outpatient")]
    Icd10CmOutpatient,

    [EnumMember(Value = "icd10pcs")]
    Icd10Pcs,

    [EnumMember(Value = "cpt")]
    Cpt,

    [EnumMember(Value = "icd10int-inpatient")]
    Icd10IntInpatient,

    [EnumMember(Value = "icd10int-outpatient")]
    Icd10IntOutpatient,

    [EnumMember(Value = "icd10uk-inpatient")]
    Icd10UkInpatient,

    [EnumMember(Value = "icd10uk-outpatient")]
    Icd10UkOutpatient,

    [EnumMember(Value = "cim10fr-inpatient")]
    Cim10FrInpatient,

    [EnumMember(Value = "cim10fr-outpatient")]
    Cim10FrOutpatient,

    [EnumMember(Value = "icd10gm-inpatient")]
    Icd10GmInpatient,

    [EnumMember(Value = "icd10gm-outpatient")]
    Icd10GmOutpatient,

    [EnumMember(Value = "opcs4")]
    Opcs4,

    [EnumMember(Value = "ops")]
    Ops,

    [EnumMember(Value = "ccam")]
    Ccam,
}

internal class CommonCodingSystemEnumSerializer
    : global::System.Text.Json.Serialization.JsonConverter<CommonCodingSystemEnum>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        CommonCodingSystemEnum
    > _stringToEnum = new()
    {
        { "icd10cm-inpatient", CommonCodingSystemEnum.Icd10CmInpatient },
        { "icd10cm-outpatient", CommonCodingSystemEnum.Icd10CmOutpatient },
        { "icd10pcs", CommonCodingSystemEnum.Icd10Pcs },
        { "cpt", CommonCodingSystemEnum.Cpt },
        { "icd10int-inpatient", CommonCodingSystemEnum.Icd10IntInpatient },
        { "icd10int-outpatient", CommonCodingSystemEnum.Icd10IntOutpatient },
        { "icd10uk-inpatient", CommonCodingSystemEnum.Icd10UkInpatient },
        { "icd10uk-outpatient", CommonCodingSystemEnum.Icd10UkOutpatient },
        { "cim10fr-inpatient", CommonCodingSystemEnum.Cim10FrInpatient },
        { "cim10fr-outpatient", CommonCodingSystemEnum.Cim10FrOutpatient },
        { "icd10gm-inpatient", CommonCodingSystemEnum.Icd10GmInpatient },
        { "icd10gm-outpatient", CommonCodingSystemEnum.Icd10GmOutpatient },
        { "opcs4", CommonCodingSystemEnum.Opcs4 },
        { "ops", CommonCodingSystemEnum.Ops },
        { "ccam", CommonCodingSystemEnum.Ccam },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        CommonCodingSystemEnum,
        string
    > _enumToString = new()
    {
        { CommonCodingSystemEnum.Icd10CmInpatient, "icd10cm-inpatient" },
        { CommonCodingSystemEnum.Icd10CmOutpatient, "icd10cm-outpatient" },
        { CommonCodingSystemEnum.Icd10Pcs, "icd10pcs" },
        { CommonCodingSystemEnum.Cpt, "cpt" },
        { CommonCodingSystemEnum.Icd10IntInpatient, "icd10int-inpatient" },
        { CommonCodingSystemEnum.Icd10IntOutpatient, "icd10int-outpatient" },
        { CommonCodingSystemEnum.Icd10UkInpatient, "icd10uk-inpatient" },
        { CommonCodingSystemEnum.Icd10UkOutpatient, "icd10uk-outpatient" },
        { CommonCodingSystemEnum.Cim10FrInpatient, "cim10fr-inpatient" },
        { CommonCodingSystemEnum.Cim10FrOutpatient, "cim10fr-outpatient" },
        { CommonCodingSystemEnum.Icd10GmInpatient, "icd10gm-inpatient" },
        { CommonCodingSystemEnum.Icd10GmOutpatient, "icd10gm-outpatient" },
        { CommonCodingSystemEnum.Opcs4, "opcs4" },
        { CommonCodingSystemEnum.Ops, "ops" },
        { CommonCodingSystemEnum.Ccam, "ccam" },
    };

    public override CommonCodingSystemEnum Read(
        ref global::System.Text.Json.Utf8JsonReader reader,
        global::System.Type typeToConvert,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        var stringValue =
            reader.GetString()
            ?? throw new global::System.Exception("The JSON value could not be read as a string.");
        return _stringToEnum.TryGetValue(stringValue, out var enumValue) ? enumValue : default;
    }

    public override void Write(
        global::System.Text.Json.Utf8JsonWriter writer,
        CommonCodingSystemEnum value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override CommonCodingSystemEnum ReadAsPropertyName(
        ref global::System.Text.Json.Utf8JsonReader reader,
        global::System.Type typeToConvert,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        var stringValue =
            reader.GetString()
            ?? throw new global::System.Exception(
                "The JSON property name could not be read as a string."
            );
        return _stringToEnum.TryGetValue(stringValue, out var enumValue) ? enumValue : default;
    }

    public override void WriteAsPropertyName(
        global::System.Text.Json.Utf8JsonWriter writer,
        CommonCodingSystemEnum value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
