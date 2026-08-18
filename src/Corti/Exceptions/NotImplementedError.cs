namespace Corti;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class NotImplementedError(CommonErrorResponse body, Corti.RawResponse? rawResponse = null)
    : CortiClientApiException("NotImplementedError", 501, body, rawResponse: rawResponse)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new CommonErrorResponse Body => body;
}
