USE [master]
GO
/****** Object:  Database [Library]    Script Date: 2017/11/12 16:08:16 ******/
CREATE DATABASE [Library]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Library', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Library.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Library_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Library_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Library] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Library].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Library] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Library] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Library] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Library] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Library] SET ARITHABORT OFF 
GO
ALTER DATABASE [Library] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Library] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Library] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Library] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Library] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Library] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Library] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Library] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Library] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Library] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Library] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Library] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Library] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Library] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Library] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Library] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Library] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Library] SET RECOVERY FULL 
GO
ALTER DATABASE [Library] SET  MULTI_USER 
GO
ALTER DATABASE [Library] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Library] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Library] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Library] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Library] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Library', N'ON'
GO
ALTER DATABASE [Library] SET QUERY_STORE = OFF
GO
USE [Library]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
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
USE [Library]
GO
/****** Object:  Table [dbo].[AdminPass]    Script Date: 2017/11/12 16:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminPass](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[password] [nvarchar](max) NOT NULL,
	[remark] [nvarchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 2017/11/12 16:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[AdminID] [int] IDENTITY(1,1) NOT NULL,
	[AdminName] [nvarchar](50) NOT NULL,
	[AdminPassword] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Admins] PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 2017/11/12 16:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[bookID] [int] IDENTITY(1,1) NOT NULL,
	[bookName] [nvarchar](max) NOT NULL,
	[author] [nvarchar](max) NOT NULL,
	[category] [nvarchar](max) NOT NULL,
	[publisher] [nvarchar](max) NOT NULL,
	[publishDate] [nvarchar](max) NOT NULL,
	[stockNumber] [nvarchar](max) NOT NULL,
	[bookAdress] [nvarchar](50) NOT NULL,
	[numbers] [nvarchar](max) NOT NULL,
	[libraryNumbers] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[bookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoanInformation]    Script Date: 2017/11/12 16:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoanInformation](
	[loanID] [int] IDENTITY(1,1) NOT NULL,
	[ReaderID] [nvarchar](max) NULL,
	[ReaderName] [nvarchar](max) NULL,
	[bookID] [varchar](max) NULL,
	[bookName] [nvarchar](max) NULL,
	[loanDate] [nvarchar](max) NULL,
	[backDate] [nvarchar](max) NULL,
 CONSTRAINT [PK_LoanInformation] PRIMARY KEY CLUSTERED 
(
	[loanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Readers]    Script Date: 2017/11/12 16:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Readers](
	[readerID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[password] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Readers] PRIMARY KEY CLUSTERED 
(
	[readerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [Library] SET  READ_WRITE 
GO
