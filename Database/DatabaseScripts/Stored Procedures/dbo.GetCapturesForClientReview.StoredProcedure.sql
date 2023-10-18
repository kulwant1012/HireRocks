USE [HireRocks_Dev]
GO

/****** Object:  StoredProcedure [dbo].[GetCapturesForClientReview]    Script Date: 22-02-2016 03:45:16 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Avtar>
-- Create date: <2 Feb,2016>
-- Description:	<This will fetch captures for client review>
-- =============================================
CREATE PROCEDURE [dbo].[GetCapturesForClientReview]
	@WorkerId AS NVARCHAR(MAX),
	@JobId AS BIGINT,
	@FromDate AS DATETIME,
	@ToDate AS DATETIME,
	@IsRejected AS BIT = NULL
AS
BEGIN	
	SET NOCOUNT ON;
	
	SELECT CaptureId,
		   KeyCount,
		   MouseCount,
		   KeyboardCapture,
		   MouseCapture,
		   ScreenCaptureThumbnailImage,
		   ScreenCaptureFullImage,
		   CaptureDate,
		   TimeBurned,
		   Capture.ContractId,
		   IsRejected
	FROM Capture LEFT JOIN Contracts ON Capture.ContractId=Contracts.ContractId

	WHERE Contracts.JobId=@JobId AND 
		  Contracts.WorkerId=@WorkerId AND 
	      Capture.IsDeleted='False'	AND
	      CAST(CaptureDate AS DATETIME)>= CAST(@FromDate AS DATETIME) AND
	      CAST(CaptureDate AS DATETIME)<=CAST(@ToDate AS DATETIME) AND 
	      (IsRejected=@IsRejected OR (IsRejected IS NULL AND @IsRejected='FALSE') OR @IsRejected IS NULL)	    
END


GO

