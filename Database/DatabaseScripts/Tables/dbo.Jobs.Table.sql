USE [HireRocks_Dev]
GO
/****** Object:  Table [dbo].[Jobs]    Script Date: 02/01/2016 15:14:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jobs](
	[JobId] [bigint] IDENTITY(1,1) NOT NULL,
	[JobTitle] [nvarchar](max) NOT NULL,
	[JobDescription] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[IsHiringClosed] [bit] NOT NULL,
	[WorkerTypeId] [bigint] NULL,
	[ExperienceLevelExperianceLevelId] [bigint] NULL,
	[JobTypeId] [bigint] NULL,
	[JobSubCategoryId] [bigint] NULL,
	[SkillsRequiredForJobIds] [nvarchar](max) NOT NULL,
	[JobStartDate] [datetime] NULL,
	[JobEndDate] [datetime] NULL,
	[EstimateDuration] [decimal](18, 0) NULL,
	[TimeUnitId] [bigint] NULL,
	[ClientId] [nvarchar](128) NULL,
	[JobPostDate] [datetime] NULL,
	[Min_PRF_Rate] [decimal](18, 0) NULL,
	[Max_PRF_Rate] [decimal](18, 0) NULL,
	[Locality_PRF] [nvarchar](max) NULL,
	[FixedRate] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Jobs] PRIMARY KEY CLUSTERED 
(
	[JobId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Jobs]  WITH CHECK ADD  CONSTRAINT [FK_JobAspNetUser] FOREIGN KEY([ClientId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Jobs] CHECK CONSTRAINT [FK_JobAspNetUser]
GO
ALTER TABLE [dbo].[Jobs]  WITH CHECK ADD  CONSTRAINT [FK_JobExperienceLevel] FOREIGN KEY([ExperienceLevelExperianceLevelId])
REFERENCES [dbo].[ExperienceLevels] ([ExperianceLevelId])
GO
ALTER TABLE [dbo].[Jobs] CHECK CONSTRAINT [FK_JobExperienceLevel]
GO
ALTER TABLE [dbo].[Jobs]  WITH CHECK ADD  CONSTRAINT [FK_JobFreelancersType] FOREIGN KEY([WorkerTypeId])
REFERENCES [dbo].[WorkerTypes] ([WorkerTypeId])
GO
ALTER TABLE [dbo].[Jobs] CHECK CONSTRAINT [FK_JobFreelancersType]
GO
ALTER TABLE [dbo].[Jobs]  WITH CHECK ADD  CONSTRAINT [FK_JobJobSubCategory] FOREIGN KEY([JobSubCategoryId])
REFERENCES [dbo].[JobSubCategories] ([JobSubCategoryId])
GO
ALTER TABLE [dbo].[Jobs] CHECK CONSTRAINT [FK_JobJobSubCategory]
GO
ALTER TABLE [dbo].[Jobs]  WITH CHECK ADD  CONSTRAINT [FK_JobJobType] FOREIGN KEY([JobTypeId])
REFERENCES [dbo].[JobTypes] ([JobTypeId])
GO
ALTER TABLE [dbo].[Jobs] CHECK CONSTRAINT [FK_JobJobType]
GO
ALTER TABLE [dbo].[Jobs]  WITH CHECK ADD  CONSTRAINT [FK_JobTimeUnits] FOREIGN KEY([TimeUnitId])
REFERENCES [dbo].[TimeUnits] ([TimeUnitId])
GO
ALTER TABLE [dbo].[Jobs] CHECK CONSTRAINT [FK_JobTimeUnits]
GO
