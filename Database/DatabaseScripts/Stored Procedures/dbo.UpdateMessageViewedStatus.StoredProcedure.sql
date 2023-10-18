USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[UpdateMessageViewedStatus]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateMessageViewedStatus]
	@UserId nvarchar(MAX),
	@JobId bigint
AS
BEGIN
	update Messages set IsViewed = 'true' where jobid=@jobid and MessageToUserId=@userid
END
GO
