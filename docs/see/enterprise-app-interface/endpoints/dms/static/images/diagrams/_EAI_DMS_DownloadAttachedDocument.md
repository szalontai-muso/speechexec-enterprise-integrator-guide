``` mermaid
sequenceDiagram
    participant Engine as Interface engine
    participant AppInt as Enterprise App Interface

    Engine-)AppInt: GET /dms/dictations/{AuthorName}/{DictationID}/attachment
    Note over AppInt: {AuthorName} is validated against SEE membership
    Note over AppInt: Dictation with {DictationID} is queried from <br/>{AuthorName}'s Archive and Finished dictations folders
    Note over AppInt: Dictation's attached document is obtained
    AppInt-)Engine: 200 OK
```