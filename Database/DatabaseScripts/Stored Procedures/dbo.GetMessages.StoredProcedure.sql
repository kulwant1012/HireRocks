USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[GetMessages]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMessages]
@JobId bigint,
@WorkerId nvarchar(max)
As 
Begin
Select * from Messages where JobId=@JobId and MessageToUserId=@WorkerId or MEssageFromUserId=@WorkerID
End
GO
