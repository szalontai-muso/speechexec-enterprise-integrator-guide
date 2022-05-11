---
grand_parent: Enterprise App Interface integrations
parent: /masterdata endpoints for HIS integrations

title: Database setup
has_children: false
nav_order: 11
---

# Database setup

The `/masterdata` endpoints of Enterprise App Interface connect to a Microsoft SQL Server database where the dictation metadata is stored.

The SQL server database must have a table with name `MasterDataItemsTableForSpeechExecEnterprise`. The SQL script for creating the table is the following:

``` sql
CREATE TABLE [dbo].[MasterDataItemsTableForSpeechExecEnterprise](
	[ID] [nvarchar](250) NOT NULL,
	[Label01] [nvarchar](250) NULL,
	[Label02] [nvarchar](250) NULL,
	[Label03] [nvarchar](250) NULL,
	[Label04] [nvarchar](250) NULL,
	[Label05] [nvarchar](250) NULL,
	[Label06] [nvarchar](250) NULL,
	[Label07] [nvarchar](250) NULL,
	[Label08] [nvarchar](250) NULL,
	[Label09] [nvarchar](250) NULL,
	[Int01] [int] NULL,
	[Int02] [int] NULL,
	[Int03] [int] NULL,
	[Int04] [int] NULL,
	[Int05] [int] NULL,
	[Datetime01] [datetime] NULL,
	[Datetime02] [datetime] NULL,
	[Datetime03] [datetime] NULL,
	[Datetime04] [datetime] NULL,
	[Datetime05] [datetime] NULL,
 CONSTRAINT [PK_MasterDataTable] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
```

Configuring the database connection settings is the responsibility of the service administrator.

See [service settings](./05_MasterDataServiceSettings.md) for more information.