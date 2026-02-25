namespace Corti;

public partial interface IFactsClient
{
    /// <summary>
    /// Returns a list of available fact groups, used to categorize facts associated with an interaction.
    /// </summary>
    WithRawResponseTask<FactsFactGroupsListResponse> FactGroupsListAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a list of facts for a given interaction.
    /// </summary>
    WithRawResponseTask<FactsListResponse> ListAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Adds new facts to an interaction.
    /// </summary>
    WithRawResponseTask<FactsCreateResponse> CreateAsync(
        string id,
        FactsCreateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates multiple facts associated with an interaction.
    /// </summary>
    WithRawResponseTask<FactsBatchUpdateResponse> BatchUpdateAsync(
        string id,
        FactsBatchUpdateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an existing fact associated with a specific interaction.
    /// </summary>
    WithRawResponseTask<FactsUpdateResponse> UpdateAsync(
        string id,
        string factId,
        FactsUpdateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Extract facts from provided text, without storing them.
    /// </summary>
    WithRawResponseTask<FactsExtractResponse> ExtractAsync(
        FactsExtractRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
