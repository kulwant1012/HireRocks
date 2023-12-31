USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[GetClientTeam]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetClientTeam]
	@ClientId nvarchar(128),
	@JobId bigint,
	@ShowActiveWorkers bit
AS
BEGIN
	SELECT 
		FirstName,
		LastName,
		Country1,
		ProfilePic,
		Email,
		Id,
		UserHourlyRate,
		UserRating	
	FROM AspNetUsers JOIN
		UserProfiles 
	ON 
		AspNetUsers.Id=UserProfiles.UserId 
	WHERE 
		Id IN 
		(
			SELECT WorkerId FROM Contracts 
			JOIN Jobs ON 
			Contracts.JobId=Jobs.JobId AND 
			Jobs.ClientId =@ClientId AND
			(Jobs.JobId=@JobId OR @JobId IS NULL) AND
			((Contracts.ContractStatusId = 1 AND @ShowActiveWorkers=0 OR @ShowActiveWorkers IS NULL) OR
			(Contracts.ContractStatusId = 2 AND @ShowActiveWorkers=1 OR @ShowActiveWorkers IS NULL)) AND
			Contracts.ContractStatusId != 3
		)
END
GO
