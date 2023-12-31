USE [HireRocks_Dev]
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 02/01/2016 15:14:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[CompanyId] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](max) NOT NULL,
	[CompanyOwner] [nvarchar](max) NOT NULL,
	[CompanyAddress] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[CompanyLogo] [nvarchar](max) NULL,
 CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
