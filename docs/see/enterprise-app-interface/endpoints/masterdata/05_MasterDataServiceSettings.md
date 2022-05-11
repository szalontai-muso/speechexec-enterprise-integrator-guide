---
grand_parent: Enterprise App Interface integrations
parent: /masterdata endpoints for HIS integrations

title: Service settings
has_children: false
nav_order: 5
---

# Service settings

`Enterprise App Interface` uses its `web.config` file to store service-level settings. Settings described below are used when serving requests to the `/masterdata` endpoints.

## Database connection settings
The following settings control how `Enterprise App Interface` connects to the Microsoft SQL Server database storing the dictation metadata.

### SQL server instance and database name
The host machine name and instance name of the SQL Server can be specified using the following settings:
``` xml
  <add key="Database.MSSQL.Server" 
       value="%ADD_MSSQL_HOST\SERVERNAME_HERE%" />

  <add key="Database.MSSQL.Database" 
       value="%ADD_MSSQL_DATABASE_NAME_HERE%" />

```

### SQL server authentication
`Enterprise App Interface` can connect to the SQL server using either `Windows Authentication` or `SQL Authentication`.

The authentication mode towards the SQL Server is specified in setting:
```
Database.MSSQL.UseSQLAuthentication
```

To use the `Windows Authentication` mode, the value of `Database.MSSQL.UseSQLAuthentication` must be `false`. In this mode, the SQL connection is authenticated using the credentials of the Windows account specified as 'Identity' for the IIS application pool hosting the `Enterprise App Interface` web service.

To use the `SQL Authentication` mode, the value of `Database.MSSQL.UseSQLAuthentication` must be `true` **and** the SQL username and password values must be specified in the `Database.MSSQL.SQLAuthentication.Username` and `Database.MSSQL.SQLAuthentication.Password` settings.
The values specified for these two settings must be the Base64 encoded forms of the original plain-text SQL username and password.

### Example
Let's assume we would like to use the following credentials in `SQL Authentication` mode:
- user name: MyUser
- password : MyPassword

The Base64 encoded values are:
- user name as Base64: TXlVc2Vy
- password as Base64 : TXlQYXNzd29yZA==

The relevant settings in `web.config`:
``` xml
<add key="Database.MSSQL.Server" value="MYMACHINE\MYSQLINSTNCE" />
<add key="Database.MSSQL.Database" value="MasterDataDB" />
<add key="Database.MSSQL.UseSQLAuthentication" value="true" />

<add key="Database.MSSQL.SQLAuthentication.Username" value="TXlVc2Vy" />
<add key="Database.MSSQL.SQLAuthentication.Password" value="TXlQYXNzd29yZA==" />
```


## Request authentication settings
Every HTTP request sent to the `/masterdata` endpoints from an integrator application must be authenticated. Authentication is realized using 'API keys'. An integrator application must specify a valid 'API key' in the custom `x-sps-api-key` HTTP  header of every HTTP request.

The 'API key' values accepted by the `/masterdata` endpoints are stored in service setting:
```
API.MasterData.AllowedAPIKeysPipeSeparated
```

The value of this setting is:
- a list of non-empty string values
- separated by a \'\|\' character, when specifying multiple values

### Example
``` xml
<add key="API.MasterData.AllowedAPIKeysPipeSeparated" 
     value="MasterDataApiKeyA_GUID1|MasterDataApiKeyB_GUID2" />
```


