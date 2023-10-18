USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[GetJobsByClientId]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetJobsByClientId]
	@ClientId nvarchar(max)
AS
BEGIN
	select JobId,JobTitle,JobStartDate,JobEndDate,IsActive,IsHiringClosed from Jobs where ClientId =@ClientId
END
GO
