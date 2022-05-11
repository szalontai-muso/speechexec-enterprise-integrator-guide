``` mermaid
sequenceDiagram
    participant Engine as DMS Connector
    participant AppInt as Enterprise App Interface
    Engine-)AppInt: GET /dms/users
    AppInt-)Engine: returns list of users
    Note over Engine: The desired user is selected from the list
    Engine-)AppInt: GET /dms/dictations/{AuthorName}
    AppInt-)Engine: returns list of dictations for requested user
    Note over Engine: The desired dictation is selected from the list
    Engine-)AppInt: GET /dms/dictations/{AuthorName}/{DictationID}/attachment
    AppInt-)Engine: returns the document of the requested dictation
```