USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[ResetPassword]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ResetPassword]
	@ForgotPasswordToken nvarchar(100),
	@NewPassword nvarchar(100)
AS
BEGIN
	SET NOCOUNT ON;
	update AspNetUsers set PasswordHash=@NewPassword,IsEmailVerified='true' where forgotpasswordtoken=@ForgotPasswordToken select @@ROWCOUNT as NumberOfRowsEffected
END
GO
