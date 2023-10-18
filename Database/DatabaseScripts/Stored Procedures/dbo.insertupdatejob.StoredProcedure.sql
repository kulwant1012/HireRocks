USE [HireRocks_Dev]
GO

/****** Object:  StoredProcedure [dbo].[insertupdatejob]    Script Date: 02/04/2016 16:06:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[insertupdatejob] 
 @JobId bigint,
 @JobTitle nvarchar(Max),
 @JobDescription nvarchar(max),
 @IsActive bit,
 @IsHiringClosed bit,
 @WorkerTypeId bigint,
 @ExperienceLevelId bigint,
 @JobTypeId bigint,
 @JobSubCategoryId bigint,
 @SkillsRequiredForJob nvarchar(max),
 @JobStartDate datetime,
 @JobEndDate datetime,
 @EstimatedDuration decimal,
 @TimeUnitId bigint,
 @ClientId nvarchar(128),
 @JobAttachments xml,
 @Min_PRF_Rate decimal,
 @Max_PRF_Rate decimal,
 @FixedRate decimal,
 @Locality_PRF nvarchar(Max)
AS
BEGIN
 IF(@JobId IS NULL)
 BEGIN
	INSERT INTO Jobs(JobTitle,JobDescription,IsActive,IsHiringClosed,WorkerTypeId,ExperienceLevelExperianceLevelId,JobTypeId,JobSubCategoryId,SkillsRequiredForJobIds,JobStartDate,JobEndDate,EstimateDuration,TimeUnitId,ClientId,Min_PRF_Rate,Max_PRF_Rate,FixedRate,Locality_PRF) 
	VALUES(@JobTitle,@JobDescription,@IsActive,@IsHiringClosed,@WorkerTypeId,@ExperienceLevelId,@JobTypeId,@JobSubCategoryId,@SkillsRequiredForJob,@JobStartDate,@JobEndDate,@EstimatedDuration,@TimeUnitId,@ClientId,@Min_PRF_Rate,@Max_PRF_Rate,@FixedRate,@Locality_PRF)
	SET @JobId=@@IDENTITY
 END 
 
 ELSE
 BEGIN
	 UPDATE Jobs SET JobTitle=@JobTitle, JobDescription=@JobDescription,IsActive=@IsActive,IsHiringClosed=@IsHiringClosed,WorkerTypeId=@WorkerTypeId,
	 ExperienceLevelExperianceLevelId=@ExperienceLevelId,JobTypeId=@JobTypeId,JobSubCategoryId=@JobSubCategoryId,SkillsRequiredForJobIds=@SkillsRequiredForJob,JobStartDate=@JobStartDate,JobEndDate=@JobEndDate,EstimateDuration=@EstimatedDuration,TimeUnitId=@TimeUnitId,ClientId=@ClientId,
	 Min_PRF_Rate=@Min_PRF_Rate,Max_PRF_Rate=@Max_PRF_Rate,FixedRate=@FixedRate,Locality_PRF=@Locality_PRF
	 WHERE JobId=@JobId 
 END 
 
 INSERT INTO JobAttachments
				SELECT [Table].[Column].value('AttachmentName[1]', 'Nvarchar(MAX)') AS 'AttachmentName',
					   @JobId,
					   [Table].[Column].value('AttachmentOriginalName[1]', 'Nvarchar(MAX)') AS 'AttachmentOriginalName'
				FROM @JobAttachments.nodes('/InsertUpdateAttachmentsViewModel/InsertAttachmentsList/JobAttachmentsViewModel') AS [Table]([Column]) 

 DELETE FROM JobAttachments WHERE JobAttachmentId IN (SELECT Attachments.AttachmentId.value('.','bigint')
													  FROM @JobAttachments.nodes('/InsertUpdateAttachmentsViewModel/DeleteAttachmentIdsList/long') AS Attachments(AttachmentId))

END

GO

