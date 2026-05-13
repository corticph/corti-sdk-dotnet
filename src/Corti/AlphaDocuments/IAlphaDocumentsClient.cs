namespace Corti;

public partial interface IAlphaDocumentsClient
{
    Task GenerateAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
