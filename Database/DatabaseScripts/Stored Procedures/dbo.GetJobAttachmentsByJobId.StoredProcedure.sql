USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[GetJobAttachmentsByJobId]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetJobAttachmentsByJobId]	
@JobId bigint
AS
BEGIN
	select * from JobAttachments where JobId =@JobId
END
GO
