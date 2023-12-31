USE [HireRocks_Dev]
GO
/****** Object:  Table [dbo].[JobsBidAttachments]    Script Date: 02/01/2016 15:14:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobsBidAttachments](
	[JobBidAttachmentId] [bigint] IDENTITY(1,1) NOT NULL,
	[AttachmentName] [nvarchar](max) NOT NULL,
	[AttachmentOriginalName] [nvarchar](max) NULL,
	[JobBidId] [bigint] NULL,
 CONSTRAINT [PK_JobsBidAttachments] PRIMARY KEY CLUSTERED 
(
	[JobBidAttachmentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[JobsBidAttachments]  WITH CHECK ADD  CONSTRAINT [FK_JobsBidAttachments_JobsBid] FOREIGN KEY([JobBidId])
REFERENCES [dbo].[JobsBids] ([JobBidId])
GO
ALTER TABLE [dbo].[JobsBidAttachments] CHECK CONSTRAINT [FK_JobsBidAttachments_JobsBid]
GO
