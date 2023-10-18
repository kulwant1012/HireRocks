USE [HireRocks_Dev]
GO

/****** Object:  StoredProcedure [dbo].[WorkSummaryOfClientByClientId]    Script Date: 27-04-2016 03:48:45 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Radhika Vasudev>
-- Create date: <10-03-2016>
-- Description:	<To Get the summary of total costing by ClientId>
-- =============================================
CREATE PROCEDURE [dbo].[WorkSummaryOfClientByClientId]
	-- Add the parameters for the stored procedure here
       @ClientId nvarchar(128),
       @StartDate Date,
       @EndDate Date
       
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
SELECT 
sum([hours]) as hrs
,Projectname,
StartDate,
EndDate,
StartDate1,
EndDate1,
ClientName
,max(EmpCount) as empcount
,sum(Cost) as cost 
from 
(
Select SUM(TimeBurned)/3600000 AS Hours,
CONVERT(varchar, CONVERT(date,@StartDate), 100)AS StartDate,
CONVERT(varchar, CONVERT(date,Contracts.StartDate), 100) AS StartDate1,
CONVERT(varchar, CONVERT(date,Contracts.EndDate), 100) AS EndDate1,
CONVERT(varchar, CONVERT(date,@EndDate), 100) AS EndDate,
(SELECT FirstName+' ' +LastName from AspNetUsers where ID=@ClientId) as ClientName,
Jobtitle AS ProjectName,
(SELECT Count(workerId)from Contracts WHERE Contracts.JobId=Jobs.JobId)AS EmpCount,
WorkerHourlyrate.HourlyRate AS HRSRATE,
(SUM(TimeBurned)/3600000*WorkerHourlyrate.HourlyRate)AS Cost
 from Capture 
inner Join Contracts ON Capture.ContractId=Contracts.ContractId
Inner Join Jobs on Jobs.JobId=Contracts.JobId
Inner Join AspNetUsers On AspNetUsers.Id=Jobs.ClientId
Inner JOIN WorkerHourlyRate ON WorkerHourlyRate.ContractId=Contracts.ContractId
Where ClientId=@ClientId
AND 
	((StartDate<=@StartDate AND EndDate is Null)
	OR (StartDate<=@StartDate AND EndDate<=@EndDate) 
	OR (StartDate>=@StartDate AND EndDate is null )
	OR (StartDate>=@StartDate AND EndDate<=@EndDate))
	
Group By
Contracts.JobId,
Jobs.JobId,
Jobs.JobTitle,
Contracts.StartDate,
WorkerHourlyRate.HourlyRate,
Contracts.EndDate
) as innerTable

group by Projectname,
ClientName,
StartDate,
StartDate1,
EndDate1,
EndDate




END

   

GO

