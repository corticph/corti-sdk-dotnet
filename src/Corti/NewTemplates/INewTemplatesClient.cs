namespace Corti;

public partial interface INewTemplatesClient
{
    Task ListAsync(RequestOptions? options = null, CancellationToken cancellationToken = default);

    Task CreateAsync(RequestOptions? options = null, CancellationToken cancellationToken = default);

    Task GetAsync(
        string templateId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    Task DeleteAsync(
        string templateId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    Task UpdateAsync(
        string templateId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
