using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(InteractionsListRequestSortSerializer))]
public enum InteractionsListRequestSort
{
    [EnumMember(Value = "id")]
    Id,

    [EnumMember(Value = "assignedUserId")]
    AssignedUserId,

    [EnumMember(Value = "patient")]
    Patient,

    [EnumMember(Value = "createdAt")]
    CreatedAt,

    [EnumMember(Value = "endedAt")]
    EndedAt,

    [EnumMember(Value = "updatedAt")]
    UpdatedAt,
}

internal class InteractionsListRequestSortSerializer
    : global::System.Text.Json.Serialization.JsonConverter<InteractionsListRequestSort>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        InteractionsListRequestSort
    > _stringToEnum = new()
    {
        { "id", InteractionsListRequestSort.Id },
        { "assignedUserId", InteractionsListRequestSort.AssignedUserId },
        { "patient", InteractionsListRequestSort.Patient },
        { "createdAt", InteractionsListRequestSort.CreatedAt },
        { "endedAt", InteractionsListRequestSort.EndedAt },
        { "updatedAt", InteractionsListRequestSort.UpdatedAt },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        InteractionsListRequestSort,
        string
    > _enumToString = new()
    {
        { InteractionsListRequestSort.Id, "id" },
        { InteractionsListRequestSort.AssignedUserId, "assignedUserId" },
        { InteractionsListRequestSort.Patient, "patient" },
        { InteractionsListRequestSort.CreatedAt, "createdAt" },
        { InteractionsListRequestSort.EndedAt, "endedAt" },
        { InteractionsListRequestSort.UpdatedAt, "updatedAt" },
    };

    public override InteractionsListRequestSort Read(
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
        InteractionsListRequestSort value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override InteractionsListRequestSort ReadAsPropertyName(
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
        InteractionsListRequestSort value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
