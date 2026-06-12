namespace Corti;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class InternalServerError(ErrorResponse body, Corti.RawResponse? rawResponse = null)
    : CortiClientApiException("InternalServerError", 500, body, rawResponse: rawResponse)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new ErrorResponse Body => body;
}
