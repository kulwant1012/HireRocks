USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[GetAllContractStatus]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllContractStatus]
AS
BEGIN	
	SET NOCOUNT ON;
Select * from ContractStatus where IsActive='true'
END
GO
