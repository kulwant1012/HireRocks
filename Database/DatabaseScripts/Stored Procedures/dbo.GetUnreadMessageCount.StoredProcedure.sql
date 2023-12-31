USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[GetUnreadMessageCount]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUnreadMessageCount]	
@UserId nvarchar(MAX)
AS
BEGIN
Select COUNT(Messages.MessageId) as UnreadMessages from Messages 
where Messages.MessageToUserId = @UserId
and Messages.IsViewed = 'False'
END
GO
