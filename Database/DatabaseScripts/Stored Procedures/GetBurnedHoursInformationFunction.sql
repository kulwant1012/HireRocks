USE [HireRocks_Dev]
GO

/****** Object:  UserDefinedFunction [dbo].[GetBurnedHoursInformationFunction]    Script Date: 04/18/2016 14:57:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Avtar>
-- Create date: <12 FEB,2016>
-- Description:	<Get hours burned by contractId>
-- =============================================
CREATE FUNCTION  [dbo].[GetBurnedHoursInformationFunction](@ContractId BIGINT) 

RETURNS @HoursInformationTable TABLE(TotalBurnedHours DECIMAL(18,2),WeeklyBurnedHours DECIMAL(18,2),TodayBurnedHours DECIMAL(18,2))	
AS
BEGIN
	DECLARE @TotalBurnedHours AS DECIMAL(18,2)
	DECLARE @WeeklyBurnedHours AS DECIMAL(18,2)
	DECLARE @TodayBurnedHours AS DECIMAL(18,2)
	DECLARE @CaptureTableTemp AS TABLE(CaptureDate DATETIME,TimeBurned DECIMAL(18,2))
	
	DECLARE @TodayDate AS DATETIME = GETDATE()
	DECLARE @WeekStartDate AS DATE=CAST(DATEADD(day, DATEDIFF(day, 0, @TodayDate) /7*7, 0) AS DATE)
	DECLARE @WeekEndDate AS DATE=CAST(DATEADD(day, DATEDIFF(day, 6, @TodayDate-1) /7*7 + 7, 6) AS DATE)

    INSERT INTO @CaptureTableTemp SELECT CaptureDate,TimeBurned FROM Capture WHERE ContractId=@ContractId	
	SELECT @TotalBurnedHours=SUM(TimeBurned) FROM @CaptureTableTemp 
	SELECT @WeeklyBurnedHours=SUM(TimeBurned) FROM @CaptureTableTemp WHERE CAST(CaptureDate AS DATE)>=@WeekStartDate AND CAST(CaptureDate AS DATE)<=@WeekEndDate
	SELECT @TodayBurnedHours=SUM(TimeBurned) FROM @CaptureTableTemp WHERE CAST(CaptureDate AS DATE)=CAST(@TodayDate AS DATE)	
	INSERT INTO @HoursInformationTable SELECT @TotalBurnedHours[TotalBurnedHours],@WeeklyBurnedHours[WeeklyBurnedHours],@TodayBurnedHours[TodayBurnedHours]
	RETURN
END



GO

