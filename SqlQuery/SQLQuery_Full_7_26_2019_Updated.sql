USE [master]
GO
/****** Object:  Database [DB_A31142_ems]    Script Date: 7/27/2019 12:59:41 PM ******/
CREATE DATABASE [DB_A31142_ems]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_A31142_ems_Data', FILENAME = N'H:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\DB_A31142_ems_DATA.mdf' , SIZE = 8192KB , MAXSIZE = 1024000KB , FILEGROWTH = 10%)
 LOG ON 
( NAME = N'DB_A31142_ems_Log', FILENAME = N'H:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\DB_A31142_ems_Log.LDF' , SIZE = 3072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DB_A31142_ems] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_A31142_ems].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_A31142_ems] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_A31142_ems] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_A31142_ems] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_A31142_ems] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_A31142_ems] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_A31142_ems] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_A31142_ems] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_A31142_ems] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_A31142_ems] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_A31142_ems] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_A31142_ems] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_A31142_ems] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_A31142_ems] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_A31142_ems] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_A31142_ems] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DB_A31142_ems] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_A31142_ems] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_A31142_ems] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_A31142_ems] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_A31142_ems] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_A31142_ems] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_A31142_ems] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_A31142_ems] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DB_A31142_ems] SET  MULTI_USER 
GO
ALTER DATABASE [DB_A31142_ems] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_A31142_ems] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_A31142_ems] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_A31142_ems] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB_A31142_ems] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DB_A31142_ems] SET QUERY_STORE = OFF
GO
USE [DB_A31142_ems]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [DB_A31142_ems]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/27/2019 12:59:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApprovalInfo]    Script Date: 7/27/2019 12:59:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApprovalInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[TravelID] [int] NOT NULL,
	[IsApproved] [bit] NOT NULL,
	[ApprovedBy] [nvarchar](max) NULL,
	[Comment] [nvarchar](max) NULL,
	[ApprovedDate] [datetime2](7) NOT NULL,
	[TotalExpenses] [float] NOT NULL,
 CONSTRAINT [PK_ApprovalInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 7/27/2019 12:59:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 7/27/2019 12:59:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 7/27/2019 12:59:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 7/27/2019 12:59:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 7/27/2019 12:59:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 7/27/2019 12:59:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[DisplayPicture] [nvarchar](max) NULL,
	[JobPost] [nvarchar](max) NULL,
	[TeamLeadId] [nvarchar](450) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 7/27/2019 12:59:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EntertainmentFB]    Script Date: 7/27/2019 12:59:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EntertainmentFB](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[Comment] [nvarchar](max) NULL,
	[Price] [float] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_EntertainmentFB] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MiscExpenses]    Script Date: 7/27/2019 12:59:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MiscExpenses](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[Comment] [nvarchar](max) NULL,
	[Price] [float] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_MiscExpenses] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MstExpenses]    Script Date: 7/27/2019 12:59:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MstExpenses](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[Comment] [nvarchar](max) NULL,
	[Order] [int] NOT NULL,
 CONSTRAINT [PK_MstExpenses] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TravelExpenses]    Script Date: 7/27/2019 12:59:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TravelExpenses](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[TravelID] [int] NOT NULL,
	[Details] [nvarchar](max) NULL,
	[Date] [datetime2](7) NOT NULL,
	[Expenses] [float] NOT NULL,
 CONSTRAINT [PK_TravelExpenses] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TravelInfo]    Script Date: 7/27/2019 12:59:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TravelInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[Destination] [nvarchar](max) NULL,
	[Purpose] [nvarchar](max) NULL,
	[Date] [datetime2](7) NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[StartTime] [datetime2](7) NOT NULL,
	[EndTime] [datetime2](7) NOT NULL,
	[IsApproved] [bit] NULL,
	[RecieptDoc] [nvarchar](max) NULL,
	[BankName] [nvarchar](max) NULL,
	[Currency] [nvarchar](max) NULL,
	[Department] [nvarchar](max) NULL,
	[EmployeeFName] [nvarchar](max) NOT NULL,
	[EmployeeLName] [nvarchar](max) NULL,
	[IBAN] [nvarchar](max) NULL,
	[TotalExpenses] [float] NOT NULL,
 CONSTRAINT [PK_TravelInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190724101516_UserAuthTable', N'2.2.6-servicing-10079')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190724101611_PrimaryTableCreation', N'2.2.6-servicing-10079')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190724104721_EntertainmentFBAdded', N'2.2.6-servicing-10079')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190724105337_EntertainmentFBAdded_Updated', N'2.2.6-servicing-10079')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190724125319_IsAPprovedAddedTravel', N'2.2.6-servicing-10079')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190725044449_ExpenseDetailInTravelTable', N'2.2.6-servicing-10079')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190725053412_TeamLeadAdded', N'2.2.6-servicing-10079')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190725060132_RelationShipAddedInDbContext', N'2.2.6-servicing-10079')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190725073001_EmployeeIdRemoved', N'2.2.6-servicing-10079')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190726130800_TotalExpensesAddedInTravelInfo', N'2.2.6-servicing-10079')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190727071226_RemovedEmployee', N'2.2.6-servicing-10079')
