USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[GetAllLanguages]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllLanguages]
AS
BEGIN	
	select * from Languages where Languages.IsActive='true'
END

SET ANSI_NULLS ON
GO
