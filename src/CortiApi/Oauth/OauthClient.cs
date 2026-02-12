using System.Text.Json;
using CortiApi.Core;

namespace CortiApi;

public partial class OauthClient : IOauthClient
{
    private RawClient _client;

    internal OauthClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<GetTokenOauthResponse>> GetTokenAsyncCore(
        GetTokenOauthRequest request,
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
                new FormRequest
                {
                    BaseUrl = _client.Options.Environment.Login,
                    Method = HttpMethod.Post,
                    Path = "token",
                    Body = request,
                    Headers = _headers,
                    ContentType = "application/x-www-form-urlencoded",
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
                var responseData = JsonUtils.Deserialize<GetTokenOauthResponse>(responseBody)!;
                return new WithRawResponse<GetTokenOauthResponse>()
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
            throw new CortiClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Minimal endpoint for Fern OAuth; implementation should call the real token endpoint.
    /// </summary>
    /// <example><code>
    /// await client.Oauth.GetTokenAsync(
    ///     new GetTokenOauthRequest { ClientId = "client_id", ClientSecret = "client_secret" }
    /// );
    /// </code></example>
    public WithRawResponseTask<GetTokenOauthResponse> GetTokenAsync(
        GetTokenOauthRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetTokenOauthResponse>(
            GetTokenAsyncCore(request, options, cancellationToken)
        );
    }
}
