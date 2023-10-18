USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[GetJobBidById]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetJobBidById]
@JobBidId bigint
AS
BEGIN
	SELECT
	JobBidId,
	Jobs.JobId,
	JobTitle,
	Rate,
	JobTypeId
	FROM
	JobsBids 
	JOIN Jobs ON Jobs.JobId = JobsBids.JobId
	WHERE
	JobsBids.JobBidId = @JobBidId
		
	
END
GO
