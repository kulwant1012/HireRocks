USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[GetAllWorkerTypes]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllWorkerTypes]	
AS
BEGIN
	select * from WorkerTypes where IsActive='true'
END
GO
