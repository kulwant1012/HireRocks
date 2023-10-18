USE [HireRocks_Dev]
GO

/****** Object:  StoredProcedure [dbo].[InsertUpdateContract]    Script Date: 05/07/2016 17:22:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[InsertUpdateContract] 
	@ContractId bigint,
	@WorkerId nvarchar(max),
	@JobId bigint,	
	@HourlyRate decimal,
	@FixedRate decimal,
	@EstimatedDuration decimal,
	@WeeklyHourLimit decimal,
	@TimeUnitId bigint,
	@ContractStatusId bigint,
	@EndDate datetime,
	@EndReason nvarchar(max),
	@CreatedModifiedByUserId nvarchar(128),	
	@IsEndingContract bit,
	@UserRatingId bigint,
	@Skill decimal,
	@Quality decimal,
	@Availability decimal,
	@Deadline decimal,
	@Communication decimal,
	@Cooperation decimal,
	@Comment nvarchar(max),
	@UserId nvarchar(128),
	@HourlyRateDateFromOrTo datetime
AS
BEGIN	
	--SET NOCOUNT ON;
IF (@ContractId is null)
BEGIN
INSERT INTO Contracts(
	ContractStatusId,
	EstimateDuration,
	HoursLimit,
	JobId,
	TimeUnitId,
	WorkerId,
	FixedRate,
	CreatedDate,
	CreatedByUserId)
OUTPUT Inserted.ContractId as ContractId
VALUES (
	@ContractStatusId,
	@EstimatedDuration,
	@WeeklyHourLimit,
	@JobId,
	@TimeUnitId,
	@WorkerId,
	@FixedRate,
	getdate(),
	@CreatedModifiedByUserId
)

IF(@HourlyRate IS NOT NULL)
BEGIN
	INSERT INTO WorkerHourlyRate(
	ContractId,
	HourlyRate,
	FromDate
	) 
	VALUES(
	@@Identity,
	@HourlyRate,
	@HourlyRateDateFromOrTo
	)
END

INSERT INTO Notifications
(
	NotificationText,
	IsViewed,
	IsDeleted,
	DateTime,
	UserId
)
SELECT
	NotificationText='New contract for job "'+Jobs.JobTitle+'" is assigned to you by client "'+AspNetUsers.FirstName +' '+AspNetUsers.LastName+'"',
	'false',
	'false',
	getdate(),
	Contracts.WorkerId
FROM  
    Jobs join Contracts on Contracts.Jobid=Jobs.JobId 
    Join AspNetUsers on Jobs.ClientId = AspNetUsers.Id
WHERE
	Contracts.ContractId=@@Identity	

UPDATE JobsBid SET IsHired='True' WHERE JobId=@JobId and WorkerId=@WorkerId
END


ELSE
	BEGIN
		UPDATE Contracts 
		SET 
		ContractStatusId=@ContractStatusId,
		EstimateDuration=@EstimatedDuration,
		HoursLimit=@WeeklyHourLimit,
		TimeUnitId=@TimeUnitId,
		EndDate=@EndDate,
		EndReason=@EndReason,
		FixedRate=@FixedRate,
		ModifiedDate=getdate(),
		ModifiedByUserId=@CreatedModifiedByUserId
		OUTPUT Inserted.ContractId as ContractId
		WHERE ContractId=@ContractId 
		
		IF(@HourlyRate IS NOT NULL)
		BEGIN
			IF EXISTS(SELECT WorkerHourlyRateId FROM WorkerHourlyRate WHERE ContractId=@ContractId AND HourlyRate != @HourlyRate AND ToDate IS NULL)
			BEGIN
				UPDATE WorkerHourlyRate
				SET ToDate = @HourlyRateDateFromOrTo
				WHERE ContractId=@ContractId AND HourlyRate != @HourlyRate AND ToDate IS NULL
				INSERT INTO WorkerHourlyRate
				(
					ContractId,
					HourlyRate,
					FromDate
				)
				VALUES
				(
					@ContractId,
					@HourlyRate,
					@HourlyRateDateFromOrTo
				)
			END
		END

		INSERT INTO Notifications
		(
			NotificationText,
			IsViewed,
			IsDeleted,
			DateTime,
			UserId
		)
		SELECT
			NotificationText='Contract for job "'+Jobs.JobTitle+'" is modified by client "'+AspNetUsers.FirstName +' '+AspNetUsers.LastName+'"',
			'false',
			'false',
			getdate(),
			Contracts.WorkerId
		FROM  
			Jobs join Contracts on Contracts.Jobid=Jobs.JobId 
			Join AspNetUsers on Jobs.ClientId = AspNetUsers.Id
		WHERE
			Contracts.ContractId=@ContractId
			
		IF (@IsEndingContract ='true')
			BEGIN
			IF(@UserRatingId IS NOT NULL)
				BEGIN
					UPDATE UserRatings
					SET
						Skill=@Skill,
						Quality=@Quality,
						Availability=@Availability,
						Deadline=@Deadline,
						Communication=@Communication,
						Cooperation=@Cooperation,
						Comment = @Comment
					WHERE
					UserRatings.ContractId = @ContractId	
				END
			ELSE
				BEGIN
					INSERT INTO UserRatings
					Values
					(
						@Skill,
						@Quality,
						@Availability,
						@Deadline,
						@Communication,
						@Cooperation,
						@Comment,
						@UserId,
						@ContractId						
					)
				END				
			END		
	END
END




GO

