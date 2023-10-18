USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[GetJobByJobIdAndClientId]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetJobByJobIdAndClientId]
 @JobId bigint,
 @ClientId nvarchar(max)
AS
BEGIN
 select * from Jobs where Jobs.JobId =@JobId and ClientId=@ClientId
END
GO
