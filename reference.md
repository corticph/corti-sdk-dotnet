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
