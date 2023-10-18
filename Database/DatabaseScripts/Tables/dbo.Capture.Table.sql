USE [HireRocks_Dev]
GO

/****** Object:  Table [dbo].[Capture]    Script Date: 02/11/2016 17:50:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Capture](
	[CaptureId] [bigint] IDENTITY(1,1) NOT NULL,
	[KeyCount] [int] NULL,
	[MouseCount] [int] NULL,
	[KeyboardCapture] [nvarchar](max) NULL,
	[MouseCapture] [nvarchar](max) NULL,
	[ScreenCaptureThumbnailImage] [nvarchar](50) NULL,
	[ScreenCaptureFullImage] [nvarchar](50) NULL,
	[CaptureDate] [datetime] NULL,
	[TimeBurned] [decimal](18, 2) NULL,
	[ContractId] [bigint] NULL,
	[IsRejected] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Captures] PRIMARY KEY CLUSTERED 
(
	[CaptureId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Capture]  WITH CHECK ADD  CONSTRAINT [FK_Contracts_ContractId] FOREIGN KEY([ContractId])
REFERENCES [dbo].[Contracts] ([ContractId])
GO

ALTER TABLE [dbo].[Capture] CHECK CONSTRAINT [FK_Contracts_ContractId]
GO

