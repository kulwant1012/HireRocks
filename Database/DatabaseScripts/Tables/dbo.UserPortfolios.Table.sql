USE [HireRocks_Dev]
GO
/****** Object:  Table [dbo].[UserPortfolios]    Script Date: 02/01/2016 15:14:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPortfolios](
	[UserPortfolioId] [bigint] IDENTITY(1,1) NOT NULL,
	[ProjectTitle] [nvarchar](max) NOT NULL,
	[ProjectDescription] [nvarchar](max) NULL,
	[ProjectStartDate] [datetime] NULL,
	[ProjectEndDate] [datetime] NULL,
	[ContractId] [bigint] NULL,
	[WorkerId] [nvarchar](128) NULL,
 CONSTRAINT [PK_UserPortfolios] PRIMARY KEY CLUSTERED 
(
	[UserPortfolioId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UserPortfolios]  WITH CHECK ADD  CONSTRAINT [FK_UserPortfolioAspNetUser] FOREIGN KEY([WorkerId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[UserPortfolios] CHECK CONSTRAINT [FK_UserPortfolioAspNetUser]
GO
ALTER TABLE [dbo].[UserPortfolios]  WITH CHECK ADD  CONSTRAINT [FK_UserPortfolioContract] FOREIGN KEY([ContractId])
REFERENCES [dbo].[Contracts] ([ContractId])
GO
ALTER TABLE [dbo].[UserPortfolios] CHECK CONSTRAINT [FK_UserPortfolioContract]
GO
