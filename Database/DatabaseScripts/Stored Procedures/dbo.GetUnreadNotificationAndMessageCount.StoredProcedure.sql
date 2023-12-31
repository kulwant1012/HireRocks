USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[GetUnreadNotificationAndMessageCount]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUnreadNotificationAndMessageCount]	
@UserId nvarchar(MAX)
AS
BEGIN
select (select count(Messages.MessageId) from Messages where Messages.MessageToUserId = @UserId and Messages.IsViewed = 'False') as UnreadMessages,
(select count(Notifications.NotificationId) from Notifications where Notifications.UserId = @UserId and Notifications.IsViewed = 'False') as UnreadNotifications
END
GO
