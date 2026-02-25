# Reference
## Auth
<details><summary><code>client.Auth.<a href="/src/CortiApi/Auth/AuthClient.cs">TokenAsync</a>(AuthTokenRequest { ... }) -> WithRawResponseTask&lt;AuthTokenResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Exchange client_id and client_secret for a short-lived access token (OAuth 2.0 client credentials).
Use the returned access_token in the Authorization header when calling the Corti API.
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
await client.Auth.TokenAsync(
    new AuthTokenRequest
    {
        ClientId = "client_id",
        ClientSecret = "client_secret",
        GrantType = "client_credentials",
        Scope = "openid",
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

**request:** `AuthTokenRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

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

<details><summary><code>client.Interactions.<a href="/src/CortiApi/Interactions/InteractionsClient.cs">GetAsync</a>(id) -> WithRawResponseTask&lt;InteractionsGetResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a previously recorded interaction by its unique identifier (interaction ID).
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
await client.Interactions.GetAsync("f47ac10b-58cc-4372-a567-0e02b2c3d479");
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

**id:** `string` — The unique identifier of the interaction. Must be a valid UUID.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Interactions.<a href="/src/CortiApi/Interactions/InteractionsClient.cs">DeleteAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes an existing interaction.
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
await client.Interactions.DeleteAsync("f47ac10b-58cc-4372-a567-0e02b2c3d479");
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

**id:** `string` — The unique identifier of the interaction. Must be a valid UUID.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Interactions.<a href="/src/CortiApi/Interactions/InteractionsClient.cs">UpdateAsync</a>(id, InteractionsUpdateRequest { ... }) -> WithRawResponseTask&lt;InteractionsGetResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Modifies an existing interaction by updating specific fields without overwriting the entire record.
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
await client.Interactions.UpdateAsync(
    "f47ac10b-58cc-4372-a567-0e02b2c3d479",
    new InteractionsUpdateRequest()
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

**id:** `string` — The unique identifier of the interaction. Must be a valid UUID.
    
</dd>
</dl>

<dl>
<dd>

**request:** `InteractionsUpdateRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Recordings
<details><summary><code>client.Recordings.<a href="/src/CortiApi/Recordings/RecordingsClient.cs">ListAsync</a>(id) -> WithRawResponseTask&lt;RecordingsListResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a list of recordings for a given interaction.
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
await client.Recordings.ListAsync("f47ac10b-58cc-4372-a567-0e02b2c3d479");
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

**id:** `string` — The unique identifier of the interaction. Must be a valid UUID.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Recordings.<a href="/src/CortiApi/Recordings/RecordingsClient.cs">GetAsync</a>(id, recordingId) -> WithRawResponseTask&lt;Stream&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a specific recording for a given interaction.
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
await client.Recordings.GetAsync("id", "recordingId");
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

**id:** `string` — The unique identifier of the interaction. Must be a valid UUID.
    
</dd>
</dl>

<dl>
<dd>

**recordingId:** `string` — The unique identifier of the recording. Must be a valid UUID.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Recordings.<a href="/src/CortiApi/Recordings/RecordingsClient.cs">DeleteAsync</a>(id, recordingId)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete a specific recording for a given interaction.
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
await client.Recordings.DeleteAsync(
    "f47ac10b-58cc-4372-a567-0e02b2c3d479",
    "f47ac10b-58cc-4372-a567-0e02b2c3d479"
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

**id:** `string` — The unique identifier of the interaction. Must be a valid UUID.
    
</dd>
</dl>

<dl>
<dd>

**recordingId:** `string` — The unique identifier of the recording. Must be a valid UUID.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Transcripts
<details><summary><code>client.Transcripts.<a href="/src/CortiApi/Transcripts/TranscriptsClient.cs">ListAsync</a>(id, TranscriptsListRequest { ... }) -> WithRawResponseTask&lt;TranscriptsListResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a list of transcripts for a given interaction.
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
await client.Transcripts.ListAsync(
    "f47ac10b-58cc-4372-a567-0e02b2c3d479",
    new TranscriptsListRequest()
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

**id:** `string` — The unique identifier of the interaction. Must be a valid UUID.
    
</dd>
</dl>

<dl>
<dd>

**request:** `TranscriptsListRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Transcripts.<a href="/src/CortiApi/Transcripts/TranscriptsClient.cs">CreateAsync</a>(id, TranscriptsCreateRequest { ... }) -> WithRawResponseTask&lt;TranscriptsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a transcript from an audio file attached, via `/recordings` endpoint, to the interaction.<br/><Note>Each interaction may have more than one audio file and transcript associated with it. While audio files up to 60min in total duration, or 150MB in total size, may be attached to an interaction, synchronous processing is only supported for audio files less than ~2min in duration.<br/><br/>If an audio file takes longer to transcribe than the 25sec synchronous processing timeout, then it will continue to process asynchronously. In this scenario, an incomplete or empty transcript with `status=processing` will be returned with a location header that can be used to retrieve the final transcript.<br/><br/>The client can poll the Get Transcript endpoint (`GET /interactions/{id}/transcripts/{transcriptId}/status`) for transcript status changes:<br/>- `200 OK` with status `processing`, `completed`, or `failed`<br/>- `404 Not Found` if the `interactionId` or `transcriptId` are invalid<br/><br/>The completed transcript can be retrieved via the Get Transcript endpoint (`GET /interactions/{id}/transcripts/{transcriptId}/`).</Note>
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
await client.Transcripts.CreateAsync(
    "f47ac10b-58cc-4372-a567-0e02b2c3d479",
    new TranscriptsCreateRequest
    {
        RecordingId = "f47ac10b-58cc-4372-a567-0e02b2c3d479",
        PrimaryLanguage = "en",
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

**id:** `string` — The unique identifier of the interaction. Must be a valid UUID.
    
</dd>
</dl>

<dl>
<dd>

**request:** `TranscriptsCreateRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Transcripts.<a href="/src/CortiApi/Transcripts/TranscriptsClient.cs">GetAsync</a>(id, transcriptId) -> WithRawResponseTask&lt;TranscriptsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a transcript from a specific interaction.<br/><Note>Each interaction may have more than one transcript associated with it. Use the List Transcript request (`GET /interactions/{id}/transcripts/`) to see all transcriptIds available for the interaction.<br/><br/>The client can poll this Get Transcript endpoint (`GET /interactions/{id}/transcripts/{transcriptId}/status`) for transcript status changes:<br/>- `200 OK` with status `processing`, `completed`, or `failed`<br/>- `404 Not Found` if the `interactionId` or `transcriptId` are invalid<br/><br/>Status of `completed` indicates the transcript is finalized. If the transcript is retrieved while status is `processing`, then it will be incomplete.</Note>
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
await client.Transcripts.GetAsync(
    "f47ac10b-58cc-4372-a567-0e02b2c3d479",
    "f47ac10b-58cc-4372-a567-0e02b2c3d479"
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

**id:** `string` — The unique identifier of the interaction. Must be a valid UUID.
    
</dd>
</dl>

<dl>
<dd>

**transcriptId:** `string` — The unique identifier of the transcript. Must be a valid UUID.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Transcripts.<a href="/src/CortiApi/Transcripts/TranscriptsClient.cs">DeleteAsync</a>(id, transcriptId)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a specific transcript associated with an interaction.
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
await client.Transcripts.DeleteAsync(
    "f47ac10b-58cc-4372-a567-0e02b2c3d479",
    "f47ac10b-58cc-4372-a567-0e02b2c3d479"
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

**id:** `string` — The unique identifier of the interaction. Must be a valid UUID.
    
</dd>
</dl>

<dl>
<dd>

**transcriptId:** `string` — The unique identifier of the transcript. Must be a valid UUID.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Transcripts.<a href="/src/CortiApi/Transcripts/TranscriptsClient.cs">GetStatusAsync</a>(id, transcriptId) -> WithRawResponseTask&lt;TranscriptsStatusResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Poll for transcript creation status.<br/><Note>Status of `completed` indicates the transcript is finalized.<br/>If the transcript is retrieved while status is `processing`, then it will be incomplete.<br/>Status of `failed` indicate the transcript was not created successfully; please retry.</Note>
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
await client.Transcripts.GetStatusAsync(
    "f47ac10b-58cc-4372-a567-0e02b2c3d479",
    "f47ac10b-58cc-4372-a567-0e02b2c3d479"
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

**id:** `string` — The unique identifier of the interaction. Must be a valid UUID.
    
</dd>
</dl>

<dl>
<dd>

**transcriptId:** `string` — The unique identifier of the transcript. Must be a valid UUID.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Facts
<details><summary><code>client.Facts.<a href="/src/CortiApi/Facts/FactsClient.cs">FactGroupsListAsync</a>() -> WithRawResponseTask&lt;FactsFactGroupsListResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a list of available fact groups, used to categorize facts associated with an interaction.
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
await client.Facts.FactGroupsListAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Facts.<a href="/src/CortiApi/Facts/FactsClient.cs">ListAsync</a>(id) -> WithRawResponseTask&lt;FactsListResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a list of facts for a given interaction.
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
await client.Facts.ListAsync("f47ac10b-58cc-4372-a567-0e02b2c3d479");
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

**id:** `string` — The unique identifier of the interaction. Must be a valid UUID.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Facts.<a href="/src/CortiApi/Facts/FactsClient.cs">CreateAsync</a>(id, FactsCreateRequest { ... }) -> WithRawResponseTask&lt;FactsCreateResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Adds new facts to an interaction.
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
await client.Facts.CreateAsync(
    "f47ac10b-58cc-4372-a567-0e02b2c3d479",
    new FactsCreateRequest
    {
        Facts = new List<FactsCreateInput>()
        {
            new FactsCreateInput { Text = "text", Group = "other" },
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

**id:** `string` — The unique identifier of the interaction. Must be a valid UUID.
    
</dd>
</dl>

<dl>
<dd>

**request:** `FactsCreateRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Facts.<a href="/src/CortiApi/Facts/FactsClient.cs">BatchUpdateAsync</a>(id, FactsBatchUpdateRequest { ... }) -> WithRawResponseTask&lt;FactsBatchUpdateResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates multiple facts associated with an interaction.
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
await client.Facts.BatchUpdateAsync(
    "f47ac10b-58cc-4372-a567-0e02b2c3d479",
    new FactsBatchUpdateRequest
    {
        Facts = new List<FactsBatchUpdateInput>()
        {
            new FactsBatchUpdateInput { FactId = "3c9d8a12-7f44-4b3e-9e6f-9271c2bbfa08" },
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

**id:** `string` — The unique identifier of the interaction. Must be a valid UUID.
    
</dd>
</dl>

<dl>
<dd>

**request:** `FactsBatchUpdateRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Facts.<a href="/src/CortiApi/Facts/FactsClient.cs">UpdateAsync</a>(id, factId, FactsUpdateRequest { ... }) -> WithRawResponseTask&lt;FactsUpdateResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates an existing fact associated with a specific interaction.
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
await client.Facts.UpdateAsync(
    "f47ac10b-58cc-4372-a567-0e02b2c3d479",
    "3c9d8a12-7f44-4b3e-9e6f-9271c2bbfa08",
    new FactsUpdateRequest()
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

**id:** `string` — The unique identifier of the interaction. Must be a valid UUID.
    
</dd>
</dl>

<dl>
<dd>

**factId:** `string` — The unique identifier of the fact to update. Must be a valid UUID.
    
</dd>
</dl>

<dl>
<dd>

**request:** `FactsUpdateRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Facts.<a href="/src/CortiApi/Facts/FactsClient.cs">ExtractAsync</a>(FactsExtractRequest { ... }) -> WithRawResponseTask&lt;FactsExtractResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Extract facts from provided text, without storing them.
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
await client.Facts.ExtractAsync(
    new FactsExtractRequest
    {
        Context = new List<CommonTextContext>()
        {
            new CommonTextContext { Type = CommonTextContextType.Text, Text = "text" },
        },
        OutputLanguage = "outputLanguage",
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

**request:** `FactsExtractRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Documents
<details><summary><code>client.Documents.<a href="/src/CortiApi/Documents/DocumentsClient.cs">ListAsync</a>(id) -> WithRawResponseTask&lt;DocumentsListResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

List Documents
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
await client.Documents.ListAsync("f47ac10b-58cc-4372-a567-0e02b2c3d479");
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

**id:** `string` — The unique identifier of the interaction. Must be a valid UUID.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Documents.<a href="/src/CortiApi/Documents/DocumentsClient.cs">CreateAsync</a>(id, DocumentsCreateRequest { ... }) -> WithRawResponseTask&lt;DocumentsGetResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This endpoint offers different ways to generate a document. Find guides to document generation [here](/textgen/documents-standard).
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
await client.Documents.CreateAsync(
    "f47ac10b-58cc-4372-a567-0e02b2c3d479",
    new DocumentsCreateRequestWithTemplateKey
    {
        Context = new List<DocumentsContext>()
        {
            new DocumentsContextWithFacts
            {
                Type = DocumentsContextWithFactsType.Facts,
                Data = new List<FactsContext>()
                {
                    new FactsContext { Text = "text", Source = CommonSourceEnum.Core },
                },
            },
        },
        TemplateKey = "templateKey",
        OutputLanguage = "outputLanguage",
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

**id:** `string` — The unique identifier of the interaction. Must be a valid UUID.
    
</dd>
</dl>

<dl>
<dd>

**request:** `DocumentsCreateRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Documents.<a href="/src/CortiApi/Documents/DocumentsClient.cs">GetAsync</a>(id, documentId) -> WithRawResponseTask&lt;DocumentsGetResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get Document.
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
await client.Documents.GetAsync(
    "f47ac10b-58cc-4372-a567-0e02b2c3d479",
    "f47ac10b-58cc-4372-a567-0e02b2c3d479"
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

**id:** `string` — The unique identifier of the interaction. Must be a valid UUID.
    
</dd>
</dl>

<dl>
<dd>

**documentId:** `string` — The document ID representing the context for the request. Must be a valid UUID.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Documents.<a href="/src/CortiApi/Documents/DocumentsClient.cs">DeleteAsync</a>(id, documentId)</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Documents.DeleteAsync(
    "f47ac10b-58cc-4372-a567-0e02b2c3d479",
    "f47ac10b-58cc-4372-a567-0e02b2c3d479"
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

**id:** `string` — The unique identifier of the interaction. Must be a valid UUID.
    
</dd>
</dl>

<dl>
<dd>

**documentId:** `string` — The document ID representing the context for the request. Must be a valid UUID.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Documents.<a href="/src/CortiApi/Documents/DocumentsClient.cs">UpdateAsync</a>(id, documentId, DocumentsUpdateRequest { ... }) -> WithRawResponseTask&lt;DocumentsGetResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Documents.UpdateAsync(
    "f47ac10b-58cc-4372-a567-0e02b2c3d479",
    "f47ac10b-58cc-4372-a567-0e02b2c3d479",
    new DocumentsUpdateRequest()
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

**id:** `string` — The unique identifier of the interaction. Must be a valid UUID.
    
</dd>
</dl>

<dl>
<dd>

**documentId:** `string` — The document ID representing the context for the request. Must be a valid UUID.
    
</dd>
</dl>

<dl>
<dd>

**request:** `DocumentsUpdateRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Templates
<details><summary><code>client.Templates.<a href="/src/CortiApi/Templates/TemplatesClient.cs">SectionListAsync</a>(TemplatesSectionListRequest { ... }) -> WithRawResponseTask&lt;TemplatesSectionListResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a list of template sections with optional filters for organization and language.
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
await client.Templates.SectionListAsync(new TemplatesSectionListRequest());
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

**request:** `TemplatesSectionListRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Templates.<a href="/src/CortiApi/Templates/TemplatesClient.cs">ListAsync</a>(TemplatesListRequest { ... }) -> WithRawResponseTask&lt;TemplatesListResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a list of templates with optional filters for organization, language, and status.
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
await client.Templates.ListAsync(new TemplatesListRequest());
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

**request:** `TemplatesListRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Templates.<a href="/src/CortiApi/Templates/TemplatesClient.cs">GetAsync</a>(key) -> WithRawResponseTask&lt;TemplatesItem&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves template by key.
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
await client.Templates.GetAsync("key");
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

**key:** `string` — The key of the template
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Codes
<details><summary><code>client.Codes.<a href="/src/CortiApi/Codes/CodesClient.cs">PredictAsync</a>(CodesGeneralPredictRequest { ... }) -> WithRawResponseTask&lt;CodesGeneralResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Predict medical codes from provided context.<br/><Note>This is a stateless endpoint, designed to predict ICD-10-CM, ICD-10-PCS, and CPT codes based on input text string or documentId.<br/><br/>More than one code system may be defined in a single request, and the maximum number of codes to return per system can also be defined.<br/><br/>Code prediction requests have two possible values for context:<br/>- `text`: One set of code prediction results will be returned based on all input text defined.<br/>- `documentId`: Code prediction will be based on that defined document only.<br/><br/>The response includes two sets of results:<br/>- `Codes`: Highest confidence bundle of codes, as selected by the code prediction model<br/>- `Candidates`: Full list of candidate codes as predicted by the model, rank sorted by model confidence with maximum possible value of 50.<br/><br/>All predicted code results are based on input context defined in the request only (not other external data or assets associated with an interaction).</Note>
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
await client.Codes.PredictAsync(
    new CodesGeneralPredictRequest
    {
        System = new List<CommonCodingSystemEnum>()
        {
            CommonCodingSystemEnum.Icd10Cm,
            CommonCodingSystemEnum.Cpt,
        },
        Context = new List<CommonAiContext>()
        {
            new CommonTextContext
            {
                Type = CommonTextContextType.Text,
                Text = "Short arm splint applied in ED for pain control.",
            },
        },
        MaxCandidates = 5,
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

**request:** `CodesGeneralPredictRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Agents
<details><summary><code>client.Agents.<a href="/src/CortiApi/Agents/AgentsClient.cs">ListAsync</a>(AgentsListRequest { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;AgentsAgentResponse&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This endpoint retrieves a list of all agents that can be called by the Corti Agent Framework.
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
await client.Agents.ListAsync(new AgentsListRequest());
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

**request:** `AgentsListRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Agents.<a href="/src/CortiApi/Agents/AgentsClient.cs">CreateAsync</a>(AgentsCreateAgent { ... }) -> WithRawResponseTask&lt;AgentsAgent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This endpoint allows the creation of a new agent that can be utilized in the `POST /agents/{id}/v1/message:send` endpoint.
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
await client.Agents.CreateAsync(
    new AgentsCreateAgent { Name = "name", Description = "description" }
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

**request:** `AgentsCreateAgent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Agents.<a href="/src/CortiApi/Agents/AgentsClient.cs">GetAsync</a>(id) -> WithRawResponseTask&lt;AgentsAgentResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This endpoint retrieves an agent by its identifier. The agent contains information about its capabilities and the experts it can call.
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
await client.Agents.GetAsync("12345678-90ab-cdef-gh12-34567890abc");
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

**id:** `string` — The identifier of the agent associated with the context.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Agents.<a href="/src/CortiApi/Agents/AgentsClient.cs">DeleteAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This endpoint deletes an agent by its identifier. Once deleted, the agent can no longer be used in threads.
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
await client.Agents.DeleteAsync("12345678-90ab-cdef-gh12-34567890abc");
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

**id:** `string` — The identifier of the agent associated with the context.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Agents.<a href="/src/CortiApi/Agents/AgentsClient.cs">UpdateAsync</a>(id, AgentsAgent { ... }) -> WithRawResponseTask&lt;AgentsAgent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This endpoint updates an existing agent. Only the fields provided in the request body will be updated; other fields will remain unchanged.
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
await client.Agents.UpdateAsync(
    "12345678-90ab-cdef-gh12-34567890abc",
    new AgentsAgent
    {
        Id = "id",
        Name = "name",
        Description = "description",
        SystemPrompt = "systemPrompt",
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

**id:** `string` — The identifier of the agent associated with the context.
    
</dd>
</dl>

<dl>
<dd>

**request:** `AgentsAgent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Agents.<a href="/src/CortiApi/Agents/AgentsClient.cs">GetCardAsync</a>(id) -> WithRawResponseTask&lt;AgentsAgentCard&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This endpoint retrieves the agent card in JSON format, which provides metadata about the agent, including its name, description, and the experts it can call.
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
await client.Agents.GetCardAsync("12345678-90ab-cdef-gh12-34567890abc");
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

**id:** `string` — The identifier of the agent associated with the context.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Agents.<a href="/src/CortiApi/Agents/AgentsClient.cs">MessageSendAsync</a>(id, AgentsMessageSendParams { ... }) -> WithRawResponseTask&lt;AgentsMessageSendResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This endpoint sends a message to the specified agent to start or continue a task. The agent processes the message and returns a response. If the message contains a task ID that matches an ongoing task, the agent will continue that task; otherwise, it will start a new task.
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
await client.Agents.MessageSendAsync(
    "12345678-90ab-cdef-gh12-34567890abc",
    new AgentsMessageSendParams
    {
        Message = new AgentsMessage
        {
            Role = AgentsMessageRole.User,
            Parts = new List<AgentsPart>()
            {
                new AgentsTextPart { Kind = AgentsTextPartKind.Text, Text = "text" },
            },
            MessageId = "messageId",
            Kind = AgentsMessageKind.Message,
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

**id:** `string` — The identifier of the agent associated with the context.
    
</dd>
</dl>

<dl>
<dd>

**request:** `AgentsMessageSendParams` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Agents.<a href="/src/CortiApi/Agents/AgentsClient.cs">GetTaskAsync</a>(id, taskId, AgentsGetTaskRequest { ... }) -> WithRawResponseTask&lt;AgentsTask&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This endpoint retrieves the status and details of a specific task associated with the given agent. It provides information about the task's current state, history, and any artifacts produced during its execution.
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
await client.Agents.GetTaskAsync(
    "12345678-90ab-cdef-gh12-34567890abc",
    "taskId",
    new AgentsGetTaskRequest()
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

**id:** `string` — The identifier of the agent associated with the context.
    
</dd>
</dl>

<dl>
<dd>

**taskId:** `string` — The identifier of the task to retrieve.
    
</dd>
</dl>

<dl>
<dd>

**request:** `AgentsGetTaskRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Agents.<a href="/src/CortiApi/Agents/AgentsClient.cs">GetContextAsync</a>(id, contextId, AgentsGetContextRequest { ... }) -> WithRawResponseTask&lt;AgentsContext&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This endpoint retrieves all tasks and top-level messages associated with a specific context for the given agent.
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
await client.Agents.GetContextAsync(
    "12345678-90ab-cdef-gh12-34567890abc",
    "contextId",
    new AgentsGetContextRequest()
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

**id:** `string` — The identifier of the agent associated with the context.
    
</dd>
</dl>

<dl>
<dd>

**contextId:** `string` — The identifier of the context (thread) to retrieve tasks for.
    
</dd>
</dl>

<dl>
<dd>

**request:** `AgentsGetContextRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Agents.<a href="/src/CortiApi/Agents/AgentsClient.cs">GetRegistryExpertsAsync</a>(AgentsGetRegistryExpertsRequest { ... }) -> WithRawResponseTask&lt;AgentsRegistryExpertsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This endpoint retrieves the experts registry, which contains information about all available experts that can be referenced when creating agents through the AgentsCreateExpertReference schema.
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
await client.Agents.GetRegistryExpertsAsync(
    new AgentsGetRegistryExpertsRequest { Limit = 100, Offset = 0 }
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

**request:** `AgentsGetRegistryExpertsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>
