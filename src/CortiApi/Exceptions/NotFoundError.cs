namespace CortiApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class NotFoundError(object body) : CortiApiApiException("NotFoundError", 404, body);
