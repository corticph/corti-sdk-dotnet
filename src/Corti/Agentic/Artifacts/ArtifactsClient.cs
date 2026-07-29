using Corti;
using Corti.Core;
using global::System.Text.Json;

namespace Corti.Agentic;

public partial class ArtifactsClient : IArtifactsClient
{
    private readonly RawClient _client;

    internal ArtifactsClient(RawClient client)
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

    private async Task<WithRawResponse<CommonArtifactResponse>> GetAsyncCore(
        string contextId,
        string taskId,
        string artifactId,
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
                            BaseUrl = _client.Options.Environment.Agents,
                            Method = HttpMethod.Get,
                            Path = string.Format(
                                "v2/agentic/contexts/{0}/tasks/{1}/artifacts/{2}",
                                ValueConvert.ToPathParameterString(contextId),
                                ValueConvert.ToPathParameterString(taskId),
                                ValueConvert.ToPathParameterString(artifactId)
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
                        var responseData = JsonUtils.Deserialize<CommonArtifactResponse>(
                            responseBody
                        )!;
                        return new WithRawResponse<CommonArtifactResponse>()
                        {
                            Data = responseData,
                            RawResponse = new Corti.RawResponse()
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
                            e,
                            rawResponse: new Corti.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
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
                            case 401:
                                throw new UnauthorizedError(
                                    JsonUtils.Deserialize<object>(responseBody),
                                    rawResponse: new Corti.RawResponse()
                                    {
                                        StatusCode = response.Raw.StatusCode,
                                        Url =
                                            response.Raw.RequestMessage?.RequestUri
                                            ?? new Uri("about:blank"),
                                        Headers = ResponseHeaders.FromHttpResponseMessage(
                                            response.Raw
                                        ),
                                    }
                                );
                            case 403:
                                throw new ForbiddenError(
                                    JsonUtils.Deserialize<object>(responseBody),
                                    rawResponse: new Corti.RawResponse()
                                    {
                                        StatusCode = response.Raw.StatusCode,
                                        Url =
                                            response.Raw.RequestMessage?.RequestUri
                                            ?? new Uri("about:blank"),
                                        Headers = ResponseHeaders.FromHttpResponseMessage(
                                            response.Raw
                                        ),
                                    }
                                );
                            case 404:
                                throw new NotFoundError(
                                    JsonUtils.Deserialize<object>(responseBody),
                                    rawResponse: new Corti.RawResponse()
                                    {
                                        StatusCode = response.Raw.StatusCode,
                                        Url =
                                            response.Raw.RequestMessage?.RequestUri
                                            ?? new Uri("about:blank"),
                                        Headers = ResponseHeaders.FromHttpResponseMessage(
                                            response.Raw
                                        ),
                                    }
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
                        responseBody,
                        rawResponse: new Corti.RawResponse()
                        {
                            StatusCode = response.Raw.StatusCode,
                            Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                            Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                        }
                    );
                }
            })
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Returns an artifact produced by a task within a context. File parts may
    /// carry inline `bytes` or a `uri` to fetch the content out of band.
    /// </summary>
    /// <example><code>
    /// await client.Agentic.Artifacts.GetAsync(
    ///     "ctx.0192f4c8-3d6b-7c4f-a02b-4d9e7f3c8b51",
    ///     "task.0192f4c8-4e7c-7d50-b13c-5eaf8a4d9c62",
    ///     "art.0192f4c8-6a9e-7f72-a35e-70c1ac6fbe84"
    /// );
    /// </code></example>
    public WithRawResponseTask<CommonArtifactResponse> GetAsync(
        string contextId,
        string taskId,
        string artifactId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CommonArtifactResponse>(
            GetAsyncCore(contextId, taskId, artifactId, options, cancellationToken)
        );
    }
}
