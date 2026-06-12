using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Corti.Core;

/// <summary>
/// Deserializes enums using <see cref="EnumMemberAttribute"/> wire names and rejects unknown values.
/// </summary>
internal sealed class StrictWireEnumConverter<TEnum> : JsonConverter<TEnum>
    where TEnum : struct, Enum
{
    private static readonly Dictionary<string, TEnum> WireToEnum;
    private static readonly Dictionary<TEnum, string> EnumToWire;

    static StrictWireEnumConverter()
    {
        WireToEnum = new Dictionary<string, TEnum>(StringComparer.Ordinal);
        EnumToWire = new Dictionary<TEnum, string>();
        foreach (var field in typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static))
        {
            var wireName = field.GetCustomAttribute<EnumMemberAttribute>()?.Value ?? field.Name;
            var enumValue = (TEnum)field.GetValue(null)!;
            WireToEnum[wireName] = enumValue;
            EnumToWire[enumValue] = wireName;
        }
    }

    public override TEnum Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return ReadWireValue(
            reader.GetString()
                ?? throw new JsonException($"The JSON value could not be read as a string.")
        );
    }

    public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(
            EnumToWire.TryGetValue(value, out var wireName) ? wireName : null
        );
    }

    public override TEnum ReadAsPropertyName(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return ReadWireValue(
            reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.")
        );
    }

    public override void WriteAsPropertyName(
        Utf8JsonWriter writer,
        TEnum value,
        JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            EnumToWire.TryGetValue(value, out var wireName) ? wireName : value.ToString()
        );
    }

    private static TEnum ReadWireValue(string wireValue)
    {
        if (WireToEnum.TryGetValue(wireValue, out var enumValue))
        {
            return enumValue;
        }

        throw new JsonException(
            $"Unknown {typeof(TEnum).Name} value \"{wireValue}\"."
        );
    }
}
