namespace Corti;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class ConflictError(object body, Corti.RawResponse? rawResponse = null)
    : CortiClientApiException("ConflictError", 409, body, rawResponse: rawResponse);
