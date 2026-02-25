using System.Text.Json;
using Corti.Core;

namespace Corti;

public partial class FactsClient
{
    private RawClient _client;

    internal FactsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Returns a list of available fact groups, used to categorize facts associated with an interaction.
    /// </summary>
    /// <example><code>
    /// await client.Facts.FactGroupsListAsync();
    /// </code></example>
    public async Task<FactsFactGroupsListResponse> FactGroupsListAsync(
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
                    Path = "factgroups/",
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
                return JsonUtils.Deserialize<FactsFactGroupsListResponse>(responseBody)!;
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
                    case 500:
                        throw new InternalServerError(
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
    /// Retrieves a list of facts for a given interaction.
    /// </summary>
    /// <example><code>
    /// await client.Facts.ListAsync("f47ac10b-58cc-4372-a567-0e02b2c3d479");
    /// </code></example>
    public async Task<FactsListResponse> ListAsync(
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
                        "interactions/{0}/facts/",
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
                return JsonUtils.Deserialize<FactsListResponse>(responseBody)!;
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
    /// Adds new facts to an interaction.
    /// </summary>
    /// <example><code>
    /// await client.Facts.CreateAsync(
    ///     "f47ac10b-58cc-4372-a567-0e02b2c3d479",
    ///     new FactsCreateRequest
    ///     {
    ///         Facts = new List&lt;FactsCreateInput&gt;()
    ///         {
    ///             new FactsCreateInput { Text = "text", Group = "other" },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<FactsCreateResponse> CreateAsync(
        string id,
        FactsCreateRequest request,
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
                        "interactions/{0}/facts/",
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
                return JsonUtils.Deserialize<FactsCreateResponse>(responseBody)!;
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
    /// Updates multiple facts associated with an interaction.
    /// </summary>
    /// <example><code>
    /// await client.Facts.BatchUpdateAsync(
    ///     "f47ac10b-58cc-4372-a567-0e02b2c3d479",
    ///     new FactsBatchUpdateRequest
    ///     {
    ///         Facts = new List&lt;FactsBatchUpdateInput&gt;()
    ///         {
    ///             new FactsBatchUpdateInput { FactId = "3c9d8a12-7f44-4b3e-9e6f-9271c2bbfa08" },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<FactsBatchUpdateResponse> BatchUpdateAsync(
        string id,
        FactsBatchUpdateRequest request,
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
                        "interactions/{0}/facts/",
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
                return JsonUtils.Deserialize<FactsBatchUpdateResponse>(responseBody)!;
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
    /// Updates an existing fact associated with a specific interaction.
    /// </summary>
    /// <example><code>
    /// await client.Facts.UpdateAsync(
    ///     "f47ac10b-58cc-4372-a567-0e02b2c3d479",
    ///     "3c9d8a12-7f44-4b3e-9e6f-9271c2bbfa08",
    ///     new FactsUpdateRequest()
    /// );
    /// </code></example>
    public async Task<FactsUpdateResponse> UpdateAsync(
        string id,
        string factId,
        FactsUpdateRequest request,
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
                        "interactions/{0}/facts/{1}",
                        ValueConvert.ToPathParameterString(id),
                        ValueConvert.ToPathParameterString(factId)
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
                return JsonUtils.Deserialize<FactsUpdateResponse>(responseBody)!;
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
    /// Extract facts from provided text, without storing them.
    /// </summary>
    /// <example><code>
    /// await client.Facts.ExtractAsync(
    ///     new FactsExtractRequest
    ///     {
    ///         Context = new List&lt;Corti.Text&gt;()
    ///         {
    ///             new Corti.Text { Type = CommonTextContextType.Text, Text_ = "text" },
    ///         },
    ///         OutputLanguage = "outputLanguage",
    ///     }
    /// );
    /// </code></example>
    public async Task<FactsExtractResponse> ExtractAsync(
        FactsExtractRequest request,
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
                    Path = "tools/extract-facts",
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
                return JsonUtils.Deserialize<FactsExtractResponse>(responseBody)!;
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
