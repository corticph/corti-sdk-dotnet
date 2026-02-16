using CortiApi.Core;

namespace CortiApi;

public partial interface IInteractionsClient
{
    /// <summary>
    /// Lists all existing interactions. Results can be filtered by encounter status and patient identifier.
    /// </summary>
    Task<Pager<InteractionsGetResponse>> ListAsync(
        InteractionsListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a new interaction.
    /// </summary>
    WithRawResponseTask<InteractionsCreateResponse> CreateAsync(
        InteractionsCreateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a previously recorded interaction by its unique identifier (interaction ID).
    /// </summary>
    WithRawResponseTask<InteractionsGetResponse> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes an existing interaction.
    /// </summary>
    Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Modifies an existing interaction by updating specific fields without overwriting the entire record.
    /// </summary>
    WithRawResponseTask<InteractionsGetResponse> UpdateAsync(
        string id,
        InteractionsUpdateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
