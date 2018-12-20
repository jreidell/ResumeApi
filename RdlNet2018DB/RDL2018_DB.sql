/*----------------------------------------------------------------------------------------*/
/****** Object:  Table [dbo].[WorkHistoryDetail]    Script Date: 12/20/2018 07:24:00 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_WorkHistoryDetail_WorkHistory]') AND parent_object_id = OBJECT_ID(N'[dbo].[WorkHistoryDetail]'))
ALTER TABLE [dbo].[WorkHistoryDetail] DROP CONSTRAINT [FK_WorkHistoryDetail_WorkHistory]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_WorkHistoryDetail_WorkHistoryDetailId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[WorkHistoryDetail] DROP CONSTRAINT [DF_WorkHistoryDetail_WorkHistoryDetailId]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_WorkHistoryDetail_Sequence]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[WorkHistoryDetail] DROP CONSTRAINT [DF_WorkHistoryDetail_Sequence]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_WorkHistoryDetail_Enabled]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[WorkHistoryDetail] DROP CONSTRAINT [DF_WorkHistoryDetail_Enabled]
END

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WorkHistoryDetail]') AND type in (N'U'))
DROP TABLE [dbo].[WorkHistoryDetail]
GO

CREATE TABLE [dbo].[WorkHistoryDetail](
	[WorkHistoryDetailId] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[WorkHistoryId] [uniqueidentifier] NOT NULL,
	[Sequence] [int] NOT NULL,
	[ContentBody] [nvarchar](1024) NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_WorkHistoryDetail] PRIMARY KEY CLUSTERED 
(
	[WorkHistoryDetailId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[WorkHistoryDetail]  WITH CHECK ADD  CONSTRAINT [FK_WorkHistoryDetail_WorkHistory] FOREIGN KEY([WorkHistoryId])
REFERENCES [dbo].[WorkHistory] ([WorkHistoryId])
GO

ALTER TABLE [dbo].[WorkHistoryDetail] CHECK CONSTRAINT [FK_WorkHistoryDetail_WorkHistory]
GO

ALTER TABLE [dbo].[WorkHistoryDetail] ADD  CONSTRAINT [DF_WorkHistoryDetail_WorkHistoryDetailId]  DEFAULT (newid()) FOR [WorkHistoryDetailId]
GO

ALTER TABLE [dbo].[WorkHistoryDetail] ADD  CONSTRAINT [DF_WorkHistoryDetail_Sequence]  DEFAULT ((0)) FOR [Sequence]
GO

ALTER TABLE [dbo].[WorkHistoryDetail] ADD  CONSTRAINT [DF_WorkHistoryDetail_Enabled]  DEFAULT ((1)) FOR [Enabled]
GO

/*----------------------------------------------------------------------------------*/
/****** Object:  Table [dbo].[WorkHistory]    Script Date: 12/20/2018 07:19:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_WorkHistory_CareerInfo]') AND parent_object_id = OBJECT_ID(N'[dbo].[WorkHistory]'))
ALTER TABLE [dbo].[WorkHistory] DROP CONSTRAINT [FK_WorkHistory_CareerInfo]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_WorkHistory_WorkHistoryId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[WorkHistory] DROP CONSTRAINT [DF_WorkHistory_WorkHistoryId]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_WorkHistory_Sequence]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[WorkHistory] DROP CONSTRAINT [DF_WorkHistory_Sequence]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_WorkHistory_Enabled]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[WorkHistory] DROP CONSTRAINT [DF_WorkHistory_Enabled]
END

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WorkHistory]') AND type in (N'U'))
DROP TABLE [dbo].[WorkHistory]
GO

CREATE TABLE [dbo].[WorkHistory](
	[WorkHistoryId] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[CareerInfoId] [uniqueidentifier] NOT NULL,
	[Sequence] [int] NOT NULL,
	[Employer] [nvarchar](128) NULL,
	[JobTitle] [nvarchar](128) NULL,
	[JobDescription] [nvarchar](1024) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_WorkHistory] PRIMARY KEY CLUSTERED 
(
	[WorkHistoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[WorkHistory]  WITH CHECK ADD  CONSTRAINT [FK_WorkHistory_CareerInfo] FOREIGN KEY([CareerInfoId])
REFERENCES [dbo].[CareerInfo] ([CareerInfoId])
GO

ALTER TABLE [dbo].[WorkHistory] CHECK CONSTRAINT [FK_WorkHistory_CareerInfo]
GO

ALTER TABLE [dbo].[WorkHistory] ADD  CONSTRAINT [DF_WorkHistory_WorkHistoryId]  DEFAULT (newid()) FOR [WorkHistoryId]
GO

ALTER TABLE [dbo].[WorkHistory] ADD  CONSTRAINT [DF_WorkHistory_Sequence]  DEFAULT ((0)) FOR [Sequence]
GO

ALTER TABLE [dbo].[WorkHistory] ADD  CONSTRAINT [DF_WorkHistory_Enabled]  DEFAULT ((1)) FOR [Enabled]
GO

/*--------------------------------------------------------------------------------*/
/****** Object:  Table [dbo].[JobSkill]    Script Date: 12/20/2018 07:19:08 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_JobSkill_CareerInfo]') AND parent_object_id = OBJECT_ID(N'[dbo].[JobSkill]'))
ALTER TABLE [dbo].[JobSkill] DROP CONSTRAINT [FK_JobSkill_CareerInfo]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_JobSkill_JobSkillId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[JobSkill] DROP CONSTRAINT [DF_JobSkill_JobSkillId]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_JobSkill_Sequence]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[JobSkill] DROP CONSTRAINT [DF_JobSkill_Sequence]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_JobSkill_Enabled]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[JobSkill] DROP CONSTRAINT [DF_JobSkill_Enabled]
END

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[JobSkill]') AND type in (N'U'))
DROP TABLE [dbo].[JobSkill]
GO

CREATE TABLE [dbo].[JobSkill](
	[JobSkillId] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[CareerInfoId] [uniqueidentifier] NOT NULL,
	[Sequence] [int] NOT NULL,
	[JobSkillTitle] [nvarchar](32) NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_JobSkill] PRIMARY KEY CLUSTERED 
(
	[JobSkillId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[JobSkill]  WITH CHECK ADD  CONSTRAINT [FK_JobSkill_CareerInfo] FOREIGN KEY([CareerInfoId])
REFERENCES [dbo].[CareerInfo] ([CareerInfoId])
GO

ALTER TABLE [dbo].[JobSkill] CHECK CONSTRAINT [FK_JobSkill_CareerInfo]
GO

ALTER TABLE [dbo].[JobSkill] ADD  CONSTRAINT [DF_JobSkill_JobSkillId]  DEFAULT (newid()) FOR [JobSkillId]
GO

ALTER TABLE [dbo].[JobSkill] ADD  CONSTRAINT [DF_JobSkill_Sequence]  DEFAULT ((0)) FOR [Sequence]
GO

ALTER TABLE [dbo].[JobSkill] ADD  CONSTRAINT [DF_JobSkill_Enabled]  DEFAULT ((1)) FOR [Enabled]
GO

/*----------------------------------------------------------------------------------*/
/****** Object:  Table [dbo].[CareerInfo]    Script Date: 12/20/2018 07:18:12 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_CareerInfo_CareerInfoId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CareerInfo] DROP CONSTRAINT [DF_CareerInfo_CareerInfoId]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_CareerInfo_Enabled]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CareerInfo] DROP CONSTRAINT [DF_CareerInfo_Enabled]
END

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CareerInfo]') AND type in (N'U'))
DROP TABLE [dbo].[CareerInfo]
GO

CREATE TABLE [dbo].[CareerInfo](
	[CareerInfoId] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[FirstName] [nvarchar](32) NULL,
	[MiddleName] [nvarchar](32) NULL,
	[LastName] [nvarchar](32) NULL,
	[Suffix] [nvarchar](32) NULL,
	[EmailAddress] [nvarchar](128) NULL,
	[Address1] [nvarchar](128) NULL,
	[Address2] [nvarchar](128) NULL,
	[City] [nvarchar](32) NULL,
	[State] [nvarchar](2) NULL,
	[PostalCode] [nvarchar](10) NULL,
	[Phone] [nvarchar](15) NULL,
	[Mobile] [nvarchar](15) NULL,
	[CareerInfoTitle] [nvarchar](128) NULL,
	[Summary] [nvarchar](2048) NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_CareerInfo] PRIMARY KEY CLUSTERED 
(
	[CareerInfoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[CareerInfo] ADD  CONSTRAINT [DF_CareerInfo_CareerInfoId]  DEFAULT (newid()) FOR [CareerInfoId]
GO

ALTER TABLE [dbo].[CareerInfo] ADD  CONSTRAINT [DF_CareerInfo_Enabled]  DEFAULT ((1)) FOR [Enabled]
GO

