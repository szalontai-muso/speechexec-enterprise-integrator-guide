---
grand_parent: Enterprise App Interface integrations
parent: /masterdata endpoints for HIS integrations

title: Authentication
has_children: false
nav_order: 10
---

# HTTP request authentication
The `/masterdata` endpoints of Enterprise App Interface are designed for server-to-server communication, assuming a relatively secure transport channel between the 'server' (`Enterprise App Interface`) and 'client' (`Interface engine`). Still, to prevent unauthorized access, every HTTP request sent to the `/masterdata` endpoints must contain a custom HTTP header called:
```
x-sps-api-key
```

The value of the header is a string. If the value provided in the `x-sps-api-key` header is not listed in the service configuration, the request will be rejected with `HTTP 401-Unauthorized`.

Configuring the accepted API keys is the responsibility of the service administrator.

See [service settings](./05_MasterDataServiceSettings.md) for more information.

## Example:
The following example shows how to set up a `HttpClient` object and configure it to send the custom `x-sps-api-key` header.
```csharp
/* C# example */

// create a HttpClient object
HttpClient _AppInterfaceHttpClient = new HttpClient();

string masterdataAPIKeyValue = "YOUR_MASTERDATA_API_KEY";

// configure HttpClient to send a header with all requests
_AppInterfaceHttpClient.DefaultRequestHeaders
    .Add("x-sps-api-key", masterdataAPIKeyValue);
```