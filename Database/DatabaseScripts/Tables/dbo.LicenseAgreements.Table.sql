USE [HireRocks_Dev]
GO
/****** Object:  Table [dbo].[LicenseAgreements]    Script Date: 02/01/2016 15:14:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LicenseAgreements](
	[LicenseAgreementId] [bigint] IDENTITY(1,1) NOT NULL,
	[Agreement] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_LicenseAgreements] PRIMARY KEY CLUSTERED 
(
	[LicenseAgreementId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
