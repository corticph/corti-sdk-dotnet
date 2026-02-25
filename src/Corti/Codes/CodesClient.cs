using System.Text.Json;
using Corti.Core;

namespace Corti;

public partial class CodesClient
{
    private RawClient _client;

    internal CodesClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Predict medical codes from provided context.&lt;br/&gt;&lt;Note&gt;This is a stateless endpoint, designed to predict ICD-10-CM, ICD-10-PCS, and CPT codes based on input text string or documentId.&lt;br/&gt;&lt;br/&gt;More than one code system may be defined in a single request, and the maximum number of codes to return per system can also be defined.&lt;br/&gt;&lt;br/&gt;Code prediction requests have two possible values for context:&lt;br/&gt;- `text`: One set of code prediction results will be returned based on all input text defined.&lt;br/&gt;- `documentId`: Code prediction will be based on that defined document only.&lt;br/&gt;&lt;br/&gt;The response includes two sets of results:&lt;br/&gt;- `Codes`: Highest confidence bundle of codes, as selected by the code prediction model&lt;br/&gt;- `Candidates`: Full list of candidate codes as predicted by the model, rank sorted by model confidence with maximum possible value of 50.&lt;br/&gt;&lt;br/&gt;All predicted code results are based on input context defined in the request only (not other external data or assets associated with an interaction).&lt;/Note&gt;
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
    ///             new CommonAiContext(
    ///                 new Corti.CommonAiContext.Text(
    ///                     new Corti.Text { Type = CommonTextContextType.Text, Text_ = "text" }
    ///                 )
    ///             ),
    ///         },
    ///         MaxCandidates = 5,
    ///     }
    /// );
    /// </code></example>
    public async Task<CodesGeneralResponse> PredictAsync(
        CodesGeneralPredictRequest request,
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
                    Path = "tools/coding/",
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
                return JsonUtils.Deserialize<CodesGeneralResponse>(responseBody)!;
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
}
