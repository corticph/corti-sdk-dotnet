namespace Corti;

public partial interface IRecordingsClient
{
    /// <summary>
    /// Retrieve a list of recordings for a given interaction. Recordings are ordered based on their creation time. Default ordering (desc) will return the most recent recording first in the list. Use query parameter `direction` to define the order of the list (`asc` for ascending and `desc` for descending).
    /// </summary>
    WithRawResponseTask<RecordingsListResponse> ListAsync(
        string id,
        RecordingsListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Upload a recording for a given interaction. There is a maximum limit of 120 minutes in audio duration and 150 MB in file size.
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
    WithRawResponseTask<global::System.IO.Stream> GetAsync(
        string id,
        string recordingId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a specific recording for a given interaction.
    /// </summary>
    WithRawResponseTask DeleteAsync(
        string id,
        string recordingId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
