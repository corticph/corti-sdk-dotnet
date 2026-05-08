using System.Text.Json;
using Corti.Core;

namespace Corti;

public partial class AlphaDocumentsClient : IAlphaDocumentsClient
{
    private readonly RawClient _client;

    internal AlphaDocumentsClient(RawClient client)
    {
        try
        {
            _client = client;
        }
        catch (Exception ex)
        {
            client.Options.ExceptionHandler?.CaptureException(ex);
            throw;
        }
    }

    private async Task<WithRawResponse<GuidedDocumentResponse>> GenerateAsyncCore(
        GuidedDocumentRequest request,
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
                            Path = "alpha/documents",
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
                        var responseData = JsonUtils.Deserialize<GuidedDocumentResponse>(
                            responseBody
                        )!;
                        return new WithRawResponse<GuidedDocumentResponse>()
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
                            case 502:
                                throw new BadGatewayError(
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
    /// Generates a structured document using one of four template-supply paths: a stored template reference (optionally with runtime overrides), an ad-hoc assembly of stored sections, or a fully inline dynamic template. Exactly one of `templateRef`, `assemblyTemplate`, or `dynamicTemplate` must be provided.
    ///
    /// With the exception of the plain `templateRef` path (no overrides), every call persists a new auto-generated template aggregate that snapshots the resolved content. The snapshot is drift-proof: subsequent edits to base templates or sections do not affect previously generated documents.
    /// </summary>
    /// <example><code>
    /// await client.AlphaDocuments.GenerateAsync(
    ///     new GuidedDocumentByTemplateRefWithContext
    ///     {
    ///         Context = new List&lt;GuidedDocumentContext&gt;()
    ///         {
    ///             new GuidedDocumentContextText { Type = "text", Text = "text" },
    ///         },
    ///         TemplateRef = new GuidedTemplateRef { TemplateId = "templateId" },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<GuidedDocumentResponse> GenerateAsync(
        GuidedDocumentRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GuidedDocumentResponse>(
            GenerateAsyncCore(request, options, cancellationToken)
        );
    }
}
