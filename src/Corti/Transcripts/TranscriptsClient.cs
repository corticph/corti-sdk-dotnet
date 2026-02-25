using System.Text.Json;
using Corti.Core;

namespace Corti;

public partial class TranscriptsClient
{
    private RawClient _client;

    internal TranscriptsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Retrieves a list of transcripts for a given interaction.
    /// </summary>
    /// <example><code>
    /// await client.Transcripts.ListAsync(
    ///     "f47ac10b-58cc-4372-a567-0e02b2c3d479",
    ///     new TranscriptsListRequest()
    /// );
    /// </code></example>
    public async Task<TranscriptsListResponse> ListAsync(
        string id,
        TranscriptsListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Full != null)
        {
            _query["full"] = JsonUtils.Serialize(request.Full.Value);
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.Environment.Base,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "interactions/{0}/transcripts/",
                        ValueConvert.ToPathParameterString(id)
                    ),
                    Query = _query,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<TranscriptsListResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new CortiClientException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 500:
                        throw new InternalServerError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new CortiClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Create a transcript from an audio file attached, via `/recordings` endpoint, to the interaction.&lt;br/&gt;&lt;Note&gt;Each interaction may have more than one audio file and transcript associated with it. While audio files up to 60min in total duration, or 150MB in total size, may be attached to an interaction, synchronous processing is only supported for audio files less than ~2min in duration.&lt;br/&gt;&lt;br/&gt;If an audio file takes longer to transcribe than the 25sec synchronous processing timeout, then it will continue to process asynchronously. In this scenario, an incomplete or empty transcript with `status=processing` will be returned with a location header that can be used to retrieve the final transcript.&lt;br/&gt;&lt;br/&gt;The client can poll the Get Transcript endpoint (`GET /interactions/{id}/transcripts/{transcriptId}/status`) for transcript status changes:&lt;br/&gt;- `200 OK` with status `processing`, `completed`, or `failed`&lt;br/&gt;- `404 Not Found` if the `interactionId` or `transcriptId` are invalid&lt;br/&gt;&lt;br/&gt;The completed transcript can be retrieved via the Get Transcript endpoint (`GET /interactions/{id}/transcripts/{transcriptId}/`).&lt;/Note&gt;
    /// </summary>
    /// <example><code>
    /// await client.Transcripts.CreateAsync(
    ///     "f47ac10b-58cc-4372-a567-0e02b2c3d479",
    ///     new TranscriptsCreateRequest
    ///     {
    ///         RecordingId = "f47ac10b-58cc-4372-a567-0e02b2c3d479",
    ///         PrimaryLanguage = "en",
    ///     }
    /// );
    /// </code></example>
    public async Task<TranscriptsResponse> CreateAsync(
        string id,
        TranscriptsCreateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.Environment.Base,
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "interactions/{0}/transcripts/",
                        ValueConvert.ToPathParameterString(id)
                    ),
                    Body = request,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<TranscriptsResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new CortiClientException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 500:
                        throw new InternalServerError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new CortiClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Retrieve a transcript from a specific interaction.&lt;br/&gt;&lt;Note&gt;Each interaction may have more than one transcript associated with it. Use the List Transcript request (`GET /interactions/{id}/transcripts/`) to see all transcriptIds available for the interaction.&lt;br/&gt;&lt;br/&gt;The client can poll this Get Transcript endpoint (`GET /interactions/{id}/transcripts/{transcriptId}/status`) for transcript status changes:&lt;br/&gt;- `200 OK` with status `processing`, `completed`, or `failed`&lt;br/&gt;- `404 Not Found` if the `interactionId` or `transcriptId` are invalid&lt;br/&gt;&lt;br/&gt;Status of `completed` indicates the transcript is finalized. If the transcript is retrieved while status is `processing`, then it will be incomplete.&lt;/Note&gt;
    /// </summary>
    /// <example><code>
    /// await client.Transcripts.GetAsync(
    ///     "f47ac10b-58cc-4372-a567-0e02b2c3d479",
    ///     "f47ac10b-58cc-4372-a567-0e02b2c3d479"
    /// );
    /// </code></example>
    public async Task<TranscriptsResponse> GetAsync(
        string id,
        string transcriptId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.Environment.Base,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "interactions/{0}/transcripts/{1}",
                        ValueConvert.ToPathParameterString(id),
                        ValueConvert.ToPathParameterString(transcriptId)
                    ),
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<TranscriptsResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new CortiClientException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 500:
                        throw new InternalServerError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new CortiClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Deletes a specific transcript associated with an interaction.
    /// </summary>
    /// <example><code>
    /// await client.Transcripts.DeleteAsync(
    ///     "f47ac10b-58cc-4372-a567-0e02b2c3d479",
    ///     "f47ac10b-58cc-4372-a567-0e02b2c3d479"
    /// );
    /// </code></example>
    public async Task DeleteAsync(
        string id,
        string transcriptId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.Environment.Base,
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "interactions/{0}/transcripts/{1}",
                        ValueConvert.ToPathParameterString(id),
                        ValueConvert.ToPathParameterString(transcriptId)
                    ),
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            return;
        }
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 500:
                        throw new InternalServerError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new CortiClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Poll for transcript creation status.&lt;br/&gt;&lt;Note&gt;Status of `completed` indicates the transcript is finalized.&lt;br/&gt;If the transcript is retrieved while status is `processing`, then it will be incomplete.&lt;br/&gt;Status of `failed` indicate the transcript was not created successfully; please retry.&lt;/Note&gt;
    /// </summary>
    /// <example><code>
    /// await client.Transcripts.GetStatusAsync(
    ///     "f47ac10b-58cc-4372-a567-0e02b2c3d479",
    ///     "f47ac10b-58cc-4372-a567-0e02b2c3d479"
    /// );
    /// </code></example>
    public async Task<TranscriptsStatusResponse> GetStatusAsync(
        string id,
        string transcriptId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.Environment.Base,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "interactions/{0}/transcripts/{1}/status",
                        ValueConvert.ToPathParameterString(id),
                        ValueConvert.ToPathParameterString(transcriptId)
                    ),
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<TranscriptsStatusResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new CortiClientException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new CortiClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }
}
