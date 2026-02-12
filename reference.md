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
