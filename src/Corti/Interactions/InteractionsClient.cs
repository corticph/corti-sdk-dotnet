using System.Text.Json;
using Corti.Core;

namespace Corti;

public partial class InteractionsClient
{
    private RawClient _client;

    internal InteractionsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Lists all existing interactions. Results can be filtered by encounter status and patient identifier.
    /// </summary>
    private async Task<InteractionsListResponse> ListInternalAsync(
        InteractionsListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        _query["encounterStatus"] = request
            .EncounterStatus.Select(_value => _value.Stringify())
            .ToList();
        if (request.Sort != null)
        {
            _query["sort"] = request.Sort.Value.Stringify();
        }
        if (request.Direction != null)
        {
            _query["direction"] = request.Direction.Value.Stringify();
        }
        if (request.PageSize != null)
        {
            _query["pageSize"] = request.PageSize.Value.ToString();
        }
        if (request.Index != null)
        {
            _query["index"] = request.Index.Value.ToString();
        }
        if (request.Patient != null)
        {
            _query["patient"] = request.Patient;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.Environment.Base,
                    Method = HttpMethod.Get,
                    Path = "interactions/",
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
                return JsonUtils.Deserialize<InteractionsListResponse>(responseBody)!;
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
                    case 403:
                        throw new ForbiddenError(
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
    /// Lists all existing interactions. Results can be filtered by encounter status and patient identifier.
    /// </summary>
    /// <example><code>
    /// await client.Interactions.ListAsync(new InteractionsListRequest());
    /// </code></example>
    public async Task<Pager<InteractionsGetResponse>> ListAsync(
        InteractionsListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        request = request with { };
        var pager = await OffsetPager<
            InteractionsListRequest,
            RequestOptions?,
            InteractionsListResponse,
            long?,
            object,
            InteractionsGetResponse
        >
            .CreateInstanceAsync(
                request,
                options,
                ListInternalAsync,
                request => request.Index ?? 0,
                (request, offset) =>
                {
                    request.Index = offset;
                },
                null,
                response => response.Interactions?.ToList(),
                null,
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Creates a new interaction.
    /// </summary>
    /// <example><code>
    /// await client.Interactions.CreateAsync(
    ///     new InteractionsCreateRequest
    ///     {
    ///         Encounter = new InteractionsEncounterCreateRequest
    ///         {
    ///             Identifier = "identifier",
    ///             Status = InteractionsEncounterStatusEnum.Planned,
    ///             Type = InteractionsEncounterTypeEnum.FirstConsultation,
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<InteractionsCreateResponse> CreateAsync(
        InteractionsCreateRequest request,
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
                    Path = "interactions/",
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
                return JsonUtils.Deserialize<InteractionsCreateResponse>(responseBody)!;
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
    /// Retrieves a previously recorded interaction by its unique identifier (interaction ID).
    /// </summary>
    /// <example><code>
    /// await client.Interactions.GetAsync("f47ac10b-58cc-4372-a567-0e02b2c3d479");
    /// </code></example>
    public async Task<InteractionsGetResponse> GetAsync(
        string id,
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
                        "interactions/{0}",
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
                return JsonUtils.Deserialize<InteractionsGetResponse>(responseBody)!;
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
                    case 403:
                        throw new ForbiddenError(
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
    /// Deletes an existing interaction.
    /// </summary>
    /// <example><code>
    /// await client.Interactions.DeleteAsync("f47ac10b-58cc-4372-a567-0e02b2c3d479");
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
                    BaseUrl = _client.Options.Environment.Base,
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "interactions/{0}",
                        ValueConvert.ToPathParameterString(id)
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
                    case 403:
                        throw new ForbiddenError(
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
    /// Modifies an existing interaction by updating specific fields without overwriting the entire record.
    /// </summary>
    /// <example><code>
    /// await client.Interactions.UpdateAsync(
    ///     "f47ac10b-58cc-4372-a567-0e02b2c3d479",
    ///     new InteractionsUpdateRequest()
    /// );
    /// </code></example>
    public async Task<InteractionsGetResponse> UpdateAsync(
        string id,
        InteractionsUpdateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.Environment.Base,
                    Method = HttpMethodExtensions.Patch,
                    Path = string.Format(
                        "interactions/{0}",
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
                return JsonUtils.Deserialize<InteractionsGetResponse>(responseBody)!;
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
                    case 403:
                        throw new ForbiddenError(
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
}
