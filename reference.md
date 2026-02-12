# Reference
## Interactions
<details><summary><code>client.Interactions.<a href="/src/CortiApi/Interactions/InteractionsClient.cs">ListAsync</a>(InteractionsListRequest { ... }) -> Pager&lt;InteractionsGetResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Lists all existing interactions. Results can be filtered by encounter status and patient identifier.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Interactions.ListAsync(new InteractionsListRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `InteractionsListRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Interactions.<a href="/src/CortiApi/Interactions/InteractionsClient.cs">CreateAsync</a>(InteractionsCreateRequest { ... }) -> WithRawResponseTask&lt;InteractionsCreateResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a new interaction.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
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
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `InteractionsCreateRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Auth
<details><summary><code>client.Auth.<a href="/src/CortiApi/Auth/AuthClient.cs">GetTokenAsync</a>(GetTokenAuthRequest { ... }) -> WithRawResponseTask&lt;GetTokenResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Obtain an OAuth2 access token. Supports multiple grant types (client_credentials, authorization_code, refresh_token, password).
The path parameter tenantName (realm) identifies the Keycloak realm; use the same value as the Tenant-Name header for API requests.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Auth.GetTokenAsync(
    new GetTokenAuthRequest
    {
        TenantName = "base",
        Body = new GetTokenRequestClientCredentials
        {
            GrantType = "client_credentials",
            ClientId = "client_id_123",
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetTokenAuthRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Oauth
<details><summary><code>client.Oauth.<a href="/src/CortiApi/Oauth/OauthClient.cs">GetTokenAsync</a>(GetTokenOauthRequest { ... }) -> WithRawResponseTask&lt;GetTokenOauthResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Minimal endpoint for Fern OAuth; implementation should call the real token endpoint.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Oauth.GetTokenAsync(
    new GetTokenOauthRequest { ClientId = "client_id", ClientSecret = "client_secret" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetTokenOauthRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>
