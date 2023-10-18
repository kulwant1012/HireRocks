USE [HireRocks_Dev]
GO

/****** Object:  StoredProcedure [dbo].[DeleteCapture]    Script Date: 02/11/2016 17:48:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DeleteCapture]
@CaptureIdsToDelete NVARCHAR(MAX)
AS 
BEGIN
UPDATE Capture SET IsDeleted = 'TRUE' WHERE CaptureId IN (SELECT * FROM FunctionSplitString(@CaptureIdsToDelete,','))
END

GO

