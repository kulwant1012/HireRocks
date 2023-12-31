USE [HireRocks_Dev]
GO
/****** Object:  Table [dbo].[UserProfiles]    Script Date: 02/01/2016 15:14:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfiles](
	[UserProfileId] [bigint] IDENTITY(1,1) NOT NULL,
	[ProfileTitle] [nvarchar](max) NULL,
	[UserSkillIds] [nvarchar](max) NULL,
	[UserLanguageIds] [nvarchar](max) NULL,
	[UserHourlyRate] [decimal](18, 0) NULL,
	[EducationIds] [nvarchar](max) NULL,
	[UserSubCategoryIds] [nvarchar](max) NULL,
	[UserRating] [decimal](18, 0) NULL,
	[UserId] [nvarchar](128) NULL,
	[TimeZone] [nvarchar](max) NULL,
	[Gender] [nvarchar](50) NULL,
	[DateOfBirth] [datetime] NULL,
	[IntroductionVideo] [nvarchar](max) NULL,
	[CertificationIds] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserProfiles] PRIMARY KEY CLUSTERED 
(
	[UserProfileId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UserProfiles]  WITH CHECK ADD  CONSTRAINT [FK_UserProfileAspNetUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[UserProfiles] CHECK CONSTRAINT [FK_UserProfileAspNetUser]
GO
