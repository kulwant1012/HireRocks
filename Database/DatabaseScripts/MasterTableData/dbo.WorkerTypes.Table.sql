USE [HireRocks_Dev]
GO
/****** Object:  Table [dbo].[WorkerTypes]    Script Date: 01/30/2016 15:59:23 ******/
SET IDENTITY_INSERT [dbo].[WorkerTypes] ON
INSERT [dbo].[WorkerTypes] ([WorkerTypeId], [Name], [Description], [IsActive]) VALUES (1, N'Full time', NULL, 1)
INSERT [dbo].[WorkerTypes] ([WorkerTypeId], [Name], [Description], [IsActive]) VALUES (2, N'PartTime', NULL, 1)
SET IDENTITY_INSERT [dbo].[WorkerTypes] OFF