GO
SET IDENTITY_INSERT [dbo].[ApprovalInfo] ON 
GO
INSERT [dbo].[ApprovalInfo] ([ID], [CreatedBy], [CreatedDate], [ModifiedDate], [ModifiedBy], [TravelID], [IsApproved], [ApprovedBy], [Comment], [ApprovedDate], [TotalExpenses]) VALUES (1, N'nish', CAST(N'2019-07-26T14:04:40.5010722' AS DateTime2), CAST(N'2019-07-26T14:20:02.3443517' AS DateTime2), N'teamlead', 6, 1, N'teamlead', NULL, CAST(N'2019-07-26T14:20:02.2478239' AS DateTime2), 0)
GO
SET IDENTITY_INSERT [dbo].[ApprovalInfo] OFF
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'5ec7e799-3ff7-45cf-9902-c6cd59138444', N'Finance', N'FINANCE', N'4223638c-b92f-4a8e-8802-ebff5486f4d3')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'6442a8d6-af54-4782-8960-09f5c8f3c979', N'Employee', N'EMPLOYEE', N'6075f990-b1eb-4d77-80eb-bb32ea56cd9b')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'86bc7eb3-cb00-4127-b052-d3764a4eddb5', N'Admin', N'ADMIN', N'a49231ed-892f-4f9d-8920-e8bbb073a445')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'bc0d3705-21ed-4746-994e-1f083115d9f7', N'TeamLead', N'TEAMLEAD', N'98552412-60f8-43e4-9a17-a1cfdee7f084')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'255cdea4-efcd-4ee4-8f52-312b7e150a8d', N'6442a8d6-af54-4782-8960-09f5c8f3c979')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a08ffc82-4c9d-4d6e-9b6f-e4b01ed32d55', N'86bc7eb3-cb00-4127-b052-d3764a4eddb5')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd4eb594e-7284-4854-a3d3-6a63659a8653', N'86bc7eb3-cb00-4127-b052-d3764a4eddb5')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9f937e4f-24d6-4560-8a03-08014675c99a', N'bc0d3705-21ed-4746-994e-1f083115d9f7')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [DisplayPicture], [JobPost], [TeamLeadId]) VALUES (N'255cdea4-efcd-4ee4-8f52-312b7e150a8d', N'Employee', N'EMPLOYEE', N'pitambarzha+employee@gmail.com', N'PITAMBARZHA+EMPLOYEE@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEPA4c6QH1bRq9wxEz5QlHSPKacIjndzNP+b+EEObYRFDDfvE4gpP2D9CE0UU2GHyYQ==', N'2QWKOAXASJFEYTDWBJ6MGT6VO7Y446XL', N'a8a925ae-2676-47b1-9c12-37ef28b4c3b4', NULL, 0, 0, NULL, 1, 0, N'Employee', N'User', N'/DisplayPicture/DisplayPicture_Field_2019_10_25_01_10_49.jpg', NULL, N'9f937e4f-24d6-4560-8a03-08014675c99a')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [DisplayPicture], [JobPost], [TeamLeadId]) VALUES (N'9f937e4f-24d6-4560-8a03-08014675c99a', N'teamlead', N'TEAMLEAD', N'pitambarzha+abc@gmail.com', N'PITAMBARZHA+ABC@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEIncCJlXu8b8BWml0pBSrEE1p4zlGS/cRsT8MQ8L1EC0opFNYE6ukSshpE86jrKvIA==', N'O67SCH5G66PKME5VD3D4EYXO2TSUTLTX', N'38808260-18a2-4ba5-a480-4bbe80f134a7', NULL, 0, 0, NULL, 1, 0, N'TeamLead', N'User', N'/DisplayPicture/DisplayPicture_Field_2019_04_25_01_04_52.jfif', NULL, NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [DisplayPicture], [JobPost], [TeamLeadId]) VALUES (N'a08ffc82-4c9d-4d6e-9b6f-e4b01ed32d55', N'johndoe@email.com', N'JOHNDOE@EMAIL.COM', N'johndoe@email.com', N'JOHNDOE@EMAIL.COM', 0, N'AQAAAAEAACcQAAAAEECMLWzjBVDxJRVAbERCQ4C/bIEWZbbFRBqAJaKJORiYkaqTH1WSezdTKUqSHzqJmA==', N'VESVUU35HZPYLHMYMXAQTV2AJZI6YHC7', N'cc5cda20-ad1d-4b54-b3b5-17a69282f98a', NULL, 0, 0, NULL, 1, 0, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [DisplayPicture], [JobPost], [TeamLeadId]) VALUES (N'd4eb594e-7284-4854-a3d3-6a63659a8653', N'nish', N'NISH', N'pitambarzha@gmail.com', N'PITAMBARZHA@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEEmVZlaxTGUjcsfQJKrd2fYdBKh2oypFHS9JNdN8q7e5hcRgmmbvaAwSYg4QLzO+XA==', N'HVM6MGXTJ3RSND6RFFMD7J6TPNWQ2L6G', N'b8bb1276-bf17-418d-adee-1acbffce78c8', NULL, 0, 0, NULL, 1, 0, N'Pitambar', N'Jha', N'', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[MstExpenses] ON 
GO
INSERT [dbo].[MstExpenses] ([ID], [CreatedBy], [CreatedDate], [ModifiedDate], [ModifiedBy], [Comment], [Order]) VALUES (1, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, N'Kilometers Driven (private Vehicle)', 1)
GO
INSERT [dbo].[MstExpenses] ([ID], [CreatedBy], [CreatedDate], [ModifiedDate], [ModifiedBy], [Comment], [Order]) VALUES (2, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, N'Kilometer Expense: Rate 0.30', 2)
GO
INSERT [dbo].[MstExpenses] ([ID], [CreatedBy], [CreatedDate], [ModifiedDate], [ModifiedBy], [Comment], [Order]) VALUES (3, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, N'Taxis & Airport Shuttles', 3)
GO
INSERT [dbo].[MstExpenses] ([ID], [CreatedBy], [CreatedDate], [ModifiedDate], [ModifiedBy], [Comment], [Order]) VALUES (4, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, N'Car Rentals - (ONLY if not booked with EGENCIA)', 4)
GO
INSERT [dbo].[MstExpenses] ([ID], [CreatedBy], [CreatedDate], [ModifiedDate], [ModifiedBy], [Comment], [Order]) VALUES (5, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, N'Parking & Tolls', 5)
GO
INSERT [dbo].[MstExpenses] ([ID], [CreatedBy], [CreatedDate], [ModifiedDate], [ModifiedBy], [Comment], [Order]) VALUES (6, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, N'Lodging(room & tax only)', 6)
GO
INSERT [dbo].[MstExpenses] ([ID], [CreatedBy], [CreatedDate], [ModifiedDate], [ModifiedBy], [Comment], [Order]) VALUES (7, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, N'Tipx (Except Meal)', 7)
GO
INSERT [dbo].[MstExpenses] ([ID], [CreatedBy], [CreatedDate], [ModifiedDate], [ModifiedBy], [Comment], [Order]) VALUES (8, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, N'Telephone/Fax/Internet', 8)
GO
INSERT [dbo].[MstExpenses] ([ID], [CreatedBy], [CreatedDate], [ModifiedDate], [ModifiedBy], [Comment], [Order]) VALUES (9, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, N'Plane Ticket(ONLY if not booked with EGENCIA)', 9)
GO
INSERT [dbo].[MstExpenses] ([ID], [CreatedBy], [CreatedDate], [ModifiedDate], [ModifiedBy], [Comment], [Order]) VALUES (10, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, N'Train Ticket(ONLY if not booked with EGENCIA)', 10)
GO
INSERT [dbo].[MstExpenses] ([ID], [CreatedBy], [CreatedDate], [ModifiedDate], [ModifiedBy], [Comment], [Order]) VALUES (11, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, N'Misc. Expenses (please explain below)', 11)
GO
INSERT [dbo].[MstExpenses] ([ID], [CreatedBy], [CreatedDate], [ModifiedDate], [ModifiedBy], [Comment], [Order]) VALUES (12, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, N'Breakfast', 12)
GO
INSERT [dbo].[MstExpenses] ([ID], [CreatedBy], [CreatedDate], [ModifiedDate], [ModifiedBy], [Comment], [Order]) VALUES (13, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, N'Lunch', 13)
GO
INSERT [dbo].[MstExpenses] ([ID], [CreatedBy], [CreatedDate], [ModifiedDate], [ModifiedBy], [Comment], [Order]) VALUES (14, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, N'Dinner', 14)
GO
INSERT [dbo].[MstExpenses] ([ID], [CreatedBy], [CreatedDate], [ModifiedDate], [ModifiedBy], [Comment], [Order]) VALUES (15, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, N'Verpflegungspauschale', 15)
GO
INSERT [dbo].[MstExpenses] ([ID], [CreatedBy], [CreatedDate], [ModifiedDate], [ModifiedBy], [Comment], [Order]) VALUES (16, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, N'Entertainment F&B (please explain below)', 16)
GO
SET IDENTITY_INSERT [dbo].[MstExpenses] OFF
GO
SET IDENTITY_INSERT [dbo].[TravelExpenses] ON 
GO
INSERT [dbo].[TravelExpenses] ([ID], [CreatedBy], [CreatedDate], [ModifiedDate], [ModifiedBy], [TravelID], [Details], [Date], [Expenses]) VALUES (1, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 8, N'Tipx (Except Meal)', CAST(N'2019-07-23T00:00:00.0000000' AS DateTime2), 234)
GO
INSERT [dbo].[TravelExpenses] ([ID], [CreatedBy], [CreatedDate], [ModifiedDate], [ModifiedBy], [TravelID], [Details], [Date], [Expenses]) VALUES (2, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 8, N'Lodging(room & tax only)', CAST(N'2019-07-23T00:00:00.0000000' AS DateTime2), 234)
GO
INSERT [dbo].[TravelExpenses] ([ID], [CreatedBy], [CreatedDate], [ModifiedDate], [ModifiedBy], [TravelID], [Details], [Date], [Expenses]) VALUES (3, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 9, N'Car Rentals - (ONLY if not booked with EGENCIA)', CAST(N'2019-07-24T00:00:00.0000000' AS DateTime2), 12)
GO
INSERT [dbo].[TravelExpenses] ([ID], [CreatedBy], [CreatedDate], [ModifiedDate], [ModifiedBy], [TravelID], [Details], [Date], [Expenses]) VALUES (4, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 10, N'Lodging(room & tax only)', CAST(N'2019-07-31T00:00:00.0000000' AS DateTime2), 23)
GO
INSERT [dbo].[TravelExpenses] ([ID], [CreatedBy], [CreatedDate], [ModifiedDate], [ModifiedBy], [TravelID], [Details], [Date], [Expenses]) VALUES (5, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 10, N'Plane Ticket(ONLY if not booked with EGENCIA)', CAST(N'2019-07-31T00:00:00.0000000' AS DateTime2), 23)
GO
INSERT [dbo].[TravelExpenses] ([ID], [CreatedBy], [CreatedDate], [ModifiedDate], [ModifiedBy], [TravelID], [Details], [Date], [Expenses]) VALUES (6, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 10, N'Train Ticket(ONLY if not booked with EGENCIA)', CAST(N'2019-07-31T00:00:00.0000000' AS DateTime2), 23)
GO
SET IDENTITY_INSERT [dbo].[TravelExpenses] OFF
GO
SET IDENTITY_INSERT [dbo].[TravelInfo] ON 
GO
INSERT [dbo].[TravelInfo] ([ID], [CreatedBy], [CreatedDate], [ModifiedDate], [ModifiedBy], [Destination], [Purpose], [Date], [StartDate], [EndDate], [StartTime], [EndTime], [IsApproved], [RecieptDoc], [BankName], [Currency], [Department], [EmployeeFName], [EmployeeLName], [IBAN], [TotalExpenses]) VALUES (6, N'Employee', CAST(N'2019-07-25T13:17:12.0117654' AS DateTime2), NULL, NULL, N'Singapore', N'Official', CAST(N'2019-07-25T13:17:03.4922833' AS DateTime2), CAST(N'2020-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2020-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2019-07-25T00:12:00.0000000' AS DateTime2), CAST(N'2019-07-25T00:12:00.0000000' AS DateTime2), 1, N'/RecieptDoc/RecieptDoc_Field_2019_17_25_01_17_03.pdf', NULL, NULL, NULL, N'Employee', N'User', NULL, 0)
GO
INSERT [dbo].[TravelInfo] ([ID], [CreatedBy], [CreatedDate], [ModifiedDate], [ModifiedBy], [Destination], [Purpose], [Date], [StartDate], [EndDate], [StartTime], [EndTime], [IsApproved], [RecieptDoc], [BankName], [Currency], [Department], [EmployeeFName], [EmployeeLName], [IBAN], [TotalExpenses]) VALUES (7, N'teamlead', CAST(N'2019-07-26T11:50:56.1178741' AS DateTime2), NULL, NULL, N'Singapore', N'For official Purpose', CAST(N'2019-07-26T11:50:56.0731217' AS DateTime2), CAST(N'2020-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2121-02-12T00:00:00.0000000' AS DateTime2), CAST(N'2019-07-26T00:12:00.0000000' AS DateTime2), CAST(N'2019-07-26T00:12:00.0000000' AS DateTime2), NULL, N'/RecieptDoc/RecieptFile_Field_2019_50_26_11_50_56.png', NULL, NULL, NULL, N'TeamLead', N'User', NULL, 0)
GO
INSERT [dbo].[TravelInfo] ([ID], [CreatedBy], [CreatedDate], [ModifiedDate], [ModifiedBy], [Destination], [Purpose], [Date], [StartDate], [EndDate], [StartTime], [EndTime], [IsApproved], [RecieptDoc], [BankName], [Currency], [Department], [EmployeeFName], [EmployeeLName], [IBAN], [TotalExpenses]) VALUES (8, N'Employee', CAST(N'2019-07-26T14:58:19.8648188' AS DateTime2), NULL, NULL, N'Srilanka', N'Cricket', CAST(N'2019-07-26T14:57:41.4963389' AS DateTime2), CAST(N'2019-07-26T00:00:00.0000000' AS DateTime2), CAST(N'2019-07-31T00:00:00.0000000' AS DateTime2), CAST(N'2019-07-26T00:12:00.0000000' AS DateTime2), CAST(N'2019-07-26T00:12:00.0000000' AS DateTime2), NULL, N'', NULL, NULL, NULL, N'Employee', N'User', NULL, 0)
GO
INSERT [dbo].[TravelInfo] ([ID], [CreatedBy], [CreatedDate], [ModifiedDate], [ModifiedBy], [Destination], [Purpose], [Date], [StartDate], [EndDate], [StartTime], [EndTime], [IsApproved], [RecieptDoc], [BankName], [Currency], [Department], [EmployeeFName], [EmployeeLName], [IBAN], [TotalExpenses]) VALUES (9, N'Employee', CAST(N'2019-07-26T17:27:18.5384972' AS DateTime2), NULL, NULL, N'kuala lumpur', N'Promotion', CAST(N'2019-07-26T17:27:17.3354958' AS DateTime2), CAST(N'1212-12-12T00:00:00.0000000' AS DateTime2), CAST(N'1212-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2019-07-26T00:12:00.0000000' AS DateTime2), CAST(N'2019-07-26T00:12:00.0000000' AS DateTime2), NULL, N'/RecieptDoc/files_Field_2019_27_26_05_27_07.png', N'Twelve Assosciate Bank', N'$', N'Information Technology', N'Employee', N'User', N'121212121', 0)
GO
INSERT [dbo].[TravelInfo] ([ID], [CreatedBy], [CreatedDate], [ModifiedDate], [ModifiedBy], [Destination], [Purpose], [Date], [StartDate], [EndDate], [StartTime], [EndTime], [IsApproved], [RecieptDoc], [BankName], [Currency], [Department], [EmployeeFName], [EmployeeLName], [IBAN], [TotalExpenses]) VALUES (10, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2019-07-26T18:32:33.3276887' AS DateTime2), N'Employee', N'Turkemistan', N'Turki ', CAST(N'2019-07-26T18:32:33.3224357' AS DateTime2), CAST(N'2002-02-12T00:00:00.0000000' AS DateTime2), CAST(N'1212-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2019-07-26T00:12:00.0000000' AS DateTime2), CAST(N'2019-07-26T00:12:00.0000000' AS DateTime2), NULL, N'', N'dsf', N'dsfa', N'dsfs', N'Employee', N'User', N'dsfsd', 0)
GO
SET IDENTITY_INSERT [dbo].[TravelInfo] OFF
GO
/****** Object:  Index [IX_ApprovalInfo_TravelID]    Script Date: 7/27/2019 12:59:54 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_ApprovalInfo_TravelID] ON [dbo].[ApprovalInfo]
(
	[TravelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 7/27/2019 12:59:54 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 7/27/2019 12:59:54 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 7/27/2019 12:59:54 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 7/27/2019 12:59:54 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 7/27/2019 12:59:54 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 7/27/2019 12:59:54 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUsers_TeamLeadId]    Script Date: 7/27/2019 12:59:54 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUsers_TeamLeadId] ON [dbo].[AspNetUsers]
(
	[TeamLeadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 7/27/2019 12:59:54 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TravelExpenses_TravelID]    Script Date: 7/27/2019 12:59:54 PM ******/
CREATE NONCLUSTERED INDEX [IX_TravelExpenses_TravelID] ON [dbo].[TravelExpenses]
(
	[TravelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TravelInfo] ADD  DEFAULT (N'') FOR [EmployeeFName]
GO
ALTER TABLE [dbo].[TravelInfo] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [TotalExpenses]
GO
ALTER TABLE [dbo].[ApprovalInfo]  WITH CHECK ADD  CONSTRAINT [FK_ApprovalInfo_TravelInfo_TravelID] FOREIGN KEY([TravelID])
REFERENCES [dbo].[TravelInfo] ([ID])
GO
ALTER TABLE [dbo].[ApprovalInfo] CHECK CONSTRAINT [FK_ApprovalInfo_TravelInfo_TravelID]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_AspNetUsers_TeamLeadId] FOREIGN KEY([TeamLeadId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_AspNetUsers_TeamLeadId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[TravelExpenses]  WITH CHECK ADD  CONSTRAINT [FK_TravelExpenses_TravelInfo_TravelID] FOREIGN KEY([TravelID])
REFERENCES [dbo].[TravelInfo] ([ID])
GO
ALTER TABLE [dbo].[TravelExpenses] CHECK CONSTRAINT [FK_TravelExpenses_TravelInfo_TravelID]
GO
USE [master]
GO
ALTER DATABASE [DB_A31142_ems] SET  READ_WRITE 
GO
