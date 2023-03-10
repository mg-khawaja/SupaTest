USE [master]
GO
/****** Object:  Database [SupaDb]    Script Date: 2/28/2023 9:27:03 PM ******/
CREATE DATABASE [SupaDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SupaDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SupaDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SupaDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SupaDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SupaDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SupaDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SupaDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SupaDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SupaDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SupaDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SupaDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [SupaDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SupaDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SupaDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SupaDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SupaDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SupaDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SupaDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SupaDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SupaDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SupaDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SupaDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SupaDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SupaDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SupaDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SupaDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SupaDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SupaDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SupaDb] SET RECOVERY FULL 
GO
ALTER DATABASE [SupaDb] SET  MULTI_USER 
GO
ALTER DATABASE [SupaDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SupaDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SupaDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SupaDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SupaDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SupaDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SupaDb', N'ON'
GO
ALTER DATABASE [SupaDb] SET QUERY_STORE = OFF
GO
USE [SupaDb]
GO
/****** Object:  User [supaUser]    Script Date: 2/28/2023 9:27:03 PM ******/
CREATE USER [supaUser] FOR LOGIN [supaUser] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [supa]    Script Date: 2/28/2023 9:27:03 PM ******/
CREATE USER [supa] FOR LOGIN [supa] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [supaUser]
GO
ALTER ROLE [db_datareader] ADD MEMBER [supaUser]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [supaUser]
GO
/****** Object:  Table [dbo].[Code]    Script Date: 2/28/2023 9:27:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Code](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [nchar](50) NOT NULL,
	[network] [nchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2/28/2023 9:27:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nchar](50) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Code] ON 

INSERT [dbo].[Code] ([id], [code], [network]) VALUES (16, N'd3ed                                              ', N'118073536                                         ')
INSERT [dbo].[Code] ([id], [code], [network]) VALUES (17, N'75cd                                              ', N'268566538                                         ')
SET IDENTITY_INSERT [dbo].[Code] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id], [username]) VALUES (1, N'manzar')
INSERT [dbo].[User] ([id], [username]) VALUES (2, N'ali')
INSERT [dbo].[User] ([id], [username]) VALUES (3, N'usman')
INSERT [dbo].[User] ([id], [username]) VALUES (4, N'haider')
INSERT [dbo].[User] ([id], [username]) VALUES (5, N'abdullah')
INSERT [dbo].[User] ([id], [username]) VALUES (6, N'tariq')
INSERT [dbo].[User] ([id], [username]) VALUES (7, N'junaid')
INSERT [dbo].[User] ([id], [username]) VALUES (8, N'wahab')
INSERT [dbo].[User] ([id], [username]) VALUES (9, N'babar')
INSERT [dbo].[User] ([id], [username]) VALUES (10, N'waqas')
INSERT [dbo].[User] ([id], [username]) VALUES (11, N'jahangir')
INSERT [dbo].[User] ([id], [username]) VALUES (12, N'gulzar')
INSERT [dbo].[User] ([id], [username]) VALUES (13, N'sajjad')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
USE [master]
GO
ALTER DATABASE [SupaDb] SET  READ_WRITE 
GO
