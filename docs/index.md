---
title: Enterprise App Interface integrations
has_children: true
nav_order: 10
---
# Enterprise App Interface integrations

## What is Enterprise App Interface?
Enterprise App Interface is a web service application built for and running in Internet Information Services for Windows (IIS). This product was introduced with SpeechExec 8.0 in 2022.
The main goal of Enterprise App Interface is to provide various programmatic endpoints for integrators, so they can relatively easily create integrations between the SpeechExec Enterprise ecosystem and other existing, business-specific systems.


## Integration endpoints
Enterprise App Interface offers multiple integration end-point groups. These endpoints are REST services grouped into the following main areas:
- [`/masterdata` endpoints](./see/enterprise-app-interface/endpoints/masterdata/01_MasterDataOverview.md): help integrations with Hospital Information Systems
- [`/dms` endpoints](./see/enterprise-app-interface/endpoints/dms/01_DmsOverview.md): help integrations with Document Management Systems
- /app endpoints: offer possibilites to access the on-premise SpeechExec Enterprise dictations from mobile devices via authenticated calls


## Test applications
Test applications demonstrating the main use-cases and technical possibilites can be found here:

[https://github.com/speechprocessing/speechexec-enterprise-integrator-guide/tree/main/testapps/EnterpriseAppInterface](https://github.com/speechprocessing/speechexec-enterprise-integrator-guide/tree/main/testapps/EnterpriseAppInterface){:target="_blank"}
