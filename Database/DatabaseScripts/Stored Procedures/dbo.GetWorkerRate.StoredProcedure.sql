USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[GetWorkerRate]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetWorkerRate]
@WorkerId nvarchar(max)
AS
BEGIN
Select UserHourlyRate from UserProfiles where UserId=@WorkerId
END
GO
