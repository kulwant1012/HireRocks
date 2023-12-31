USE [HireRocks_Dev]
GO
/****** Object:  Table [dbo].[ContractEndReasons]    Script Date: 02/01/2016 15:14:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContractEndReasons](
	[ContractEndReasonId] [bigint] IDENTITY(1,1) NOT NULL,
	[EndReason] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[RoleId] [nvarchar](128) NULL,
 CONSTRAINT [PK_ContractEndReasons] PRIMARY KEY CLUSTERED 
(
	[ContractEndReasonId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ContractEndReasons]  WITH CHECK ADD  CONSTRAINT [FK_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
GO
ALTER TABLE [dbo].[ContractEndReasons] CHECK CONSTRAINT [FK_RoleId]
GO
