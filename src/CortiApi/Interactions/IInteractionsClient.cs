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
}
