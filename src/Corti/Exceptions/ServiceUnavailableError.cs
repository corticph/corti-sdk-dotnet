namespace Corti;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class ServiceUnavailableError(
    CommonErrorResponse body,
    Corti.RawResponse? rawResponse = null
) : CortiClientApiException("ServiceUnavailableError", 503, body, rawResponse: rawResponse)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new CommonErrorResponse Body => body;
}
