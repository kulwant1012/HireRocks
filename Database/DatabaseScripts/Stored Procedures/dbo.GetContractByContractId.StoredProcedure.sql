USE [HireRocks_Dev]
GO

/****** Object:  StoredProcedure [dbo].[GetContractByContractId]    Script Date: 04/18/2016 14:53:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetContractByContractId]
	@ContractId bigint,
	@ClientId nvarchar(max)
AS
BEGIN
	if(@ContractId is not null)
	select top(1) 
	(SELECT SUM(TimeBurned) FROM Capture WHERE Capture.ContractId=Contracts.ContractId ) AS ActualDuration,
	Contracts.ContractId,
	Contracts.ContractStatusId,
	Contracts.EndDate,
	Contracts.EndReason,
	Contracts.EstimateDuration,
	Contracts.HourlyRate,
	Contracts.FixedRate,
	Contracts.HoursLimit,
	Contracts.JobId,
	Contracts.JobRating,
	Contracts.StartDate,
	Contracts.TimeUnitId,
	Contracts.WorkerId,
	Jobs.JobTypeId,
	Jobs.JobTitle,
	UserRatings.UserRatingId,
	UserRatings.Skill,
	UserRatings.Quality,
	UserRatings.Availability,
	UserRatings.Deadline,
	UserRatings.Communication,
	UserRatings.Cooperation,
	UserRatings.Comment,
	UserRatings.UserId
	from Contracts 
	join Jobs on Contracts.JobId = Jobs.JobId
	LEFT JOIN UserRatings on UserRatings.ContractId = @ContractId and UserRatings.UserId = @ClientId
	LEFT JOIN WorkerHourlyRate ON WorkerHourlyRate.ContractId = Contracts.ContractId AND WorkerHourlyRate.ToDate IS NULL
	
	WHERE Contracts.ContractId=@ContractId and Jobs.ClientId=@ClientId
END


GO

