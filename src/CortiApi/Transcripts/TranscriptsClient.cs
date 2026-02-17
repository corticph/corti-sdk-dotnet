using System.Text.Json;
using CortiApi.Core;

namespace CortiApi;

public partial class TranscriptsClient : ITranscriptsClient
{
    private RawClient _client;

    internal TranscriptsClient(RawClient client)
    {
        try
        {
            _client = client;
        }
        catch (Exception ex)
        {
            client.Options.ExceptionHandler?.CaptureException(ex);
            throw;
        }
    }

    private async Task<WithRawResponse<TranscriptsListResponse>> ListAsyncCore(
        string id,
        TranscriptsListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return await _client
            .Options.ExceptionHandler.TryCatchAsync(async () =>
            {
                var _queryString = new CortiApi.Core.QueryStringBuilder.Builder(capacity: 1)
                    .Add("full", request.Full)
                    .MergeAdditional(options?.AdditionalQueryParameters)
                    .Build();
                var _headers = await new CortiApi.Core.HeadersBuilder.Builder()
                    .Add(_client.Options.Headers)
                    .Add(_client.Options.AdditionalHeaders)
                    .Add(options?.AdditionalHeaders)
                    .BuildAsync()
                    .ConfigureAwait(false);
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
                            QueryString = _queryString,
                            Headers = _headers,
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
                        var responseData = JsonUtils.Deserialize<TranscriptsListResponse>(
                            responseBody
                        )!;
                        return new WithRawResponse<TranscriptsListResponse>()
                        {
                            Data = responseData,
                            RawResponse = new RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            },
                        };
                    }
                    catch (JsonException e)
                    {
                        throw new CortiClientApiException(
                            "Failed to deserialize response",
                            response.StatusCode,
                            responseBody,
                            e
                        );
                    }
                }
                {
                    var responseBody = await response.Raw.Content.ReadAsStringAsync();
                    try
                    {
                        switch (response.StatusCode)
                        {
                            case 400:
                                throw new BadRequestError(
                                    JsonUtils.Deserialize<object>(responseBody)
                                );
                            case 401:
                                throw new UnauthorizedError(
                                    JsonUtils.Deserialize<object>(responseBody)
                                );
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
            })
            .ConfigureAwait(false);
    }

    private async Task<WithRawResponse<TranscriptsResponse>> CreateAsyncCore(
        string id,
        TranscriptsCreateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return await _client
            .Options.ExceptionHandler.TryCatchAsync(async () =>
            {
                var _headers = await new CortiApi.Core.HeadersBuilder.Builder()
                    .Add(_client.Options.Headers)
                    .Add(_client.Options.AdditionalHeaders)
                    .Add(options?.AdditionalHeaders)
                    .BuildAsync()
                    .ConfigureAwait(false);
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
                            Headers = _headers,
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
                        var responseData = JsonUtils.Deserialize<TranscriptsResponse>(
                            responseBody
                        )!;
                        return new WithRawResponse<TranscriptsResponse>()
                        {
                            Data = responseData,
                            RawResponse = new RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            },
                        };
                    }
                    catch (JsonException e)
                    {
                        throw new CortiClientApiException(
                            "Failed to deserialize response",
                            response.StatusCode,
                            responseBody,
                            e
                        );
                    }
                }
                {
                    var responseBody = await response.Raw.Content.ReadAsStringAsync();
                    try
                    {
                        switch (response.StatusCode)
                        {
                            case 400:
                                throw new BadRequestError(
                                    JsonUtils.Deserialize<object>(responseBody)
                                );
                            case 401:
                                throw new UnauthorizedError(
                                    JsonUtils.Deserialize<object>(responseBody)
                                );
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
            })
            .ConfigureAwait(false);
    }

    private async Task<WithRawResponse<TranscriptsResponse>> GetAsyncCore(
        string id,
        string transcriptId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return await _client
            .Options.ExceptionHandler.TryCatchAsync(async () =>
            {
                var _headers = await new CortiApi.Core.HeadersBuilder.Builder()
                    .Add(_client.Options.Headers)
                    .Add(_client.Options.AdditionalHeaders)
                    .Add(options?.AdditionalHeaders)
                    .BuildAsync()
                    .ConfigureAwait(false);
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
                            Headers = _headers,
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
                        var responseData = JsonUtils.Deserialize<TranscriptsResponse>(
                            responseBody
                        )!;
                        return new WithRawResponse<TranscriptsResponse>()
                        {
                            Data = responseData,
                            RawResponse = new RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            },
                        };
                    }
                    catch (JsonException e)
                    {
                        throw new CortiClientApiException(
                            "Failed to deserialize response",
                            response.StatusCode,
                            responseBody,
                            e
                        );
                    }
                }
                {
                    var responseBody = await response.Raw.Content.ReadAsStringAsync();
                    try
                    {
                        switch (response.StatusCode)
                        {
                            case 400:
                                throw new BadRequestError(
                                    JsonUtils.Deserialize<object>(responseBody)
                                );
                            case 401:
                                throw new UnauthorizedError(
                                    JsonUtils.Deserialize<object>(responseBody)
                                );
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
            })
            .ConfigureAwait(false);
    }

