namespace CortiApi;

public partial interface IRecordingsClient
{
    /// <summary>
    /// Retrieve a list of recordings for a given interaction.
    /// </summary>
    WithRawResponseTask<RecordingsListResponse> ListAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Upload a recording for a given interaction. There is a maximum limit of 60 minutes in length and 150MB in size for recordings.
    /// </summary>
    WithRawResponseTask<RecordingsCreateResponse> UploadAsync(
        string id,
        Stream request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a specific recording for a given interaction.
    /// </summary>
    WithRawResponseTask<System.IO.Stream> GetAsync(
        string id,
        string recordingId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a specific recording for a given interaction.
    /// </summary>
    Task DeleteAsync(
        string id,
        string recordingId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
