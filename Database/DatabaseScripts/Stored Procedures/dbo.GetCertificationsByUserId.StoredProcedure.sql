USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[GetCertificationsByUserId]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCertificationsByUserId]
	@UserId nvarchar(MAX)
AS
BEGIN
	Select * from certification where
	certification.certificationid in (select * from dbo.FunctionSplitString((select certificationids from userprofiles where userid=@userid),','))
END
GO
