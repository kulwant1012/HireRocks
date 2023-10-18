USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[InsertMessage]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertMessage]
@JobId bigint,
@MessageText nvarchar(max),
@MessageFromUserId nvarchar(max),
@MessageToUserId nvarchar(max)

AS
BEGIN
insert into Messages(MessageText,MessageFromUserId,MessageToUserId,DateTime,JobId,IsViewed) Values 
(@MessageText,@MessageFromUserId,@MessageToUserId,getdate(),@JobId,'false')
End
GO
