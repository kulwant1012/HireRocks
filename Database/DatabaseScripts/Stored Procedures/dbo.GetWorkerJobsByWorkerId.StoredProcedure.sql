USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[GetWorkerJobsByWorkerId]    Script Date: 02/01/2016 15:16:43 ******/
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
Jobrating
FROM
Contracts JOIN Jobs on Jobs.JobId=Contracts.JobId 
WHERE
WorkerId=@WorkerId and (Contracts.ContractStatusId='2'or Contracts.ContractStatusId='1')
END
GO
