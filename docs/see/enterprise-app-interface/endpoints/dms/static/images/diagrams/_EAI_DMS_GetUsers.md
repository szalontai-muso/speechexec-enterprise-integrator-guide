``` mermaid
sequenceDiagram
    participant Engine as Interface engine
    participant AppInt as Enterprise App Interface
    participant AD as Active directory

    Engine-)AppInt: GET /dms/users
    AD-)AppInt: Query users from AD
    Note over AppInt,AD: Users only from appropriate <br/>AD groups are retrieved (see below)
    Note over AppInt: Users are validated against SEE membership
    AppInt-)Engine: 200 OK
```