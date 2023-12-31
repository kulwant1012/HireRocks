USE [HireRocks_Dev]
GO
/****** Object:  Table [dbo].[Certification]    Script Date: 02/01/2016 15:14:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Certification](
	[CertificationId] [bigint] IDENTITY(1,1) NOT NULL,
	[CertificationName] [nvarchar](100) NULL,
	[CertificationDate] [datetime] NULL,
	[CertificationNumber] [nvarchar](100) NULL,
 CONSTRAINT [PK__Certific__1237E58A11158940] PRIMARY KEY CLUSTERED 
(
	[CertificationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
