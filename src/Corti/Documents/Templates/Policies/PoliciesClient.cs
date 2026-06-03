using System.Text.Json;
using Corti;
using Corti.Core;

namespace Corti.Documents.Templates;

public partial class PoliciesClient : IPoliciesClient
{
    private readonly RawClient _client;

    internal PoliciesClient(RawClient client)
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

    private async Task<WithRawResponse<IEnumerable<GuidedTemplatePolicy>>> ListAsyncCore(
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
                                "documents/templates/{0}/policies/",
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
                        var responseData = JsonUtils.Deserialize<IEnumerable<GuidedTemplatePolicy>>(
                            responseBody
                        )!;
                        return new WithRawResponse<IEnumerable<GuidedTemplatePolicy>>()
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

    private async Task<WithRawResponse<IEnumerable<GuidedTemplatePolicy>>> CreateAsyncCore(
        string templateId,
        IEnumerable<GuidedTemplatesCreatePolicyRequest> request,
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
                                "documents/templates/{0}/policies/",
                                ValueConvert.ToPathParameterString(templateId)
                            ),
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
                        var responseData = JsonUtils.Deserialize<IEnumerable<GuidedTemplatePolicy>>(
                            responseBody
                        )!;
                        return new WithRawResponse<IEnumerable<GuidedTemplatePolicy>>()
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

    /// <example><code>
    /// await client.Documents.Templates.Policies.ListAsync("templateID");
    /// </code></example>
    public WithRawResponseTask<IEnumerable<GuidedTemplatePolicy>> ListAsync(
        string templateId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IEnumerable<GuidedTemplatePolicy>>(
            ListAsyncCore(templateId, options, cancellationToken)
        );
    }

    /// <example><code>
    /// await client.Documents.Templates.Policies.CreateAsync(
    ///     "templateID",
    ///     new List&lt;GuidedTemplatesCreatePolicyRequest&gt;()
    ///     {
    ///         new GuidedTemplatesCreatePolicyRequest { Kind = GuidedTemplatePolicyKind.Project },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<IEnumerable<GuidedTemplatePolicy>> CreateAsync(
        string templateId,
        IEnumerable<GuidedTemplatesCreatePolicyRequest> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IEnumerable<GuidedTemplatePolicy>>(
            CreateAsyncCore(templateId, request, options, cancellationToken)
        );
    }
}
