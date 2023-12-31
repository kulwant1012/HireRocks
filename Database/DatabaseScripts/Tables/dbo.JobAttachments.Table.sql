USE [HireRocks_Dev]
GO
/****** Object:  Table [dbo].[JobAttachments]    Script Date: 02/01/2016 15:14:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobAttachments](
	[JobAttachmentId] [bigint] IDENTITY(1,1) NOT NULL,
	[AttachmentName] [nvarchar](max) NOT NULL,
	[JobId] [bigint] NULL,
	[AttachmentOriginalName] [nvarchar](max) NULL,
 CONSTRAINT [PK_JobAttachments] PRIMARY KEY CLUSTERED 
(
	[JobAttachmentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[JobAttachments]  WITH CHECK ADD  CONSTRAINT [FK_JobAttachmentsJob] FOREIGN KEY([JobId])
REFERENCES [dbo].[Jobs] ([JobId])
GO
ALTER TABLE [dbo].[JobAttachments] CHECK CONSTRAINT [FK_JobAttachmentsJob]
GO
