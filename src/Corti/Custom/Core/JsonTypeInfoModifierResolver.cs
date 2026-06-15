using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace Corti.Core;

/// <summary>
/// Runs a modifier on <see cref="JsonTypeInfo"/> instances produced by an inner resolver.
/// </summary>
internal sealed class JsonTypeInfoModifierResolver : IJsonTypeInfoResolver
{
    private readonly IJsonTypeInfoResolver _inner;
    private readonly Action<JsonTypeInfo> _modifier;

    public JsonTypeInfoModifierResolver(
        IJsonTypeInfoResolver inner,
        Action<JsonTypeInfo> modifier
    )
    {
        _inner = inner;
        _modifier = modifier;
    }

    public JsonTypeInfo? GetTypeInfo(Type type, JsonSerializerOptions options)
    {
        var typeInfo = _inner.GetTypeInfo(type, options);
        if (typeInfo is not null && !typeInfo.IsReadOnly)
        {
            _modifier(typeInfo);
        }

        return typeInfo;
    }
}
