using Corti;
using Corti.Core;
using global::System.Net.ServerSentEvents;
using global::System.Runtime.CompilerServices;
using global::System.Text.Json;

namespace Corti.Agentic.Agents.A2A;

public partial class TasksClient : ITasksClient
{
    private readonly RawClient _client;

    internal TasksClient(RawClient client)
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

    private WithRawResponseTask<CommonTaskListResponse> ListInternalAsync(
        string agentId,
        AgenticAgentsA2ATasksListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CommonTaskListResponse>(
            ListInternalAsyncCore(agentId, request, options, cancellationToken)
        );
    }

    private async Task<WithRawResponse<CommonTaskListResponse>> ListInternalAsyncCore(
        string agentId,
        AgenticAgentsA2ATasksListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return await _client
            .Options.ExceptionHandler.TryCatchAsync(async () =>
            {
                var _queryString = new Corti.Core.QueryStringBuilder.Builder(capacity: 3)
                    .Add("pageSize", request.PageSize)
                    .Add("pageToken", request.PageToken)
                    .Add("contextId", request.ContextId)
                    .MergeAdditional(options?.AdditionalQueryParameters)
                    .Build();
                var _headers = await new Corti.Core.HeadersBuilder.Builder()
                    .Add("A2A-Version", request.A2AVersion)
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
                                "agentic/agents/{0}/a2a/tasks",
                                ValueConvert.ToPathParameterString(agentId)
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
                    var responseBody = await response
                        .Raw.Content.ReadAsStringAsync(cancellationToken)
                        .ConfigureAwait(false);
                    try
                    {
                        var responseData = JsonUtils.Deserialize<CommonTaskListResponse>(
                            responseBody
                        )!;
                        return new WithRawResponse<CommonTaskListResponse>()
                        {
                            Data = responseData,
                            RawResponse = new Corti.RawResponse()
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
                            e,
                            rawResponse: new Corti.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    }
                }
                {
                    var responseBody = await response
                        .Raw.Content.ReadAsStringAsync(cancellationToken)
                        .ConfigureAwait(false);
                    try
                    {
                        switch (response.StatusCode)
                        {
                            case 401:
                                throw new UnauthorizedError(
                                    JsonUtils.Deserialize<object>(responseBody),
                                    rawResponse: new Corti.RawResponse()
                                    {
                                        StatusCode = response.Raw.StatusCode,
                                        Url =
                                            response.Raw.RequestMessage?.RequestUri
                                            ?? new Uri("about:blank"),
                                        Headers = ResponseHeaders.FromHttpResponseMessage(
                                            response.Raw
                                        ),
                                    }
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
                        responseBody,
                        rawResponse: new Corti.RawResponse()
                        {
                            StatusCode = response.Raw.StatusCode,
                            Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                            Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                        }
                    );
                }
            })
            .ConfigureAwait(false);
    }

    private async Task<WithRawResponse<CommonTaskResponse>> GetAsyncCore(
        string agentId,
        string taskId,
        AgenticAgentsA2ATasksGetRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return await _client
            .Options.ExceptionHandler.TryCatchAsync(async () =>
            {
                var _queryString = new Corti.Core.QueryStringBuilder.Builder(capacity: 1)
                    .Add("historyLength", request.HistoryLength)
                    .MergeAdditional(options?.AdditionalQueryParameters)
                    .Build();
                var _headers = await new Corti.Core.HeadersBuilder.Builder()
                    .Add("A2A-Version", request.A2AVersion)
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
                                "agentic/agents/{0}/a2a/tasks/{1}",
                                ValueConvert.ToPathParameterString(agentId),
                                ValueConvert.ToPathParameterString(taskId)
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
                    var responseBody = await response
                        .Raw.Content.ReadAsStringAsync(cancellationToken)
                        .ConfigureAwait(false);
                    try
                    {
                        var responseData = JsonUtils.Deserialize<CommonTaskResponse>(responseBody)!;
                        return new WithRawResponse<CommonTaskResponse>()
                        {
                            Data = responseData,
                            RawResponse = new Corti.RawResponse()
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
                            e,
                            rawResponse: new Corti.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    }
                }
                {
                    var responseBody = await response
                        .Raw.Content.ReadAsStringAsync(cancellationToken)
                        .ConfigureAwait(false);
                    try
                    {
                        switch (response.StatusCode)
                        {
                            case 401:
                                throw new UnauthorizedError(
                                    JsonUtils.Deserialize<object>(responseBody),
                                    rawResponse: new Corti.RawResponse()
                                    {
                                        StatusCode = response.Raw.StatusCode,
                                        Url =
                                            response.Raw.RequestMessage?.RequestUri
                                            ?? new Uri("about:blank"),
                                        Headers = ResponseHeaders.FromHttpResponseMessage(
                                            response.Raw
                                        ),
                                    }
                                );
                            case 404:
                                throw new NotFoundError(
                                    JsonUtils.Deserialize<object>(responseBody),
                                    rawResponse: new Corti.RawResponse()
                                    {
                                        StatusCode = response.Raw.StatusCode,
                                        Url =
                                            response.Raw.RequestMessage?.RequestUri
                                            ?? new Uri("about:blank"),
                                        Headers = ResponseHeaders.FromHttpResponseMessage(
                                            response.Raw
                                        ),
                                    }
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
                        responseBody,
                        rawResponse: new Corti.RawResponse()
                        {
                            StatusCode = response.Raw.StatusCode,
                            Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                            Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                        }
                    );
                }
            })
            .ConfigureAwait(false);
    }

    private async Task<WithRawResponse<CommonTaskResponse>> CancelAsyncCore(
        string agentId,
        string taskId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return await _client
            .Options.ExceptionHandler.TryCatchAsync(async () =>
            {
                var _headers = await new Corti.Core.HeadersBuilder.Builder()
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
                                "agentic/agents/{0}/a2a/tasks/{1}:cancel",
                                ValueConvert.ToPathParameterString(agentId),
                                ValueConvert.ToPathParameterString(taskId)
                            ),
                            Headers = _headers,
                            Options = options,
                        },
                        cancellationToken
                    )
                    .ConfigureAwait(false);
                if (response.StatusCode is >= 200 and < 400)
                {
                    var responseBody = await response
                        .Raw.Content.ReadAsStringAsync(cancellationToken)
                        .ConfigureAwait(false);
                    try
                    {
                        var responseData = JsonUtils.Deserialize<CommonTaskResponse>(responseBody)!;
                        return new WithRawResponse<CommonTaskResponse>()
                        {
                            Data = responseData,
                            RawResponse = new Corti.RawResponse()
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
                            e,
                            rawResponse: new Corti.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    }
                }
                {
                    var responseBody = await response
                        .Raw.Content.ReadAsStringAsync(cancellationToken)
                        .ConfigureAwait(false);
                    try
                    {
                        switch (response.StatusCode)
                        {
                            case 401:
                                throw new UnauthorizedError(
                                    JsonUtils.Deserialize<object>(responseBody),
                                    rawResponse: new Corti.RawResponse()
                                    {
                                        StatusCode = response.Raw.StatusCode,
                                        Url =
                                            response.Raw.RequestMessage?.RequestUri
                                            ?? new Uri("about:blank"),
                                        Headers = ResponseHeaders.FromHttpResponseMessage(
                                            response.Raw
                                        ),
                                    }
                                );
                            case 404:
                                throw new NotFoundError(
                                    JsonUtils.Deserialize<object>(responseBody),
                                    rawResponse: new Corti.RawResponse()
                                    {
                                        StatusCode = response.Raw.StatusCode,
                                        Url =
                                            response.Raw.RequestMessage?.RequestUri
                                            ?? new Uri("about:blank"),
                                        Headers = ResponseHeaders.FromHttpResponseMessage(
                                            response.Raw
                                        ),
                                    }
                                );
                            case 409:
                                throw new ConflictError(
                                    JsonUtils.Deserialize<object>(responseBody),
                                    rawResponse: new Corti.RawResponse()
                                    {
                                        StatusCode = response.Raw.StatusCode,
                                        Url =
                                            response.Raw.RequestMessage?.RequestUri
                                            ?? new Uri("about:blank"),
                                        Headers = ResponseHeaders.FromHttpResponseMessage(
                                            response.Raw
                                        ),
                                    }
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
                        responseBody,
                        rawResponse: new Corti.RawResponse()
                        {
                            StatusCode = response.Raw.StatusCode,
                            Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                            Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                        }
                    );
                }
            })
            .ConfigureAwait(false);
    }

    private async Task<
        WithRawResponse<IAsyncEnumerable<A2AStreamEventResponse>>
    > SubscribeAsyncCore(
        string agentId,
        string taskId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return await _client
            .Options.ExceptionHandler.TryCatchAsync(async () =>
            {
                var _headers = await new Corti.Core.HeadersBuilder.Builder()
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
                                "agentic/agents/{0}/a2a/tasks/{1}:subscribe",
                                ValueConvert.ToPathParameterString(agentId),
                                ValueConvert.ToPathParameterString(taskId)
                            ),
                            Headers = _headers,
                            Options = options,
                        },
                        cancellationToken
                    )
                    .ConfigureAwait(false);
                if (response.StatusCode is >= 200 and < 400)
                {
                    return new WithRawResponse<IAsyncEnumerable<A2AStreamEventResponse>>()
                    {
                        Data = SubscribeAsyncBody(response, cancellationToken),
                        RawResponse = new Corti.RawResponse()
                        {
                            StatusCode = response.Raw.StatusCode,
                            Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                            Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                        },
                    };
                }
                {
                    var responseBody = await response
                        .Raw.Content.ReadAsStringAsync(cancellationToken)
                        .ConfigureAwait(false);
                    try
                    {
                        switch (response.StatusCode)
                        {
                            case 401:
                                throw new UnauthorizedError(
                                    JsonUtils.Deserialize<object>(responseBody),
                                    rawResponse: new Corti.RawResponse()
                                    {
                                        StatusCode = response.Raw.StatusCode,
                                        Url =
                                            response.Raw.RequestMessage?.RequestUri
                                            ?? new Uri("about:blank"),
                                        Headers = ResponseHeaders.FromHttpResponseMessage(
                                            response.Raw
                                        ),
                                    }
                                );
                            case 404:
                                throw new NotFoundError(
                                    JsonUtils.Deserialize<object>(responseBody),
                                    rawResponse: new Corti.RawResponse()
                                    {
                                        StatusCode = response.Raw.StatusCode,
                                        Url =
                                            response.Raw.RequestMessage?.RequestUri
                                            ?? new Uri("about:blank"),
                                        Headers = ResponseHeaders.FromHttpResponseMessage(
                                            response.Raw
                                        ),
                                    }
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
                        responseBody,
                        rawResponse: new Corti.RawResponse()
                        {
                            StatusCode = response.Raw.StatusCode,
                            Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                            Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                        }
                    );
                }
            })
            .ConfigureAwait(false);
    }

    private async IAsyncEnumerable<A2AStreamEventResponse> SubscribeAsyncBody(
        ApiResponse response,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        return await _client
            .Options.ExceptionHandler.TryCatchAsync(async () =>
            {
                await foreach (
                    var item in SseParser
                        .Create(await response.Raw.Content.ReadAsStreamAsync())
                        .EnumerateAsync(cancellationToken)
                )
                {
                    if (!string.IsNullOrEmpty(item.Data))
                    {
                        A2AStreamEventResponse? result;
                        try
                        {
                            result = JsonUtils.Deserialize<A2AStreamEventResponse>(item.Data);
                        }
                        catch (JsonException)
                        {
                            throw new CortiClientException(
                                $"Unable to deserialize JSON response 'item.Data'"
                            );
                        }
                        yield return result!;
                    }
                }
            })
            .ConfigureAwait(false);
    }

    /// <example><code>
    /// await client.Agentic.Agents.A2A.Tasks.ListAsync(
    ///     "agt.0192f4c8-2c5a-7b3e-9f1a-3c8d6e2b7a40",
    ///     new AgenticAgentsA2ATasksListRequest { A2AVersion = "1.0" }
    /// );
    /// </code></example>
    public async Task<Pager<CommonTaskResponse>> ListAsync(
        string agentId,
        AgenticAgentsA2ATasksListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return await _client
            .Options.ExceptionHandler.TryCatchAsync(async () =>
            {
                if (request is not null)
                {
                    request = request with { };
                }
                var pager = await CursorPager<
                    AgenticAgentsA2ATasksListRequest,
                    RequestOptions?,
                    CommonTaskListResponse,
                    string?,
                    CommonTaskResponse
                >
                    .CreateInstanceAsync(
                        request,
                        options,
                        async (request, options, cancellationToken) =>
                            await ListInternalAsync(agentId, request, options, cancellationToken)
                                .WithRawResponse(),
                        (request, cursor) =>
                        {
                            request.PageToken = cursor;
                        },
                        response => response.NextPageToken,
                        response => response.Tasks?.ToList(),
                        cancellationToken
                    )
                    .ConfigureAwait(false);
                return pager;
            })
            .ConfigureAwait(false);
    }

    /// <example><code>
    /// await client.Agentic.Agents.A2A.Tasks.GetAsync(
    ///     "agt.0192f4c8-2c5a-7b3e-9f1a-3c8d6e2b7a40",
    ///     "task.0192f4c8-4e7c-7d50-b13c-5eaf8a4d9c62",
    ///     new AgenticAgentsA2ATasksGetRequest { A2AVersion = "1.0" }
    /// );
    /// </code></example>
    public WithRawResponseTask<CommonTaskResponse> GetAsync(
        string agentId,
        string taskId,
        AgenticAgentsA2ATasksGetRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CommonTaskResponse>(
            GetAsyncCore(agentId, taskId, request, options, cancellationToken)
        );
    }

    /// <example><code>
    /// await client.Agentic.Agents.A2A.Tasks.CancelAsync(
    ///     "agt.0192f4c8-2c5a-7b3e-9f1a-3c8d6e2b7a40",
    ///     "task.0192f4c8-4e7c-7d50-b13c-5eaf8a4d9c62"
    /// );
    /// </code></example>
    public WithRawResponseTask<CommonTaskResponse> CancelAsync(
        string agentId,
        string taskId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CommonTaskResponse>(
            CancelAsyncCore(agentId, taskId, options, cancellationToken)
        );
    }

    /// <summary>
    /// Resubscribe to an in-flight task's event stream over SSE.
    /// </summary>
    /// <example><code>
    /// client.Agentic.Agents.A2A.Tasks.SubscribeAsync(
    ///     "agt.0192f4c8-2c5a-7b3e-9f1a-3c8d6e2b7a40",
    ///     "task.0192f4c8-4e7c-7d50-b13c-5eaf8a4d9c62"
    /// );
    /// </code></example>
    public WithRawResponseStream<A2AStreamEventResponse> SubscribeAsync(
        string agentId,
        string taskId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseStream<A2AStreamEventResponse>(
            SubscribeAsyncCore(agentId, taskId, options, cancellationToken),
            cancellationToken
        );
    }
}
