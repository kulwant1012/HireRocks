USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[VerifyEmailAddress]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerifyEmailAddress]
	@VerificationCode nvarchar(50)
AS
BEGIN
	update AspNetUsers set IsEmailVerified='true' where EmailVerificationCode=@VerificationCode select @@ROWCOUNT
END
GO
