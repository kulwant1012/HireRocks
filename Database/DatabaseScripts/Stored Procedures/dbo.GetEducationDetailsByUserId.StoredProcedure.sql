USE [HireRocks_Dev]
GO
/****** Object:  StoredProcedure [dbo].[GetEducationDetailsByUserId]    Script Date: 02/01/2016 15:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetEducationDetailsByUserId]
@UserId nvarchar(max)
AS
BEGIN
	select 
	DegreeTypes.DegreeTypeId,
	DegreeTypes.DegreeTypeName,
	Educations.DegreeName,
	Educations.DegreeStartDate,
	Educations.DegreeEndDate,
	Educations.EducationId,
	Educations.Percentage
	from DegreeTypes 
	left join Educations on Educations.DegreeTypeId=DegreeTypes.DegreeTypeId
	and Educations.EducationId is not null and Educations.EducationId in (select splitdata from dbo.FunctionSplitString((select EducationIds from UserProfiles where UserId=@UserId),','))
END
GO
