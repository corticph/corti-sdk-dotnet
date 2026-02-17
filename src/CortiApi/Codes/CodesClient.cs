using System.Text.Json;
using CortiApi.Core;

namespace CortiApi;

public partial class CodesClient : ICodesClient
{
    private RawClient _client;

    internal CodesClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<CodesGeneralResponse>> PredictAsyncCore(
        CodesGeneralPredictRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
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
                    BaseUrl = _client.Options.Environment.Base,
                    Method = HttpMethod.Post,
                    Path = "tools/coding/",
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
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                var responseData = JsonUtils.Deserialize<CodesGeneralResponse>(responseBody)!;
                return new WithRawResponse<CodesGeneralResponse>()
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
                    case 403:
                        throw new ForbiddenError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 500:
                        throw new InternalServerError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                    case 502:
                        throw new BadGatewayError(
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
    /// Predict medical codes from provided context.<br/>&lt;Note&gt;This is a stateless endpoint, designed to predict ICD-10-CM, ICD-10-PCS, and CPT codes based on input text string or documentId.<br/><br/>More than one code system may be defined in a single request, and the maximum number of codes to return per system can also be defined.<br/><br/>Code prediction requests have two possible values for context:<br/>- `text`: One set of code prediction results will be returned based on all input text defined.<br/>- `documentId`: Code prediction will be based on that defined document only.<br/><br/>The response includes two sets of results:<br/>- `Codes`: Highest confidence bundle of codes, as selected by the code prediction model<br/>- `Candidates`: Full list of candidate codes as predicted by the model, rank sorted by model confidence with maximum possible value of 50.<br/><br/>All predicted code results are based on input context defined in the request only (not other external data or assets associated with an interaction).&lt;/Note&gt;
    /// </summary>
    /// <example><code>
    /// await client.Codes.PredictAsync(
    ///     new CodesGeneralPredictRequest
    ///     {
    ///         System = new List&lt;CommonCodingSystemEnum&gt;()
    ///         {
    ///             CommonCodingSystemEnum.Icd10Cm,
    ///             CommonCodingSystemEnum.Cpt,
    ///         },
    ///         Context = new List&lt;CommonAiContext&gt;()
    ///         {
    ///             new CommonTextContext
    ///             {
    ///                 Type = CommonTextContextType.Text,
    ///                 Text = "Short arm splint applied in ED for pain control.",
    ///             },
    ///         },
    ///         MaxCandidates = 5,
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<CodesGeneralResponse> PredictAsync(
        CodesGeneralPredictRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CodesGeneralResponse>(
            PredictAsyncCore(request, options, cancellationToken)
        );
    }
}
