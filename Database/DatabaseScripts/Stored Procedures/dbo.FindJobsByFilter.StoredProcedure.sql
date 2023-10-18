USE [HireRocks_Dev]
GO

/****** Object:  StoredProcedure [dbo].[FindJobsByFilter]    Script Date: 02/03/2016 11:41:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[FindJobsByFilter]
	@JobTitle NVARCHAR(MAX),
	@JobCategoryId BIGINT,
	@JobSubCategoryIds NVARCHAR(MAX),
	@JobTypeId BIGINT,
	@ExperienceLevelRequiredId BIGINT,	
	@WorkerId NVARCHAR(MAX)
AS
BEGIN
	DECLARE @ApplyButtonText NVARCHAR(MAX)
	DECLARE @JobSubCategories TABLE(JobSubCategory NVARCHAR(MAX))
	IF(@JobSubCategoryIds IS NULL AND @JobCategoryId IS NOT NULL)
	BEGIN
		INSERT INTO @JobSubCategories SELECT JobSubCategoryId FROM JobSubCategories WHERE JobCategoryId=@JobCategoryId
	END
	SELECT 
		Jobs.JobId,
		jobs.JobTitle,
		Jobs.JobDescription,
		Jobs.JobStartDate, 
		Jobs.JobEndDate,
		JobCategories.CategoryName,
		JobSubCategories.SubCategoryName,
		JobTypes.JobTypeName,
		Jobs.JobTypeId,
		Jobs.EstimateDuration,
		ExperienceLevels.LevelName,
		AspNetUsers.FirstName,
		AspNetUsers.LastName,
		AspNetUsers.UserName,
		WorkerTypes.Name AS WorkerType,
		Jobs.IsActive,
		TimeUnits.UnitName,
		Jobs.IsHiringClosed,
		Jobs.FixedRate,
		(CASE WHEN Contracts.WorkerId=@WorkerId AND Contracts.ContractStatusId=1 THEN (SELECT 'Already applied') 
			  WHEN (Contracts.WorkerId=@WorkerId AND Contracts.ContractStatusId=4 AND Contracts.ModifiedByUserId=@WorkerId) OR (JobsBids.IsDenied='False' AND JobsBids.IsHired='False') THEN (SELECT 'Waiting client review')
			  WHEN Contracts.WorkerId=@WorkerId AND Contracts.ContractStatusId=4 AND Contracts.ModifiedByUserId!=@WorkerId THEN (SELECT 'Waiting your review')
			  ELSE (SELECT 'Apply') END) AS ApplyButtonText
	
	FROM Jobs
		LEFT JOIN JobSubCategories ON JobSubCategories.JobSubCategoryId= Jobs.JobSubCategoryId
		LEFT JOIN JobCategories ON JobCategories.JobCategoryId=JobSubCategories.JobCategoryId
		LEFT JOIN JobTypes ON JobTypes.JobTypeId=Jobs.JobTypeId
		LEFT JOIN ExperienceLevels ON ExperienceLevels.ExperianceLevelId=Jobs.ExperienceLevelExperianceLevelId
		LEFT JOIN AspNetUsers ON AspNetUsers.Id=Jobs.ClientId
		LEFT JOIN WorkerTypes ON WorkerTypes.WorkerTypeId=Jobs.WorkerTypeId
		LEFT JOIN TimeUnits ON TimeUnits.TimeUnitId=Jobs.TimeUnitId
		LEFT JOIN Contracts ON Contracts.JobId=Jobs.JobId AND Contracts.WorkerId=@WorkerId AND (Contracts.ContractStatusId=1 OR Contracts.ContractStatusId=4)
		LEFT JOIN JobsBids ON JobsBids.JobId=Jobs.JobId AND JobsBids.WorkerId=@WorkerId AND JobsBids.IsHired='False' AND JobsBids.IsDenied='False'
	WHERE 
		(((@JobTitle IS NOT NULL AND Jobs.JobTitle LIKE '%'+@JobTitle+'%') OR @JobTitle IS NULL) AND
		(( @JobTypeId IS NOT NULL AND Jobs.JobTypeId=@JobTypeId) OR @JobTypeId IS NULL) AND
		((@JobSubCategoryIds IS NOT NULL AND Jobs.JobSubCategoryId IN (select splitdata from dbo.FunctionSplitString(@JobSubCategoryIds,','))) OR @JobSubCategoryIds IS NULL) AND
		((@ExperienceLevelRequiredId IS NOT NULL AND Jobs.ExperienceLevelExperianceLevelId = @ExperienceLevelRequiredId )OR @ExperienceLevelRequiredId IS NULL)) AND
		((@JobSubCategoryIds IS NULL AND @JobCategoryId IS NOT NULL AND Jobs.JobSubCategoryId IN (SELECT * FROM @JobSubCategories)) OR (@JobCategoryId IS NULL AND @JobSubCategoryIds IS NULL) OR (@JobCategoryId IS NOT NULL AND @JobSubCategoryIds IS NOT NULL))
END




GO

