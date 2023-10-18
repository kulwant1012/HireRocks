USE [HireRocks_Dev]
GO

/****** Object:  StoredProcedure [dbo].[GetCapturesScreenData]    Script Date: 02/11/2016 17:47:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Avtar>
-- Create date: <9 Feb, 2016>
-- Description:	<Get list of workers for review captures screen for client>
-- =============================================
CREATE PROCEDURE [dbo].[GetCapturesScreenData]
	@JobId BIGINT
AS
BEGIN	
	SET NOCOUNT ON;
    SELECT Id,FirstName,LastName 
    FROM AspNetUsers JOIN Contracts ON AspNetUsers.Id= Contracts.WorkerId 
    WHERE Contracts.JobId=@JobId
    
    SELECT JobTitle FROM Jobs WHERE JobId=@JobId
END

GO

