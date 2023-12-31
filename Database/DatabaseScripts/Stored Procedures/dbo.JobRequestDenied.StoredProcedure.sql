USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[JobRequestDenied]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[JobRequestDenied]
@JobBidId bigint
AS
BEGIN
	UPDATE JobsBids 
	SET 
		IsDenied='True' 
	WHERE
		JobBidId=@JobBidId 
		
	INSERT INTO Notifications(NotificationText,IsViewed,IsDeleted,DateTime,UserId)
	SELECT
		NotificationText ='Client "'+AspNetUsers.FirstName+' '+AspNetUsers.LastName+'" denied your bid for job "'+Jobs.JobTitle+'"',
		'False',
		'False',
		getdate(),
		JobsBids.WorkerId
	FROM
		JobsBids 
		Join Jobs On JobsBids.JobId = Jobs.JobId
		Join AspNetUsers On AspNetUsers.Id = Jobs.ClientId
	WHERE 
		JobsBids.JobBidId = @JobBidId
END
GO
