``` mermaid
sequenceDiagram
    participant Engine as Interface engine
    participant AppInt as Enterprise App Interface
    participant SQLDB as SQL Database
    %%rect rgb(191, 223, 255)
    Engine-)AppInt: POST /masterdata/dataitems
    AppInt-)SQLDB: Insert by dictationID
    Note over AppInt,SQLDB: Data inserted into a <br/>pre-defined table (see below)
    AppInt-)Engine: 201 Created
    %%end
```