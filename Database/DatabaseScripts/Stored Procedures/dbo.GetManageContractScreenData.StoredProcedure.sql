USE [HireRocks_Dev]
GO

/****** Object:  StoredProcedure [dbo].[GetManageContractScreenData]    Script Date: 04/18/2016 14:54:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetManageContractScreenData]
	@ContractId BIGINT,
	@UserId NVARCHAR(128)
AS
BEGIN
	SELECT
		Contracts.ContractId,
		Contracts.EstimateDuration,
		Contracts.HoursLimit,
		Contracts.FixedRate,
		Contracts.EndReason,
		Contracts.ContractStatusId,
		Jobs.JobTitle,
		Jobs.JobTypeId,
		JobTypes.JobTypeName,
		UserRatings.UserRatingId,
		UserRatings.Skill,
		UserRatings.Quality,
		UserRatings.Availability,
		UserRatings.Deadline,
		UserRatings.Communication,
		UserRatings.Cooperation,
		UserRatings.Comment,
		WorkerHourlyRate.HourlyRate,
		EndDate,
		(SELECT SUM(TimeBurned) FROM Capture WHERE Capture.ContractId = Contracts.ContractId) AS ActualDuration
	FROM
		Contracts 
		JOIN Jobs ON Contracts.JobId=Jobs.JobId
		JOIN JobTypes ON JobTypes.JobTypeId = Jobs.JobTypeId
		LEFT JOIN UserRatings ON UserRatings.ContractId = Contracts.ContractId AND UserRatings.UserId = @UserId
		LEFT JOIN WorkerHourlyRate ON WorkerHourlyRate.ContractId=@ContractId AND WorkerHourlyRate.ToDate IS NULL
	WHERE
		Contracts.ContractId=@ContractId
END


GO

