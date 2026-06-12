namespace Corti;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class BadRequestError(object body, Corti.RawResponse? rawResponse = null)
    : CortiClientApiException("BadRequestError", 400, body, rawResponse: rawResponse);
