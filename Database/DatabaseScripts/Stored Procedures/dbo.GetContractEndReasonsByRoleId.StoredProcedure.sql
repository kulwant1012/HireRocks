USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[GetContractEndReasonsByRoleId]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetContractEndReasonsByRoleId]
	@RoleId nvarchar(128)
AS
BEGIN
	select * from ContractEndReasons where (RoleId=@RoleId and IsActive = 'true') or RoleId is null
END
GO
