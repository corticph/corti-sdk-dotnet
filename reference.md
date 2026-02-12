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

<details><summary><code>client.Interactions.<a href="/src/CortiApi/Interactions/InteractionsClient.cs">GetAsync</a>(InteractionsGetRequest { ... }) -> WithRawResponseTask&lt;InteractionsGetResponse&gt;</code></summary>
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
await client.Interactions.GetAsync(
    new InteractionsGetRequest { Id = "f47ac10b-58cc-4372-a567-0e02b2c3d479" }
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

**request:** `InteractionsGetRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Interactions.<a href="/src/CortiApi/Interactions/InteractionsClient.cs">DeleteAsync</a>(InteractionsDeleteRequest { ... })</code></summary>
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
await client.Interactions.DeleteAsync(
    new InteractionsDeleteRequest { Id = "f47ac10b-58cc-4372-a567-0e02b2c3d479" }
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

**request:** `InteractionsDeleteRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Interactions.<a href="/src/CortiApi/Interactions/InteractionsClient.cs">UpdateAsync</a>(InteractionsUpdateRequest { ... }) -> WithRawResponseTask&lt;InteractionsGetResponse&gt;</code></summary>
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
    new InteractionsUpdateRequest { Id = "f47ac10b-58cc-4372-a567-0e02b2c3d479" }
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

**request:** `InteractionsUpdateRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Recordings
<details><summary><code>client.Recordings.<a href="/src/CortiApi/Recordings/RecordingsClient.cs">ListAsync</a>(RecordingsListRequest { ... }) -> WithRawResponseTask&lt;RecordingsListResponse&gt;</code></summary>
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
await client.Recordings.ListAsync(
    new RecordingsListRequest { Id = "f47ac10b-58cc-4372-a567-0e02b2c3d479" }
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

**request:** `RecordingsListRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Recordings.<a href="/src/CortiApi/Recordings/RecordingsClient.cs">GetAsync</a>(RecordingsGetRequest { ... }) -> WithRawResponseTask&lt;Stream&gt;</code></summary>
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
await client.Recordings.GetAsync(
    new RecordingsGetRequest { Id = "id", RecordingId = "recordingId" }
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

**request:** `RecordingsGetRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Recordings.<a href="/src/CortiApi/Recordings/RecordingsClient.cs">DeleteAsync</a>(RecordingsDeleteRequest { ... })</code></summary>
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
    new RecordingsDeleteRequest
    {
        Id = "f47ac10b-58cc-4372-a567-0e02b2c3d479",
        RecordingId = "f47ac10b-58cc-4372-a567-0e02b2c3d479",
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

**request:** `RecordingsDeleteRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Transcripts
<details><summary><code>client.Transcripts.<a href="/src/CortiApi/Transcripts/TranscriptsClient.cs">ListAsync</a>(TranscriptsListRequest { ... }) -> WithRawResponseTask&lt;TranscriptsListResponse&gt;</code></summary>
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
    new TranscriptsListRequest { Id = "f47ac10b-58cc-4372-a567-0e02b2c3d479" }
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

**request:** `TranscriptsListRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Transcripts.<a href="/src/CortiApi/Transcripts/TranscriptsClient.cs">CreateAsync</a>(TranscriptsCreateRequest { ... }) -> WithRawResponseTask&lt;TranscriptsResponse&gt;</code></summary>
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
    new TranscriptsCreateRequest
    {
        Id = "f47ac10b-58cc-4372-a567-0e02b2c3d479",
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

**request:** `TranscriptsCreateRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Transcripts.<a href="/src/CortiApi/Transcripts/TranscriptsClient.cs">GetAsync</a>(TranscriptsGetRequest { ... }) -> WithRawResponseTask&lt;TranscriptsResponse&gt;</code></summary>
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
    new TranscriptsGetRequest
    {
        Id = "f47ac10b-58cc-4372-a567-0e02b2c3d479",
        TranscriptId = "f47ac10b-58cc-4372-a567-0e02b2c3d479",
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

**request:** `TranscriptsGetRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Transcripts.<a href="/src/CortiApi/Transcripts/TranscriptsClient.cs">DeleteAsync</a>(TranscriptsDeleteRequest { ... })</code></summary>
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
    new TranscriptsDeleteRequest
    {
        Id = "f47ac10b-58cc-4372-a567-0e02b2c3d479",
        TranscriptId = "f47ac10b-58cc-4372-a567-0e02b2c3d479",
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

**request:** `TranscriptsDeleteRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Transcripts.<a href="/src/CortiApi/Transcripts/TranscriptsClient.cs">GetStatusAsync</a>(TranscriptsGetStatusRequest { ... }) -> WithRawResponseTask&lt;TranscriptsStatusResponse&gt;</code></summary>
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
    new TranscriptsGetStatusRequest
    {
        Id = "f47ac10b-58cc-4372-a567-0e02b2c3d479",
        TranscriptId = "f47ac10b-58cc-4372-a567-0e02b2c3d479",
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

**request:** `TranscriptsGetStatusRequest` 
    
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

<details><summary><code>client.Facts.<a href="/src/CortiApi/Facts/FactsClient.cs">ListAsync</a>(FactsListRequest { ... }) -> WithRawResponseTask&lt;FactsListResponse&gt;</code></summary>
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
await client.Facts.ListAsync(new FactsListRequest { Id = "f47ac10b-58cc-4372-a567-0e02b2c3d479" });
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

**request:** `FactsListRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Facts.<a href="/src/CortiApi/Facts/FactsClient.cs">CreateAsync</a>(FactsCreateRequest { ... }) -> WithRawResponseTask&lt;FactsCreateResponse&gt;</code></summary>
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
    new FactsCreateRequest
    {
        Id = "f47ac10b-58cc-4372-a567-0e02b2c3d479",
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

**request:** `FactsCreateRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Facts.<a href="/src/CortiApi/Facts/FactsClient.cs">BatchUpdateAsync</a>(FactsBatchUpdateRequest { ... }) -> WithRawResponseTask&lt;FactsBatchUpdateResponse&gt;</code></summary>
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
    new FactsBatchUpdateRequest
    {
        Id = "f47ac10b-58cc-4372-a567-0e02b2c3d479",
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

**request:** `FactsBatchUpdateRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Facts.<a href="/src/CortiApi/Facts/FactsClient.cs">UpdateAsync</a>(FactsUpdateRequest { ... }) -> WithRawResponseTask&lt;FactsUpdateResponse&gt;</code></summary>
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
    new FactsUpdateRequest
    {
        Id = "f47ac10b-58cc-4372-a567-0e02b2c3d479",
        FactId = "3c9d8a12-7f44-4b3e-9e6f-9271c2bbfa08",
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
<details><summary><code>client.Documents.<a href="/src/CortiApi/Documents/DocumentsClient.cs">ListAsync</a>(DocumentsListRequest { ... }) -> WithRawResponseTask&lt;DocumentsListResponse&gt;</code></summary>
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
await client.Documents.ListAsync(
    new DocumentsListRequest { Id = "f47ac10b-58cc-4372-a567-0e02b2c3d479" }
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

**request:** `DocumentsListRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Documents.<a href="/src/CortiApi/Documents/DocumentsClient.cs">CreateAsync</a>(DocumentsCreateRequest { ... }) -> WithRawResponseTask&lt;DocumentsGetResponse&gt;</code></summary>
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
    new DocumentsCreateRequest
    {
        Id = "f47ac10b-58cc-4372-a567-0e02b2c3d479",
        Body = new DocumentsCreateRequestWithTemplateKey
        {
            Context = new List<
                OneOf<
                    DocumentsContextWithFacts,
                    DocumentsContextWithTranscript,
                    DocumentsContextWithString
                >
            >()
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

**request:** `DocumentsCreateRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Documents.<a href="/src/CortiApi/Documents/DocumentsClient.cs">GetAsync</a>(DocumentsGetRequest { ... }) -> WithRawResponseTask&lt;DocumentsGetResponse&gt;</code></summary>
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
    new DocumentsGetRequest
    {
        Id = "f47ac10b-58cc-4372-a567-0e02b2c3d479",
        DocumentId = "f47ac10b-58cc-4372-a567-0e02b2c3d479",
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

**request:** `DocumentsGetRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Documents.<a href="/src/CortiApi/Documents/DocumentsClient.cs">DeleteAsync</a>(DocumentsDeleteRequest { ... })</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Documents.DeleteAsync(
    new DocumentsDeleteRequest
    {
        Id = "f47ac10b-58cc-4372-a567-0e02b2c3d479",
        DocumentId = "f47ac10b-58cc-4372-a567-0e02b2c3d479",
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

**request:** `DocumentsDeleteRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Documents.<a href="/src/CortiApi/Documents/DocumentsClient.cs">UpdateAsync</a>(DocumentsUpdateRequest { ... }) -> WithRawResponseTask&lt;DocumentsGetResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Documents.UpdateAsync(
    new DocumentsUpdateRequest
    {
        Id = "f47ac10b-58cc-4372-a567-0e02b2c3d479",
        DocumentId = "f47ac10b-58cc-4372-a567-0e02b2c3d479",
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

<details><summary><code>client.Templates.<a href="/src/CortiApi/Templates/TemplatesClient.cs">GetAsync</a>(TemplatesGetRequest { ... }) -> WithRawResponseTask&lt;TemplatesItem&gt;</code></summary>
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
await client.Templates.GetAsync(new TemplatesGetRequest { Key = "key" });
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

**request:** `TemplatesGetRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Codes
<details><summary><code>client.Codes.<a href="/src/CortiApi/Codes/CodesClient.cs">ListCodesAsync</a>(GetInteractionsIdCodesRequest { ... }) -> WithRawResponseTask&lt;ResponseCodesList&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

`Limited Access - Contact us for more information`<br/><br/>List predicted codes within the context of an interaction.<br/><Note>This endpoint is only accessible within specific customer tenants. It is not available in the public API.<br/><br/>For stateless code prediction based on input text string or documentId, please refer to the [Predict Codes](/api-reference/codes/predict-codes) API, or [contact us](https://help.corti.app) for more information.</Note>
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
await client.Codes.ListCodesAsync(
    new GetInteractionsIdCodesRequest { Id = "f47ac10b-58cc-4372-a567-0e02b2c3d479" }
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

**request:** `GetInteractionsIdCodesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Codes.<a href="/src/CortiApi/Codes/CodesClient.cs">GenerateCodesAsync</a>(RequestCodesPredict { ... }) -> WithRawResponseTask&lt;ResponseCodesList&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

`Limited Access - Contact us for more information`<br/><br/>Generate codes within the context of an interaction.<br/><Note>This endpoint is only accessible within specific customer tenants. It is not available in the public API.<br/><br/>For stateless code prediction based on input text string or documentId, please refer to the [Predict Codes](/api-reference/codes/predict-codes) API, or [contact us](https://help.corti.app) for more information.</Note>
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
await client.Codes.GenerateCodesAsync(
    new RequestCodesPredict
    {
        Id = "f47ac10b-58cc-4372-a567-0e02b2c3d479",
        ModelName = "\"geography_modelName (Latest)\" | \"geography_modelName_version\"",
        Context = new CodesContext { Type = CodesContextTypeEnum.String, Data = "data" },
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

**request:** `RequestCodesPredict` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Codes.<a href="/src/CortiApi/Codes/CodesClient.cs">SelectCodesAsync</a>(RequestCodesUpdate { ... }) -> WithRawResponseTask&lt;ResponseCodesList&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

`Limited Access - Contact us for more information`<br/><br/>Select predicted codes within the context of an interaction.<br/><Note>This endpoint is only accessible within specific customer tenants. It is not available in the public API.<br/><br/>For stateless code prediction based on input text string or documentId, please refer to the [Predict Codes](/api-reference/codes/predict-codes) API, or [contact us](https://help.corti.app) for more information.</Note>
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
await client.Codes.SelectCodesAsync(
    new RequestCodesUpdate { Id = "f47ac10b-58cc-4372-a567-0e02b2c3d479" }
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

**request:** `RequestCodesUpdate` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

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
        Context = new List<OneOf<CommonTextContext, CommonDocumentIdContext>>()
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
