USE [HireRocks_Dev]
GO

/****** Object:  StoredProcedure [dbo].[GetWorkerJobsByWorkerId]    Script Date: 27-04-2016 03:51:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetWorkerJobsByWorkerId]
@WorkerId nvarchar(max)
AS
BEGIN
SELECT
JobTitle,
StartDate,
EndDate,
HourlyRate,
Contracts.FixedRate,
ContractStatusId,
Jobrating,
Jobs.JobId
FROM
Contracts JOIN Jobs on Jobs.JobId=Contracts.JobId 
WHERE
WorkerId=@WorkerId and (Contracts.ContractStatusId='2'or Contracts.ContractStatusId='1')
END

GO

