USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[GetLicenseAgreementById]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetLicenseAgreementById]
	@LicenseAgreementId bigint
AS
BEGIN
	select * from LicenseAgreements where LicenseAgreementId=@LicenseAgreementId
END
GO
