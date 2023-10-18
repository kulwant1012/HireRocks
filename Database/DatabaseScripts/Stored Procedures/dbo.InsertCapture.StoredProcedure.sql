USE [HireRocks_Dev]
GO

/****** Object:  StoredProcedure [dbo].[InsertCapture]    Script Date: 04/18/2016 14:58:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[InsertCapture]
	@ContractId BIGINT=NULL,
	@KeyCount INT=NULL,
	@MouseCount INT=NULL,
	@KeyboardCapture NVARCHAR(MAX)=NULL,
	@MouseCapture NVARCHAR(MAX)=NULL,
	@ScreenCaptureThumbnailImage NVARCHAR(50)=NULL,
	@ScreenCaptureFullImage NVARCHAR(50)=NULL,
	@CaptureDate DATETIME=NULL,
	@TimeBurned DECIMAL(18,2)=NULL
AS
BEGIN
	SET NOCOUNT ON	
	
	DECLARE @IsContractOpen AS BIT	
	SELECT @IsContractOpen=CASE WHEN ContractStatusId=1 THEN 'TRUE' ELSE 'FALSE' END FROM Contracts WHERE ContractId=@ContractId
	
	IF(@IsContractOpen='TRUE')
	BEGIN
		INSERT INTO Capture
		(
			KeyCount,
			MouseCount,
			KeyboardCapture,
			MouseCapture,
			ScreenCaptureThumbnailImage,
			ScreenCaptureFullImage,
			CaptureDate,
			TimeBurned,
			ContractId,
			IsDeleted
		)
		VALUES(
			@KeyCount ,
			@MouseCount ,
			@KeyboardCapture,
			@MouseCapture,
			@ScreenCaptureThumbnailImage,
			@ScreenCaptureFullImage,
			@CaptureDate,
			@TimeBurned,
			@ContractId,
			'FALSE')
	END
		
	SELECT *,@IsContractOpen[IsContractOpen] FROM GetBurnedHoursInformationFunction(@ContractId)
END
GO

