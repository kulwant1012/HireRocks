USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserById]
	@UserId nvarchar(MAX)
AS
BEGIN
	--select top(1) 
	--Email,
	--UserName,
	--FirstName,
	--LastName,
	--UserHourlyRate	
	--from AspNetUsers
	--join UserProfiles
	--on AspNetUsers.Id=UserProfiles.UserId
	--where AspNetUsers.Id=@UserId	
	select top(1)
	Email,
	UserName,
	FirstName,
	LastName,
	UserHourlyRate,
	UserRating,
	Count(case when Contracts.ContractStatusId='2' then  Contracts.ContractStatusId end ) as JobsCompleted,
	sum(Capture.TimeBurned) as TimeBurned,
	ProfilePic,
	Country1,
	ProfileTitle,
	IntroductionVideo
	from AspNetUsers
	join UserProfiles
	on AspNetUsers.Id=UserProfiles.UserId
    full join Contracts on  Contracts.WorkerId =UserProfiles.UserId 
	full join Capture on Capture.ContractId=Contracts.ContractId
	where AspNetUsers.Id=@UserId
	group by UserRating,Email,UserName,FirstName,LastName,UserHourlyRate,ProfilePic,Country1,ProfileTitle,IntroductionVideo
END
GO
