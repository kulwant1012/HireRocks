USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[GetWorkersForMessageScreen]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetWorkersForMessageScreen]
	@JobId bigint,
	@WorkerId nvarchar(max),
	@ClientId nvarchar(max)
AS
BEGIN
select distinct 
	(UserName),
	FirstName,
	LastName,
	ProfilePic,
	Email,
	Id,
	ContractId
	from(
	Select 
	UserName,
	FirstName,
	LastName,	
	ProfilePic,
	Email,
	Id,
	ContractId
	from 
	AspNetUsers join Contracts on Contracts.WorkerID=AspNetUsers.ID where Contracts.JobId=@JobId
	union
	Select 
	UserName,
	FirstName,
	LastName,
	ProfilePic,
	Email,
	Id,
	Null
	from 
	AspNetUsers where AspNetUsers.Id = @WorkerId
	Union
	Select 
	UserName,
	FirstName,
	LastName,	
	ProfilePic,
	Email,
	Id,
	Null
	from 
	AspNetUsers Join Messages on Messages.MessageToUserId = AspNetUsers.Id where Messages.JobId=@JobId and Messages.MessageToUserId!=@ClientId
) 
as Temp
END
GO
