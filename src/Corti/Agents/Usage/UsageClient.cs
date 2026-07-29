using Corti;
using Corti.Core;
using global::System.Text.Json;

namespace Corti.Agents;

public partial class UsageClient : IUsageClient
{
    private readonly RawClient _client;

    internal UsageClient(RawClient client)
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

    private async Task<WithRawResponse<UsageReportResponse>> GetAsyncCore(
        string agentId,
        GetUsageRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return await _client
            .Options.ExceptionHandler.TryCatchAsync(async () =>
            {
                var _queryString = new Corti.Core.QueryStringBuilder.Builder(capacity: 3)
                    .Add("from", request.From)
                    .Add("to", request.To)
                    .Add("granularity", request.Granularity)
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
                            BaseUrl = _client.Options.Environment.Agents,
                            Method = HttpMethod.Get,
                            Path = string.Format(
                                "v2/agentic/agents/{0}/usage",
                                ValueConvert.ToPathParameterString(agentId)
                            ),
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
                        var responseData = JsonUtils.Deserialize<UsageReportResponse>(
                            responseBody
                        )!;
                        return new WithRawResponse<UsageReportResponse>()
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
                            case 400:
                                throw new BadRequestError(
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
    /// Returns invocation metrics for the agent over the half-open `[from, to)`
    /// time range (UTC), bucketed at the requested `granularity`. The response
    /// echoes the resolved range and granularity, a `totals` summary across the
    /// whole range, and one `buckets` entry per period that had activity (the
    /// array is empty when there was none). When `from`/`to` are omitted, the
    /// range defaults to the last 30 days.
    /// </summary>
    /// <example><code>
    /// await client.Agents.Usage.GetAsync(
    ///     "agt.0192f4c8-2c5a-7b3e-9f1a-3c8d6e2b7a40",
    ///     new GetUsageRequest
    ///     {
    ///         From = new DateTime(2026, 05, 19, 00, 00, 00, 000),
    ///         To = new DateTime(2026, 05, 20, 00, 00, 00, 000),
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<UsageReportResponse> GetAsync(
        string agentId,
        GetUsageRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<UsageReportResponse>(
            GetAsyncCore(agentId, request, options, cancellationToken)
        );
    }
}
