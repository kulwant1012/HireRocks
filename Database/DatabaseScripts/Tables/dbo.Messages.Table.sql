USE [HireRocks_Dev]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 02/01/2016 15:14:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[MessageId] [bigint] IDENTITY(1,1) NOT NULL,
	[MessageText] [nvarchar](max) NULL,
	[Subject] [nvarchar](max) NULL,
	[DateTime] [datetime] NULL,
	[IsViewed] [bit] NULL,
	[MessageLabelId] [bigint] NULL,
	[MessageFromUserId] [nvarchar](128) NULL,
	[MessageToUserId] [nvarchar](128) NULL,
	[JobId] [bigint] NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[MessageId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_MessageAspNetUser] FOREIGN KEY([MessageFromUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_MessageAspNetUser]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_MessageAspNetUser1] FOREIGN KEY([MessageToUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_MessageAspNetUser1]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_Jobs] FOREIGN KEY([JobId])
REFERENCES [dbo].[Jobs] ([JobId])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_Jobs]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_MessagesMessageLabels] FOREIGN KEY([MessageLabelId])
REFERENCES [dbo].[MessageLabels] ([MessageLabelId])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_MessagesMessageLabels]
GO
