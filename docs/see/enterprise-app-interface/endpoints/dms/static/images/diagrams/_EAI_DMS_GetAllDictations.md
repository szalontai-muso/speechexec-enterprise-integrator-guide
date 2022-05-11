``` mermaid
sequenceDiagram
    participant Engine as Interface engine
    participant AppInt as Enterprise App Interface

    Engine-)AppInt: GET /dms/dictations
    loop for all users
    Note over AppInt: user is validated against SEE membership
    Note over AppInt: Dictations are queried from user's<br/>Archive and Finished dictations folders
    end
    AppInt-)Engine: 200 OK
```