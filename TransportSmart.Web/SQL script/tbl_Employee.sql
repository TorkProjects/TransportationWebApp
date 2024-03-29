/****** Object:  Table [dbo].[tbl_employee]    Script Date: 16-06-2019 20:53:47 ******/
DROP TABLE [dbo].[tbl_employee]
GO
/****** Object:  Table [dbo].[tbl_employee]    Script Date: 16-06-2019 20:53:47 ******/
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
SET IDENTITY_INSERT [dbo].[tbl_employee] ON 

GO
INSERT [dbo].[tbl_employee] ([EmployeeId], [Name], [Nationality], [PassportNumber], [Placeofissue], [DateofIssue], [ExpiryDate], [DOB], [CopyofPassport], [ResidenceNumber], [UnifiedNumber], [DateofResidence], [ExpirationofResidence], [ResidenceCopy], [LaborCardNumber], [LaborCardExpiryDate], [EmiratesIDNumber], [EmiratedExpiryDate], [FrontFaceforEmiratesID], [BackfaceForEmiratesID]) VALUES (1, N'sdfdsf', N'AZ', N'dsfsdfds', N'sdfsd', CAST(0x0000AA6700000000 AS DateTime), CAST(0x0000AA7700000000 AS DateTime), CAST(0x0000AA6100000000 AS DateTime), N'~/Upload/09d51720-bb79-4160-be31-b287a59e7aab.jpg', N'sdfsdf', N'sdfsd', CAST(0x0000AA6100000000 AS DateTime), CAST(0x0000AA6F00000000 AS DateTime), N'~/Upload/d4c8dd46-c6d2-4cef-8826-9f82f518c5eb.jpg', N'fdsfsdfsdf', CAST(0x0000AA6700000000 AS DateTime), N'sdfsdf', CAST(0x0000AA6800000000 AS DateTime), N'~/Upload/87bd0a6a-718c-4115-969b-f920ca606c68.jpg', N'~/Upload/47a333cd-ac90-4560-9939-a9d557466d98.png')
GO
INSERT [dbo].[tbl_employee] ([EmployeeId], [Name], [Nationality], [PassportNumber], [Placeofissue], [DateofIssue], [ExpiryDate], [DOB], [CopyofPassport], [ResidenceNumber], [UnifiedNumber], [DateofResidence], [ExpirationofResidence], [ResidenceCopy], [LaborCardNumber], [LaborCardExpiryDate], [EmiratesIDNumber], [EmiratedExpiryDate], [FrontFaceforEmiratesID], [BackfaceForEmiratesID]) VALUES (2, N'Name2', N'ID', N'dsfsdfds', N'Test', CAST(0x0000A9FA00000000 AS DateTime), CAST(0x0000AA6800000000 AS DateTime), CAST(0x0000AA6800000000 AS DateTime), N'~/Upload/48c953da-c8d0-4606-8759-7f836cf840ff.jpg', N'sdfds', N'sdfdsf', CAST(0x0000AA6800000000 AS DateTime), CAST(0x0000AA6E00000000 AS DateTime), N'~/Upload/7e3e4867-7adf-4261-a575-20ff9b7257a0.jpg', N'sdfsdf', CAST(0x0000AA6100000000 AS DateTime), N'sdfdsfsdfds', CAST(0x0000AA6F00000000 AS DateTime), N'~/Upload/5fe472ec-7e10-414a-894a-129a770a14f7.jpg', N'~/Upload/31ac074f-f7ac-40c8-9e9c-7c3fd9aa3c8a.png')
GO
SET IDENTITY_INSERT [dbo].[tbl_employee] OFF
GO
