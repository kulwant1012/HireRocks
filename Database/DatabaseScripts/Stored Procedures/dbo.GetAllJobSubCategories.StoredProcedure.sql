USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[GetAllJobSubCategories]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllJobSubCategories]
AS
BEGIN	
	select * from JobSubCategories where JobSubCategories.IsActive='true'
END
GO
