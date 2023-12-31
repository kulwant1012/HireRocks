USE [HireRocks_Dev]
GO
/****** Object:  Table [dbo].[WorkerHourlyRate]    Script Date: 02/01/2016 15:14:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkerHourlyRate](
	[WorkerHourlyRateId] [bigint] IDENTITY(1,1) NOT NULL,
	[ContractId] [bigint] NULL,
	[HourlyRate] [decimal](18, 0) NULL,
	[FromDate] [datetime] NULL,
	[ToDate] [datetime] NULL,
 CONSTRAINT [Pk_WorkerHourlyRate] PRIMARY KEY CLUSTERED 
(
	[WorkerHourlyRateId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[WorkerHourlyRate]  WITH CHECK ADD  CONSTRAINT [FK_ContractId] FOREIGN KEY([ContractId])
REFERENCES [dbo].[Contracts] ([ContractId])
GO
ALTER TABLE [dbo].[WorkerHourlyRate] CHECK CONSTRAINT [FK_ContractId]
GO
