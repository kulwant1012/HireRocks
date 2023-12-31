USE [HireRocks_Dev]
GO
/****** Object:  Table [dbo].[Contracts]    Script Date: 02/01/2016 15:14:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contracts](
	[ContractId] [bigint] IDENTITY(1,1) NOT NULL,
	[JobId] [bigint] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[EstimateDuration] [decimal](18, 0) NULL,
	[ActualDuration] [decimal](18, 0) NULL,
	[TimeUnitId] [bigint] NULL,
	[ContractStatusId] [bigint] NULL,
	[HoursLimit] [decimal](18, 0) NULL,
	[EndReason] [nvarchar](max) NULL,
	[JobRating] [decimal](18, 0) NULL,
	[WorkerId] [nvarchar](128) NULL,
	[FixedRate] [decimal](18, 0) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedByUserId] [nvarchar](128) NULL,
	[ModifiedByUserId] [nvarchar](128) NULL,
	[HourlyRate] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Contracts] PRIMARY KEY CLUSTERED 
(
	[ContractId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Contracts]  WITH CHECK ADD  CONSTRAINT [FK_ContractAspNetUser] FOREIGN KEY([WorkerId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Contracts] CHECK CONSTRAINT [FK_ContractAspNetUser]
GO
ALTER TABLE [dbo].[Contracts]  WITH CHECK ADD  CONSTRAINT [FK_ContractContractStatus] FOREIGN KEY([ContractStatusId])
REFERENCES [dbo].[ContractStatus] ([ContractStatusId])
GO
ALTER TABLE [dbo].[Contracts] CHECK CONSTRAINT [FK_ContractContractStatus]
GO
ALTER TABLE [dbo].[Contracts]  WITH CHECK ADD  CONSTRAINT [FK_ContractJob] FOREIGN KEY([JobId])
REFERENCES [dbo].[Jobs] ([JobId])
GO
ALTER TABLE [dbo].[Contracts] CHECK CONSTRAINT [FK_ContractJob]
GO
ALTER TABLE [dbo].[Contracts]  WITH CHECK ADD  CONSTRAINT [FK_ContractTimeUnits] FOREIGN KEY([TimeUnitId])
REFERENCES [dbo].[TimeUnits] ([TimeUnitId])
GO
ALTER TABLE [dbo].[Contracts] CHECK CONSTRAINT [FK_ContractTimeUnits]
GO
ALTER TABLE [dbo].[Contracts]  WITH CHECK ADD  CONSTRAINT [FK_CreatedByUserId] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Contracts] CHECK CONSTRAINT [FK_CreatedByUserId]
GO
ALTER TABLE [dbo].[Contracts]  WITH CHECK ADD  CONSTRAINT [FK_ModifiedByUserId] FOREIGN KEY([ModifiedByUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Contracts] CHECK CONSTRAINT [FK_ModifiedByUserId]
GO
