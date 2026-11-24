// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

[JsonConverter(typeof(GuidedSectionImpactTemplateItem.JsonConverter))]
[Serializable]
public class GuidedSectionImpactTemplateItem
{
    private GuidedSectionImpactTemplateItem(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Type discriminator
    /// </summary>
    [JsonIgnore]
    public string Type { get; internal set; }

    /// <summary>
    /// Union value
    /// </summary>
    [JsonIgnore]
    public object? Value { get; internal set; }

    /// <summary>
    /// Factory method to create a union from a Corti.GuidedSectionImpactTemplateDirect value.
    /// </summary>
    public static GuidedSectionImpactTemplateItem FromGuidedSectionImpactTemplateDirect(
        Corti.GuidedSectionImpactTemplateDirect value
    ) => new("guidedSectionImpactTemplateDirect", value);

    /// <summary>
    /// Factory method to create a union from a Corti.GuidedSectionImpactTemplateInheritedSection value.
    /// </summary>
    public static GuidedSectionImpactTemplateItem FromGuidedSectionImpactTemplateInheritedSection(
        Corti.GuidedSectionImpactTemplateInheritedSection value
    ) => new("guidedSectionImpactTemplateInheritedSection", value);

    /// <summary>
    /// Factory method to create a union from a Corti.GuidedSectionImpactTemplateInheritedTemplate value.
    /// </summary>
    public static GuidedSectionImpactTemplateItem FromGuidedSectionImpactTemplateInheritedTemplate(
        Corti.GuidedSectionImpactTemplateInheritedTemplate value
    ) => new("guidedSectionImpactTemplateInheritedTemplate", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "guidedSectionImpactTemplateDirect"
    /// </summary>
    public bool IsGuidedSectionImpactTemplateDirect() =>
        Type == "guidedSectionImpactTemplateDirect";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "guidedSectionImpactTemplateInheritedSection"
    /// </summary>
    public bool IsGuidedSectionImpactTemplateInheritedSection() =>
        Type == "guidedSectionImpactTemplateInheritedSection";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "guidedSectionImpactTemplateInheritedTemplate"
    /// </summary>
    public bool IsGuidedSectionImpactTemplateInheritedTemplate() =>
        Type == "guidedSectionImpactTemplateInheritedTemplate";

    /// <summary>
    /// Returns the value as a <see cref="Corti.GuidedSectionImpactTemplateDirect"/> if <see cref="Type"/> is 'guidedSectionImpactTemplateDirect', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'guidedSectionImpactTemplateDirect'.</exception>
    public Corti.GuidedSectionImpactTemplateDirect AsGuidedSectionImpactTemplateDirect() =>
        IsGuidedSectionImpactTemplateDirect()
            ? (Corti.GuidedSectionImpactTemplateDirect)Value!
            : throw new CortiClientException(
                "Union type is not 'guidedSectionImpactTemplateDirect'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Corti.GuidedSectionImpactTemplateInheritedSection"/> if <see cref="Type"/> is 'guidedSectionImpactTemplateInheritedSection', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'guidedSectionImpactTemplateInheritedSection'.</exception>
    public Corti.GuidedSectionImpactTemplateInheritedSection AsGuidedSectionImpactTemplateInheritedSection() =>
        IsGuidedSectionImpactTemplateInheritedSection()
            ? (Corti.GuidedSectionImpactTemplateInheritedSection)Value!
            : throw new CortiClientException(
                "Union type is not 'guidedSectionImpactTemplateInheritedSection'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Corti.GuidedSectionImpactTemplateInheritedTemplate"/> if <see cref="Type"/> is 'guidedSectionImpactTemplateInheritedTemplate', otherwise throws an exception.
    /// </summary>
    /// <exception cref="CortiClientException">Thrown when <see cref="Type"/> is not 'guidedSectionImpactTemplateInheritedTemplate'.</exception>
    public Corti.GuidedSectionImpactTemplateInheritedTemplate AsGuidedSectionImpactTemplateInheritedTemplate() =>
        IsGuidedSectionImpactTemplateInheritedTemplate()
            ? (Corti.GuidedSectionImpactTemplateInheritedTemplate)Value!
            : throw new CortiClientException(
                "Union type is not 'guidedSectionImpactTemplateInheritedTemplate'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.GuidedSectionImpactTemplateDirect"/> and returns true if successful.
    /// </summary>
    public bool TryGetGuidedSectionImpactTemplateDirect(
        out Corti.GuidedSectionImpactTemplateDirect? value
    )
    {
        if (Type == "guidedSectionImpactTemplateDirect")
        {
            value = (Corti.GuidedSectionImpactTemplateDirect)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.GuidedSectionImpactTemplateInheritedSection"/> and returns true if successful.
    /// </summary>
    public bool TryGetGuidedSectionImpactTemplateInheritedSection(
        out Corti.GuidedSectionImpactTemplateInheritedSection? value
    )
    {
        if (Type == "guidedSectionImpactTemplateInheritedSection")
        {
            value = (Corti.GuidedSectionImpactTemplateInheritedSection)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Corti.GuidedSectionImpactTemplateInheritedTemplate"/> and returns true if successful.
    /// </summary>
    public bool TryGetGuidedSectionImpactTemplateInheritedTemplate(
        out Corti.GuidedSectionImpactTemplateInheritedTemplate? value
    )
    {
        if (Type == "guidedSectionImpactTemplateInheritedTemplate")
        {
            value = (Corti.GuidedSectionImpactTemplateInheritedTemplate)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Corti.GuidedSectionImpactTemplateDirect, T> onGuidedSectionImpactTemplateDirect,
        Func<
            Corti.GuidedSectionImpactTemplateInheritedSection,
            T
        > onGuidedSectionImpactTemplateInheritedSection,
        Func<
            Corti.GuidedSectionImpactTemplateInheritedTemplate,
            T
        > onGuidedSectionImpactTemplateInheritedTemplate
    )
    {
        return Type switch
        {
            "guidedSectionImpactTemplateDirect" => onGuidedSectionImpactTemplateDirect(
                AsGuidedSectionImpactTemplateDirect()
            ),
            "guidedSectionImpactTemplateInheritedSection" =>
                onGuidedSectionImpactTemplateInheritedSection(
                    AsGuidedSectionImpactTemplateInheritedSection()
                ),
            "guidedSectionImpactTemplateInheritedTemplate" =>
                onGuidedSectionImpactTemplateInheritedTemplate(
                    AsGuidedSectionImpactTemplateInheritedTemplate()
                ),
            _ => throw new CortiClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        Action<Corti.GuidedSectionImpactTemplateDirect> onGuidedSectionImpactTemplateDirect,
        Action<Corti.GuidedSectionImpactTemplateInheritedSection> onGuidedSectionImpactTemplateInheritedSection,
        Action<Corti.GuidedSectionImpactTemplateInheritedTemplate> onGuidedSectionImpactTemplateInheritedTemplate
    )
    {
        switch (Type)
        {
            case "guidedSectionImpactTemplateDirect":
                onGuidedSectionImpactTemplateDirect(AsGuidedSectionImpactTemplateDirect());
                break;
            case "guidedSectionImpactTemplateInheritedSection":
                onGuidedSectionImpactTemplateInheritedSection(
                    AsGuidedSectionImpactTemplateInheritedSection()
                );
                break;
            case "guidedSectionImpactTemplateInheritedTemplate":
                onGuidedSectionImpactTemplateInheritedTemplate(
                    AsGuidedSectionImpactTemplateInheritedTemplate()
                );
                break;
            default:
                throw new CortiClientException($"Unknown union type: {Type}");
        }
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = Type.GetHashCode();
            if (Value != null)
            {
                hashCode = (hashCode * 397) ^ Value.GetHashCode();
            }
            return hashCode;
        }
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (obj is not GuidedSectionImpactTemplateItem other)
            return false;

        // Compare type discriminators
        if (Type != other.Type)
            return false;

        // Compare values using EqualityComparer for deep comparison
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator GuidedSectionImpactTemplateItem(
        Corti.GuidedSectionImpactTemplateDirect value
    ) => new("guidedSectionImpactTemplateDirect", value);

    public static implicit operator GuidedSectionImpactTemplateItem(
        Corti.GuidedSectionImpactTemplateInheritedSection value
    ) => new("guidedSectionImpactTemplateInheritedSection", value);

    public static implicit operator GuidedSectionImpactTemplateItem(
        Corti.GuidedSectionImpactTemplateInheritedTemplate value
    ) => new("guidedSectionImpactTemplateInheritedTemplate", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<GuidedSectionImpactTemplateItem>
    {
        public override GuidedSectionImpactTemplateItem? Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                var document = JsonDocument.ParseValue(ref reader);

                var types = new (string Key, System.Type Type)[]
                {
                    (
                        "guidedSectionImpactTemplateDirect",
                        typeof(Corti.GuidedSectionImpactTemplateDirect)
                    ),
                    (
                        "guidedSectionImpactTemplateInheritedSection",
                        typeof(Corti.GuidedSectionImpactTemplateInheritedSection)
                    ),
                    (
                        "guidedSectionImpactTemplateInheritedTemplate",
                        typeof(Corti.GuidedSectionImpactTemplateInheritedTemplate)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            GuidedSectionImpactTemplateItem result = new(key, value);
                            return result;
                        }
                    }
                    catch (JsonException)
                    {
                        // Try next type;
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into GuidedSectionImpactTemplateItem"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            GuidedSectionImpactTemplateItem value,
            JsonSerializerOptions options
        )
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            value.Visit(
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override GuidedSectionImpactTemplateItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            GuidedSectionImpactTemplateItem result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GuidedSectionImpactTemplateItem value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
