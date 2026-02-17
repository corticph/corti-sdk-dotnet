using System.Text.Json;
using CortiApi.Core;
using OneOf;

namespace CortiApi;

public partial class AgentsClient : IAgentsClient
{
    private RawClient _client;

    internal AgentsClient(RawClient client)
    {
        _client = client;
    }

    private async Task<
        WithRawResponse<IEnumerable<OneOf<AgentsAgent, AgentsAgentReference>>>
    > ListAsyncCore(
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
                var responseData = JsonUtils.Deserialize<
                    IEnumerable<OneOf<AgentsAgent, AgentsAgentReference>>
                >(responseBody)!;
                return new WithRawResponse<IEnumerable<OneOf<AgentsAgent, AgentsAgentReference>>>()
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

    /// <summary>
    /// This endpoint retrieves a list of all agents that can be called by the Corti Agent Framework.
    /// </summary>
    /// <example><code>
    /// await client.Agents.ListAsync(new AgentsListRequest());
    /// </code></example>
    public WithRawResponseTask<IEnumerable<OneOf<AgentsAgent, AgentsAgentReference>>> ListAsync(
        AgentsListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IEnumerable<OneOf<AgentsAgent, AgentsAgentReference>>>(
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
}
