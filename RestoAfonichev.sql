USE [master]
GO
/****** Object:  Database [RestoDb_Afonichev]    Script Date: 04.05.2023 15:07:42 ******/
CREATE DATABASE [RestoDb_Afonichev]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RestoDb_Afonichev', FILENAME = N'D:\User\RestoDb_Afonichev.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RestoDb_Afonichev_log', FILENAME = N'D:\User\RestoDb_Afonichev_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [RestoDb_Afonichev] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RestoDb_Afonichev].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RestoDb_Afonichev] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RestoDb_Afonichev] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RestoDb_Afonichev] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RestoDb_Afonichev] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RestoDb_Afonichev] SET ARITHABORT OFF 
GO
ALTER DATABASE [RestoDb_Afonichev] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RestoDb_Afonichev] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RestoDb_Afonichev] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RestoDb_Afonichev] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RestoDb_Afonichev] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RestoDb_Afonichev] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RestoDb_Afonichev] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RestoDb_Afonichev] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RestoDb_Afonichev] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RestoDb_Afonichev] SET  ENABLE_BROKER 
GO
ALTER DATABASE [RestoDb_Afonichev] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RestoDb_Afonichev] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RestoDb_Afonichev] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RestoDb_Afonichev] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RestoDb_Afonichev] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RestoDb_Afonichev] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RestoDb_Afonichev] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RestoDb_Afonichev] SET RECOVERY FULL 
GO
ALTER DATABASE [RestoDb_Afonichev] SET  MULTI_USER 
GO
ALTER DATABASE [RestoDb_Afonichev] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RestoDb_Afonichev] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RestoDb_Afonichev] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RestoDb_Afonichev] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RestoDb_Afonichev] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'RestoDb_Afonichev', N'ON'
GO
ALTER DATABASE [RestoDb_Afonichev] SET QUERY_STORE = OFF
GO
USE [RestoDb_Afonichev]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 04.05.2023 15:07:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cheque]    Script Date: 04.05.2023 15:07:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cheque](
	[ChequeId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](30) NOT NULL,
	[TotalCost] [decimal](8, 2) NOT NULL,
	[IsClosed] [bit] NOT NULL,
	[OpeningDate] [datetime] NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[TableId] [int] NOT NULL,
 CONSTRAINT [PK_Cheque] PRIMARY KEY CLUSTERED 
(
	[ChequeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChequePosition]    Script Date: 04.05.2023 15:07:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChequePosition](
	[ChequePositionId] [int] IDENTITY(1,1) NOT NULL,
	[ChequeId] [int] NOT NULL,
	[PositionId] [int] NOT NULL,
 CONSTRAINT [PK_ChequePosition] PRIMARY KEY CLUSTERED 
(
	[ChequePositionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 04.05.2023 15:07:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Pincode] [varchar](4) NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_Waiter] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Position]    Script Date: 04.05.2023 15:07:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Position](
	[PositionId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](40) NOT NULL,
	[Cost] [decimal](7, 2) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Photo] [varbinary](max) NULL,
 CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED 
(
	[PositionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 04.05.2023 15:07:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Role_name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table]    Script Date: 04.05.2023 15:07:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table](
	[TableId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](20) NOT NULL,
	[NumberOfVisitors] [int] NOT NULL,
	[Description] [nvarchar](100) NULL,
	[IsFree] [bit] NOT NULL,
 CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED 
(
	[TableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cheque] ADD  CONSTRAINT [DF_Cheque_IsClosed]  DEFAULT ((0)) FOR [IsClosed]
GO
ALTER TABLE [dbo].[Table] ADD  CONSTRAINT [DF_Table_IsFree]  DEFAULT ((1)) FOR [IsFree]
GO
ALTER TABLE [dbo].[Cheque]  WITH CHECK ADD  CONSTRAINT [FK_Cheque_Table] FOREIGN KEY([TableId])
REFERENCES [dbo].[Table] ([TableId])
GO
ALTER TABLE [dbo].[Cheque] CHECK CONSTRAINT [FK_Cheque_Table]
GO
ALTER TABLE [dbo].[Cheque]  WITH CHECK ADD  CONSTRAINT [FK_Cheque_Waiter] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[Cheque] CHECK CONSTRAINT [FK_Cheque_Waiter]
GO
ALTER TABLE [dbo].[ChequePosition]  WITH CHECK ADD  CONSTRAINT [FK_ChequePosition_Cheque] FOREIGN KEY([ChequeId])
REFERENCES [dbo].[Cheque] ([ChequeId])
GO
ALTER TABLE [dbo].[ChequePosition] CHECK CONSTRAINT [FK_ChequePosition_Cheque]
GO
ALTER TABLE [dbo].[ChequePosition]  WITH CHECK ADD  CONSTRAINT [FK_ChequePosition_Position] FOREIGN KEY([PositionId])
REFERENCES [dbo].[Position] ([PositionId])
GO
ALTER TABLE [dbo].[ChequePosition] CHECK CONSTRAINT [FK_ChequePosition_Position]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Role]
GO
ALTER TABLE [dbo].[Position]  WITH CHECK ADD  CONSTRAINT [FK_Position_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[Position] CHECK CONSTRAINT [FK_Position_Category]
GO
USE [master]
GO
ALTER DATABASE [RestoDb_Afonichev] SET  READ_WRITE 
GO
