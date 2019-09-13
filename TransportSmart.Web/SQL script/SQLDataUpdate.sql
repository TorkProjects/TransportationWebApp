use master
go
create database [Transport]
go
USE [Transport]
GO
/****** Object:  Table [dbo].[tbl_users]    Script Date: 6/13/2019 5:12:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_users](
	[ID] [int] NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NULL,
	[Email] [varchar](200) NULL,
	[Password] [varchar](max) NULL,
	[Active] [bit] NULL,
	[ClientId] [smallint] NULL,
 CONSTRAINT [PK_tbl_users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tbl_employee]    Script Date: 15-06-2019 23:07:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tbl_employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NULL,
	[Nationality] [varchar](50) NULL,
	[PassportNumber] [varchar](200) NULL,
	[Placeofissue] [varchar](300) NULL,
	[DateofIssue] [datetime] NULL,
	[ExpiryDate] [datetime] NULL,
	[DOB] [datetime] NULL,
	[CopyofPassport] [varchar](500) NULL,
	[ResidenceNumber] [varchar](200) NULL,
	[UnifiedNumber] [varchar](200) NULL,
	[DateofResidence] [datetime] NULL,
	[ExpirationofResidence] [datetime] NULL,
	[ResidenceCopy] [varchar](500) NULL,
	[LaborCardNumber] [varchar](200) NULL,
	[LaborCardExpiryDate] [datetime] NULL,
	[EmiratesIDNumber] [varchar](200) NULL,
	[EmiratedExpiryDate] [datetime] NULL,
	[FrontFaceforEmiratesID] [varchar](500) NULL,
	[BackfaceForEmiratesID] [varchar](500) NULL,
 CONSTRAINT [PK_tbl_employee1] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO




