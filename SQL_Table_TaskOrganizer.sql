USE [DbOrganizer]
GO

ALTER TABLE [dbo].[TableOrganizer] DROP CONSTRAINT [DF__TableOrgani__Day__4AB81AF0]
GO

ALTER TABLE [dbo].[TableOrganizer] DROP CONSTRAINT [DF__TableOrga__Month__49C3F6B7]
GO

ALTER TABLE [dbo].[TableOrganizer] DROP CONSTRAINT [DF__TableOrgan__Year__48CFD27E]
GO

/****** Object:  Table [dbo].[TableOrganizer]    Script Date: 11.03.2019 10:00:20 ******/
DROP TABLE [dbo].[TableOrganizer]
GO

/****** Object:  Table [dbo].[TableOrganizer]    Script Date: 11.03.2019 10:00:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TableOrganizer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Priority] [varchar](8) NOT NULL,
	[Status] [bit] NOT NULL,
	[Year] [int] NOT NULL,
	[Month] [int] NOT NULL,
	[Day] [int] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TableOrganizer] ADD  DEFAULT ((0)) FOR [Year]
GO

ALTER TABLE [dbo].[TableOrganizer] ADD  DEFAULT ((0)) FOR [Month]
GO

ALTER TABLE [dbo].[TableOrganizer] ADD  DEFAULT ((0)) FOR [Day]
GO

