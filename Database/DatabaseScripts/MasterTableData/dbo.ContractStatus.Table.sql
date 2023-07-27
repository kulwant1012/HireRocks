USE [HireRocks_Dev]
GO
/****** Object:  Table [dbo].[ContractStatus]    Script Date: 01/30/2016 15:59:23 ******/
SET IDENTITY_INSERT [dbo].[ContractStatus] ON
INSERT [dbo].[ContractStatus] ([ContractStatusId], [ContractStatusName], [IsActive]) VALUES (1, N'Open', 1)
INSERT [dbo].[ContractStatus] ([ContractStatusId], [ContractStatusName], [IsActive]) VALUES (2, N'Closed', 1)
INSERT [dbo].[ContractStatus] ([ContractStatusId], [ContractStatusName], [IsActive]) VALUES (3, N'Cancel', 1)
INSERT [dbo].[ContractStatus] ([ContractStatusId], [ContractStatusName], [IsActive]) VALUES (4, N'Awaiting', 1)
SET IDENTITY_INSERT [dbo].[ContractStatus] OFF
