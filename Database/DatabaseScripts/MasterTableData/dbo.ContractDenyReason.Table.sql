USE [HireRocks_Dev]
GO
/****** Object:  Table [dbo].[ContractDenyReason]    Script Date: 01/30/2016 15:59:23 ******/
SET IDENTITY_INSERT [dbo].[ContractDenyReasons] ON
INSERT [dbo].[ContractDenyReasons] ([ContractDenyReasonId], [DenyReason], [IsActive], [RoleId]) VALUES (1, N'Already busy in another task', 1, N'3')
INSERT [dbo].[ContractDenyReasons] ([ContractDenyReasonId], [DenyReason], [IsActive], [RoleId]) VALUES (2, N'Other', 1, N'3')
SET IDENTITY_INSERT [dbo].[ContractDenyReasons] OFF
