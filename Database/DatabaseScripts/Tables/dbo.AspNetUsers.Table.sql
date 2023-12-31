USE [HireRocks_Dev]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 02/01/2016 15:14:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Address1] [nvarchar](max) NULL,
	[Address2] [nvarchar](max) NULL,
	[City1] [nvarchar](max) NULL,
	[City2] [nvarchar](max) NULL,
	[State1] [nvarchar](max) NULL,
	[State2] [nvarchar](max) NULL,
	[Country1] [nvarchar](max) NULL,
	[Country2] [nvarchar](max) NULL,
	[HomePhone] [nvarchar](max) NULL,
	[WorkPhone] [nvarchar](max) NULL,
	[CellPhone] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[ProfilePic] [nvarchar](max) NULL,
	[IsEmailVerified] [bit] NULL,
	[IsPhoneVerified] [bit] NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
	[EmailVerificationCode] [nvarchar](max) NULL,
	[PhoneVerificationCode] [nvarchar](max) NULL,
	[ForgotPasswordToken] [nvarchar](100) NULL,
	[IsProfileCompleted] [bit] NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
