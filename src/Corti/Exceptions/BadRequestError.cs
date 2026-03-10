namespace Corti;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class BadRequestError(object body)
    : CortiClientBaseApiException("BadRequestError", 400, body);
