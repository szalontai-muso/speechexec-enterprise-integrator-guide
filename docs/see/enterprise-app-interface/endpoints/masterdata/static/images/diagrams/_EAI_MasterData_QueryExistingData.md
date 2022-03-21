``` mermaid
sequenceDiagram
    actor ED as Enterprise Dictate
    participant ConfServ as Enterprise Configuration service
    participant SQLDB as SQL Database
    %%rect rgb(219, 178, 255)
    ED-)ConfServ: GET /masterdata/dataitems/{dictationID}
    ConfServ-)SQLDB: Query by dictationID
    Note over ConfServ,SQLDB: Data queried from a pre-defined<br/>view/table (see below)
    ConfServ-)ED: Return result from SQL
    %%end
```