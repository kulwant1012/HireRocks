USE [HireRocks_Dev]
GO

/****** Object:  StoredProcedure [dbo].[GetJobsForTracker]    Script Date: 04/18/2016 14:59:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Avtar>
-- Create date: <2 Feb,2016>
-- Description:	<Fetch worker jobs for tracking>
-- =============================================
CREATE PROCEDURE [dbo].[GetJobsForTracker]
	@WorkerId NVARCHAR(MAX)
AS
BEGIN	
	SET NOCOUNT ON;
	SELECT Contracts.ContractId,
		   JobTitle,
		   JobStartDate,		   
	       JobTypeName,
	       HoursLimit,	       
	       TotalBurnedHours,
	       WeeklyBurnedHours,
	       TodayBurnedHours
	              
	FROM Jobs LEFT JOIN JobTypes ON Jobs.JobTypeId=JobTypes.JobTypeId
			  LEFT JOIN Contracts ON Contracts.JobId=Jobs.JobId AND Contracts.WorkerId=@WorkerId
			  CROSS APPLY GetBurnedHoursInformationFunction(Contracts.ContractId) 			  			  
    WHERE Contracts.WorkerId=@WorkerId AND
		  Contracts.ContractStatusId=1
    
END

GO

