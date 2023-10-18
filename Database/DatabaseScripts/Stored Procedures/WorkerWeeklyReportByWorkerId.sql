USE [HireRocks_Dev]
GO

/****** Object:  StoredProcedure [dbo].[WorkerWeeklyReportByWorkerId]    Script Date: 27-04-2016 03:46:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Radhika>
-- Create date: <23-02-2016>
-- Description:	<To get captureDate,Timeburned,MemoText based on WorkerID>		
-- =============================================
CREATE PROCEDURE [dbo].[WorkerWeeklyReportByWorkerId]
	-- Add the parameters for the stored procedure here
	@WorkerId nvarchar(max),
	@FromDate Date,
	@ToDate Date,
	@JobId Bigint=null
 AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT CONVERT(varchar, CONVERT(date,@FromDate), 100) AS FromDate,
	       CONVERT(varchar, CONVERT(date,@ToDate), 100) AS ToDate,
	       FirstName+' ' +LastName AS WorkerName,
	       SUM(TimeBurned) AS Timeburned,
	       MemoText,
		   JobTitle,
		   JobDescription,
		   Capture.ContractId,
		   WorkerHourlyRate.HourlyRate AS HourlyRate,
		   SUM(TimeBurned)/3600000 as hours,
		   SUM(TimeBurned)/3600000*WorkerHourlyRate.HourlyRate AS Earnings,
		   (SELECT FirstName+' '+ LastName from AspNetUsers where ID= jobs.ClientId) as ClientName,
		    CONVERT(varchar, CONVERT(date,CaptureDate), 100) as CaptureDate
	 FROM Capture inner JOIN Contracts ON Capture.ContractId=Contracts.ContractId
		LEFT OUTER JOIN Memo ON Memo.MemoId=Capture.MemoId 
		LEFT OUTER JOIN Jobs ON Jobs.JobId=Contracts.JobId
		LEFT OUTER JOIN WorkerHourlyRate ON WorkerHourlyRate.ContractId=Contracts.ContractId
		INNER JOIN AspNetUsers ON Contracts.WorkerId=AspNetUsers.Id
        WHERE Contracts.WorkerId=@WorkerId
        and CONVERT(DATE,CaptureDate,101) between @FromDate and @ToDate
		AND (@JobId is null or jobs.JobId=@JobId)
  GROUP BY   
            MemoText,
            JobTitle,
            JobDescription,
            FirstName,
            LastName,
            Jobs.ClientId,
     CONVERT(varchar, CONVERT(date,CaptureDate), 100),
			WorkerHourlyRate.HourlyRate,
			Capture.ContractId
		
			
END

GO

