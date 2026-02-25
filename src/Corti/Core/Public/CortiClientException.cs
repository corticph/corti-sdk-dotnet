namespace Corti;

/// <summary>
/// Base exception class for all exceptions thrown by the SDK.
/// </summary>
public class CortiClientException(string message, Exception? innerException = null)
    : Exception(message, innerException);
