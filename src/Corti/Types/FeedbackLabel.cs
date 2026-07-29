using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(FeedbackLabelSerializer))]
public enum FeedbackLabel
{
    [EnumMember(Value = "correct")]
    Correct,

    [EnumMember(Value = "complete")]
    Complete,

    [EnumMember(Value = "helpful")]
    Helpful,

    [EnumMember(Value = "wellPresented")]
    WellPresented,

    [EnumMember(Value = "efficient")]
    Efficient,

    [EnumMember(Value = "incorrect")]
    Incorrect,

    [EnumMember(Value = "missingInformation")]
    MissingInformation,

    [EnumMember(Value = "irrelevant")]
    Irrelevant,

    [EnumMember(Value = "misunderstoodRequest")]
    MisunderstoodRequest,

    [EnumMember(Value = "unsupportedClaim")]
    UnsupportedClaim,

    [EnumMember(Value = "unsafeOrInappropriate")]
    UnsafeOrInappropriate,

    [EnumMember(Value = "poorlyPresented")]
    PoorlyPresented,

    [EnumMember(Value = "tooVerbose")]
    TooVerbose,

    [EnumMember(Value = "other")]
    Other,
}

internal class FeedbackLabelSerializer
    : global::System.Text.Json.Serialization.JsonConverter<FeedbackLabel>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        FeedbackLabel
    > _stringToEnum = new()
    {
        { "correct", FeedbackLabel.Correct },
        { "complete", FeedbackLabel.Complete },
        { "helpful", FeedbackLabel.Helpful },
        { "wellPresented", FeedbackLabel.WellPresented },
        { "efficient", FeedbackLabel.Efficient },
        { "incorrect", FeedbackLabel.Incorrect },
        { "missingInformation", FeedbackLabel.MissingInformation },
        { "irrelevant", FeedbackLabel.Irrelevant },
        { "misunderstoodRequest", FeedbackLabel.MisunderstoodRequest },
        { "unsupportedClaim", FeedbackLabel.UnsupportedClaim },
        { "unsafeOrInappropriate", FeedbackLabel.UnsafeOrInappropriate },
        { "poorlyPresented", FeedbackLabel.PoorlyPresented },
        { "tooVerbose", FeedbackLabel.TooVerbose },
        { "other", FeedbackLabel.Other },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        FeedbackLabel,
        string
    > _enumToString = new()
    {
        { FeedbackLabel.Correct, "correct" },
        { FeedbackLabel.Complete, "complete" },
        { FeedbackLabel.Helpful, "helpful" },
        { FeedbackLabel.WellPresented, "wellPresented" },
        { FeedbackLabel.Efficient, "efficient" },
        { FeedbackLabel.Incorrect, "incorrect" },
        { FeedbackLabel.MissingInformation, "missingInformation" },
        { FeedbackLabel.Irrelevant, "irrelevant" },
        { FeedbackLabel.MisunderstoodRequest, "misunderstoodRequest" },
        { FeedbackLabel.UnsupportedClaim, "unsupportedClaim" },
        { FeedbackLabel.UnsafeOrInappropriate, "unsafeOrInappropriate" },
        { FeedbackLabel.PoorlyPresented, "poorlyPresented" },
        { FeedbackLabel.TooVerbose, "tooVerbose" },
        { FeedbackLabel.Other, "other" },
    };

    public override FeedbackLabel Read(
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
        FeedbackLabel value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override FeedbackLabel ReadAsPropertyName(
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
        FeedbackLabel value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
