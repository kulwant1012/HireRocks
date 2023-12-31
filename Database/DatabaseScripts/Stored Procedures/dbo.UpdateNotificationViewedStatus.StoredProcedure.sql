USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[UpdateNotificationViewedStatus]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateNotificationViewedStatus]
	@UserId nvarchar(128)
AS
BEGIN
	UPDATE Notifications
	SET 
		IsViewed='True'
	WHERE
		Userid=@UserId AND
		IsViewed='False'
END
GO
