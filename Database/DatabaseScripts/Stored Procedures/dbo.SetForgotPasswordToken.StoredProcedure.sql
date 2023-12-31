USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[SetForgotPasswordToken]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SetForgotPasswordToken]
	@ForgotPasswordToken nvarchar(100),
	@EmailAddress nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	update AspNetUsers set forgotpasswordtoken=@ForgotPasswordToken
	output inserted.FirstName,inserted.LastName where Email=@EmailAddress  
END
GO
