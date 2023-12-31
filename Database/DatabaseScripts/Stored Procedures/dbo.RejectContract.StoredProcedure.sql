USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[RejectContract]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RejectContract]
	@ContractId bigint,
	@ModifiedByUserId nvarchar(128),
	@EndReason nvarchar(max)
AS
BEGIN
    
	Update contracts 
	Set 
	ContractStatusId = 3,
	EndReason = @EndReason,
	ModifiedDate = getdate(),
	ModifiedByUserId = @ModifiedByUserId
	Where 
	ContractId=@ContractId and ( ContractStatusId=4 or ContractStatusId=1)
	
	Insert into Notifications
	(
		NotificationText,
		IsViewed,
		IsDeleted,
		DateTime,
		UserId
	)
	SELECT
		NotificationText='Your proposal for job "'+Jobs.JobTitle+'" is denied by worker "'+AspNetUsers.FirstName +' '+AspNetUsers.LastName+'"',
		'false',
		'false',
		getdate(),
		Jobs.ClientId
    From  Jobs join Contracts on Contracts.Jobid=Jobs.JobId 
    Join AspNetUsers on Contracts.WorkerId = AspNetUsers.Id
    Where Contracts.ContractId=@ContractId
END
GO
