USE [HireRocks_Dev]
GO
/****** Object:  Table [dbo].[Educations]    Script Date: 02/01/2016 15:14:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Educations](
	[EducationId] [bigint] IDENTITY(1,1) NOT NULL,
	[DegreeTypeId] [bigint] NULL,
	[DegreeName] [nvarchar](max) NULL,
	[DegreeStartDate] [datetime] NULL,
	[DegreeEndDate] [datetime] NULL,
	[Percentage] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Educations] PRIMARY KEY CLUSTERED 
(
	[EducationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Educations]  WITH CHECK ADD  CONSTRAINT [FK_EducationDegreeType] FOREIGN KEY([DegreeTypeId])
REFERENCES [dbo].[DegreeTypes] ([DegreeTypeId])
GO
ALTER TABLE [dbo].[Educations] CHECK CONSTRAINT [FK_EducationDegreeType]
GO
