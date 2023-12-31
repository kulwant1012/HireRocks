USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[GetContractByContractIdOrWorkerAndJobId]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetContractByContractIdOrWorkerAndJobId]
	@ContractId bigint,
	@WorkerId nvarchar(max),
	@JobId bigint
AS
BEGIN
	if(@ContractId is not null)
	select top(1) * from Contracts where ContractId=@ContractId 
	else
	select * from Contracts where WorkerId=@WorkerId and JobId=@JobId
END
GO
