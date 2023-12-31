USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[FindWorkersByFilter]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FindWorkersByFilter]
	@WorkerName nvarchar(max),
	@HourlyRate decimal=NULL,
	@Rating decimal=NULL,
	@TimeZone nvarchar(max)='',
	@CountryName nvarchar(max),
	@SkillIds nvarchar(max)
AS
BEGIN
	select Id,FirstName,LastName,ProfileTitle,Country1,ProfilePic,UserProfiles.UserHourlyRate,UserProfiles.UserRating
	from AspNetUsers 
	left join UserProfiles on UserProfiles.UserId=AspNetUsers.Id 
	join AspNetUserRoles on AspNetUserRoles.UserId=AspNetUsers.Id
	where 
	(UserName like '%'+@WorkerName+'%' or
	FirstName+' '+LastName like '%'+@WorkerName+'%') and
	UserHourlyRate >=@HourlyRate and
    (@TimeZone is not null and TimeZone=@TimeZone or @TimeZone is null) and
	(@CountryName is not null and Country1 in (select splitdata from dbo.FunctionSplitString(@CountryName,',')) or @CountryName is null)and
	UserRating>=@Rating and
	RoleId='3' and
	IsEmailVerified='true' and  
    (@SkillIds is Not null and(SELECT COUNT(*)  FROM dbo.FunctionSplitString(UserSkillIds,',') AS a
    INNER JOIN dbo.FunctionSplitString(@SkillIds,',') AS b
    ON a.splitdata = b.splitdata)>0 or @SkillIds is null)
END;
GO
