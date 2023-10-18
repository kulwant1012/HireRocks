USE [HireRocks_Dev]
GO

/****** Object:  StoredProcedure [dbo].[ApproveContract]    Script Date: 04-02-2016 17:54:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ApproveContract]
	@ContractId bigint,
	@ModifiedByUserId nvarchar(128),
	@JobId bigint
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE Contracts 
	SET 
	Contracts.ContractStatusId = 1,
	Contracts.StartDate = Getdate(),
	Contracts.ModifiedByUserId =@ModifiedByUserId,
	Contracts.ModifiedDate = getdate()
	WHERE ContractId=@ContractId and ContractStatusId=4
	INSERT into Notifications
	(
		NotificationText,
		IsViewed,
		IsDeleted,
		DateTime,
		UserId
	)
	SELECT
		NotificationText='Your proposal for job "'+Jobs.JobTitle+'" is accepted by worker "'+AspNetUsers.FirstName +' '+AspNetUsers.LastName+'"',
		'false',
		'false',
		getdate(),
		Jobs.ClientId
    FROM  Jobs join Contracts on Contracts.Jobid=Jobs.JobId 
    Join AspNetUsers on Contracts.WorkerId = AspNetUsers.Id
    WHERE Contracts.ContractId=@ContractId

	UPDATE JobsBids Set JobsBids.IsHired='True' where JobId=@JobId
END


GO

