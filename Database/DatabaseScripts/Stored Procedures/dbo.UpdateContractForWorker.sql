USE [HireRocks_Dev]
GO

/****** Object:  StoredProcedure [dbo].[UpdateContractForWorker]    Script Date: 05/07/2016 16:59:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateContractForWorker]
	@ContractId BIGINT,
	@FixedRate DECIMAL,
	@HourlyRate DECIMAL,
	@WeeklyHourLimit DECIMAL,
	@IsEndingContract BIT,
	@EndReason NVARCHAR(MAX),
	@Skill DECIMAL,
	@Quality DECIMAL,
	@Availability DECIMAL,
	@Deadline DECIMAL,
	@Communication DECIMAL,
	@Cooperation DECIMAL,
	@Comment NVARCHAR(MAX),
    @UserId NVARCHAR(128)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @NotificationMessage AS NVARCHAR(MAX)
	DECLARE @CurrentDate AS DATETIME= GETDATE()
	
	IF(@IsEndingContract='FALSE')
	BEGIN
		UPDATE Contracts 
		SET FixedRate=@FixedRate,
			HoursLimit=@WeeklyHourLimit,
			ModifiedByUserId=@UserId,
			ModifiedDate=@CurrentDate
		WHERE ContractId=@ContractId
		
		IF EXISTS(SELECT WorkerHourlyRateId FROM WorkerHourlyRate WHERE ContractId=@ContractId AND HourlyRate != @HourlyRate AND ToDate IS NULL)
		BEGIN
			UPDATE WorkerHourlyRate
			SET ToDate = @CurrentDate
			WHERE ContractId=@ContractId AND HourlyRate != @HourlyRate AND ToDate IS NULL				
			INSERT INTO WorkerHourlyRate(ContractId,HourlyRate,FromDate) VALUES(@ContractId,@HourlyRate,@CurrentDate)
		END		
	END

	IF (@IsEndingContract = 'TRUE')	
	BEGIN
		IF EXISTS(SELECT * FROM UserRatings WHERE ContractId=@ContractId AND UserId=@UserId )
		BEGIN
			UPDATE UserRatings
			SET
				Skill = @Skill, 
				Quality = @Quality, 
				Availability = @Availability, 
				Deadline = @Deadline, 
				Communication = @Communication, 
				Cooperation = @Cooperation, 
				Comment = @Comment
			WHERE ContractId=@ContractId AND UserId=@UserId
		END
		
		ELSE
		BEGIN
			INSERT INTO UserRatings
			(
			    Skill,
			    Quality,
			    Availability,
			    Deadline,
			    Communication,
			    Cooperation,
			    Comment,
			    UserId,
			    ContractId
			)
			VALUES
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
			
			UPDATE Contracts 
			SET EndReason=@EndReason,
				EndDate=@CurrentDate,
				ContractStatusId=2,
				ModifiedByUserId=@UserId,
				ModifiedDate=@CurrentDate
			WHERE ContractId=@ContractId
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
	    'Contract for job '+ JobTitle +' is updated by user ' +FirstName+' '+LastName,
	    'FALSE', 
	    'FALSE',
	    @CurrentDate, 
	    ClientId
	 FROM AspNetUsers 
		  LEFT JOIN Contracts ON Contracts.WorkerId = AspNetUsers.Id
		  LEFT JOIN Jobs ON Jobs.JobId = Contracts.JobId
     WHERE Contracts.ContractId=@ContractId
END

GO

