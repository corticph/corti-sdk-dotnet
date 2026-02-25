using global::System.Text.Json.Serialization;

namespace Corti.Core;

public interface IStringEnum : IEquatable<string>
{
    public string Value { get; }
}
