USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[GetNotificationsByUserId]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetNotificationsByUserId]
	@UserId nvarchar(max)
AS
BEGIN
	Select NotificationId,NotificationText,DateTime,IsViewed from Notifications where UserId=@UserId and IsDeleted='false'
END
GO
