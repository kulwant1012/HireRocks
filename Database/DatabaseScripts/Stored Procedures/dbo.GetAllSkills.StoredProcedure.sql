USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[GetAllSkills]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllSkills]
AS
BEGIN	
	select * from Skills where Skills.IsActive='true'
END

SET ANSI_NULLS ON
GO
