USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[GetJobListForMessageScreen]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetJobListForMessageScreen]
@ClientId nvarchar(max)
AS
BEGIN
select JobId,JobTitle from Jobs where ClientId=@ClientId
END
GO
