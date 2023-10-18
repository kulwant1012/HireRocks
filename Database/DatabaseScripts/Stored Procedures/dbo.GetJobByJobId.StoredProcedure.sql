USE [HireRocks_Dev]
GO

/****** Object:  StoredProcedure [dbo].[GetJobByJobId]    Script Date: 03-02-2016 11:53:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetJobByJobId]
	@JobId bigint
AS
BEGIN
	select 
	Jobs.JobId,
	jobs.JobTitle,
	Jobs.JobDescription,
	Jobs.JobStartDate, 
	Jobs.JobEndDate,
	JobCategories.CategoryName,
	JobSubCategories.SubCategoryName,
	JobTypes.JobTypeName,
	Jobs.EstimateDuration,
	Jobs.Locality_PRF,
	jobs.Min_PRF_Rate,
	jobs.Max_PRF_Rate,
	Jobs.FixedRate,
	ExperienceLevels.LevelName,
	AspNetUsers.FirstName,
	AspNetUsers.LastName,
	WorkerTypes.Name as WorkerType,
	Jobs.IsActive,
	TimeUnits.UnitName,
	Jobs.IsHiringClosed
	from Jobs join JobSubCategories on JobSubCategories.JobSubCategoryId= Jobs.JobSubCategoryId
	join JobCategories on JobCategories.JobCategoryId=JobSubCategories.JobCategoryId
	join JobTypes on JobTypes.JobTypeId=Jobs.JobTypeId
	join ExperienceLevels on ExperienceLevels.ExperianceLevelId=Jobs.ExperienceLevelExperianceLevelId
	join AspNetUsers on AspNetUsers.Id=Jobs.ClientId
	join WorkerTypes on WorkerTypes.WorkerTypeId=Jobs.WorkerTypeId
	join TimeUnits on TimeUnits.TimeUnitId=Jobs.TimeUnitId
	where Jobs.JobId=@JobId
	
END


GO

