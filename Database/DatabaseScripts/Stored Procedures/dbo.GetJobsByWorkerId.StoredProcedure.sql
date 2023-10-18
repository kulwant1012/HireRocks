USE [HireRocks_Dev]
GO

/****** Object:  StoredProcedure [dbo].[GetJobsByWorkerId]    Script Date: 04-02-2016 17:55:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[GetJobsByWorkerId] 
 @WorkerId nvarchar(max),
 @IsActive bit = NULL
AS
BEGIN
SELECT
	Contracts.ContractId,
	Contracts.StartDate,
	Contracts.HoursLimit,
	Contracts.FixedRate,
	Jobs.JobTitle,
	Jobs.JobTypeId,		
	WorkerHourlyRate.HourlyRate,
	JobTypes.JobTypeName,
	(CASE WHEN Contracts.ContractStatusId=1 THEN (SELECT 'Open')
	      WHEN Contracts.ContractStatusId=2 THEN (Select 'Closed')
		  WHEN Contracts.ContractStatusId=3 THEN (Select 'Cancel')
		  WHEN Contracts.ContractStatusId=4 THEN (Select 'Awaiting')
	END) AS ContractStatus	
FROM
	Contracts 
	JOIN Jobs ON Jobs.JobId=Contracts.JobId 
	JOIN JobTypes ON Jobs.JobTypeId = JobTypes.JobTypeId
	Left JOIN WorkerHourlyRate ON WorkerHourlyRate.ContractId = Contracts.ContractId
WHERE
	WorkerId=@WorkerId AND
	WorkerHourlyRate.ToDate IS NULL AND
	( 
	ContractStatusId= case when @IsActive='true' then '1'
	end
	or
	ContractStatusId= case when @IsActive='false' then '2'
	end
	or
	@IsActive is null
	)
END

GO

