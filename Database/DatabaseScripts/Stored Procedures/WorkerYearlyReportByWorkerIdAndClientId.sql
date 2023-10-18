USE [HireRocks_Dev]
GO

/****** Object:  StoredProcedure [dbo].[WorkerYearlyReportByWorkerIdAndClientId]    Script Date: 27-04-2016 03:48:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[WorkerYearlyReportByWorkerIdAndClientId]
 -- Add the parameters for the stored procedure here
        @WorkerId nvarchar(128),
        @Year int,
		@JobId Bigint=NULL,
    	@ClientId nvarchar(Max)
AS
BEGIN
 -- SET NOCOUNT ON added to prevent extra result sets from
 -- interfering with SELECT statements.
 SET NOCOUNT ON;
  Select 
  SUM([Hours]) AS Hours,
  SUM([Earnings]) AS Earnings,
  ClientName,
  Month,
  Year,
  Address,
  WorkerName
  from
  (
     Select 
     @Year AS Year,
    (firstName+' '+LastName) AS WorkerName,
     Address1 AS Address,
    (SELECT FirstName+' ' +LastName from AspNetUsers where ID=jobs.ClientId) as ClientName,
  SUM(TimeBurned)/3600000 AS Hours,
  DATENAME(mm,CaptureDate)AS Month,
  WorkerHourlyRate.HourlyRate AS HourlyRate,
  SUM(TimeBurned)/3600000*WorkerHourlyRate.HourlyRate AS Earnings from Capture
     inner Join Contracts on Capture.ContractId=Contracts.ContractId
     inner Join WorkerHourlyRate ON Contracts.ContractId=WorkerHourlyRate.ContractId
     inner Join AspNetUsers ON Contracts.workerId=AspNetUsers.Id
     inner Join Jobs ON  Jobs.JobId=Contracts.JobId
     Where WorkerId=@WorkerId
    AND Year(CaptureDate)=@Year
	and Contracts.CreatedByUserId=@ClientId
	and  (@JobId IS NULL OR Jobs.JobId =@JobId)
    Group By
    WorkerHourlyRate.HourlyRate,
    Capture.CaptureDate,
    DATENAME(mm,CaptureDate),
    AspNetUsers.FirstName,
    AspNetUsers.LastName,
    Jobs.ClientId,
    Address1


  
  ) as innerTable
    Group By
    Month,
    ClientName,
    WorkerName,
    Address,
    Year
      Order BY DATEPART(mm,CAST([MONTH]+ ' 1900' AS DATETIME)) asc

END
GO

