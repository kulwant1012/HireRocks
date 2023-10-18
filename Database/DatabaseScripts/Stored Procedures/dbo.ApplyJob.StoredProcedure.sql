USE [HireRocks_Dev]
GO

/****** Object:  StoredProcedure [dbo].[ApplyJob]    Script Date: 02/04/2016 16:06:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ApplyJob]
	@jobId BIGINT,
	@Rate DECIMAL,
	@WorkerId NVARCHAR(MAX),
	@ApplyJobAttachments XML,	
	@CoverLetter NVARCHAR(MAX),
	@WorkerName NVARCHAR(MAX)
AS
BEGIN
	DECLARE @JobBidId BIGINT
	IF NOT EXISTS(SELECT JobId,WorkerId FROM JobsBids WHERE JobId=@JobId and WorkerId=@WorkerId)
	BEGIN
		INSERT INTO JobsBids (JobId,Rate,WorkerId,IsHired,IsDenied,CoverLetter) VALUES(@JobId,@Rate,@WorkerId,'False','False',@CoverLetter)		
		SET @JobBidId=@@IDENTITY

		INSERT INTO JobsBidAttachments 
					SELECT [Table].[Column].value('AttachmentName[1]', 'Nvarchar(MAX)') AS 'AttachmentName',
						   [Table].[Column].value('AttachmentOriginalName[1]', 'Nvarchar(MAX)') AS 'AttachmentOriginalName',
						   @JobBidId
					FROM @ApplyJobAttachments.nodes('/ArrayOfJobAttachmentsViewModel/JobAttachmentsViewModel') AS [Table]([Column]) 

		INSERT INTO Notifications(NotificationText,IsViewed,IsDeleted,DateTime,UserId)
					SELECT NotificationText='Worker "'+@WorkerName+'" applied to job "'+Jobs.JobTitle+'"','false','false',GETDATE(),Jobs.ClientId 
					FROM Jobs 
					WHERE Jobs.JobId=@JobId
	END
END

GO

