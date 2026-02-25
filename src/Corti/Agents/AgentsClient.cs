using System.Text.Json;
using Corti.Core;
using OneOf;

namespace Corti;

public partial class AgentsClient
{
    private RawClient _client;

    internal AgentsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// This endpoint retrieves a list of all agents that can be called by the Corti Agent Framework.
    /// </summary>
    /// <example><code>
    /// await client.Agents.ListAsync(new AgentsListRequest());
    /// </code></example>
    public async Task<IEnumerable<OneOf<AgentsAgent, AgentsAgentReference>>> ListAsync(
        AgentsListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Limit != null)
        {
            _query["limit"] = request.Limit.Value.ToString();
        }
        if (request.Offset != null)
        {
            _query["offset"] = request.Offset.Value.ToString();
        }
        if (request.Ephemeral != null)
        {
            _query["ephemeral"] = JsonUtils.Serialize(request.Ephemeral.Value);
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.Environment.Agents,
                    Method = HttpMethod.Get,
                    Path = "agents",
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
                return JsonUtils.Deserialize<IEnumerable<OneOf<AgentsAgent, AgentsAgentReference>>>(
                    responseBody
                )!;
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
    /// This endpoint allows the creation of a new agent that can be utilized in the `POST /agents/{id}/v1/message:send` endpoint.
    /// </summary>
    /// <example><code>
    /// await client.Agents.CreateAsync(
    ///     new AgentsCreateAgent { Name = "name", Description = "description" }
    /// );
    /// </code></example>
    public async Task<AgentsAgent> CreateAsync(
        AgentsCreateAgent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Ephemeral != null)
        {
            _query["ephemeral"] = JsonUtils.Serialize(request.Ephemeral.Value);
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.Environment.Agents,
                    Method = HttpMethod.Post,
                    Path = "agents",
                    Body = request,
                    Query = _query,
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
                return JsonUtils.Deserialize<AgentsAgent>(responseBody)!;
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
    /// This endpoint retrieves an agent by its identifier. The agent contains information about its capabilities and the experts it can call.
    /// </summary>
    /// <example><code>
    /// await client.Agents.GetAsync("12345678-90ab-cdef-gh12-34567890abc");
    /// </code></example>
    public async Task<OneOf<AgentsAgent, AgentsAgentReference>> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.Environment.Agents,
                    Method = HttpMethod.Get,
                    Path = string.Format("agents/{0}", ValueConvert.ToPathParameterString(id)),
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
                return JsonUtils.Deserialize<OneOf<AgentsAgent, AgentsAgentReference>>(
                    responseBody
                )!;
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
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.Environment.Agents,
                    Method = HttpMethod.Delete,
                    Path = string.Format("agents/{0}", ValueConvert.ToPathParameterString(id)),
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
    public async Task<AgentsAgent> UpdateAsync(
        string id,
        AgentsAgent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.Environment.Agents,
                    Method = HttpMethodExtensions.Patch,
                    Path = string.Format("agents/{0}", ValueConvert.ToPathParameterString(id)),
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
                return JsonUtils.Deserialize<AgentsAgent>(responseBody)!;
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
    /// This endpoint retrieves the agent card in JSON format, which provides metadata about the agent, including its name, description, and the experts it can call.
    /// </summary>
    /// <example><code>
    /// await client.Agents.GetCardAsync("12345678-90ab-cdef-gh12-34567890abc");
    /// </code></example>
    public async Task<AgentsAgentCard> GetCardAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.Environment.Agents,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "agents/{0}/agent-card.json",
                        ValueConvert.ToPathParameterString(id)
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
                return JsonUtils.Deserialize<AgentsAgentCard>(responseBody)!;
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
    /// This endpoint sends a message to the specified agent to start or continue a task. The agent processes the message and returns a response. If the message contains a task ID that matches an ongoing task, the agent will continue that task; otherwise, it will start a new task.
    /// </summary>
    /// <example><code>
    /// await client.Agents.MessageSendAsync(
    ///     "12345678-90ab-cdef-gh12-34567890abc",
    ///     new AgentsMessageSendParams
    ///     {
    ///         Message = new AgentsMessage
    ///         {
    ///             Role = AgentsMessageRole.User,
    ///             Parts = new List&lt;AgentsPart&gt;()
    ///             {
    ///                 new AgentsPart(new Corti.AgentsPart.Text(new AgentsTextPart { Text = "text" })),
    ///             },
    ///             MessageId = "messageId",
    ///             Kind = AgentsMessageKind.Message,
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<AgentsMessageSendResponse> MessageSendAsync(
        string id,
        AgentsMessageSendParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.Environment.Agents,
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "agents/{0}/v1/message:send",
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
                return JsonUtils.Deserialize<AgentsMessageSendResponse>(responseBody)!;
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
    /// This endpoint retrieves the status and details of a specific task associated with the given agent. It provides information about the task's current state, history, and any artifacts produced during its execution.
    /// </summary>
    /// <example><code>
    /// await client.Agents.GetTaskAsync(
    ///     "12345678-90ab-cdef-gh12-34567890abc",
    ///     "taskId",
    ///     new AgentsGetTaskRequest()
    /// );
    /// </code></example>
    public async Task<AgentsTask> GetTaskAsync(
        string id,
        string taskId,
        AgentsGetTaskRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.HistoryLength != null)
        {
            _query["historyLength"] = request.HistoryLength.Value.ToString();
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.Environment.Agents,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "agents/{0}/v1/tasks/{1}",
                        ValueConvert.ToPathParameterString(id),
                        ValueConvert.ToPathParameterString(taskId)
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
                return JsonUtils.Deserialize<AgentsTask>(responseBody)!;
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
    /// This endpoint retrieves all tasks and top-level messages associated with a specific context for the given agent.
    /// </summary>
    /// <example><code>
    /// await client.Agents.GetContextAsync(
    ///     "12345678-90ab-cdef-gh12-34567890abc",
    ///     "contextId",
    ///     new AgentsGetContextRequest()
    /// );
    /// </code></example>
    public async Task<AgentsContext> GetContextAsync(
        string id,
        string contextId,
        AgentsGetContextRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Limit != null)
        {
            _query["limit"] = request.Limit.Value.ToString();
        }
        if (request.Offset != null)
        {
            _query["offset"] = request.Offset.Value.ToString();
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.Environment.Agents,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "agents/{0}/v1/contexts/{1}",
                        ValueConvert.ToPathParameterString(id),
                        ValueConvert.ToPathParameterString(contextId)
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
                return JsonUtils.Deserialize<AgentsContext>(responseBody)!;
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
    /// This endpoint retrieves the experts registry, which contains information about all available experts that can be referenced when creating agents through the AgentsCreateExpertReference schema.
    /// </summary>
    /// <example><code>
    /// await client.Agents.GetRegistryExpertsAsync(
    ///     new AgentsGetRegistryExpertsRequest { Limit = 100, Offset = 0 }
    /// );
    /// </code></example>
    public async Task<AgentsRegistryExpertsResponse> GetRegistryExpertsAsync(
        AgentsGetRegistryExpertsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Limit != null)
        {
            _query["limit"] = request.Limit.Value.ToString();
        }
        if (request.Offset != null)
        {
            _query["offset"] = request.Offset.Value.ToString();
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.Environment.Agents,
                    Method = HttpMethod.Get,
                    Path = "agents/registry/experts",
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
                return JsonUtils.Deserialize<AgentsRegistryExpertsResponse>(responseBody)!;
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
