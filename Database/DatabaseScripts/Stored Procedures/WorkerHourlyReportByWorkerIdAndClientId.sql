USE [HireRocks_Dev]
GO

/****** Object:  StoredProcedure [dbo].[WorkerHourlyReportByWorkerIdAndClientId]    Script Date: 27-04-2016 03:46:16 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Radhika>
-- Create date: <23-02-2016>
-- Description:	<To get captureDate,Timeburned,MemoText based on contractID>
-- =============================================
Create PROCEDURE [dbo].[WorkerHourlyReportByWorkerIdAndClientId]
	-- Add the parameters for the stored procedure here
	@WorkerId nvarchar(max),
	@Date Date,
	@JobId Bigint=NULL,
	@ClientId nvarchar(Max)
 AS
BEGIN
--DECLARE @SQL NVARCHAR(MAX)=''

--SET @SQL = 'SELECT SUM(TimeBurned) AS Timeburned,
--	     MemoText,
--		 JobTitle,
--		 Capture.ContractId,
--		 Contracts.FixedRate,
--		 WorkerHourlyRate.HourlyRate,
--		 SUM(TimeBurned)/3600000 as hours,
--		 SUM(TimeBurned)/3600000*WorkerHourlyRate.HourlyRate AS Earnings,
--		 CaptureDate,
--	     CONVERT(DATE,CaptureDate,101) as DT
--	    FROM Capture inner JOIN Contracts ON Capture.ContractId=Contracts.ContractId
--	    Left JOIN WorkerHourlyRate ON WorkerHourlyRate.ContractId=Contracts.ContractId
--		inner JOIN Memo ON Memo.MemoId=Capture.MemoId 
--		inner JOIN Jobs ON Jobs.JobId=Contracts.JobId'

--		SET @SQL = @SQL + ' WHERE Contracts.WorkerId ='+ CHAR(39) + REPLACE(@WorkerId, CHAR(39), CHAR(39)+CHAR(39)) + CHAR(39)
--     	SET @SQL = @SQL + ' AND CONVERT(DATE,CaptureDate,101) =' + CHAR(39) + REPLACE(@Date, CHAR(39), CHAR(39)+CHAR(39)) + CHAR(39)
--		if @JobId<>''
--		SET @SQL = @SQL + ' AND Jobs.JobId=' + CHAR(39) + REPLACE(@JobId, CHAR(39), CHAR(39)+CHAR(39)) + CHAR(39)
--		SET @SQL = @SQL + '   
--            GROUP BY    MemoText,
--            JobTitle,
--			WorkerHourlyRate.HourlyRate,
--			CaptureDate,
--			Capture.ContractId,
--			Contracts.FixedRate' 

--			--PRINT @SQL
--			EXEC SP_EXECUTESQL @SQL

	SET NOCOUNT ON;
	SELECT SUM(TimeBurned) AS Timeburned,
	     MemoText,
		 JobTitle,
		 Capture.ContractId,
		 Contracts.FixedRate,
		 WorkerHourlyRate.HourlyRate,
		 SUM(TimeBurned)/3600000 as hours,
		 SUM(TimeBurned)/3600000*WorkerHourlyRate.HourlyRate AS Earnings,
		 CaptureDate,
	     CONVERT(DATE,CaptureDate,101) as DT
	    FROM Capture inner JOIN Contracts ON Capture.ContractId=Contracts.ContractId
	    Left JOIN WorkerHourlyRate ON WorkerHourlyRate.ContractId=Contracts.ContractId
		inner JOIN Memo ON Memo.MemoId=Capture.MemoId 
		inner JOIN Jobs ON Jobs.JobId=Contracts.JobId
  WHERE Contracts.WorkerId=@WorkerId
  and CONVERT(DATE,CaptureDate,101)=@Date
  and Contracts.CreatedByUserId=@ClientId
  and (@JobId IS NULL OR Jobs.JobId =@JobId)
  
GROUP BY    MemoText,
            JobTitle,
			WorkerHourlyRate.HourlyRate,
			CaptureDate,
			Capture.ContractId,
			Contracts.FixedRate
END

GO

