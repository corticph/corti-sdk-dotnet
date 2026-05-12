namespace Corti;

public partial interface IAlphaSectionsClient
{
    Task ListAsync(RequestOptions? options = null, CancellationToken cancellationToken = default);

    Task CreateAsync(RequestOptions? options = null, CancellationToken cancellationToken = default);

    Task GetAsync(
        string sectionId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    Task DeleteAsync(
        string sectionId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    Task UpdateAsync(
        string sectionId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
