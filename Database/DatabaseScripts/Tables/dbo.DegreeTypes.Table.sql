USE [HireRocks_Dev]
GO
/****** Object:  Table [dbo].[DegreeTypes]    Script Date: 02/01/2016 15:14:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DegreeTypes](
	[DegreeTypeId] [bigint] IDENTITY(1,1) NOT NULL,
	[DegreeTypeName] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_DegreeTypes] PRIMARY KEY CLUSTERED 
(
	[DegreeTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
