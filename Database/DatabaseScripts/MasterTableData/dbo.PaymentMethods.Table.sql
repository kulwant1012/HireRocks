USE [HireRocks_Dev]
GO
/****** Object:  Table [dbo].[PaymentMethods]    Script Date: 01/30/2016 15:59:23 ******/
SET IDENTITY_INSERT [dbo].[PaymentMethods] ON
INSERT [dbo].[PaymentMethods] ([PaymentMethodId], [PaymentMethodName], [PaymentMethodDescription], [IsActive]) VALUES (1, N'Hourly', NULL, 1)
INSERT [dbo].[PaymentMethods] ([PaymentMethodId], [PaymentMethodName], [PaymentMethodDescription], [IsActive]) VALUES (2, N'Fixed', NULL, 1)
SET IDENTITY_INSERT [dbo].[PaymentMethods] OFF
