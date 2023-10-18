USE [HireRocks_Dev]
GO

/****** Object:  StoredProcedure [dbo].[RejectCapture]    Script Date: 02/11/2016 17:48:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Avtar>
-- Create date: <10 Feb,2016>
-- Description:	<Reject captures by Client>
-- =============================================
CREATE PROCEDURE [dbo].[RejectCapture]
	@CaptureIdsToReject NVARCHAR(MAX),
	@FromDate DATETIME,
	@ToDate DATETIME
AS
BEGIN	
	SET NOCOUNT ON;
	UPDATE Capture SET IsRejected='FALSE' WHERE CaptureDate<=@ToDate AND CaptureDate>=@FromDate
	UPDATE Capture SET IsRejected='TRUE' WHERE CaptureId IN (SELECT splitdata FROM FunctionSplitString(@CaptureIdsToReject,',')) 
END

GO

