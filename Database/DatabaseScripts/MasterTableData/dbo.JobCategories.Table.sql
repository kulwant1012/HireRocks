USE [HireRocks_Dev]
GO
/****** Object:  Table [dbo].[JobCategories]    Script Date: 01/30/2016 15:59:23 ******/
SET IDENTITY_INSERT [dbo].[JobCategories] ON
INSERT [dbo].[JobCategories] ([JobCategoryId], [CategoryName], [CategoryDescription], [IsActive]) VALUES (1, N'Web Development', NULL, 1)
INSERT [dbo].[JobCategories] ([JobCategoryId], [CategoryName], [CategoryDescription], [IsActive]) VALUES (2, N'Testing', NULL, 1)
INSERT [dbo].[JobCategories] ([JobCategoryId], [CategoryName], [CategoryDescription], [IsActive]) VALUES (3, N'Content Writing', NULL, 1)
SET IDENTITY_INSERT [dbo].[JobCategories] OFF
