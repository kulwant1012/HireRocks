USE [HireRocks_Dev]
GO
/****** Object:  Table [dbo].[ContractEndReasons]    Script Date: 01/30/2016 15:59:23 ******/
SET IDENTITY_INSERT [dbo].[ContractEndReasons] ON
INSERT [dbo].[ContractEndReasons] ([ContractEndReasonId], [EndReason], [IsActive], [RoleId]) VALUES (1, N'Client not responsive', 1, N'3')
INSERT [dbo].[ContractEndReasons] ([ContractEndReasonId], [EndReason], [IsActive], [RoleId]) VALUES (2, N'Completed successfully', 1, N'3')
INSERT [dbo].[ContractEndReasons] ([ContractEndReasonId], [EndReason], [IsActive], [RoleId]) VALUES (3, N'Not successfully completed', 1, N'3')
INSERT [dbo].[ContractEndReasons] ([ContractEndReasonId], [EndReason], [IsActive], [RoleId]) VALUES (4, N'Other', 1, NULL)
INSERT [dbo].[ContractEndReasons] ([ContractEndReasonId], [EndReason], [IsActive], [RoleId]) VALUES (5, N'Completed successfully', NULL, NULL)
SET IDENTITY_INSERT [dbo].[ContractEndReasons] OFF
