USE [HireRocks_Dev]
GO
/****** Object:  Table [dbo].[ExperienceLevels]    Script Date: 01/30/2016 15:59:23 ******/
SET IDENTITY_INSERT [dbo].[ExperienceLevels] ON
INSERT [dbo].[ExperienceLevels] ([ExperianceLevelId], [LevelName], [IsActive], [ExperienceLowerRange], [ExperienceHigherRange]) VALUES (1, N'Fresher', 1, 0, 2)
INSERT [dbo].[ExperienceLevels] ([ExperianceLevelId], [LevelName], [IsActive], [ExperienceLowerRange], [ExperienceHigherRange]) VALUES (2, N'InterMediate', 1, 3, 5)
SET IDENTITY_INSERT [dbo].[ExperienceLevels] OFF
