using System.Text.Json;
using Corti;
using Corti.Core;

namespace Corti.Documents;

public partial class TemplatesClient : ITemplatesClient
{
    private readonly RawClient _client;

    internal TemplatesClient(RawClient client)
    {
        try
        {
            _client = client;
            Versions = new Corti.Documents.Templates.VersionsClient(_client);
        }
        catch (Exception ex)
        {
            client.Options.ExceptionHandler?.CaptureException(ex);
            throw;
        }
    }

    public Corti.Documents.Templates.IVersionsClient Versions { get; }

    private async Task<WithRawResponse<IEnumerable<GuidedTemplate>>> ListAsyncCore(
        GuidedTemplatesListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return await _client
            .Options.ExceptionHandler.TryCatchAsync(async () =>
            {
                var _queryString = new Corti.Core.QueryStringBuilder.Builder(capacity: 6)
                    .Add("lang", request.Lang)
                    .Add("region", request.Region)
                    .Add("specialty", request.Specialty)
                    .Add("label", request.Label)
                    .Add("published", request.Published)
                    .Add("source", request.Source)
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
                            Path = "documents/templates/",
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
                        var responseData = JsonUtils.Deserialize<IEnumerable<GuidedTemplate>>(
                            responseBody
                        )!;
                        return new WithRawResponse<IEnumerable<GuidedTemplate>>()
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
                    var responseBody = await response
                        .Raw.Content.ReadAsStringAsync(cancellationToken)
                        .ConfigureAwait(false);
                    throw new CortiClientApiException(
                        $"Error with status code {response.StatusCode}",
                        response.StatusCode,
                        responseBody
                    );
                }
            })
            .ConfigureAwait(false);
    }

    private async Task<WithRawResponse<GuidedTemplate>> CreateAsyncCore(
        GuidedTemplatesCreateRequest request,
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
                            Path = "documents/templates/",
                            Body = request,
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
                        var responseData = JsonUtils.Deserialize<GuidedTemplate>(responseBody)!;
                        return new WithRawResponse<GuidedTemplate>()
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
                    var responseBody = await response
                        .Raw.Content.ReadAsStringAsync(cancellationToken)
                        .ConfigureAwait(false);
                    try
                    {
                        switch (response.StatusCode)
                        {
                            case 400:
                                throw new BadRequestError(
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

    private async Task<WithRawResponse<GuidedTemplate>> GetAsyncCore(
        string templateId,
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
                            Method = HttpMethod.Get,
                            Path = string.Format(
                                "documents/templates/{0}",
                                ValueConvert.ToPathParameterString(templateId)
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
                        var responseData = JsonUtils.Deserialize<GuidedTemplate>(responseBody)!;
                        return new WithRawResponse<GuidedTemplate>()
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
                    var responseBody = await response
                        .Raw.Content.ReadAsStringAsync(cancellationToken)
                        .ConfigureAwait(false);
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

    private async Task<WithRawResponse<GuidedTemplate>> UpdateAsyncCore(
        string templateId,
        GuidedTemplatesUpdateRequest request,
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
                            Method = HttpMethodExtensions.Patch,
                            Path = string.Format(
                                "documents/templates/{0}",
                                ValueConvert.ToPathParameterString(templateId)
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
                        var responseData = JsonUtils.Deserialize<GuidedTemplate>(responseBody)!;
                        return new WithRawResponse<GuidedTemplate>()
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
                    var responseBody = await response
                        .Raw.Content.ReadAsStringAsync(cancellationToken)
                        .ConfigureAwait(false);
                    try
                    {
                        switch (response.StatusCode)
                        {
                            case 400:
                                throw new BadRequestError(
                                    JsonUtils.Deserialize<object>(responseBody)
                                );
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
    /// Returns a list of templates and their metadata. Fetch a specific templateId to get the expanded sections.
    /// Use query parameters to filter by language, region, specialty, label, publish status, or source.
    /// </summary>
    /// <example><code>
    /// await client.Documents.Templates.ListAsync(new GuidedTemplatesListRequest());
    /// </code></example>
    public WithRawResponseTask<IEnumerable<GuidedTemplate>> ListAsync(
        GuidedTemplatesListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IEnumerable<GuidedTemplate>>(
            ListAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Creates a new template with an initial version. When `publish` is true (default),
    /// the response includes the published version with full inheritance resolution applied
    /// (template-level and section-level inheritance walked).
    /// </summary>
    /// <example><code>
    /// await client.Documents.Templates.CreateAsync(
    ///     new GuidedTemplatesCreateFromScratchRequest
    ///     {
    ///         Name = "name",
    ///         Generation = new GuidedTemplatesCreateFromScratchRequestGeneration
    ///         {
    ///             Instructions = new GuidedTemplateInstructions { Prompt = "prompt" },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<GuidedTemplate> CreateAsync(
        GuidedTemplatesCreateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GuidedTemplate>(
            CreateAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Returns the template with its published version fully resolved (inheritance walked,
    /// sections expanded with their own inheritance applied). To see raw authored
    /// values without inheritance, use GET /documents/templates/{templateID}/versions/{versionID}.
    /// </summary>
    /// <example><code>
    /// await client.Documents.Templates.GetAsync("templateID");
    /// </code></example>
    public WithRawResponseTask<GuidedTemplate> GetAsync(
        string templateId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GuidedTemplate>(
            GetAsyncCore(templateId, options, cancellationToken)
        );
    }

    /// <summary>
    /// Deletes a template and its versions. Returns 409 if other templates or sections inherit from this template.
    /// </summary>
    /// <example><code>
    /// await client.Documents.Templates.DeleteAsync("templateID");
    /// </code></example>
    public async Task DeleteAsync(
        string templateId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        await _client
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
                                "documents/templates/{0}",
                                ValueConvert.ToPathParameterString(templateId)
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
                    var responseBody = await response
                        .Raw.Content.ReadAsStringAsync(cancellationToken)
                        .ConfigureAwait(false);
                    try
                    {
                        switch (response.StatusCode)
                        {
                            case 404:
                                throw new NotFoundError(
                                    JsonUtils.Deserialize<object>(responseBody)
                                );
                            case 409:
                                throw new ConflictError(
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
    /// Updates the template's metadata fields (name, description, languages, regions, specialties, labels).
    /// Generation content (template instructions, section composition) is managed through versions
    /// and cannot be updated here.
    /// </summary>
    /// <example><code>
    /// await client.Documents.Templates.UpdateAsync("templateID", new GuidedTemplatesUpdateRequest());
    /// </code></example>
    public WithRawResponseTask<GuidedTemplate> UpdateAsync(
        string templateId,
        GuidedTemplatesUpdateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GuidedTemplate>(
            UpdateAsyncCore(templateId, request, options, cancellationToken)
        );
    }
}
