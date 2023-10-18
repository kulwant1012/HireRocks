USE [HireRocks_Dev]
GO

/****** Object:  StoredProcedure [dbo].[GetAllContractsByWorkerIdAndClientId]    Script Date: 08-02-2016 18:45:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetAllContractsByWorkerIdAndClientId]
	@WorkerId nvarchar(max),
	@ClientId nvarchar(max)
AS
BEGIN
	SET NOCOUNT ON;
    SELECT 
		Contracts.ContractId, 
		JobTitle, 
		StartDate, 
		WorkerHourlyRate.HourlyRate,
		Contracts.FixedRate, 
		ContractStatusName,
		JobTypeName 
    FROM Contracts 
		LEFT JOIN ContractStatus ON Contracts.ContractStatusId = ContractStatus.ContractStatusId
		LEFT JOIN Jobs ON Jobs.JobId = Contracts.JobId AND Jobs.ClientId=@ClientId
		LEFT JOIN WorkerHourlyRate ON WorkerHourlyRate.ContractId = Contracts.ContractId AND WorkerHourlyRate.ToDate IS NULL
		LEFT JOIN JobTypes ON JobTypes.JobTypeId = Jobs.JobTypeId
    WHERE WorkerId=@WorkerId AND 
		Contracts.ContractStatusId != 3
END


GO

