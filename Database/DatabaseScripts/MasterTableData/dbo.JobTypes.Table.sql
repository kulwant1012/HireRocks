USE [HireRocks_Dev]
GO
/****** Object:  Table [dbo].[JobTypes]    Script Date: 01/30/2016 15:59:23 ******/
SET IDENTITY_INSERT [dbo].[JobTypes] ON
INSERT [dbo].[JobTypes] ([JobTypeId], [JobTypeName], [IsActive]) VALUES (1, N'Hourly', 1)
INSERT [dbo].[JobTypes] ([JobTypeId], [JobTypeName], [IsActive]) VALUES (2, N'Fixed', 1)
SET IDENTITY_INSERT [dbo].[JobTypes] OFF
