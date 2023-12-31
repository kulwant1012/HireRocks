USE [HireRocks_Dev]
GO
/****** Object:  Table [dbo].[JobSubCategories]    Script Date: 02/01/2016 15:14:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobSubCategories](
	[JobSubCategoryId] [bigint] IDENTITY(1,1) NOT NULL,
	[SubCategoryName] [nvarchar](max) NOT NULL,
	[SubCategoryDescription] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[JobCategoryId] [bigint] NULL,
 CONSTRAINT [PK_JobSubCategories] PRIMARY KEY CLUSTERED 
(
	[JobSubCategoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[JobSubCategories]  WITH CHECK ADD  CONSTRAINT [FK_JobSubCategoryJobCategory] FOREIGN KEY([JobCategoryId])
REFERENCES [dbo].[JobCategories] ([JobCategoryId])
GO
ALTER TABLE [dbo].[JobSubCategories] CHECK CONSTRAINT [FK_JobSubCategoryJobCategory]
GO
