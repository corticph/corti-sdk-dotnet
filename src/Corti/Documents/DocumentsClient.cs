using System.Text.Json;
using Corti.Core;
using Corti.Documents;

namespace Corti;

public partial class DocumentsClient : IDocumentsClient
{
    private readonly RawClient _client;

    internal DocumentsClient(RawClient client)
    {
        try
        {
            _client = client;
            Templates = new TemplatesClient(_client);
            Sections = new SectionsClient(_client);
        }
        catch (Exception ex)
        {
            client.Options.ExceptionHandler?.CaptureException(ex);
            throw;
        }
    }

    public ITemplatesClient Templates { get; }

    public ISectionsClient Sections { get; }

    private async Task<WithRawResponse<CreateEphemeralDocumentResponse>> GenerateAsyncCore(
        GenerateDocumentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return await _client
            .Options.ExceptionHandler.TryCatchAsync(async () =>
            {
                var _headers = await new Corti.Core.HeadersBuilder.Builder()
                    .Add("X-Corti-Retention-Policy", request.CortiRetentionPolicy)
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
                            Path = "documents/",
                            Body = request.Body,
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
                        var responseData = JsonUtils.Deserialize<CreateEphemeralDocumentResponse>(
                            responseBody
                        )!;
                        return new WithRawResponse<CreateEphemeralDocumentResponse>()
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
                            case 422:
                                throw new UnprocessableEntityError(
                                    JsonUtils.Deserialize<object>(responseBody)
                                );
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
            })
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Generates a structured document using one of three template-supply paths: a stored template reference (optionally with runtime overrides), an ad-hoc assembly of stored sections, or a fully inline dynamic template. Exactly one of `templateRef`, `assemblyTemplate`, or `dynamicTemplate` must be provided.
    ///
    /// With the exception of the plain `templateRef` path (no overrides), every call persists a new auto-generated template aggregate that snapshots the resolved content. The snapshot is drift-proof: subsequent edits to base templates or sections do not affect previously generated documents.
    /// </summary>
    /// <example><code>
    /// await client.Documents.GenerateAsync(
    ///     new GenerateDocumentsRequest
    ///     {
    ///         Body = new GuidedDocumentByTemplateRef
    ///         {
    ///             OutputLanguage = "outputLanguage",
    ///             TemplateRef = new GuidedTemplateRef { TemplateId = "templateId" },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<CreateEphemeralDocumentResponse> GenerateAsync(
        GenerateDocumentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CreateEphemeralDocumentResponse>(
            GenerateAsyncCore(request, options, cancellationToken)
        );
    }
}
