USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[GetAllJobCategories]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllJobCategories]
AS
BEGIN	
	select * from JobCategories where JobCategories.IsActive='true'
END

SET ANSI_NULLS ON
GO
