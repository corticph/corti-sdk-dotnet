# Corti C# Library

[![fern shield](https://img.shields.io/badge/%F0%9F%8C%BF-Built%20with%20Fern-brightgreen)](https://buildwithfern.com?utm_source=github&utm_medium=github&utm_campaign=readme&utm_source=https%3A%2F%2Fgithub.com%2Fcorticph%2Fcorti-sdk-dotnet)
[![nuget shield](https://img.shields.io/nuget/v/Corti.Sdk)](https://nuget.org/packages/Corti.Sdk)

The Corti C# library provides convenient access to the Corti APIs from C#.

## Table of Contents

- [Documentation](#documentation)
- [Requirements](#requirements)
- [Installation](#installation)
- [Usage](#usage)
- [Authentication](#authentication)
- [Exception Handling](#exception-handling)
- [Pagination](#pagination)
- [Advanced](#advanced)
  - [Retries](#retries)
  - [Timeouts](#timeouts)
  - [Raw Response](#raw-response)
  - [Additional Headers](#additional-headers)
  - [Additional Query Parameters](#additional-query-parameters)
  - [Forward Compatible Enums](#forward-compatible-enums)
- [Contributing](#contributing)

## Documentation

API reference documentation is available [here](https://docs.corti.ai/api-reference).

## Requirements

This SDK requires:

## Installation

```sh
dotnet add package Corti.Sdk
```

## Usage

Instantiate and use the client with the following:

```csharp
using Corti;

var client = new CortiClient("TENANT_NAME", "YOUR_ENVIRONMENT_ID", new CortiClientAuth.ClientCredentials("CLIENT_ID", "CLIENT_SECRET"));
await client.Interactions.CreateAsync(
    new InteractionsCreateRequest
    {
        Encounter = new InteractionsEncounterCreateRequest
        {
            Identifier = "identifier",
            Status = InteractionsEncounterStatusEnum.Planned,
            Type = InteractionsEncounterTypeEnum.FirstConsultation,
        },
    }
);
```

## Authentication

The SDK supports several OAuth 2.0 flows. In all cases the SDK manages tokens in memory — before each request it checks whether the stored access token is still valid, and if not, calls the appropriate token endpoint transparently. No manual token management is needed.

### Client Credentials (recommended for server-side apps)

The SDK fetches and refreshes tokens automatically using your client credentials.

```csharp
var client = new CortiClient(
    "YOUR_TENANT_NAME",
    "YOUR_ENVIRONMENT_ID",
    new CortiClientAuth.ClientCredentials("YOUR_CLIENT_ID", "YOUR_CLIENT_SECRET")
);
```

### Bearer token (pre-obtained)

Use when you already have a valid access token. Pass `ClientId` + `RefreshToken` to enable automatic renewal when the token expires.

```csharp
// Static token — no automatic renewal
var client = new CortiClient(new CortiClientAuth.Bearer("YOUR_ACCESS_TOKEN"));

// Token with automatic refresh via stored refresh token
var client = new CortiClient(new CortiClientAuth.Bearer(
    AccessToken: "YOUR_ACCESS_TOKEN",
    ClientId: "YOUR_CLIENT_ID",
    RefreshToken: "YOUR_REFRESH_TOKEN",
    ExpiresIn: 300,          // seconds until access token expires
    RefreshExpiresIn: 1800   // seconds until refresh token expires
));
```

### Bearer token with custom refresh

Use when your application manages token renewal (e.g. via a proxy or an external identity provider). The SDK calls `RefreshAccessToken` whenever the stored token expires.

```csharp
var client = new CortiClient(new CortiClientAuth.BearerCustomRefresh(
    RefreshAccessToken: async (refreshToken, ct) =>
    {
        // call your own token endpoint and return the new token
        return new CustomRefreshResult { AccessToken = "NEW_TOKEN", ExpiresIn = 300 };
    },
    AccessToken: "YOUR_ACCESS_TOKEN"
));
```

### Resource Owner Password Credentials (ROPC)

```csharp
var client = new CortiClient(
    "YOUR_TENANT_NAME",
    "YOUR_ENVIRONMENT_ID",
    new CortiClientAuth.Ropc("YOUR_CLIENT_ID", "USERNAME", "PASSWORD")
);
```

### Authorization Code

```csharp
var client = new CortiClient(
    "YOUR_TENANT_NAME",
    "YOUR_ENVIRONMENT_ID",
    new CortiClientAuth.AuthorizationCode("YOUR_CLIENT_ID", "YOUR_CLIENT_SECRET", "AUTH_CODE", "YOUR_REDIRECT_URI")
);
```

### PKCE

```csharp
var client = new CortiClient(
    "YOUR_TENANT_NAME",
    "YOUR_ENVIRONMENT_ID",
    new CortiClientAuth.Pkce("YOUR_CLIENT_ID", "AUTH_CODE", "YOUR_REDIRECT_URI", "YOUR_CODE_VERIFIER")
);
```

## Exception Handling

When the API returns a non-success status code (4xx or 5xx response), a subclass of the following error
will be thrown.

```csharp
using Corti;

try {
    var response = await client.Interactions.CreateAsync(...);
} catch (CortiClientApiException e) {
    System.Console.WriteLine(e.Body);
    System.Console.WriteLine(e.StatusCode);
}
```

## Pagination

List endpoints are paginated. The SDK provides an async enumerable so that you can simply loop over the items:

```csharp
using Corti;

var client = new CortiClient("TENANT_NAME", "YOUR_ENVIRONMENT_ID", new CortiClientAuth.ClientCredentials("CLIENT_ID", "CLIENT_SECRET"));
var items = await client.Interactions.ListAsync(new InteractionsListRequest());

await foreach (var item in items)
{
    // do something with item
}
```

## Advanced

### Retries

The SDK is instrumented with automatic retries with exponential backoff. A request will be retried as long
as the request is deemed retryable and the number of retry attempts has not grown larger than the configured
retry limit (default: 2).

A request is deemed retryable when any of the following HTTP status codes is returned:

- [408](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/408) (Timeout)
- [429](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/429) (Too Many Requests)
- [5XX](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/500) (Internal Server Errors)

Use the `MaxRetries` request option to configure this behavior.

```csharp
var response = await client.Interactions.CreateAsync(
    ...,
    new RequestOptions {
        MaxRetries: 0 // Override MaxRetries at the request level
    }
);
```

### Timeouts

The SDK defaults to a 30 second timeout. Use the `Timeout` option to configure this behavior.

```csharp
var response = await client.Interactions.CreateAsync(
    ...,
    new RequestOptions {
        Timeout: TimeSpan.FromSeconds(3) // Override timeout to 3s
    }
);
```

### Raw Response

Access raw HTTP response data (status code, headers, URL) alongside parsed response data using the `.WithRawResponse()` method.

```csharp
using Corti;

// Access raw response data (status code, headers, etc.) alongside the parsed response
var result = await client.Interactions.CreateAsync(...).WithRawResponse();

// Access the parsed data
var data = result.Data;

// Access raw response metadata
var statusCode = result.RawResponse.StatusCode;
var headers = result.RawResponse.Headers;
var url = result.RawResponse.Url;

// Access specific headers (case-insensitive)
if (headers.TryGetValue("X-Request-Id", out var requestId))
{
    System.Console.WriteLine($"Request ID: {requestId}");
}

// For the default behavior, simply await without .WithRawResponse()
var data = await client.Interactions.CreateAsync(...);
```

### Additional Headers

If you would like to send additional headers as part of the request, use the `AdditionalHeaders` request option.

```csharp
var response = await client.Interactions.CreateAsync(
    ...,
    new RequestOptions {
        AdditionalHeaders = new Dictionary<string, string?>
        {
            { "X-Custom-Header", "custom-value" }
        }
    }
);
```

### Additional Query Parameters

If you would like to send additional query parameters as part of the request, use the `AdditionalQueryParameters` request option.

```csharp
var response = await client.Interactions.CreateAsync(
    ...,
    new RequestOptions {
        AdditionalQueryParameters = new Dictionary<string, string>
        {
            { "custom_param", "custom-value" }
        }
    }
);
```

### Forward Compatible Enums

This SDK uses forward-compatible enums that can handle unknown values gracefully.

```csharp
using Corti;

// Using a built-in value
var interactionsListRequestSort = InteractionsListRequestSort.Id;

// Using a custom value
var customInteractionsListRequestSort = InteractionsListRequestSort.FromCustom("custom-value");

// Using in a switch statement
switch (interactionsListRequestSort.Value)
{
    case InteractionsListRequestSort.Values.Id:
        Console.WriteLine("Id");
        break;
    default:
        Console.WriteLine($"Unknown value: {interactionsListRequestSort.Value}");
        break;
}

// Explicit casting
string interactionsListRequestSortString = (string)InteractionsListRequestSort.Id;
InteractionsListRequestSort interactionsListRequestSortFromString = (InteractionsListRequestSort)"id";
```

## Contributing

While we value open-source contributions to this SDK, this library is generated programmatically.
Additions made directly to this library would have to be moved over to our generation code,
otherwise they would be overwritten upon the next generated release. Feel free to open a PR as
a proof of concept, but know that we will not be able to merge it as-is. We suggest opening
an issue first to discuss with us!

On the other hand, contributions to the README are always very welcome!
