USE [master]
GO
/****** Object:  Database [wordversions]    Script Date: 1/20/2021 4:39:05 PM ******/
CREATE DATABASE [wordversions]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'wordversions', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\wordversions.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'wordversions_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\wordversions_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [wordversions] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [wordversions].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [wordversions] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [wordversions] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [wordversions] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [wordversions] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [wordversions] SET ARITHABORT OFF 
GO
ALTER DATABASE [wordversions] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [wordversions] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [wordversions] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [wordversions] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [wordversions] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [wordversions] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [wordversions] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [wordversions] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [wordversions] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [wordversions] SET  DISABLE_BROKER 
GO
ALTER DATABASE [wordversions] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [wordversions] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [wordversions] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [wordversions] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [wordversions] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [wordversions] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [wordversions] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [wordversions] SET RECOVERY FULL 
GO
ALTER DATABASE [wordversions] SET  MULTI_USER 
GO
ALTER DATABASE [wordversions] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [wordversions] SET DB_CHAINING OFF 
GO
ALTER DATABASE [wordversions] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [wordversions] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [wordversions] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'wordversions', N'ON'
GO
ALTER DATABASE [wordversions] SET QUERY_STORE = OFF
GO
USE [wordversions]
GO
/****** Object:  Table [dbo].[tableofcontent]    Script Date: 1/20/2021 4:39:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tableofcontent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Heading] [nvarchar](max) NULL,
	[templateid] [int] NOT NULL,
 CONSTRAINT [PK_TableofContent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TemplateVersion]    Script Date: 1/20/2021 4:39:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TemplateVersion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[function_name] [nvarchar](max) NULL,
	[function_example] [nvarchar](max) NULL,
	[alternate_example] [nvarchar](max) NULL,
	[image_path] [nvarchar](max) NULL,
	[function_description] [nvarchar](max) NULL,
	[example_exaplanation] [nvarchar](max) NULL,
	[alternate_examples_explanation] [nvarchar](max) NULL,
 CONSTRAINT [PK_TemplateVersion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[tableofcontent]  WITH CHECK ADD  CONSTRAINT [FK_TableofContent_TemplateVersion] FOREIGN KEY([templateid])
REFERENCES [dbo].[TemplateVersion] ([id])
GO
ALTER TABLE [dbo].[tableofcontent] CHECK CONSTRAINT [FK_TableofContent_TemplateVersion]
GO
USE [master]
GO
ALTER DATABASE [wordversions] SET  READ_WRITE 
GO
