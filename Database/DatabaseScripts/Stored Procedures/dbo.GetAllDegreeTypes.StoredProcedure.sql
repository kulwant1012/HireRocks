USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[GetAllDegreeTypes]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllDegreeTypes]
AS
BEGIN	
	select * from DegreeTypes where DegreeTypes.IsActive='true'
END
GO
