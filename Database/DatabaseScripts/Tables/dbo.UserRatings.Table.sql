USE [HireRocks_Dev]
GO
/****** Object:  Table [dbo].[UserRatings]    Script Date: 02/01/2016 15:14:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRatings](
	[UserRatingId] [bigint] IDENTITY(1,1) NOT NULL,
	[Skill] [decimal](18, 0) NULL,
	[Quality] [decimal](18, 0) NULL,
	[Availability] [decimal](18, 0) NULL,
	[Deadline] [decimal](18, 0) NULL,
	[Communication] [decimal](18, 0) NULL,
	[Cooperation] [decimal](18, 0) NULL,
	[Comment] [nvarchar](max) NULL,
	[UserId] [nvarchar](128) NULL,
	[ContractId] [bigint] NULL,
 CONSTRAINT [PK_UserRatings] PRIMARY KEY CLUSTERED 
(
	[UserRatingId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UserRatings]  WITH CHECK ADD  CONSTRAINT [FK__UserRatin__Contr__589C25F3] FOREIGN KEY([ContractId])
REFERENCES [dbo].[Contracts] ([ContractId])
GO
ALTER TABLE [dbo].[UserRatings] CHECK CONSTRAINT [FK__UserRatin__Contr__589C25F3]
GO
ALTER TABLE [dbo].[UserRatings]  WITH CHECK ADD  CONSTRAINT [FK_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[UserRatings] CHECK CONSTRAINT [FK_UserId]
GO
