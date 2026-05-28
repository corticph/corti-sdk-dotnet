using System.Text.Json;
using System.Text.Json.Serialization;
using Corti.Core;

namespace Corti.Documents;

[JsonConverter(typeof(ListSectionsRequestSource.ListSectionsRequestSourceSerializer))]
[Serializable]
public readonly record struct ListSectionsRequestSource : IStringEnum
{
    public static readonly ListSectionsRequestSource User = new(Values.User);

    public static readonly ListSectionsRequestSource Corti = new(Values.Corti);

    public ListSectionsRequestSource(string value)
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
    public static ListSectionsRequestSource FromCustom(string value)
    {
        return new ListSectionsRequestSource(value);
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

    public static bool operator ==(ListSectionsRequestSource value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListSectionsRequestSource value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListSectionsRequestSource value) => value.Value;

    public static explicit operator ListSectionsRequestSource(string value) => new(value);

    internal class ListSectionsRequestSourceSerializer : JsonConverter<ListSectionsRequestSource>
    {
        public override ListSectionsRequestSource Read(
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
            return new ListSectionsRequestSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListSectionsRequestSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListSectionsRequestSource ReadAsPropertyName(
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
            return new ListSectionsRequestSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListSectionsRequestSource value,
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
        public const string User = "user";

        public const string Corti = "corti";
    }
}