    private async Task<WithRawResponse<TranscriptsStatusResponse>> GetStatusAsyncCore(
        string id,
        string transcriptId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return await _client
            .Options.ExceptionHandler.TryCatchAsync(async () =>
            {
                var _headers = await new CortiApi.Core.HeadersBuilder.Builder()
                    .Add(_client.Options.Headers)
                    .Add(_client.Options.AdditionalHeaders)
                    .Add(options?.AdditionalHeaders)
                    .BuildAsync()
                    .ConfigureAwait(false);
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
                            Headers = _headers,
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
                        var responseData = JsonUtils.Deserialize<TranscriptsStatusResponse>(
                            responseBody
                        )!;
                        return new WithRawResponse<TranscriptsStatusResponse>()
                        {
                            Data = responseData,
                            RawResponse = new RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            },
                        };
                    }
                    catch (JsonException e)
                    {
                        throw new CortiClientApiException(
                            "Failed to deserialize response",
                            response.StatusCode,
                            responseBody,
                            e
                        );
                    }
                }
                {
                    var responseBody = await response.Raw.Content.ReadAsStringAsync();
                    try
                    {
                        switch (response.StatusCode)
                        {
                            case 404:
                                throw new NotFoundError(
                                    JsonUtils.Deserialize<object>(responseBody)
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
            })
            .ConfigureAwait(false);
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
    public WithRawResponseTask<TranscriptsListResponse> ListAsync(
        string id,
        TranscriptsListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<TranscriptsListResponse>(
            ListAsyncCore(id, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Create a transcript from an audio file attached, via `/recordings` endpoint, to the interaction.<br/>&lt;Note&gt;Each interaction may have more than one audio file and transcript associated with it. While audio files up to 60min in total duration, or 150MB in total size, may be attached to an interaction, synchronous processing is only supported for audio files less than ~2min in duration.<br/><br/>If an audio file takes longer to transcribe than the 25sec synchronous processing timeout, then it will continue to process asynchronously. In this scenario, an incomplete or empty transcript with `status=processing` will be returned with a location header that can be used to retrieve the final transcript.<br/><br/>The client can poll the Get Transcript endpoint (`GET /interactions/{id}/transcripts/{transcriptId}/status`) for transcript status changes:<br/>- `200 OK` with status `processing`, `completed`, or `failed`<br/>- `404 Not Found` if the `interactionId` or `transcriptId` are invalid<br/><br/>The completed transcript can be retrieved via the Get Transcript endpoint (`GET /interactions/{id}/transcripts/{transcriptId}/`).&lt;/Note&gt;
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
    public WithRawResponseTask<TranscriptsResponse> CreateAsync(
        string id,
        TranscriptsCreateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<TranscriptsResponse>(
            CreateAsyncCore(id, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve a transcript from a specific interaction.<br/>&lt;Note&gt;Each interaction may have more than one transcript associated with it. Use the List Transcript request (`GET /interactions/{id}/transcripts/`) to see all transcriptIds available for the interaction.<br/><br/>The client can poll this Get Transcript endpoint (`GET /interactions/{id}/transcripts/{transcriptId}/status`) for transcript status changes:<br/>- `200 OK` with status `processing`, `completed`, or `failed`<br/>- `404 Not Found` if the `interactionId` or `transcriptId` are invalid<br/><br/>Status of `completed` indicates the transcript is finalized. If the transcript is retrieved while status is `processing`, then it will be incomplete.&lt;/Note&gt;
    /// </summary>
    /// <example><code>
    /// await client.Transcripts.GetAsync(
    ///     "f47ac10b-58cc-4372-a567-0e02b2c3d479",
    ///     "f47ac10b-58cc-4372-a567-0e02b2c3d479"
    /// );
    /// </code></example>
    public WithRawResponseTask<TranscriptsResponse> GetAsync(
        string id,
        string transcriptId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<TranscriptsResponse>(
            GetAsyncCore(id, transcriptId, options, cancellationToken)
        );
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
        await _client
            .Options.ExceptionHandler.TryCatchAsync(async () =>
            {
                var _headers = await new CortiApi.Core.HeadersBuilder.Builder()
                    .Add(_client.Options.Headers)
                    .Add(_client.Options.AdditionalHeaders)
                    .Add(options?.AdditionalHeaders)
                    .BuildAsync()
                    .ConfigureAwait(false);
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
                            Headers = _headers,
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
                                throw new BadRequestError(
                                    JsonUtils.Deserialize<object>(responseBody)
                                );
                            case 401:
                                throw new UnauthorizedError(
                                    JsonUtils.Deserialize<object>(responseBody)
                                );
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
            })
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Poll for transcript creation status.<br/>&lt;Note&gt;Status of `completed` indicates the transcript is finalized.<br/>If the transcript is retrieved while status is `processing`, then it will be incomplete.<br/>Status of `failed` indicate the transcript was not created successfully; please retry.&lt;/Note&gt;
    /// </summary>
    /// <example><code>
    /// await client.Transcripts.GetStatusAsync(
    ///     "f47ac10b-58cc-4372-a567-0e02b2c3d479",
    ///     "f47ac10b-58cc-4372-a567-0e02b2c3d479"
    /// );
    /// </code></example>
    public WithRawResponseTask<TranscriptsStatusResponse> GetStatusAsync(
        string id,
        string transcriptId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<TranscriptsStatusResponse>(
            GetStatusAsyncCore(id, transcriptId, options, cancellationToken)
        );
    }
}
