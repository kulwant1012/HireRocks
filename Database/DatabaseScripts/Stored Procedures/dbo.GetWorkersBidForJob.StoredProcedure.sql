USE [HireRocks_Dev]
GO

/****** Object:  StoredProcedure [dbo].[GetWorkersBidForJob]    Script Date: 05-02-2016 15:18:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetWorkersBidForJob]
@JobId BIGINT,
@ClientId NVARCHAR(MAX)
AS
BEGIN

SELECT 
	 Id,
	 FirstName,
	 LastName,
	 ProfileTitle,
	 Country1,
	 ProfilePic,
	 JobsBids.Rate,
	 JobsBids.JobId,
	 JobsBids.IsHired,
	 JobsBids.IsDenied,
	 JobsBids.JobBidId,
	 JobsBids.CoverLetter,
	 UserProfiles.UserHourlyRate,
	 UserProfiles.UserRating,
	 (SELECT (SELECT (SELECT AttachmentName, AttachmentOriginalName 
							 FROM JobsBidAttachments WHERE JobBidId=JobsBids.JobBidId
							 FOR XML PATH('JobAttachmentsViewModel'),TYPE)FOR XML PATH(''),ROOT('ArrayOfJobAttachmentsViewModel'))) AS Attachments,
							 							 
	 (CASE WHEN Contracts.ContractStatusId=1 THEN 'Already hired' 
			       WHEN Contracts.ContractStatusId=4 AND Contracts.ModifiedByUserId = @ClientId THEN 'Waiting you to review' 
			       WHEN (Contracts.ModifiedByUserId IS NULL AND Contracts.ContractStatusId=4) OR (Contracts.ContractStatusId=4 AND Contracts.ModifiedByUserId != @ClientId) THEN 'Waiting for worker review' 
			       WHEN Contracts.ContractStatusId=2 THEN 'Contract closed'
			       WHEN Contracts.ContractStatusId=3 THEN 'Contract canceled'
			       WHEN Contracts.ContractId IS NULL AND JobsBids.IsHired='FALSE' AND JobsBids.IsDenied='FALSE' THEN 'Hire' END)AS HireButtonText

FROM AspNetUsers 
	 LEFT JOIN UserProfiles ON UserProfiles.UserId=AspNetUsers.Id 
	 LEFT JOIN AspNetUserRoles on AspNetUserRoles.UserId=AspNetUsers.Id
	 LEFT JOIN JobsBids on JobsBids.WorkerId=AspNetUsers.Id
	 LEFT JOIN Contracts ON JobsBids.JobId=Contracts.JobId AND JobsBids.WorkerId=Contracts.WorkerId
	 
WHERE JobsBids.JobId=@JobID AND JobsBids.IsDenied='False'
END


GO

