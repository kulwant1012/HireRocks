USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[GetClientInfoByJobId]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetClientInfoByJobId]
@JobId bigint
AS
BEGIN
SELECT 
FirstName,
LastName,
UserName,
ProfilePic,
Email,
Id,
Country1,
UserRating,
count(ClientId) as TotalJobsPosted
FROM AspNetUsers join Jobs ON Jobs.ClientId=AspNetUsers.ID
join UserProfiles ON Jobs.ClientId=UserProfiles.UserId
WHERE JobId=@JobId or ClientId=(select ClientId from Jobs where JobId=@JobId)
group by FirstName,LastName,UserName,ProfilePic,Email,Id,Country1,UserRating
END
GO
