
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/19/2015 14:33:21
-- Generated from EDMX file: E:\HireRocks\ActivityManagementSystem\PS.HireRocks.Data\Database\HireRocks_Dev.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [HireRocks_Dev3];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__UserRatin__Contr__589C25F3]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRatings] DROP CONSTRAINT [FK__UserRatin__Contr__589C25F3];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserRoles_AspNetRoles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserRoles_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_ContractAspNetUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contracts] DROP CONSTRAINT [FK_ContractAspNetUser];
GO
IF OBJECT_ID(N'[dbo].[FK_ContractContractStatus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contracts] DROP CONSTRAINT [FK_ContractContractStatus];
GO
IF OBJECT_ID(N'[dbo].[FK_ContractDenyReason_RoleId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContractDenyReasons] DROP CONSTRAINT [FK_ContractDenyReason_RoleId];
GO
IF OBJECT_ID(N'[dbo].[FK_ContractId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WorkerHourlyRate] DROP CONSTRAINT [FK_ContractId];
GO
IF OBJECT_ID(N'[dbo].[FK_ContractJob]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contracts] DROP CONSTRAINT [FK_ContractJob];
GO
IF OBJECT_ID(N'[dbo].[FK_ContractTimeUnits]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contracts] DROP CONSTRAINT [FK_ContractTimeUnits];
GO
IF OBJECT_ID(N'[dbo].[FK_CreatedByUserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contracts] DROP CONSTRAINT [FK_CreatedByUserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserClaims_dbo_AspNetUsers_User_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_User_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_EducationDegreeType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Educations] DROP CONSTRAINT [FK_EducationDegreeType];
GO
IF OBJECT_ID(N'[dbo].[FK_JobAspNetUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Jobs] DROP CONSTRAINT [FK_JobAspNetUser];
GO
IF OBJECT_ID(N'[dbo].[FK_JobAttachmentsJob]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[JobAttachments] DROP CONSTRAINT [FK_JobAttachmentsJob];
GO
IF OBJECT_ID(N'[dbo].[FK_JobExperienceLevel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Jobs] DROP CONSTRAINT [FK_JobExperienceLevel];
GO
IF OBJECT_ID(N'[dbo].[FK_JobFreelancersType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Jobs] DROP CONSTRAINT [FK_JobFreelancersType];
GO
IF OBJECT_ID(N'[dbo].[FK_JobJobSubCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Jobs] DROP CONSTRAINT [FK_JobJobSubCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_JobJobType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Jobs] DROP CONSTRAINT [FK_JobJobType];
GO
IF OBJECT_ID(N'[dbo].[FK_JobsBid_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[JobsBid] DROP CONSTRAINT [FK_JobsBid_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_JobsBid_Jobs]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[JobsBid] DROP CONSTRAINT [FK_JobsBid_Jobs];
GO
IF OBJECT_ID(N'[dbo].[FK_JobsBidAttachments_JobsBid]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[JobsBidAttachments] DROP CONSTRAINT [FK_JobsBidAttachments_JobsBid];
GO
IF OBJECT_ID(N'[dbo].[FK_JobSubCategoryJobCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[JobSubCategories] DROP CONSTRAINT [FK_JobSubCategoryJobCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_JobTimeUnits]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Jobs] DROP CONSTRAINT [FK_JobTimeUnits];
GO
IF OBJECT_ID(N'[dbo].[FK_MessageAspNetUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Messages] DROP CONSTRAINT [FK_MessageAspNetUser];
GO
IF OBJECT_ID(N'[dbo].[FK_MessageAspNetUser1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Messages] DROP CONSTRAINT [FK_MessageAspNetUser1];
GO
IF OBJECT_ID(N'[dbo].[FK_Messages_Jobs]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Messages] DROP CONSTRAINT [FK_Messages_Jobs];
GO
IF OBJECT_ID(N'[dbo].[FK_MessagesMessageLabels]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Messages] DROP CONSTRAINT [FK_MessagesMessageLabels];
GO
IF OBJECT_ID(N'[dbo].[FK_ModifiedByUserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contracts] DROP CONSTRAINT [FK_ModifiedByUserId];
GO
IF OBJECT_ID(N'[dbo].[FK_NotificationAspNetUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Notifications] DROP CONSTRAINT [FK_NotificationAspNetUser];
GO
IF OBJECT_ID(N'[dbo].[FK_ReadyMadeToolAspNetUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ReadyMadeTools] DROP CONSTRAINT [FK_ReadyMadeToolAspNetUser];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContractEndReasons] DROP CONSTRAINT [FK_RoleId];
GO
IF OBJECT_ID(N'[dbo].[FK_TeamAspNetUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Teams] DROP CONSTRAINT [FK_TeamAspNetUser];
GO
IF OBJECT_ID(N'[dbo].[FK_TeamAspNetUser1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Teams] DROP CONSTRAINT [FK_TeamAspNetUser1];
GO
IF OBJECT_ID(N'[dbo].[FK_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRatings] DROP CONSTRAINT [FK_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_UserPortfolioAspNetUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserPortfolios] DROP CONSTRAINT [FK_UserPortfolioAspNetUser];
GO
IF OBJECT_ID(N'[dbo].[FK_UserPortfolioContract]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserPortfolios] DROP CONSTRAINT [FK_UserPortfolioContract];
GO
IF OBJECT_ID(N'[dbo].[FK_UserProfileAspNetUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserProfiles] DROP CONSTRAINT [FK_UserProfileAspNetUser];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AspNetRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserClaims];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserLogins];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[C__MigrationHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[C__MigrationHistory];
GO
IF OBJECT_ID(N'[dbo].[Captures]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Captures];
GO
IF OBJECT_ID(N'[dbo].[Certification]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Certification];
GO
IF OBJECT_ID(N'[dbo].[Companies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Companies];
GO
IF OBJECT_ID(N'[dbo].[ContractDenyReasons]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContractDenyReasons];
GO
IF OBJECT_ID(N'[dbo].[ContractEndReasons]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContractEndReasons];
GO
IF OBJECT_ID(N'[dbo].[Contracts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contracts];
GO
IF OBJECT_ID(N'[dbo].[ContractStatus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContractStatus];
GO
IF OBJECT_ID(N'[dbo].[DegreeTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DegreeTypes];
GO
IF OBJECT_ID(N'[dbo].[Educations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Educations];
GO
IF OBJECT_ID(N'[dbo].[ExceptionLogs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExceptionLogs];
GO
IF OBJECT_ID(N'[dbo].[ExperienceLevels]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExperienceLevels];
GO
IF OBJECT_ID(N'[dbo].[JobAttachments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JobAttachments];
GO
IF OBJECT_ID(N'[dbo].[JobCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JobCategories];
GO
IF OBJECT_ID(N'[dbo].[Jobs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Jobs];
GO
IF OBJECT_ID(N'[dbo].[JobsBid]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JobsBid];
GO
IF OBJECT_ID(N'[dbo].[JobsBidAttachments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JobsBidAttachments];
GO
IF OBJECT_ID(N'[dbo].[JobSubCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JobSubCategories];
GO
IF OBJECT_ID(N'[dbo].[JobTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JobTypes];
GO
IF OBJECT_ID(N'[dbo].[Languages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Languages];
GO
IF OBJECT_ID(N'[dbo].[LicenseAgreements]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LicenseAgreements];
GO
IF OBJECT_ID(N'[dbo].[MessageLabels]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MessageLabels];
GO
IF OBJECT_ID(N'[dbo].[Messages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Messages];
GO
IF OBJECT_ID(N'[dbo].[Notifications]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Notifications];
GO
IF OBJECT_ID(N'[dbo].[PaymentMethods]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaymentMethods];
GO
IF OBJECT_ID(N'[dbo].[ReadyMadeTools]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ReadyMadeTools];
GO
IF OBJECT_ID(N'[dbo].[Skills]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Skills];
GO
IF OBJECT_ID(N'[dbo].[Teams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Teams];
GO
IF OBJECT_ID(N'[dbo].[TimeSheets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TimeSheets];
GO
IF OBJECT_ID(N'[dbo].[TimeUnits]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TimeUnits];
GO
IF OBJECT_ID(N'[dbo].[TransactionStatus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TransactionStatus];
GO
IF OBJECT_ID(N'[dbo].[UserPortfolios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserPortfolios];
GO
IF OBJECT_ID(N'[dbo].[UserProfiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserProfiles];
GO
IF OBJECT_ID(N'[dbo].[UserRatings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserRatings];
GO
IF OBJECT_ID(N'[dbo].[WorkerHourlyRate]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkerHourlyRate];
GO
IF OBJECT_ID(N'[dbo].[WorkerTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkerTypes];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AspNetRoles'
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AspNetUserClaims'
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL,
    [User_Id] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUserLogins'
CREATE TABLE [dbo].[AspNetUserLogins] (
    [UserId] nvarchar(128)  NOT NULL,
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [UserName] nvarchar(max)  NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [FirstName] nvarchar(max)  NULL,
    [LastName] nvarchar(max)  NULL,
    [Address1] nvarchar(max)  NULL,
    [Address2] nvarchar(max)  NULL,
    [City1] nvarchar(max)  NULL,
    [City2] nvarchar(max)  NULL,
    [State1] nvarchar(max)  NULL,
    [State2] nvarchar(max)  NULL,
    [Country1] nvarchar(max)  NULL,
    [Country2] nvarchar(max)  NULL,
    [HomePhone] nvarchar(max)  NULL,
    [WorkPhone] nvarchar(max)  NULL,
    [CellPhone] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NULL,
    [ProfilePic] nvarchar(max)  NULL,
    [IsEmailVerified] bit  NULL,
    [IsPhoneVerified] bit  NULL,
    [Discriminator] nvarchar(128)  NOT NULL,
    [EmailVerificationCode] nvarchar(max)  NULL,
    [PhoneVerificationCode] nvarchar(max)  NULL,
    [ForgotPasswordToken] nvarchar(100)  NULL,
    [IsProfileCompleted] bit  NULL
);
GO

-- Creating table 'C__MigrationHistory'
CREATE TABLE [dbo].[C__MigrationHistory] (
    [MigrationId] nvarchar(150)  NOT NULL,
    [ContextKey] nvarchar(300)  NOT NULL,
    [Model] varbinary(max)  NOT NULL,
    [ProductVersion] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'Companies'
CREATE TABLE [dbo].[Companies] (
    [CompanyId] bigint IDENTITY(1,1) NOT NULL,
    [CompanyName] nvarchar(max)  NOT NULL,
    [CompanyOwner] nvarchar(max)  NOT NULL,
    [CompanyAddress] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL,
    [CompanyLogo] nvarchar(max)  NULL
);
GO

-- Creating table 'Contracts'
CREATE TABLE [dbo].[Contracts] (
    [ContractId] bigint IDENTITY(1,1) NOT NULL,
    [JobId] bigint  NULL,
    [StartDate] datetime  NULL,
    [EndDate] datetime  NULL,
    [EstimateDuration] decimal(18,0)  NULL,
    [ActualDuration] decimal(18,0)  NULL,
    [TimeUnitId] bigint  NULL,
    [ContractStatusId] bigint  NULL,
    [HoursLimit] decimal(18,0)  NULL,
    [EndReason] nvarchar(max)  NULL,
    [JobRating] decimal(18,0)  NULL,
    [WorkerId] nvarchar(128)  NULL,
    [FixedRate] decimal(18,0)  NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [CreatedByUserId] nvarchar(128)  NULL,
    [ModifiedByUserId] nvarchar(128)  NULL,
    [HourlyRate] decimal(18,0)  NULL
);
GO

-- Creating table 'ContractStatus'
CREATE TABLE [dbo].[ContractStatus] (
    [ContractStatusId] bigint IDENTITY(1,1) NOT NULL,
    [ContractStatusName] nvarchar(max)  NOT NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'DegreeTypes'
CREATE TABLE [dbo].[DegreeTypes] (
    [DegreeTypeId] bigint IDENTITY(1,1) NOT NULL,
    [DegreeTypeName] nvarchar(max)  NOT NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'Educations'
CREATE TABLE [dbo].[Educations] (
    [EducationId] bigint IDENTITY(1,1) NOT NULL,
    [DegreeTypeId] bigint  NULL,
    [DegreeName] nvarchar(max)  NULL,
    [DegreeStartDate] datetime  NULL,
    [DegreeEndDate] datetime  NULL,
    [Percentage] decimal(18,0)  NULL
);
GO

-- Creating table 'ExperienceLevels'
CREATE TABLE [dbo].[ExperienceLevels] (
    [ExperianceLevelId] bigint IDENTITY(1,1) NOT NULL,
    [LevelName] nvarchar(max)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [ExperienceLowerRange] smallint  NOT NULL,
    [ExperienceHigherRange] smallint  NOT NULL
);
GO

-- Creating table 'JobAttachments'
CREATE TABLE [dbo].[JobAttachments] (
    [JobAttachmentId] bigint IDENTITY(1,1) NOT NULL,
    [AttachmentName] nvarchar(max)  NOT NULL,
    [JobId] bigint  NULL,
    [AttachmentOriginalName] nvarchar(max)  NULL
);
GO

-- Creating table 'JobCategories'
CREATE TABLE [dbo].[JobCategories] (
    [JobCategoryId] bigint IDENTITY(1,1) NOT NULL,
    [CategoryName] nvarchar(max)  NOT NULL,
    [CategoryDescription] nvarchar(max)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'JobSubCategories'
CREATE TABLE [dbo].[JobSubCategories] (
    [JobSubCategoryId] bigint IDENTITY(1,1) NOT NULL,
    [SubCategoryName] nvarchar(max)  NOT NULL,
    [SubCategoryDescription] nvarchar(max)  NULL,
    [IsActive] bit  NOT NULL,
    [JobCategoryId] bigint  NULL
);
GO

-- Creating table 'JobTypes'
CREATE TABLE [dbo].[JobTypes] (
    [JobTypeId] bigint IDENTITY(1,1) NOT NULL,
    [JobTypeName] nvarchar(max)  NOT NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'LicenseAgreements'
CREATE TABLE [dbo].[LicenseAgreements] (
    [LicenseAgreementId] bigint IDENTITY(1,1) NOT NULL,
    [Agreement] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MessageLabels'
CREATE TABLE [dbo].[MessageLabels] (
    [MessageLabelId] bigint IDENTITY(1,1) NOT NULL,
    [LabelName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Messages'
CREATE TABLE [dbo].[Messages] (
    [MessageId] bigint IDENTITY(1,1) NOT NULL,
    [MessageText] nvarchar(max)  NULL,
    [Subject] nvarchar(max)  NULL,
    [DateTime] datetime  NULL,
    [IsViewed] bit  NULL,
    [MessageLabelId] bigint  NULL,
    [MessageFromUserId] nvarchar(128)  NULL,
    [MessageToUserId] nvarchar(128)  NULL,
    [JobId] bigint  NULL
);
GO

-- Creating table 'Notifications'
CREATE TABLE [dbo].[Notifications] (
    [NotificationId] bigint IDENTITY(1,1) NOT NULL,
    [NotificationText] nvarchar(max)  NULL,
    [IsViewed] bit  NULL,
    [IsDeleted] bit  NULL,
    [DateTime] datetime  NOT NULL,
    [UserId] nvarchar(128)  NULL
);
GO

-- Creating table 'PaymentMethods'
CREATE TABLE [dbo].[PaymentMethods] (
    [PaymentMethodId] bigint IDENTITY(1,1) NOT NULL,
    [PaymentMethodName] nvarchar(max)  NOT NULL,
    [PaymentMethodDescription] nvarchar(max)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'ReadyMadeTools'
CREATE TABLE [dbo].[ReadyMadeTools] (
    [ToolId] bigint IDENTITY(1,1) NOT NULL,
    [ToolName] nvarchar(max)  NOT NULL,
    [ToolDescription] nvarchar(max)  NULL,
    [DownloadURL] nvarchar(max)  NULL,
    [ToolLogo] nvarchar(max)  NULL,
    [ToolVersion] nvarchar(max)  NULL,
    [ToolOwnerId] nvarchar(128)  NULL
);
GO

-- Creating table 'Skills'
CREATE TABLE [dbo].[Skills] (
    [SkillId] bigint IDENTITY(1,1) NOT NULL,
    [SkillName] nvarchar(max)  NOT NULL,
    [SkillDescription] nvarchar(max)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'Teams'
CREATE TABLE [dbo].[Teams] (
    [TeamId] bigint IDENTITY(1,1) NOT NULL,
    [IsActive] bit  NOT NULL,
    [TeamOwnerId] nvarchar(128)  NULL,
    [TeamMemberId] nvarchar(128)  NULL
);
GO

-- Creating table 'TimeSheets'
CREATE TABLE [dbo].[TimeSheets] (
    [Id] bigint IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'TimeUnits'
CREATE TABLE [dbo].[TimeUnits] (
    [TimeUnitId] bigint IDENTITY(1,1) NOT NULL,
    [UnitName] nvarchar(max)  NOT NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'TransactionStatus'
CREATE TABLE [dbo].[TransactionStatus] (
    [TransactionStatusId] bigint IDENTITY(1,1) NOT NULL,
    [StatusCode] nvarchar(max)  NOT NULL,
    [StatusName] nvarchar(max)  NOT NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'UserPortfolios'
CREATE TABLE [dbo].[UserPortfolios] (
    [UserPortfolioId] bigint IDENTITY(1,1) NOT NULL,
    [ProjectTitle] nvarchar(max)  NOT NULL,
    [ProjectDescription] nvarchar(max)  NULL,
    [ProjectStartDate] datetime  NULL,
    [ProjectEndDate] datetime  NULL,
    [ContractId] bigint  NULL,
    [WorkerId] nvarchar(128)  NULL
);
GO

-- Creating table 'UserProfiles'
CREATE TABLE [dbo].[UserProfiles] (
    [UserProfileId] bigint IDENTITY(1,1) NOT NULL,
    [ProfileTitle] nvarchar(max)  NULL,
    [UserSkillIds] nvarchar(max)  NULL,
    [UserLanguageIds] nvarchar(max)  NULL,
    [UserHourlyRate] decimal(18,0)  NULL,
    [EducationIds] nvarchar(max)  NULL,
    [UserSubCategoryIds] nvarchar(max)  NULL,
    [UserRating] decimal(18,0)  NULL,
    [UserId] nvarchar(128)  NULL,
    [TimeZone] nvarchar(max)  NULL,
    [Gender] nvarchar(50)  NULL,
    [DateOfBirth] datetime  NULL,
    [IntroductionVideo] nvarchar(max)  NULL,
    [CertificationIds] nvarchar(max)  NULL
);
GO

-- Creating table 'WorkerTypes'
CREATE TABLE [dbo].[WorkerTypes] (
    [WorkerTypeId] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'ExceptionLogs'
CREATE TABLE [dbo].[ExceptionLogs] (
    [ExceptionLogId] bigint IDENTITY(1,1) NOT NULL,
    [Exception] nvarchar(max)  NULL,
    [DateTime] datetime  NULL
);
GO

-- Creating table 'Languages'
CREATE TABLE [dbo].[Languages] (
    [LanguageId] bigint IDENTITY(1,1) NOT NULL,
    [LanguageName] nvarchar(max)  NOT NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'JobsBids'
CREATE TABLE [dbo].[JobsBids] (
    [JobBidId] bigint IDENTITY(1,1) NOT NULL,
    [JobId] bigint  NOT NULL,
    [Rate] decimal(18,0)  NULL,
    [WorkerId] nvarchar(128)  NOT NULL,
    [IsHired] bit  NULL,
    [IsDenied] bit  NULL,
    [CoverLetter] nvarchar(max)  NULL
);
GO

-- Creating table 'JobsBidAttachments'
CREATE TABLE [dbo].[JobsBidAttachments] (
    [JobBidAttachmentId] bigint IDENTITY(1,1) NOT NULL,
    [AttachmentName] nvarchar(max)  NOT NULL,
    [AttachmentOriginalName] nvarchar(max)  NULL,
    [JobBidId] bigint  NULL
);
GO

-- Creating table 'Jobs'
CREATE TABLE [dbo].[Jobs] (
    [JobId] bigint IDENTITY(1,1) NOT NULL,
    [JobTitle] nvarchar(max)  NOT NULL,
    [JobDescription] nvarchar(max)  NULL,
    [IsActive] bit  NOT NULL,
    [IsHiringClosed] bit  NOT NULL,
    [WorkerTypeId] bigint  NULL,
    [ExperienceLevelExperianceLevelId] bigint  NULL,
    [JobTypeId] bigint  NULL,
    [JobSubCategoryId] bigint  NULL,
    [SkillsRequiredForJobIds] nvarchar(max)  NOT NULL,
    [JobStartDate] datetime  NULL,
    [JobEndDate] datetime  NULL,
    [EstimateDuration] decimal(18,0)  NULL,
    [TimeUnitId] bigint  NULL,
    [ClientId] nvarchar(128)  NULL,
    [JobPostDate] datetime  NULL,
    [Min_PRF_Rate] decimal(18,0)  NULL,
    [Max_PRF_Rate] decimal(18,0)  NULL,
    [Locality_PRF] nvarchar(max)  NULL,
    [FixedRate] decimal(18,0)  NULL
);
GO

-- Creating table 'Certifications'
CREATE TABLE [dbo].[Certifications] (
    [CertificationId] bigint  NOT NULL,
    [CertificationName] nvarchar(100)  NULL,
    [CertificationDate] datetime  NULL,
    [CertificationNumber] nvarchar(100)  NULL
);
GO

-- Creating table 'Captures'
CREATE TABLE [dbo].[Captures] (
    [CaptureId] bigint IDENTITY(1,1) NOT NULL,
    [KeyCount] int  NULL,
    [MouseCount] int  NULL,
    [KeyboardCapture] nvarchar(max)  NULL,
    [MouseCapture] nvarchar(max)  NULL,
    [ScreenCaptureThumbnailImage] nvarchar(50)  NULL,
    [ScreenCaptureFullImage] nvarchar(50)  NULL,
    [CaptureDate] datetime  NULL,
    [TimeBurned] decimal(18,2)  NULL,
    [ContractId] bigint  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'ContractDenyReasons'
CREATE TABLE [dbo].[ContractDenyReasons] (
    [ContractDenyReasonId] bigint IDENTITY(1,1) NOT NULL,
    [DenyReason] nvarchar(max)  NULL,
    [IsActive] bit  NULL,
    [RoleId] nvarchar(128)  NULL
);
GO

-- Creating table 'ContractEndReasons'
CREATE TABLE [dbo].[ContractEndReasons] (
    [ContractEndReasonId] bigint IDENTITY(1,1) NOT NULL,
    [EndReason] nvarchar(max)  NULL,
    [IsActive] bit  NULL,
    [RoleId] nvarchar(128)  NULL
);
GO

-- Creating table 'UserRatings'
CREATE TABLE [dbo].[UserRatings] (
    [UserRatingId] bigint IDENTITY(1,1) NOT NULL,
    [Skill] decimal(18,0)  NULL,
    [Quality] decimal(18,0)  NULL,
    [Availability] decimal(18,0)  NULL,
    [Deadline] decimal(18,0)  NULL,
    [Communication] decimal(18,0)  NULL,
    [Cooperation] decimal(18,0)  NULL,
    [Comment] nvarchar(max)  NULL,
    [UserId] nvarchar(128)  NULL,
    [ContractId] bigint  NULL
);
GO

-- Creating table 'Capture1'
CREATE TABLE [dbo].[Capture1] (
    [CaptureId] bigint IDENTITY(1,1) NOT NULL,
    [KeyCount] int  NULL,
    [MouseCount] int  NULL,
    [KeyboardCapture] nvarchar(max)  NULL,
    [MouseCapture] nvarchar(max)  NULL,
    [ScreenCaptureThumbnailImage] nvarchar(50)  NULL,
    [ScreenCaptureFullImage] nvarchar(50)  NULL,
    [CaptureDate] datetime  NULL,
    [TimeBurned] decimal(18,2)  NULL,
    [ContractId] bigint  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'ContractDenyReason1'
CREATE TABLE [dbo].[ContractDenyReason1] (
    [ContractDenyReasonId] bigint IDENTITY(1,1) NOT NULL,
    [DenyReason] nvarchar(max)  NULL,
    [IsActive] bit  NULL,
    [RoleId] nvarchar(128)  NULL
);
GO

-- Creating table 'UserRating1'
CREATE TABLE [dbo].[UserRating1] (
    [UserRatingId] bigint IDENTITY(1,1) NOT NULL,
    [Skill] decimal(18,0)  NULL,
    [Quality] decimal(18,0)  NULL,
    [Availability] decimal(18,0)  NULL,
    [Deadline] decimal(18,0)  NULL,
    [Communication] decimal(18,0)  NULL,
    [Cooperation] decimal(18,0)  NULL,
    [Comment] nvarchar(max)  NULL,
    [UserId] nvarchar(128)  NULL,
    [ContractId] bigint  NULL
);
GO

-- Creating table 'WorkerHourlyRates'
CREATE TABLE [dbo].[WorkerHourlyRates] (
    [WorkerHourlyRateId] bigint IDENTITY(1,1) NOT NULL,
    [ContractId] bigint  NULL,
    [HourlyRate] decimal(18,0)  NULL,
    [FromDate] datetime  NULL,
    [ToDate] datetime  NULL
);
GO

-- Creating table 'AspNetUserRoles'
CREATE TABLE [dbo].[AspNetUserRoles] (
    [AspNetRoles_Id] nvarchar(128)  NOT NULL,
    [AspNetUsers_Id] nvarchar(128)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AspNetRoles'
ALTER TABLE [dbo].[AspNetRoles]
ADD CONSTRAINT [PK_AspNetRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [PK_AspNetUserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UserId], [LoginProvider], [ProviderKey] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [PK_AspNetUserLogins]
    PRIMARY KEY CLUSTERED ([UserId], [LoginProvider], [ProviderKey] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [MigrationId], [ContextKey] in table 'C__MigrationHistory'
ALTER TABLE [dbo].[C__MigrationHistory]
ADD CONSTRAINT [PK_C__MigrationHistory]
    PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey] ASC);
GO

-- Creating primary key on [CompanyId] in table 'Companies'
ALTER TABLE [dbo].[Companies]
ADD CONSTRAINT [PK_Companies]
    PRIMARY KEY CLUSTERED ([CompanyId] ASC);
GO

-- Creating primary key on [ContractId] in table 'Contracts'
ALTER TABLE [dbo].[Contracts]
ADD CONSTRAINT [PK_Contracts]
    PRIMARY KEY CLUSTERED ([ContractId] ASC);
GO

-- Creating primary key on [ContractStatusId] in table 'ContractStatus'
ALTER TABLE [dbo].[ContractStatus]
ADD CONSTRAINT [PK_ContractStatus]
    PRIMARY KEY CLUSTERED ([ContractStatusId] ASC);
GO

-- Creating primary key on [DegreeTypeId] in table 'DegreeTypes'
ALTER TABLE [dbo].[DegreeTypes]
ADD CONSTRAINT [PK_DegreeTypes]
    PRIMARY KEY CLUSTERED ([DegreeTypeId] ASC);
GO

-- Creating primary key on [EducationId] in table 'Educations'
ALTER TABLE [dbo].[Educations]
ADD CONSTRAINT [PK_Educations]
    PRIMARY KEY CLUSTERED ([EducationId] ASC);
GO

-- Creating primary key on [ExperianceLevelId] in table 'ExperienceLevels'
ALTER TABLE [dbo].[ExperienceLevels]
ADD CONSTRAINT [PK_ExperienceLevels]
    PRIMARY KEY CLUSTERED ([ExperianceLevelId] ASC);
GO

-- Creating primary key on [JobAttachmentId] in table 'JobAttachments'
ALTER TABLE [dbo].[JobAttachments]
ADD CONSTRAINT [PK_JobAttachments]
    PRIMARY KEY CLUSTERED ([JobAttachmentId] ASC);
GO

-- Creating primary key on [JobCategoryId] in table 'JobCategories'
ALTER TABLE [dbo].[JobCategories]
ADD CONSTRAINT [PK_JobCategories]
    PRIMARY KEY CLUSTERED ([JobCategoryId] ASC);
GO

-- Creating primary key on [JobSubCategoryId] in table 'JobSubCategories'
ALTER TABLE [dbo].[JobSubCategories]
ADD CONSTRAINT [PK_JobSubCategories]
    PRIMARY KEY CLUSTERED ([JobSubCategoryId] ASC);
GO

-- Creating primary key on [JobTypeId] in table 'JobTypes'
ALTER TABLE [dbo].[JobTypes]
ADD CONSTRAINT [PK_JobTypes]
    PRIMARY KEY CLUSTERED ([JobTypeId] ASC);
GO

-- Creating primary key on [LicenseAgreementId] in table 'LicenseAgreements'
ALTER TABLE [dbo].[LicenseAgreements]
ADD CONSTRAINT [PK_LicenseAgreements]
    PRIMARY KEY CLUSTERED ([LicenseAgreementId] ASC);
GO

-- Creating primary key on [MessageLabelId] in table 'MessageLabels'
ALTER TABLE [dbo].[MessageLabels]
ADD CONSTRAINT [PK_MessageLabels]
    PRIMARY KEY CLUSTERED ([MessageLabelId] ASC);
GO

-- Creating primary key on [MessageId] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [PK_Messages]
    PRIMARY KEY CLUSTERED ([MessageId] ASC);
GO

-- Creating primary key on [NotificationId] in table 'Notifications'
ALTER TABLE [dbo].[Notifications]
ADD CONSTRAINT [PK_Notifications]
    PRIMARY KEY CLUSTERED ([NotificationId] ASC);
GO

-- Creating primary key on [PaymentMethodId] in table 'PaymentMethods'
ALTER TABLE [dbo].[PaymentMethods]
ADD CONSTRAINT [PK_PaymentMethods]
    PRIMARY KEY CLUSTERED ([PaymentMethodId] ASC);
GO

-- Creating primary key on [ToolId] in table 'ReadyMadeTools'
ALTER TABLE [dbo].[ReadyMadeTools]
ADD CONSTRAINT [PK_ReadyMadeTools]
    PRIMARY KEY CLUSTERED ([ToolId] ASC);
GO

-- Creating primary key on [SkillId] in table 'Skills'
ALTER TABLE [dbo].[Skills]
ADD CONSTRAINT [PK_Skills]
    PRIMARY KEY CLUSTERED ([SkillId] ASC);
GO

-- Creating primary key on [TeamId] in table 'Teams'
ALTER TABLE [dbo].[Teams]
ADD CONSTRAINT [PK_Teams]
    PRIMARY KEY CLUSTERED ([TeamId] ASC);
GO

-- Creating primary key on [Id] in table 'TimeSheets'
ALTER TABLE [dbo].[TimeSheets]
ADD CONSTRAINT [PK_TimeSheets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [TimeUnitId] in table 'TimeUnits'
ALTER TABLE [dbo].[TimeUnits]
ADD CONSTRAINT [PK_TimeUnits]
    PRIMARY KEY CLUSTERED ([TimeUnitId] ASC);
GO

-- Creating primary key on [TransactionStatusId] in table 'TransactionStatus'
ALTER TABLE [dbo].[TransactionStatus]
ADD CONSTRAINT [PK_TransactionStatus]
    PRIMARY KEY CLUSTERED ([TransactionStatusId] ASC);
GO

-- Creating primary key on [UserPortfolioId] in table 'UserPortfolios'
ALTER TABLE [dbo].[UserPortfolios]
ADD CONSTRAINT [PK_UserPortfolios]
    PRIMARY KEY CLUSTERED ([UserPortfolioId] ASC);
GO

-- Creating primary key on [UserProfileId] in table 'UserProfiles'
ALTER TABLE [dbo].[UserProfiles]
ADD CONSTRAINT [PK_UserProfiles]
    PRIMARY KEY CLUSTERED ([UserProfileId] ASC);
GO

-- Creating primary key on [WorkerTypeId] in table 'WorkerTypes'
ALTER TABLE [dbo].[WorkerTypes]
ADD CONSTRAINT [PK_WorkerTypes]
    PRIMARY KEY CLUSTERED ([WorkerTypeId] ASC);
GO

-- Creating primary key on [ExceptionLogId] in table 'ExceptionLogs'
ALTER TABLE [dbo].[ExceptionLogs]
ADD CONSTRAINT [PK_ExceptionLogs]
    PRIMARY KEY CLUSTERED ([ExceptionLogId] ASC);
GO

-- Creating primary key on [LanguageId] in table 'Languages'
ALTER TABLE [dbo].[Languages]
ADD CONSTRAINT [PK_Languages]
    PRIMARY KEY CLUSTERED ([LanguageId] ASC);
GO

-- Creating primary key on [JobBidId] in table 'JobsBids'
ALTER TABLE [dbo].[JobsBids]
ADD CONSTRAINT [PK_JobsBids]
    PRIMARY KEY CLUSTERED ([JobBidId] ASC);
GO

-- Creating primary key on [JobBidAttachmentId] in table 'JobsBidAttachments'
ALTER TABLE [dbo].[JobsBidAttachments]
ADD CONSTRAINT [PK_JobsBidAttachments]
    PRIMARY KEY CLUSTERED ([JobBidAttachmentId] ASC);
GO

-- Creating primary key on [JobId] in table 'Jobs'
ALTER TABLE [dbo].[Jobs]
ADD CONSTRAINT [PK_Jobs]
    PRIMARY KEY CLUSTERED ([JobId] ASC);
GO

-- Creating primary key on [CertificationId] in table 'Certifications'
ALTER TABLE [dbo].[Certifications]
ADD CONSTRAINT [PK_Certifications]
    PRIMARY KEY CLUSTERED ([CertificationId] ASC);
GO

-- Creating primary key on [CaptureId] in table 'Captures'
ALTER TABLE [dbo].[Captures]
ADD CONSTRAINT [PK_Captures]
    PRIMARY KEY CLUSTERED ([CaptureId] ASC);
GO

-- Creating primary key on [ContractDenyReasonId] in table 'ContractDenyReasons'
ALTER TABLE [dbo].[ContractDenyReasons]
ADD CONSTRAINT [PK_ContractDenyReasons]
    PRIMARY KEY CLUSTERED ([ContractDenyReasonId] ASC);
GO

-- Creating primary key on [ContractEndReasonId] in table 'ContractEndReasons'
ALTER TABLE [dbo].[ContractEndReasons]
ADD CONSTRAINT [PK_ContractEndReasons]
    PRIMARY KEY CLUSTERED ([ContractEndReasonId] ASC);
GO

-- Creating primary key on [UserRatingId] in table 'UserRatings'
ALTER TABLE [dbo].[UserRatings]
ADD CONSTRAINT [PK_UserRatings]
    PRIMARY KEY CLUSTERED ([UserRatingId] ASC);
GO

-- Creating primary key on [CaptureId] in table 'Capture1'
ALTER TABLE [dbo].[Capture1]
ADD CONSTRAINT [PK_Capture1]
    PRIMARY KEY CLUSTERED ([CaptureId] ASC);
GO

-- Creating primary key on [ContractDenyReasonId] in table 'ContractDenyReason1'
ALTER TABLE [dbo].[ContractDenyReason1]
ADD CONSTRAINT [PK_ContractDenyReason1]
    PRIMARY KEY CLUSTERED ([ContractDenyReasonId] ASC);
GO

-- Creating primary key on [UserRatingId] in table 'UserRating1'
ALTER TABLE [dbo].[UserRating1]
ADD CONSTRAINT [PK_UserRating1]
    PRIMARY KEY CLUSTERED ([UserRatingId] ASC);
GO

-- Creating primary key on [WorkerHourlyRateId] in table 'WorkerHourlyRates'
ALTER TABLE [dbo].[WorkerHourlyRates]
ADD CONSTRAINT [PK_WorkerHourlyRates]
    PRIMARY KEY CLUSTERED ([WorkerHourlyRateId] ASC);
GO

-- Creating primary key on [AspNetRoles_Id], [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [PK_AspNetUserRoles]
    PRIMARY KEY CLUSTERED ([AspNetRoles_Id], [AspNetUsers_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [User_Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_User_Id]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserClaims_dbo_AspNetUsers_User_Id'
CREATE INDEX [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_User_Id]
ON [dbo].[AspNetUserClaims]
    ([User_Id]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [WorkerId] in table 'Contracts'
ALTER TABLE [dbo].[Contracts]
ADD CONSTRAINT [FK_ContractAspNetUser]
    FOREIGN KEY ([WorkerId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ContractAspNetUser'
CREATE INDEX [IX_FK_ContractAspNetUser]
ON [dbo].[Contracts]
    ([WorkerId]);
GO

-- Creating foreign key on [MessageFromUserId] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [FK_MessageAspNetUser]
    FOREIGN KEY ([MessageFromUserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MessageAspNetUser'
CREATE INDEX [IX_FK_MessageAspNetUser]
ON [dbo].[Messages]
    ([MessageFromUserId]);
GO

-- Creating foreign key on [MessageToUserId] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [FK_MessageAspNetUser1]
    FOREIGN KEY ([MessageToUserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MessageAspNetUser1'
CREATE INDEX [IX_FK_MessageAspNetUser1]
ON [dbo].[Messages]
    ([MessageToUserId]);
GO

-- Creating foreign key on [UserId] in table 'Notifications'
ALTER TABLE [dbo].[Notifications]
ADD CONSTRAINT [FK_NotificationAspNetUser]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_NotificationAspNetUser'
CREATE INDEX [IX_FK_NotificationAspNetUser]
ON [dbo].[Notifications]
    ([UserId]);
GO

-- Creating foreign key on [ToolOwnerId] in table 'ReadyMadeTools'
ALTER TABLE [dbo].[ReadyMadeTools]
ADD CONSTRAINT [FK_ReadyMadeToolAspNetUser]
    FOREIGN KEY ([ToolOwnerId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ReadyMadeToolAspNetUser'
CREATE INDEX [IX_FK_ReadyMadeToolAspNetUser]
ON [dbo].[ReadyMadeTools]
    ([ToolOwnerId]);
GO

-- Creating foreign key on [TeamOwnerId] in table 'Teams'
ALTER TABLE [dbo].[Teams]
ADD CONSTRAINT [FK_TeamAspNetUser]
    FOREIGN KEY ([TeamOwnerId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamAspNetUser'
CREATE INDEX [IX_FK_TeamAspNetUser]
ON [dbo].[Teams]
    ([TeamOwnerId]);
GO

-- Creating foreign key on [TeamMemberId] in table 'Teams'
ALTER TABLE [dbo].[Teams]
ADD CONSTRAINT [FK_TeamAspNetUser1]
    FOREIGN KEY ([TeamMemberId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamAspNetUser1'
CREATE INDEX [IX_FK_TeamAspNetUser1]
ON [dbo].[Teams]
    ([TeamMemberId]);
GO

-- Creating foreign key on [WorkerId] in table 'UserPortfolios'
ALTER TABLE [dbo].[UserPortfolios]
ADD CONSTRAINT [FK_UserPortfolioAspNetUser]
    FOREIGN KEY ([WorkerId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserPortfolioAspNetUser'
CREATE INDEX [IX_FK_UserPortfolioAspNetUser]
ON [dbo].[UserPortfolios]
    ([WorkerId]);
GO

-- Creating foreign key on [UserId] in table 'UserProfiles'
ALTER TABLE [dbo].[UserProfiles]
ADD CONSTRAINT [FK_UserProfileAspNetUser]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserProfileAspNetUser'
CREATE INDEX [IX_FK_UserProfileAspNetUser]
ON [dbo].[UserProfiles]
    ([UserId]);
GO

-- Creating foreign key on [ContractStatusId] in table 'Contracts'
ALTER TABLE [dbo].[Contracts]
ADD CONSTRAINT [FK_ContractContractStatus]
    FOREIGN KEY ([ContractStatusId])
    REFERENCES [dbo].[ContractStatus]
        ([ContractStatusId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ContractContractStatus'
CREATE INDEX [IX_FK_ContractContractStatus]
ON [dbo].[Contracts]
    ([ContractStatusId]);
GO

-- Creating foreign key on [TimeUnitId] in table 'Contracts'
ALTER TABLE [dbo].[Contracts]
ADD CONSTRAINT [FK_ContractTimeUnits]
    FOREIGN KEY ([TimeUnitId])
    REFERENCES [dbo].[TimeUnits]
        ([TimeUnitId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ContractTimeUnits'
CREATE INDEX [IX_FK_ContractTimeUnits]
ON [dbo].[Contracts]
    ([TimeUnitId]);
GO

-- Creating foreign key on [ContractId] in table 'UserPortfolios'
ALTER TABLE [dbo].[UserPortfolios]
ADD CONSTRAINT [FK_UserPortfolioContract]
    FOREIGN KEY ([ContractId])
    REFERENCES [dbo].[Contracts]
        ([ContractId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserPortfolioContract'
CREATE INDEX [IX_FK_UserPortfolioContract]
ON [dbo].[UserPortfolios]
    ([ContractId]);
GO

-- Creating foreign key on [DegreeTypeId] in table 'Educations'
ALTER TABLE [dbo].[Educations]
ADD CONSTRAINT [FK_EducationDegreeType]
    FOREIGN KEY ([DegreeTypeId])
    REFERENCES [dbo].[DegreeTypes]
        ([DegreeTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EducationDegreeType'
CREATE INDEX [IX_FK_EducationDegreeType]
ON [dbo].[Educations]
    ([DegreeTypeId]);
GO

-- Creating foreign key on [JobCategoryId] in table 'JobSubCategories'
ALTER TABLE [dbo].[JobSubCategories]
ADD CONSTRAINT [FK_JobSubCategoryJobCategory]
    FOREIGN KEY ([JobCategoryId])
    REFERENCES [dbo].[JobCategories]
        ([JobCategoryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_JobSubCategoryJobCategory'
CREATE INDEX [IX_FK_JobSubCategoryJobCategory]
ON [dbo].[JobSubCategories]
    ([JobCategoryId]);
GO

-- Creating foreign key on [MessageLabelId] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [FK_MessagesMessageLabels]
    FOREIGN KEY ([MessageLabelId])
    REFERENCES [dbo].[MessageLabels]
        ([MessageLabelId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MessagesMessageLabels'
CREATE INDEX [IX_FK_MessagesMessageLabels]
ON [dbo].[Messages]
    ([MessageLabelId]);
GO

-- Creating foreign key on [AspNetRoles_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRoles]
    FOREIGN KEY ([AspNetRoles_Id])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers]
    FOREIGN KEY ([AspNetUsers_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles_AspNetUsers'
CREATE INDEX [IX_FK_AspNetUserRoles_AspNetUsers]
ON [dbo].[AspNetUserRoles]
    ([AspNetUsers_Id]);
GO

-- Creating foreign key on [WorkerId] in table 'JobsBids'
ALTER TABLE [dbo].[JobsBids]
ADD CONSTRAINT [FK_JobsBid_AspNetUsers]
    FOREIGN KEY ([WorkerId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_JobsBid_AspNetUsers'
CREATE INDEX [IX_FK_JobsBid_AspNetUsers]
ON [dbo].[JobsBids]
    ([WorkerId]);
GO

-- Creating foreign key on [JobBidId] in table 'JobsBidAttachments'
ALTER TABLE [dbo].[JobsBidAttachments]
ADD CONSTRAINT [FK_JobsBidAttachments_JobsBid]
    FOREIGN KEY ([JobBidId])
    REFERENCES [dbo].[JobsBids]
        ([JobBidId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_JobsBidAttachments_JobsBid'
CREATE INDEX [IX_FK_JobsBidAttachments_JobsBid]
ON [dbo].[JobsBidAttachments]
    ([JobBidId]);
GO

-- Creating foreign key on [ClientId] in table 'Jobs'
ALTER TABLE [dbo].[Jobs]
ADD CONSTRAINT [FK_JobAspNetUser]
    FOREIGN KEY ([ClientId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_JobAspNetUser'
CREATE INDEX [IX_FK_JobAspNetUser]
ON [dbo].[Jobs]
    ([ClientId]);
GO

-- Creating foreign key on [JobId] in table 'Contracts'
ALTER TABLE [dbo].[Contracts]
ADD CONSTRAINT [FK_ContractJob]
    FOREIGN KEY ([JobId])
    REFERENCES [dbo].[Jobs]
        ([JobId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ContractJob'
CREATE INDEX [IX_FK_ContractJob]
ON [dbo].[Contracts]
    ([JobId]);
GO

-- Creating foreign key on [ExperienceLevelExperianceLevelId] in table 'Jobs'
ALTER TABLE [dbo].[Jobs]
ADD CONSTRAINT [FK_JobExperienceLevel]
    FOREIGN KEY ([ExperienceLevelExperianceLevelId])
    REFERENCES [dbo].[ExperienceLevels]
        ([ExperianceLevelId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_JobExperienceLevel'
CREATE INDEX [IX_FK_JobExperienceLevel]
ON [dbo].[Jobs]
    ([ExperienceLevelExperianceLevelId]);
GO

-- Creating foreign key on [JobId] in table 'JobAttachments'
ALTER TABLE [dbo].[JobAttachments]
ADD CONSTRAINT [FK_JobAttachmentsJob]
    FOREIGN KEY ([JobId])
    REFERENCES [dbo].[Jobs]
        ([JobId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_JobAttachmentsJob'
CREATE INDEX [IX_FK_JobAttachmentsJob]
ON [dbo].[JobAttachments]
    ([JobId]);
GO

-- Creating foreign key on [WorkerTypeId] in table 'Jobs'
ALTER TABLE [dbo].[Jobs]
ADD CONSTRAINT [FK_JobFreelancersType]
    FOREIGN KEY ([WorkerTypeId])
    REFERENCES [dbo].[WorkerTypes]
        ([WorkerTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_JobFreelancersType'
CREATE INDEX [IX_FK_JobFreelancersType]
ON [dbo].[Jobs]
    ([WorkerTypeId]);
GO

-- Creating foreign key on [JobSubCategoryId] in table 'Jobs'
ALTER TABLE [dbo].[Jobs]
ADD CONSTRAINT [FK_JobJobSubCategory]
    FOREIGN KEY ([JobSubCategoryId])
    REFERENCES [dbo].[JobSubCategories]
        ([JobSubCategoryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_JobJobSubCategory'
CREATE INDEX [IX_FK_JobJobSubCategory]
ON [dbo].[Jobs]
    ([JobSubCategoryId]);
GO

-- Creating foreign key on [JobTypeId] in table 'Jobs'
ALTER TABLE [dbo].[Jobs]
ADD CONSTRAINT [FK_JobJobType]
    FOREIGN KEY ([JobTypeId])
    REFERENCES [dbo].[JobTypes]
        ([JobTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_JobJobType'
CREATE INDEX [IX_FK_JobJobType]
ON [dbo].[Jobs]
    ([JobTypeId]);
GO

-- Creating foreign key on [JobId] in table 'JobsBids'
ALTER TABLE [dbo].[JobsBids]
ADD CONSTRAINT [FK_JobsBid_Jobs]
    FOREIGN KEY ([JobId])
    REFERENCES [dbo].[Jobs]
        ([JobId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_JobsBid_Jobs'
CREATE INDEX [IX_FK_JobsBid_Jobs]
ON [dbo].[JobsBids]
    ([JobId]);
GO

-- Creating foreign key on [TimeUnitId] in table 'Jobs'
ALTER TABLE [dbo].[Jobs]
ADD CONSTRAINT [FK_JobTimeUnits]
    FOREIGN KEY ([TimeUnitId])
    REFERENCES [dbo].[TimeUnits]
        ([TimeUnitId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_JobTimeUnits'
CREATE INDEX [IX_FK_JobTimeUnits]
ON [dbo].[Jobs]
    ([TimeUnitId]);
GO

-- Creating foreign key on [JobId] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [FK_Messages_Jobs]
    FOREIGN KEY ([JobId])
    REFERENCES [dbo].[Jobs]
        ([JobId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Messages_Jobs'
CREATE INDEX [IX_FK_Messages_Jobs]
ON [dbo].[Messages]
    ([JobId]);
GO

-- Creating foreign key on [CreatedByUserId] in table 'Contracts'
ALTER TABLE [dbo].[Contracts]
ADD CONSTRAINT [FK_CreatedByUserId]
    FOREIGN KEY ([CreatedByUserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CreatedByUserId'
CREATE INDEX [IX_FK_CreatedByUserId]
ON [dbo].[Contracts]
    ([CreatedByUserId]);
GO

-- Creating foreign key on [ModifiedByUserId] in table 'Contracts'
ALTER TABLE [dbo].[Contracts]
ADD CONSTRAINT [FK_ModifiedByUserId]
    FOREIGN KEY ([ModifiedByUserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ModifiedByUserId'
CREATE INDEX [IX_FK_ModifiedByUserId]
ON [dbo].[Contracts]
    ([ModifiedByUserId]);
GO

-- Creating foreign key on [RoleId] in table 'ContractDenyReasons'
ALTER TABLE [dbo].[ContractDenyReasons]
ADD CONSTRAINT [FK_ContractDenyReason_RoleId]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ContractDenyReason_RoleId'
CREATE INDEX [IX_FK_ContractDenyReason_RoleId]
ON [dbo].[ContractDenyReasons]
    ([RoleId]);
GO

-- Creating foreign key on [RoleId] in table 'ContractEndReasons'
ALTER TABLE [dbo].[ContractEndReasons]
ADD CONSTRAINT [FK_RoleId]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RoleId'
CREATE INDEX [IX_FK_RoleId]
ON [dbo].[ContractEndReasons]
    ([RoleId]);
GO

-- Creating foreign key on [UserId] in table 'UserRatings'
ALTER TABLE [dbo].[UserRatings]
ADD CONSTRAINT [FK_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserId'
CREATE INDEX [IX_FK_UserId]
ON [dbo].[UserRatings]
    ([UserId]);
GO

-- Creating foreign key on [ContractId] in table 'UserRatings'
ALTER TABLE [dbo].[UserRatings]
ADD CONSTRAINT [FK__UserRatin__Contr__589C25F3]
    FOREIGN KEY ([ContractId])
    REFERENCES [dbo].[Contracts]
        ([ContractId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK__UserRatin__Contr__589C25F3'
CREATE INDEX [IX_FK__UserRatin__Contr__589C25F3]
ON [dbo].[UserRatings]
    ([ContractId]);
GO

-- Creating foreign key on [RoleId] in table 'ContractDenyReason1'
ALTER TABLE [dbo].[ContractDenyReason1]
ADD CONSTRAINT [FK_ContractDenyReason_RoleId1]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ContractDenyReason_RoleId1'
CREATE INDEX [IX_FK_ContractDenyReason_RoleId1]
ON [dbo].[ContractDenyReason1]
    ([RoleId]);
GO

-- Creating foreign key on [UserId] in table 'UserRating1'
ALTER TABLE [dbo].[UserRating1]
ADD CONSTRAINT [FK_UserId1]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserId1'
CREATE INDEX [IX_FK_UserId1]
ON [dbo].[UserRating1]
    ([UserId]);
GO

-- Creating foreign key on [ContractId] in table 'UserRating1'
ALTER TABLE [dbo].[UserRating1]
ADD CONSTRAINT [FK__UserRatin__Contr__589C25F31]
    FOREIGN KEY ([ContractId])
    REFERENCES [dbo].[Contracts]
        ([ContractId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK__UserRatin__Contr__589C25F31'
CREATE INDEX [IX_FK__UserRatin__Contr__589C25F31]
ON [dbo].[UserRating1]
    ([ContractId]);
GO

-- Creating foreign key on [ContractId] in table 'WorkerHourlyRates'
ALTER TABLE [dbo].[WorkerHourlyRates]
ADD CONSTRAINT [FK_ContractId]
    FOREIGN KEY ([ContractId])
    REFERENCES [dbo].[Contracts]
        ([ContractId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ContractId'
CREATE INDEX [IX_FK_ContractId]
ON [dbo].[WorkerHourlyRates]
    ([ContractId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------