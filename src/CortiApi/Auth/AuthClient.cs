using System.Text.Json;
using CortiApi.Core;

namespace CortiApi;

public partial class AuthClient : IAuthClient
{
    private RawClient _client;

    internal AuthClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<GetTokenResponse>> GetTokenAsyncCore(
        GetTokenAuthRequest request,
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
                    Path = "protocol/openid-connect/token",
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
                var responseData = JsonUtils.Deserialize<GetTokenResponse>(responseBody)!;
                return new WithRawResponse<GetTokenResponse>()
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
                throw new CortiApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new CortiApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Obtain an OAuth2 access token using client credentials
    /// </summary>
    /// <example><code>
    /// await client.Auth.GetTokenAsync(
    ///     new GetTokenAuthRequest
    ///     {
    ///         ClientId = "client_id_123",
    ///         ClientSecret = "my_secret_value",
    ///         Scope = "openid",
    ///         GrantType = "client_credentials",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<GetTokenResponse> GetTokenAsync(
        GetTokenAuthRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetTokenResponse>(
            GetTokenAsyncCore(request, options, cancellationToken)
        );
    }
}
