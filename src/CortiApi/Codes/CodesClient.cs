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

    private async Task<WithRawResponse<ResponseCodesList>> ListCodesAsyncCore(
        GetInteractionsIdCodesRequest request,
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
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "interactions/{0}/codes/",
                        ValueConvert.ToPathParameterString(request.Id)
                    ),
                    Headers = _headers,
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
                var responseData = JsonUtils.Deserialize<ResponseCodesList>(responseBody)!;
                return new WithRawResponse<ResponseCodesList>()
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
                        throw new BadRequestError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
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

    private async Task<WithRawResponse<ResponseCodesList>> GenerateCodesAsyncCore(
        RequestCodesPredict request,
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
                    Path = string.Format(
                        "interactions/{0}/codes/",
                        ValueConvert.ToPathParameterString(request.Id)
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
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                var responseData = JsonUtils.Deserialize<ResponseCodesList>(responseBody)!;
                return new WithRawResponse<ResponseCodesList>()
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
                        throw new BadRequestError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
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

    private async Task<WithRawResponse<ResponseCodesList>> SelectCodesAsyncCore(
        RequestCodesUpdate request,
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
                    Method = HttpMethod.Put,
                    Path = string.Format(
                        "interactions/{0}/codes/",
                        ValueConvert.ToPathParameterString(request.Id)
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
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                var responseData = JsonUtils.Deserialize<ResponseCodesList>(responseBody)!;
                return new WithRawResponse<ResponseCodesList>()
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
                        throw new BadRequestError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
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
                        throw new BadRequestError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
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
    /// `Limited Access - Contact us for more information`<br/><br/>List predicted codes within the context of an interaction.<br/>&lt;Note&gt;This endpoint is only accessible within specific customer tenants. It is not available in the public API.<br/><br/>For stateless code prediction based on input text string or documentId, please refer to the [Predict Codes](/api-reference/codes/predict-codes) API, or [contact us](https://help.corti.app) for more information.&lt;/Note&gt;
    /// </summary>
    /// <example><code>
    /// await client.Codes.ListCodesAsync(
    ///     new GetInteractionsIdCodesRequest { Id = "f47ac10b-58cc-4372-a567-0e02b2c3d479" }
    /// );
    /// </code></example>
    public WithRawResponseTask<ResponseCodesList> ListCodesAsync(
        GetInteractionsIdCodesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ResponseCodesList>(
            ListCodesAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// `Limited Access - Contact us for more information`<br/><br/>Generate codes within the context of an interaction.<br/>&lt;Note&gt;This endpoint is only accessible within specific customer tenants. It is not available in the public API.<br/><br/>For stateless code prediction based on input text string or documentId, please refer to the [Predict Codes](/api-reference/codes/predict-codes) API, or [contact us](https://help.corti.app) for more information.&lt;/Note&gt;
    /// </summary>
    /// <example><code>
    /// await client.Codes.GenerateCodesAsync(
    ///     new RequestCodesPredict
    ///     {
    ///         Id = "f47ac10b-58cc-4372-a567-0e02b2c3d479",
    ///         ModelName = "\"geography_modelName (Latest)\" | \"geography_modelName_version\"",
    ///         Context = new CodesContext { Type = CodesContextTypeEnum.String, Data = "data" },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<ResponseCodesList> GenerateCodesAsync(
        RequestCodesPredict request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ResponseCodesList>(
            GenerateCodesAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// `Limited Access - Contact us for more information`<br/><br/>Select predicted codes within the context of an interaction.<br/>&lt;Note&gt;This endpoint is only accessible within specific customer tenants. It is not available in the public API.<br/><br/>For stateless code prediction based on input text string or documentId, please refer to the [Predict Codes](/api-reference/codes/predict-codes) API, or [contact us](https://help.corti.app) for more information.&lt;/Note&gt;
    /// </summary>
    /// <example><code>
    /// await client.Codes.SelectCodesAsync(
    ///     new RequestCodesUpdate { Id = "f47ac10b-58cc-4372-a567-0e02b2c3d479" }
    /// );
    /// </code></example>
    public WithRawResponseTask<ResponseCodesList> SelectCodesAsync(
        RequestCodesUpdate request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ResponseCodesList>(
            SelectCodesAsyncCore(request, options, cancellationToken)
        );
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
    ///         Context = new List&lt;OneOf&lt;CommonTextContext, CommonDocumentIdContext&gt;&gt;()
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
