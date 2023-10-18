USE [HireRocks_Dev]
GO

/****** Object:  StoredProcedure [dbo].[GetJobCapturesByContractId]    Script Date: 22-02-2016 03:38:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[GetJobCapturesByContractId]
	@ContractId BIGINT,
	@FromDate DATETIME,
	@ToDate DATETIME
AS
BEGIN
SELECT * FROM Capture 
		 WHERE ContractId=@ContractId AND
			   IsDeleted='FALSE' AND
			   CAST(CaptureDate AS DateTime)>=CAST(@FromDate AS DateTime) AND
			   CAST(CaptureDate AS DateTime)<=CAST(@ToDate AS DateTime) 
END


GO

