``` mermaid
sequenceDiagram
    participant Engine as Interface engine
    participant AppInt as Enterprise App Interface

    Engine-)AppInt: GET /dms/dictations/{AuthorName}
    Note over AppInt: {AuthorName} is validated against SEE membership
    Note over AppInt: Dictations are queried from {AuthorName}'s<br/>Archive and Finished dictations folders
    AppInt-)Engine: 200 OK
```