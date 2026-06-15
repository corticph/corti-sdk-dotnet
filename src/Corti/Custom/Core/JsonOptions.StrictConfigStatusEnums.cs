using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace Corti.Core;

internal static partial class JsonOptions
{
    /// <summary>
    /// Patch: WebSocket config-status enums share a <c>type</c> field with unrelated message
    /// discriminators. Fern's generated enum serializer maps unknown strings to <c>default</c>,
    /// so misrouted payloads deserialize as config status. Strict converters reject unknown
    /// wire values so <see cref="JsonUtils.TryDeserialize{T}"/> can fall through to the correct handler.
    /// </summary>
    static partial void ConfigureJsonSerializerOptions(JsonSerializerOptions defaultOptions)
    {
        defaultOptions.TypeInfoResolver = new JsonTypeInfoModifierResolver(
            defaultOptions.TypeInfoResolver!,
            ApplyStrictConfigStatusEnumConverters
        );
    }

    private static void ApplyStrictConfigStatusEnumConverters(JsonTypeInfo typeInfo)
    {
        if (typeInfo.Type == typeof(Corti.StreamConfigStatusMessage))
        {
            ApplyStrictEnumConverter<Corti.StreamConfigStatusMessageType>(typeInfo);
            return;
        }

        if (typeInfo.Type == typeof(Corti.TranscribeConfigStatusMessage))
        {
            ApplyStrictEnumConverter<Corti.TranscribeConfigStatusMessageType>(typeInfo);
        }
    }

    private static void ApplyStrictEnumConverter<TEnum>(JsonTypeInfo typeInfo)
        where TEnum : struct, Enum
    {
        if (typeInfo.Kind != JsonTypeInfoKind.Object)
        {
            return;
        }

        foreach (var property in typeInfo.Properties)
        {
            if (property.PropertyType == typeof(TEnum))
            {
                property.CustomConverter = new StrictWireEnumConverter<TEnum>();
                return;
            }
        }
    }
}
