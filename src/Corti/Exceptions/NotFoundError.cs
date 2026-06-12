namespace Corti;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class NotFoundError(object body, Corti.RawResponse? rawResponse = null)
    : CortiClientApiException("NotFoundError", 404, body, rawResponse: rawResponse);
