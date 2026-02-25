using System.Text.Json;
using Corti.Core;
using OneOf;

namespace Corti;

public partial class DocumentsClient
{
    private RawClient _client;

    internal DocumentsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// List Documents
    /// </summary>
    /// <example><code>
    /// await client.Documents.ListAsync("f47ac10b-58cc-4372-a567-0e02b2c3d479");
    /// </code></example>
    public async Task<DocumentsListResponse> ListAsync(
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
                        "interactions/{0}/documents/",
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
                return JsonUtils.Deserialize<DocumentsListResponse>(responseBody)!;
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
    /// This endpoint offers different ways to generate a document. Find guides to document generation [here](/textgen/documents-standard).
    /// </summary>
    /// <example><code>
    /// await client.Documents.CreateAsync(
    ///     "f47ac10b-58cc-4372-a567-0e02b2c3d479",
    ///     new DocumentsCreateRequestWithTemplateKey
    ///     {
    ///         Context = new List&lt;DocumentsContext&gt;()
    ///         {
    ///             new DocumentsContext(
    ///                 new DocumentsContext.Facts(
    ///                     new DocumentsContextWithFacts
    ///                     {
    ///                         Data = new List&lt;FactsContext&gt;()
    ///                         {
    ///                             new FactsContext { Text = "text", Source = CommonSourceEnum.Core },
    ///                         },
    ///                     }
    ///                 )
    ///             ),
    ///         },
    ///         TemplateKey = "templateKey",
    ///         OutputLanguage = "outputLanguage",
    ///     }
    /// );
    /// </code></example>
    public async Task<DocumentsGetResponse> CreateAsync(
        string id,
        OneOf<DocumentsCreateRequestWithTemplateKey, DocumentsCreateRequestWithTemplate> request,
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
                        "interactions/{0}/documents/",
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
                return JsonUtils.Deserialize<DocumentsGetResponse>(responseBody)!;
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
    /// Get Document.
    /// </summary>
    /// <example><code>
    /// await client.Documents.GetAsync(
    ///     "f47ac10b-58cc-4372-a567-0e02b2c3d479",
    ///     "f47ac10b-58cc-4372-a567-0e02b2c3d479"
    /// );
    /// </code></example>
    public async Task<DocumentsGetResponse> GetAsync(
        string id,
        string documentId,
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
                        "interactions/{0}/documents/{1}",
                        ValueConvert.ToPathParameterString(id),
                        ValueConvert.ToPathParameterString(documentId)
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
                return JsonUtils.Deserialize<DocumentsGetResponse>(responseBody)!;
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

    /// <example><code>
    /// await client.Documents.DeleteAsync(
    ///     "f47ac10b-58cc-4372-a567-0e02b2c3d479",
    ///     "f47ac10b-58cc-4372-a567-0e02b2c3d479"
    /// );
    /// </code></example>
    public async Task DeleteAsync(
        string id,
        string documentId,
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
                        "interactions/{0}/documents/{1}",
                        ValueConvert.ToPathParameterString(id),
                        ValueConvert.ToPathParameterString(documentId)
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
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
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

    /// <example><code>
    /// await client.Documents.UpdateAsync(
    ///     "f47ac10b-58cc-4372-a567-0e02b2c3d479",
    ///     "f47ac10b-58cc-4372-a567-0e02b2c3d479",
    ///     new DocumentsUpdateRequest()
    /// );
    /// </code></example>
    public async Task<DocumentsGetResponse> UpdateAsync(
        string id,
        string documentId,
        DocumentsUpdateRequest request,
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
                        "interactions/{0}/documents/{1}",
                        ValueConvert.ToPathParameterString(id),
                        ValueConvert.ToPathParameterString(documentId)
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
                return JsonUtils.Deserialize<DocumentsGetResponse>(responseBody)!;
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
}
