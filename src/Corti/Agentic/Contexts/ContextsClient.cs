using Corti;
using Corti.Core;
using global::System.Text.Json;

namespace Corti.Agentic;

public partial class ContextsClient : IContextsClient
{
    private readonly RawClient _client;

    internal ContextsClient(RawClient client)
    {
        try
        {
            _client = client;
            Tasks = new Corti.Agentic.Contexts.TasksClient(_client);
        }
        catch (Exception ex)
        {
            client.Options.ExceptionHandler?.CaptureException(ex);
            throw;
        }
    }

    public Corti.Agentic.Contexts.ITasksClient Tasks { get; }

    /// <summary>
    /// Lists contexts matching the filters.
    /// **Future scope**: not yet implemented; the server currently returns an empty page and ignores all parameters.
    /// </summary>
    private WithRawResponseTask<AgenticContextsListResponse> ListInternalAsync(
        AgenticContextsListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<AgenticContextsListResponse>(
            ListInternalAsyncCore(request, options, cancellationToken)
        );
    }

    private async Task<WithRawResponse<AgenticContextsListResponse>> ListInternalAsyncCore(
        AgenticContextsListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return await _client
            .Options.ExceptionHandler.TryCatchAsync(async () =>
            {
                var _queryString = new Corti.Core.QueryStringBuilder.Builder(capacity: 5)
                    .Add("agentId", request.AgentId)
                    .Add("from", request.From)
                    .Add("to", request.To)
                    .Add("pageSize", request.PageSize)
                    .Add("pageToken", request.PageToken)
                    .MergeAdditional(options?.AdditionalQueryParameters)
                    .Build();
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
                            Method = HttpMethod.Get,
                            Path = "agentic/contexts",
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
                        var responseData = JsonUtils.Deserialize<AgenticContextsListResponse>(
                            responseBody
                        )!;
                        return new WithRawResponse<AgenticContextsListResponse>()
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

    private async Task<WithRawResponse<AgenticContextsDetailResponse>> GetAsyncCore(
        string contextId,
        AgenticContextsGetRequest request,
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
                                "agentic/contexts/{0}",
                                ValueConvert.ToPathParameterString(contextId)
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
                        var responseData = JsonUtils.Deserialize<AgenticContextsDetailResponse>(
                            responseBody
                        )!;
                        return new WithRawResponse<AgenticContextsDetailResponse>()
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

    private async Task<RawResponse> DeleteAsyncCore(
        string contextId,
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
                            Method = HttpMethod.Delete,
                            Path = string.Format(
                                "agentic/contexts/{0}",
                                ValueConvert.ToPathParameterString(contextId)
                            ),
                            Headers = _headers,
                            Options = options,
                        },
                        cancellationToken
                    )
                    .ConfigureAwait(false);
                if (response.StatusCode is >= 200 and < 400)
                {
                    return new Corti.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
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

    /// <summary>
    /// Returns the execution traces for the context — LLM calls, tool
    /// executions, and token usage — in OpenInference format. Traces are
    /// ordered newest-first and paginated; each page returns up to `pageSize`
    /// traces with their spans inlined.
    /// </summary>
    private WithRawResponseTask<AgenticContextsTraceResponse> TraceInternalAsync(
        string contextId,
        AgenticContextsTraceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<AgenticContextsTraceResponse>(
            TraceInternalAsyncCore(contextId, request, options, cancellationToken)
        );
    }

    private async Task<WithRawResponse<AgenticContextsTraceResponse>> TraceInternalAsyncCore(
        string contextId,
        AgenticContextsTraceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return await _client
            .Options.ExceptionHandler.TryCatchAsync(async () =>
            {
                var _queryString = new Corti.Core.QueryStringBuilder.Builder(capacity: 2)
                    .Add("pageSize", request.PageSize)
                    .Add("pageToken", request.PageToken)
                    .MergeAdditional(options?.AdditionalQueryParameters)
                    .Build();
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
                            Method = HttpMethod.Get,
                            Path = string.Format(
                                "agentic/contexts/{0}/trace",
                                ValueConvert.ToPathParameterString(contextId)
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
                        var responseData = JsonUtils.Deserialize<AgenticContextsTraceResponse>(
                            responseBody
                        )!;
                        return new WithRawResponse<AgenticContextsTraceResponse>()
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
                            case 400:
                                throw new BadRequestError(
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

    /// <summary>
    /// Lists contexts matching the filters.
    /// **Future scope**: not yet implemented; the server currently returns an empty page and ignores all parameters.
    /// </summary>
    /// <example><code>
    /// await client.Agentic.Contexts.ListAsync(new AgenticContextsListRequest());
    /// </code></example>
    public async Task<Pager<AgenticContext>> ListAsync(
        AgenticContextsListRequest request,
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
                    AgenticContextsListRequest,
                    RequestOptions?,
                    AgenticContextsListResponse,
                    string?,
                    AgenticContext
                >
                    .CreateInstanceAsync(
                        request,
                        options,
                        async (request, options, cancellationToken) =>
                            await ListInternalAsync(request, options, cancellationToken)
                                .WithRawResponse(),
                        (request, cursor) =>
                        {
                            request.PageToken = cursor;
                        },
                        response => response.NextPageToken,
                        response => response.Contexts?.ToList(),
                        cancellationToken
                    )
                    .ConfigureAwait(false);
                return pager;
            })
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Returns the context's metadata together with its `tasks`, oldest first.
    /// Each task carries its full message `history`; the user's prompt for a
    /// task is the `ROLE_USER` message within that task's history (there is no
    /// separate top-level message list).
    /// </summary>
    /// <example><code>
    /// await client.Agentic.Contexts.GetAsync(
    ///     "ctx.0192f4c8-3d6b-7c4f-a02b-4d9e7f3c8b51",
    ///     new AgenticContextsGetRequest()
    /// );
    /// </code></example>
    public WithRawResponseTask<AgenticContextsDetailResponse> GetAsync(
        string contextId,
        AgenticContextsGetRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<AgenticContextsDetailResponse>(
            GetAsyncCore(contextId, request, options, cancellationToken)
        );
    }

    /// <example><code>
    /// await client.Agentic.Contexts.DeleteAsync("ctx.0192f4c8-3d6b-7c4f-a02b-4d9e7f3c8b51");
    /// </code></example>
    public WithRawResponseTask DeleteAsync(
        string contextId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask(DeleteAsyncCore(contextId, options, cancellationToken));
    }

    /// <summary>
    /// Returns the execution traces for the context — LLM calls, tool
    /// executions, and token usage — in OpenInference format. Traces are
    /// ordered newest-first and paginated; each page returns up to `pageSize`
    /// traces with their spans inlined.
    /// </summary>
    /// <example><code>
    /// await client.Agentic.Contexts.TraceAsync(
    ///     "ctx.0192f4c8-3d6b-7c4f-a02b-4d9e7f3c8b51",
    ///     new AgenticContextsTraceRequest()
    /// );
    /// </code></example>
    public async Task<Pager<AgenticContextsTraceItem>> TraceAsync(
        string contextId,
        AgenticContextsTraceRequest request,
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
                    AgenticContextsTraceRequest,
                    RequestOptions?,
                    AgenticContextsTraceResponse,
                    string?,
                    AgenticContextsTraceItem
                >
                    .CreateInstanceAsync(
                        request,
                        options,
                        async (request, options, cancellationToken) =>
                            await TraceInternalAsync(contextId, request, options, cancellationToken)
                                .WithRawResponse(),
                        (request, cursor) =>
                        {
                            request.PageToken = cursor;
                        },
                        response => response.NextPageToken,
                        response => response.Traces?.ToList(),
                        cancellationToken
                    )
                    .ConfigureAwait(false);
                return pager;
            })
            .ConfigureAwait(false);
    }
}
