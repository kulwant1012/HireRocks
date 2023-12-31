USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[GetUnreadNotificationsCount]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUnreadNotificationsCount]	
@UserId nvarchar(MAX)
AS
BEGIN
Select COUNT(Notifications.NotificationId) as UnreadNotifications from Notifications 
where Notifications.UserId = @UserId
and Notifications.IsViewed = 'False'
END
GO
