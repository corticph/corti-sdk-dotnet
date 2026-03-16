using System.Text.Json;
using Corti.Core;

namespace Corti;

public partial class AuthClient : IAuthClient
{
    private readonly RawClient _client;

    internal AuthClient(RawClient client)
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

    private async Task<WithRawResponse<AuthTokenResponse>> GetTokenAsyncCore(
        OAuthTokenRequest request,
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
                            BaseUrl = _client.Options.Environment.Login,
                            Method = HttpMethod.Post,
                            Path = "fake-token",
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
                    var responseBody = await response
                        .Raw.Content.ReadAsStringAsync(cancellationToken)
                        .ConfigureAwait(false);
                    try
                    {
                        var responseData = JsonUtils.Deserialize<AuthTokenResponse>(responseBody)!;
                        return new WithRawResponse<AuthTokenResponse>()
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
                    throw new CortiClientApiException(
                        $"Error with status code {response.StatusCode}",
                        response.StatusCode,
                        responseBody
                    );
                }
            })
            .ConfigureAwait(false);
    }

    private async Task<WithRawResponse<AuthTokenResponse>> TokenAsyncCore(
        string tenantName,
        AuthTokenRequestBody request,
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
                            BaseUrl = _client.Options.Environment.Login,
                            Method = HttpMethod.Post,
                            Path = string.Format(
                                "{0}/protocol/openid-connect/token",
                                ValueConvert.ToPathParameterString(tenantName)
                            ),
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
                    var responseBody = await response
                        .Raw.Content.ReadAsStringAsync(cancellationToken)
                        .ConfigureAwait(false);
                    try
                    {
                        var responseData = JsonUtils.Deserialize<AuthTokenResponse>(responseBody)!;
                        return new WithRawResponse<AuthTokenResponse>()
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
                            case 401:
                                throw new UnauthorizedError(
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
    /// await client.Auth.GetTokenAsync(
    ///     new OAuthTokenRequest { ClientId = "client_id", ClientSecret = "client_secret" }
    /// );
    /// </code></example>
    public WithRawResponseTask<AuthTokenResponse> GetTokenAsync(
        OAuthTokenRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<AuthTokenResponse>(
            GetTokenAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Exchange credentials for a short-lived access token. Supports grant_type client_credentials (server-to-server),
    /// authorization_code (with client_secret), authorization_code with PKCE (code_verifier), password (ROPC), or refresh_token. Use the returned access_token in the Authorization header when calling the Corti API.
    /// </summary>
    /// <example><code>
    /// await client.Auth.TokenAsync(
    ///     "tenantName",
    ///     new AuthTokenRequestClientCredentials
    ///     {
    ///         ClientId = "client_id",
    ///         ClientSecret = "client_secret",
    ///         GrantType = "client_credentials",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<AuthTokenResponse> TokenAsync(
        string tenantName,
        AuthTokenRequestBody request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<AuthTokenResponse>(
            TokenAsyncCore(tenantName, request, options, cancellationToken)
        );
    }
}
