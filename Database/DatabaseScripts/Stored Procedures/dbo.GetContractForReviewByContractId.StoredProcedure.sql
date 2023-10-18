USE [HireRocks_Dev]
GO

/****** Object:  StoredProcedure [dbo].[GetContractForReviewByContractId]    Script Date: 02/09/2016 12:49:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetContractForReviewByContractId]
	@ContractId bigint
AS
BEGIN
	SELECT
		Contracts.ContractId,
		Contracts.ContractStatusId,
		WorkerHourlyRate.HourlyRate,
		Contracts.FixedRate,
		Contracts.EstimateDuration,
		Contracts.HoursLimit,
		TimeUnits.UnitName,
		Jobs.JobTitle,
		Jobs.JobTypeId,
		Jobs.JobId,
		AspNetUsers.FirstName,
		AspNetUsers.LastName,
		AspNetUsers.UserName
	FROM
		Contracts LEFT JOIN Jobs on Contracts.JobId=Jobs.JobId
		LEFT JOIN WorkerHourlyRate on Contracts.ContractId=WorkerHourlyRate.ContractId
		LEFT JOIN TimeUnits on Contracts.TimeUnitId = TimeUnits.TimeUnitId
		LEFT JOIN AspNetUsers on Jobs.ClientId=AspNetUsers.Id
		LEFT JOIN ContractStatus on Contracts.ContractStatusId=ContractStatus.ContractStatusId
	WHERE
	Contracts.ContractId=@ContractId and (Contracts.ContractStatusId=4 or Contracts.ContractStatusId=1)

END
GO
