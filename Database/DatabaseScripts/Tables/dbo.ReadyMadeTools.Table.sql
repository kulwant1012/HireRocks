USE [HireRocks_Dev]
GO
/****** Object:  Table [dbo].[ReadyMadeTools]    Script Date: 02/01/2016 15:14:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReadyMadeTools](
	[ToolId] [bigint] IDENTITY(1,1) NOT NULL,
	[ToolName] [nvarchar](max) NOT NULL,
	[ToolDescription] [nvarchar](max) NULL,
	[DownloadURL] [nvarchar](max) NULL,
	[ToolLogo] [nvarchar](max) NULL,
	[ToolVersion] [nvarchar](max) NULL,
	[ToolOwnerId] [nvarchar](128) NULL,
 CONSTRAINT [PK_ReadyMadeTools] PRIMARY KEY CLUSTERED 
(
	[ToolId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ReadyMadeTools]  WITH CHECK ADD  CONSTRAINT [FK_ReadyMadeToolAspNetUser] FOREIGN KEY([ToolOwnerId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[ReadyMadeTools] CHECK CONSTRAINT [FK_ReadyMadeToolAspNetUser]
GO
