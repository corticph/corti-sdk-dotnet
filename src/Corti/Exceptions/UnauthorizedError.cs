namespace Corti;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class UnauthorizedError(object body, Corti.RawResponse? rawResponse = null)
    : CortiClientApiException("UnauthorizedError", 401, body, rawResponse: rawResponse);
