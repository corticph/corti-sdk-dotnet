using Corti;
using Corti.Core;
using global::System.Net.ServerSentEvents;
using global::System.Runtime.CompilerServices;
using global::System.Text.Json;

namespace Corti.Agentic.Agents;

public partial class A2AClient : IA2AClient
{
    private readonly RawClient _client;

    internal A2AClient(RawClient client)
    {
        try
        {
            _client = client;
            Tasks = new Corti.Agentic.Agents.A2A.TasksClient(_client);
        }
        catch (Exception ex)
        {
            client.Options.ExceptionHandler?.CaptureException(ex);
            throw;
        }
    }

    public Corti.Agentic.Agents.A2A.ITasksClient Tasks { get; }

    private async Task<WithRawResponse<A2AjsonrpcResponse>> JsonRpcAsyncCore(
        string agentId,
        A2AjsonrpcRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return await _client
            .Options.ExceptionHandler.TryCatchAsync(async () =>
            {
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
                            Method = HttpMethod.Post,
                            Path = string.Format(
                                "agentic/agents/{0}/a2a",
                                ValueConvert.ToPathParameterString(agentId)
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
                    var responseBody = await response
                        .Raw.Content.ReadAsStringAsync(cancellationToken)
                        .ConfigureAwait(false);
                    try
                    {
                        var responseData = JsonUtils.Deserialize<A2AjsonrpcResponse>(responseBody)!;
                        return new WithRawResponse<A2AjsonrpcResponse>()
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

    private async Task<WithRawResponse<A2ASendMessageResponse>> SendMessageAsyncCore(
        string agentId,
        A2ASendMessageRequest request,
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
                                "agentic/agents/{0}/a2a/message:send",
                                ValueConvert.ToPathParameterString(agentId)
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
                    var responseBody = await response
                        .Raw.Content.ReadAsStringAsync(cancellationToken)
                        .ConfigureAwait(false);
                    try
                    {
                        var responseData = JsonUtils.Deserialize<A2ASendMessageResponse>(
                            responseBody
                        )!;
                        return new WithRawResponse<A2ASendMessageResponse>()
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

    private async Task<
        WithRawResponse<IAsyncEnumerable<A2AStreamEventResponse>>
    > StreamMessageAsyncCore(
        string agentId,
        A2ASendMessageRequest request,
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
                                "agentic/agents/{0}/a2a/message:stream",
                                ValueConvert.ToPathParameterString(agentId)
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
                    return new WithRawResponse<IAsyncEnumerable<A2AStreamEventResponse>>()
                    {
                        Data = StreamMessageAsyncBody(response, cancellationToken),
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

    private async IAsyncEnumerable<A2AStreamEventResponse> StreamMessageAsyncBody(
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

    /// <summary>
    /// The `JSONRPC` protocol binding for A2A v1.0. Accepts a single JSON-RPC 2.0
    /// request whose `method` is one of `SendMessage`, `SendStreamingMessage`,
    /// `GetTask`, `ListTasks`, `CancelTask`, or `SubscribeToTask`.
    ///
    /// Streaming methods (`SendStreamingMessage`, `SubscribeToTask`) respond with
    /// `text/event-stream`; all others respond with a single JSON-RPC response.
    /// </summary>
    /// <example><code>
    /// await client.Agentic.Agents.A2A.JsonRpcAsync(
    ///     "agt.0192f4c8-2c5a-7b3e-9f1a-3c8d6e2b7a40",
    ///     new A2AjsonrpcRequest
    ///     {
    ///         A2AVersion = "1.0",
    ///         Id = "1",
    ///         Method = A2AjsonrpcRequestMethod.SendMessage,
    ///         Params = new Dictionary&lt;string, object?&gt;()
    ///         {
    ///             {
    ///                 "message",
    ///                 new Dictionary&lt;object, object?&gt;()
    ///                 {
    ///                     { "messageId", "msg.0192f4c8-5f8d-7e61-924d-6fb09b5ead73" },
    ///                     {
    ///                         "parts",
    ///                         new List&lt;object?&gt;()
    ///                         {
    ///                             new Dictionary&lt;object, object?&gt;()
    ///                             {
    ///                                 { "text", "Code this encounter." },
    ///                             },
    ///                         }
    ///                     },
    ///                     { "role", "ROLE_USER" },
    ///                 }
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<A2AjsonrpcResponse> JsonRpcAsync(
        string agentId,
        A2AjsonrpcRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<A2AjsonrpcResponse>(
            JsonRpcAsyncCore(agentId, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// The `HTTP+JSON` binding of A2A `SendMessage`.
    /// </summary>
    /// <example><code>
    /// await client.Agentic.Agents.A2A.SendMessageAsync(
    ///     "agt.0192f4c8-2c5a-7b3e-9f1a-3c8d6e2b7a40",
    ///     new A2ASendMessageRequest
    ///     {
    ///         Message = new CommonMessage
    ///         {
    ///             MessageId = "msg.0192f4c8-5f8d-7e61-924d-6fb09b5ead73",
    ///             Role = CommonRole.RoleUser,
    ///             Parts = new List&lt;CommonPart&gt;()
    ///             {
    ///                 new CommonPart { Text = "What is the ICD-10 code for asthma?" },
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<A2ASendMessageResponse> SendMessageAsync(
        string agentId,
        A2ASendMessageRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<A2ASendMessageResponse>(
            SendMessageAsyncCore(agentId, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// The `HTTP+JSON` binding of A2A `SendStreamingMessage`. Responds with a
    /// `text/event-stream` of `Task`, `statusUpdate`, and `artifactUpdate` events.
    /// </summary>
    /// <example><code>
    /// client.Agentic.Agents.A2A.StreamMessageAsync(
    ///     "agt.0192f4c8-2c5a-7b3e-9f1a-3c8d6e2b7a40",
    ///     new A2ASendMessageRequest
    ///     {
    ///         Message = new CommonMessage
    ///         {
    ///             MessageId = "msg.0192f4c8-5f8d-7e61-924d-6fb09b5ead73",
    ///             Role = CommonRole.RoleUser,
    ///             Parts = new List&lt;CommonPart&gt;()
    ///             {
    ///                 new CommonPart { Text = "What is the ICD-10 code for asthma?" },
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseStream<A2AStreamEventResponse> StreamMessageAsync(
        string agentId,
        A2ASendMessageRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseStream<A2AStreamEventResponse>(
            StreamMessageAsyncCore(agentId, request, options, cancellationToken),
            cancellationToken
        );
    }
}
