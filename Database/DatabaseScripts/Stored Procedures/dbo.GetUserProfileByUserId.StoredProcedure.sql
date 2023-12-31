USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[GetUserProfileByUserId]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserProfileByUserId]
@UserId nvarchar(max)
AS
BEGIN
	select 
	ProfileTitle,
	UserProfileId,
	UserSkillIds,
	UserLanguageIds,
	UserHourlyRate,
	EducationIds,
	UserSubCategoryIds,
	UserId,	
	Address1,
	Address2 ,
	City1,
	City2,
	Country1,
	Country2,	
	HomePhone,
	WorkPhone,
	CellPhone,
	ProfilePic,	
	TimeZone,
	Gender,
	DateOfBirth,
	Email,
	IntroductionVideo
	from UserProfiles
	join AspNetUsers on UserProfiles.UserId=AspNetUsers.Id
	where UserId=@UserId
END
GO
