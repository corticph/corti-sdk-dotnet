using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(AgenticFeedbackLabelSerializer))]
public enum AgenticFeedbackLabel
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

internal class AgenticFeedbackLabelSerializer
    : global::System.Text.Json.Serialization.JsonConverter<AgenticFeedbackLabel>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AgenticFeedbackLabel
    > _stringToEnum = new()
    {
        { "correct", AgenticFeedbackLabel.Correct },
        { "complete", AgenticFeedbackLabel.Complete },
        { "helpful", AgenticFeedbackLabel.Helpful },
        { "wellPresented", AgenticFeedbackLabel.WellPresented },
        { "efficient", AgenticFeedbackLabel.Efficient },
        { "incorrect", AgenticFeedbackLabel.Incorrect },
        { "missingInformation", AgenticFeedbackLabel.MissingInformation },
        { "irrelevant", AgenticFeedbackLabel.Irrelevant },
        { "misunderstoodRequest", AgenticFeedbackLabel.MisunderstoodRequest },
        { "unsupportedClaim", AgenticFeedbackLabel.UnsupportedClaim },
        { "unsafeOrInappropriate", AgenticFeedbackLabel.UnsafeOrInappropriate },
        { "poorlyPresented", AgenticFeedbackLabel.PoorlyPresented },
        { "tooVerbose", AgenticFeedbackLabel.TooVerbose },
        { "other", AgenticFeedbackLabel.Other },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AgenticFeedbackLabel,
        string
    > _enumToString = new()
    {
        { AgenticFeedbackLabel.Correct, "correct" },
        { AgenticFeedbackLabel.Complete, "complete" },
        { AgenticFeedbackLabel.Helpful, "helpful" },
        { AgenticFeedbackLabel.WellPresented, "wellPresented" },
        { AgenticFeedbackLabel.Efficient, "efficient" },
        { AgenticFeedbackLabel.Incorrect, "incorrect" },
        { AgenticFeedbackLabel.MissingInformation, "missingInformation" },
        { AgenticFeedbackLabel.Irrelevant, "irrelevant" },
        { AgenticFeedbackLabel.MisunderstoodRequest, "misunderstoodRequest" },
        { AgenticFeedbackLabel.UnsupportedClaim, "unsupportedClaim" },
        { AgenticFeedbackLabel.UnsafeOrInappropriate, "unsafeOrInappropriate" },
        { AgenticFeedbackLabel.PoorlyPresented, "poorlyPresented" },
        { AgenticFeedbackLabel.TooVerbose, "tooVerbose" },
        { AgenticFeedbackLabel.Other, "other" },
    };

    public override AgenticFeedbackLabel Read(
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
        AgenticFeedbackLabel value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AgenticFeedbackLabel ReadAsPropertyName(
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
        AgenticFeedbackLabel value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
