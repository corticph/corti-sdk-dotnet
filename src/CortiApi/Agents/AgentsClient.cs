using System.Text.Json;
using CortiApi.Core;

namespace CortiApi;

public partial class AgentsClient : IAgentsClient
{
    private RawClient _client;

    internal AgentsClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<IEnumerable<AgentsAgentResponse>>> ListAsyncCore(
        AgentsListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new CortiApi.Core.QueryStringBuilder.Builder(capacity: 3)
            .Add("limit", request.Limit)
            .Add("offset", request.Offset)
            .Add("ephemeral", request.Ephemeral)
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
                    BaseUrl = _client.Options.Environment.Agents,
                    Method = HttpMethod.Get,
                    Path = "agents",
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
                var responseData = JsonUtils.Deserialize<IEnumerable<AgentsAgentResponse>>(
                    responseBody
                )!;
                return new WithRawResponse<IEnumerable<AgentsAgentResponse>>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
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
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
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

    private async Task<WithRawResponse<AgentsAgent>> CreateAsyncCore(
        AgentsCreateAgent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new CortiApi.Core.QueryStringBuilder.Builder(capacity: 1)
            .Add("ephemeral", request.Ephemeral)
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
                    BaseUrl = _client.Options.Environment.Agents,
                    Method = HttpMethod.Post,
                    Path = "agents",
                    Body = request,
                    QueryString = _queryString,
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
                var responseData = JsonUtils.Deserialize<AgentsAgent>(responseBody)!;
                return new WithRawResponse<AgentsAgent>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
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
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
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

    private async Task<WithRawResponse<AgentsAgentResponse>> GetAsyncCore(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
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
                    BaseUrl = _client.Options.Environment.Agents,
                    Method = HttpMethod.Get,
                    Path = string.Format("agents/{0}", ValueConvert.ToPathParameterString(id)),
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
                var responseData = JsonUtils.Deserialize<AgentsAgentResponse>(responseBody)!;
                return new WithRawResponse<AgentsAgentResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
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
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
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

    private async Task<WithRawResponse<AgentsAgent>> UpdateAsyncCore(
        string id,
        AgentsAgent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
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
                    BaseUrl = _client.Options.Environment.Agents,
                    Method = HttpMethodExtensions.Patch,
                    Path = string.Format("agents/{0}", ValueConvert.ToPathParameterString(id)),
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
                var responseData = JsonUtils.Deserialize<AgentsAgent>(responseBody)!;
                return new WithRawResponse<AgentsAgent>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
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
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
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

    /// <summary>
    /// This endpoint retrieves a list of all agents that can be called by the Corti Agent Framework.
    /// </summary>
    /// <example><code>
    /// await client.Agents.ListAsync(new AgentsListRequest());
    /// </code></example>
    public WithRawResponseTask<IEnumerable<AgentsAgentResponse>> ListAsync(
        AgentsListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IEnumerable<AgentsAgentResponse>>(
            ListAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// This endpoint allows the creation of a new agent that can be utilized in the `POST /agents/{id}/v1/message:send` endpoint.
    /// </summary>
    /// <example><code>
    /// await client.Agents.CreateAsync(
    ///     new AgentsCreateAgent { Name = "name", Description = "description" }
    /// );
    /// </code></example>
    public WithRawResponseTask<AgentsAgent> CreateAsync(
        AgentsCreateAgent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<AgentsAgent>(
            CreateAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// This endpoint retrieves an agent by its identifier. The agent contains information about its capabilities and the experts it can call.
    /// </summary>
    /// <example><code>
    /// await client.Agents.GetAsync("12345678-90ab-cdef-gh12-34567890abc");
    /// </code></example>
    public WithRawResponseTask<AgentsAgentResponse> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<AgentsAgentResponse>(
            GetAsyncCore(id, options, cancellationToken)
        );
    }

    /// <summary>
    /// This endpoint deletes an agent by its identifier. Once deleted, the agent can no longer be used in threads.
    /// </summary>
    /// <example><code>
    /// await client.Agents.DeleteAsync("12345678-90ab-cdef-gh12-34567890abc");
    /// </code></example>
    public async Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
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
                    BaseUrl = _client.Options.Environment.Agents,
                    Method = HttpMethod.Delete,
                    Path = string.Format("agents/{0}", ValueConvert.ToPathParameterString(id)),
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
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
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

    /// <summary>
    /// This endpoint updates an existing agent. Only the fields provided in the request body will be updated; other fields will remain unchanged.
    /// </summary>
    /// <example><code>
    /// await client.Agents.UpdateAsync(
    ///     "12345678-90ab-cdef-gh12-34567890abc",
    ///     new AgentsAgent
    ///     {
    ///         Id = "id",
    ///         Name = "name",
    ///         Description = "description",
    ///         SystemPrompt = "systemPrompt",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<AgentsAgent> UpdateAsync(
        string id,
        AgentsAgent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<AgentsAgent>(
            UpdateAsyncCore(id, request, options, cancellationToken)
        );
    }
}
