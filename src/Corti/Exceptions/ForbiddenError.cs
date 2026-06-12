namespace Corti;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class ForbiddenError(object body, Corti.RawResponse? rawResponse = null)
    : CortiClientApiException("ForbiddenError", 403, body, rawResponse: rawResponse);
