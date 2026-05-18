namespace Corti;

public partial interface ITranscriptsClient
{
    /// <summary>
    /// Retrieves a list of transcripts for a given interaction.
    /// </summary>
    WithRawResponseTask<TranscriptsListResponse> ListAsync(
        string id,
        TranscriptsListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a transcript from an audio file uploaded to the interaction via `/recordings` endpoint.<br/>&lt;Note&gt;Each interaction may have more than one audio file and transcript associated with it. Audio files up to 60 min in total duration, or 150 MB in total size, may be used.<br/><br/>Requests will process synchronously for 25 seconds before timeout, upon which processing will continue asynchronously. In the latter scenario, a partial or empty transcript with `status=processing` will be returned with a location header that can be used to retrieve the completed transcript.<br/><br/>The client can poll the `/transcripts` endpoint (`GET /interactions/{id}/transcripts/{transcriptId}/status`) for transcript status monitoring:<br/>- `200 OK` with status `processing`, `completed`, or `failed`<br/>- `404 Not Found` if the `interactionId` or `transcriptId` are invalid<br/><br/>The completed transcript can be retrieved via the Get Transcript request (`GET /interactions/{id}/transcripts/{transcriptId}/`).&lt;/Note&gt;
    /// </summary>
    WithRawResponseTask<TranscriptsResponse> CreateAsync(
        string id,
        TranscriptsCreateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a transcript from a specific interaction.<br/>&lt;Note&gt;Each interaction may have more than one transcript associated with it. Use the List Transcript request (`GET /interactions/{id}/transcripts/`) to see all transcriptIds available for the interaction.<br/><br/>The client can poll this Get Transcript endpoint (`GET /interactions/{id}/transcripts/{transcriptId}/status`) for transcript status changes:<br/>- `200 OK` with status `processing`, `completed`, or `failed`<br/>- `404 Not Found` if the `interactionId` or `transcriptId` are invalid<br/><br/>Status of `completed` indicates the transcript is finalized. If the transcript is retrieved while status is `processing`, then it will be incomplete.&lt;/Note&gt;
    /// </summary>
    WithRawResponseTask<TranscriptsResponse> GetAsync(
        string id,
        string transcriptId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a specific transcript associated with an interaction.
    /// </summary>
    Task DeleteAsync(
        string id,
        string transcriptId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Poll for transcript creation status.<br/>&lt;Note&gt;Status of `completed` indicates the transcript is finalized.<br/>If the transcript is retrieved while status is `processing`, then it will be incomplete.<br/>Status of `failed` indicate the transcript was not created successfully; please retry.&lt;/Note&gt;
    /// </summary>
    WithRawResponseTask<TranscriptsStatusResponse> GetStatusAsync(
        string id,
        string transcriptId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
