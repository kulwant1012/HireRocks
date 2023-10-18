USE [HireRocks_Dev]
GO

/****** Object:  StoredProcedure [dbo].[GetAllJobTypes]    Script Date: 03-02-2016 11:52:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetAllJobTypes]	
AS
BEGIN
	SELECT * FROM JobTypes where IsActive='true'
END


GO

