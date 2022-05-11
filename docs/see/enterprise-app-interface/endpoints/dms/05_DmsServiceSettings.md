---
grand_parent: Enterprise App Interface integrations
parent: /dms endpoints for DMS integrations

title: Service settings
has_children: false
nav_order: 5
---

# Service settings

`Enterprise App Interface` uses its `web.config` file to store service-level settings. Settings described below are used when serving requests to the `/dms` endpoints.


## Request authentication settings
Every HTTP request sent to the `/dms` endpoints from an integrator application must be authenticated. Authentication is realized using 'API keys'. An integrator application must specify a valid 'API key' in the custom `x-sps-api-key` HTTP  header of every HTTP request.

The 'API key' values accepted by the `/dms` endpoints are stored in service setting:
```
API.DMS.AllowedAPIKeysPipeSeparated
```

The value of this setting is:
- a list of non-empty string values
- separated by a \'\|\' character, when specifying multiple values

### Example
``` xml
<add key="API.DMS.AllowedAPIKeysPipeSeparated" 
     value="DMSApiKeyX_GUID1|DMSApiKeyY_GUID2" />
```
