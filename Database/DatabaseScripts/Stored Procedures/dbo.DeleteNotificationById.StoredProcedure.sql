USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[DeleteNotificationById]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteNotificationById]
	@NotificationId bigint
AS
BEGIN
	delete from Notifications where NotificationId=@NotificationId
END
GO
