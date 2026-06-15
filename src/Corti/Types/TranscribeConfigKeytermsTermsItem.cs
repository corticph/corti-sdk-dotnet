using Corti.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Corti;

[Serializable]
<<<<<<<< HEAD:src/Corti/Types/TranscribeConfigKeytermsTermsItem.cs
public record TranscribeConfigKeytermsTermsItem : IJsonOnDeserialized
========
public record TranscribeConfigReplacementsItem : IJsonOnDeserialized
>>>>>>>> acdd432b83f58c335dc16e05fe7715806a821ce8:src/Corti/Types/TranscribeConfigReplacementsItem.cs
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

<<<<<<<< HEAD:src/Corti/Types/TranscribeConfigKeytermsTermsItem.cs
    /// <summary>
    /// The word to be recognized, defined in its expected written form.
    /// </summary>
    [JsonPropertyName("term")]
    public required string Term { get; set; }
========
    /// <summary>
    /// The term to be replaced, such as "BID".
    /// </summary>
    [JsonPropertyName("find")]
    public required string Find { get; set; }

    /// <summary>
    /// The preferred replacement for the term, such as "twice daily".
    /// </summary>
    [JsonPropertyName("replace")]
    public required string Replace { get; set; }
>>>>>>>> acdd432b83f58c335dc16e05fe7715806a821ce8:src/Corti/Types/TranscribeConfigReplacementsItem.cs

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
