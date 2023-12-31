USE [HireRocks_Dev]
GO
/****** Object:  Table [dbo].[JobsBids]    Script Date: 02/01/2016 15:14:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobsBids](
	[JobBidId] [bigint] IDENTITY(1,1) NOT NULL,
	[JobId] [bigint] NOT NULL,
	[Rate] [decimal](18, 0) NULL,
	[WorkerId] [nvarchar](128) NOT NULL,
	[IsHired] [bit] NULL,
	[IsDenied] [bit] NULL,
	[CoverLetter] [nvarchar](max) NULL,
 CONSTRAINT [PK_JobsBids] PRIMARY KEY CLUSTERED 
(
	[JobBidId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[JobsBids]  WITH CHECK ADD  CONSTRAINT [FK_JobsBid_AspNetUsers] FOREIGN KEY([WorkerId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[JobsBids] CHECK CONSTRAINT [FK_JobsBid_AspNetUsers]
GO
ALTER TABLE [dbo].[JobsBids]  WITH CHECK ADD  CONSTRAINT [FK_JobsBid_Jobs] FOREIGN KEY([JobId])
REFERENCES [dbo].[Jobs] ([JobId])
GO
ALTER TABLE [dbo].[JobsBids] CHECK CONSTRAINT [FK_JobsBid_Jobs]
GO
