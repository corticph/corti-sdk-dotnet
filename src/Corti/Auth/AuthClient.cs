using System.Text.Json;
using Corti.Core;

namespace Corti;

public partial class AuthClient
{
    private RawClient _client;

    internal AuthClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Exchange client_id and client_secret for a short-lived access token (OAuth 2.0 client credentials).
    /// Use the returned access_token in the Authorization header when calling the Corti API.
    /// </summary>
    /// <example><code>
    /// await client.Auth.TokenAsync(
    ///     new AuthTokenRequest
    ///     {
    ///         ClientId = "client_id",
    ///         ClientSecret = "client_secret",
    ///         GrantType = "client_credentials",
    ///         Scope = "openid",
    ///     }
    /// );
    /// </code></example>
    public async Task<AuthTokenResponse> TokenAsync(
        AuthTokenRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.Environment.Login,
                    Method = HttpMethod.Post,
                    Path = "protocol/openid-connect/token",
                    Body = request,
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
                return JsonUtils.Deserialize<AuthTokenResponse>(responseBody)!;
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
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
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
