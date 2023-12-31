USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateUserProfile]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertUpdateUserProfile]
	@UserProfileId bigint,
	@ProfileTitle nvarchar(max),
	@UserSkillIds nvarchar(max),
	@UserLanguageIds nvarchar(max),
	@UserHourlyRate decimal,
	@EducationXML xml,
	@UserSubCategoryIds nvarchar(max),
	@UserId nvarchar(max),	
	@Address1 nvarchar(max),
	@Address2 nvarchar(max),
	@City1 nvarchar(max),
	@City2 nvarchar(max),
	@Country1 nvarchar(max),
	@Country2 nvarchar(max),	
	@HomePhone nvarchar(max),
	@WorkPhone nvarchar(max),
	@CellPhone nvarchar(max),
	@ProfilePic nvarchar(max),
	@TimeZone nvarchar(max),
	@Gender nvarchar(max),
	@DateOfBirth datetime,
	@CertificationDetailXML xml,
	@IntroductionVideo nvarchar(max)
AS
BEGIN
--Insert/Update/Delete education
   DECLARE @EducationIdsTable TABLE (Id nvarchar(max))
   INSERT INTO Educations(DegreeName,DegreeStartDate,DegreeTypeId,Percentage,DegreeEndDate)
   OUTPUT inserted.EducationId INTO @EducationIdsTable
   SELECT     
      DegreeName = Education.value('DegreeName[1]','varchar(25)'),
      DegreeStartDate = Education.value('DegreeStartDate[1]','datetime'),
      DegreeTypeId = Education.value('DegreeTypeId[1]','bigint'),
      Percentage = Education.value('Percentage[1]','decimal'),
      DegreeEndDate = Education.value('DegreeEndDate[1]','datetime')
   FROM 
      @EducationXML.nodes('/ArrayOfEducationViewModel/EducationViewModel') AS EducationDetails(Education)
   WHERE 
	  Education.value('EducationId[1]','bigint') is null or Education.value('EducationId[1]','bigint')=0 
	  
	  
   UPDATE Educations set
	  DegreeName= Education.value('DegreeName[1]','varchar(25)'),
	  DegreeStartDate = Education.value('DegreeStartDate[1]','datetime'),
      DegreeTypeId = Education.value('DegreeTypeId[1]','bigint'),
      Percentage = Education.value('Percentage[1]','decimal'),
      DegreeEndDate = Education.value('DegreeEndDate[1]','datetime')
   OUTPUT inserted.EducationId INTO @EducationIdsTable
   FROM 
      @EducationXML.nodes('/ArrayOfEducationViewModel/EducationViewModel') AS EducationDetails(Education)   
   WHERE 
	  Education.value('EducationId[1]','bigint') is not null and 
	  Education.value('EducationId[1]','bigint')>0 and
	  Education.value('IsDeleted[1]','bit')='0'	and
	  Educations.EducationId = Education.value('EducationId[1]','bigint')

   DELETE FROM dbo.Educations
   WHERE
	  Educations.EducationId in (SELECT Education.value('EducationId[1]','bigint') FROM @EducationXML.nodes('/ArrayOfEducationViewModel/EducationViewModel') AS Educations(Education)
	  where Education.value('IsDeleted[1]','bit')='1')


  --Manage user certifications 
 
 DECLARE @CertificationIdsTable TABLE (Id nvarchar(max))
 INSERT INTO Certification(CertificationName,CertificationDate,CertificationNumber)
   OUTPUT inserted.CertificationId into @CertificationIdsTable
   SELECT     
      CertificationName = Certification.value('CertificationName[1]','varchar(100)'),
      CertificationDate = Certification.value('CertificationYear[1]','datetime'),
      CertificationNumber = Certification.value('CertificationNumber[1]','varchar(100)')
   FROM 
      @CertificationDetailXML.nodes('/ArrayOfCertificationViewModel/CertificationViewModel') AS Certifications(Certification)
   WHERE 
	  Certification.value('HasTempCertificationId[1]','bit')='1' 
	  
	  
   UPDATE Certification set
	  CertificationName = Certification.value('CertificationName[1]','varchar(100)'),
      CertificationDate = Certification.value('CertificationYear[1]','datetime'),
      CertificationNumber = Certification.value('CertificationNumber[1]','varchar(100)')
      OUTPUT inserted.CertificationId into @CertificationIdsTable
   FROM 
      @CertificationDetailXML.nodes('/ArrayOfCertificationViewModel/CertificationViewModel') AS Certifications(Certification) 
   WHERE 
	  Certification.value('CertificationId[1]','bigint') is not null and 
	  Certification.value('CertificationId[1]','bigint')>0 and
	  Certification.value('IsDeleted[1]','bit')='0'	and
	  Certification.value('CertificationId[1]','bigint')=Certification.CertificationId

   DELETE FROM Certification
   WHERE
	  Certification.CertificationId in (SELECT Certification.value('CertificationId[1]','bigint') FROM @CertificationDetailXML.nodes('/ArrayOfCertificationViewModel/CertificationViewModel') AS Certifications(Certification)
	  where Certification.value('IsDeleted[1]','bit')='1')

   UPDATE AspNetUsers set 
      Address1=@Address1,
      City1=@City1,
      Address2=@Address2,
      City2=@City2,
      Country1=@Country1,
      Country2=@Country2,
      HomePhone=@HomePhone,
      WorkPhone=@WorkPhone,
      CellPhone=@CellPhone,
      ProfilePic=@ProfilePic,
      IsProfileCompleted='true' 
      where id=@userid     
      
   DECLARE @educationIds nvarchar(max)
   DECLARE @certificationIds nvarchar(max)
   SET @educationIds = (SELECT  SUBSTRING((SELECT ',' + Id FROM @EducationIdsTable FOR XML PATH('')),2,200000))
   SET @certificationIds = (SELECT  SUBSTRING((SELECT ',' + Id FROM @CertificationIdsTable FOR XML PATH('')),2,200000))
   
   IF  @UserProfileId is NULL 
		begin
		insert into UserProfiles(
		ProfileTitle,
		UserSkillIds,
		UserLanguageIds,
		UserHourlyRate,
		EducationIds,
		UserSubCategoryIds,
		UserId,
		TimeZone,
		Gender,
		DateOfBirth,
		UserRating,
		IntroductionVideo,
		CertificationIds
		)
		values (
		@ProfileTitle,
		@UserSkillIds,
		@UserLanguageIds,
		@UserHourlyRate,
		@educationIds,
		@UserSubCategoryIds,
		@UserId,
		@TimeZone,
		@Gender,
		@DateOfBirth,
		0,
		@IntroductionVideo,
		@certificationIds
		);	
		end
	else
		begin
		update UserProfiles set 
		ProfileTitle=@ProfileTitle,
		UserSkillIds=@UserSkillIds,
		UserLanguageIds=@UserLanguageIds,
		UserHourlyRate=@UserHourlyRate,
		EducationIds=@EducationIds,
		UserSubCategoryIds=@UserSubCategoryIds,
		UserId=@UserId,
		TimeZone=@TimeZone,
		Gender=@Gender,
		DateOfBirth=@DateOfBirth,
		IntroductionVideo=@IntroductionVideo,
		CertificationIds=@certificationIds
		where UserProfileId=@UserProfileId
		end
END
GO
