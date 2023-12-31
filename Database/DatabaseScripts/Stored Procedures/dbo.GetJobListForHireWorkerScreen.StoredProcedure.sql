USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[GetJobListForHireWorkerScreen]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetJobListForHireWorkerScreen]
	@ClientId nvarchar(max),
	@WorkerId nvarchar(max)
AS
BEGIN
	select 
	Jobs.JobId,
	JobTitle,
	JobTypeId,
	FixedRate
	from Jobs	
	where 
	Jobs.ClientId=@ClientId and 
	Jobs.IsActive='true' and 
	Jobs.IsHiringClosed='false' and
	Jobs.JobId not in (select JobId from Contracts where Contracts.WorkerId = @WorkerId)
END
GO
