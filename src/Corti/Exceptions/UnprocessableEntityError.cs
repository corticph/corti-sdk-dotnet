namespace Corti;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class UnprocessableEntityError(object body)
    : CortiClientApiException("UnprocessableEntityError", 422, body);
