USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[GetWorkerJobListForMessageScreen]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetWorkerJobListForMessageScreen]
@WorkerId nvarchar(max)
AS
BEGIN
Select Jobs.JobId,Jobs.JobTitle from Jobs join Contracts on Jobs.JobId=Contracts.JobId where WorkerId=@WorkerId
union
Select Jobs.JobId,Jobs.JobTitle from Jobs join Messages on Jobs.JobId=Messages.JobId where Messages.MessageToUserId=@WorkerId
END
GO
