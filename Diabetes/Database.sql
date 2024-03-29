USE [master]
GO
/****** Object:  Database [BenhVien]    Script Date: 03/21/2013 18:12:19 ******/
CREATE DATABASE [BenhVien] ON  PRIMARY 
( NAME = N'BenhVien', FILENAME = N'c:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\BenhVien.mdf' , SIZE = 5376KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BenhVien_log', FILENAME = N'c:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\BenhVien_log.LDF' , SIZE = 2304KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BenhVien] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BenhVien].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BenhVien] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [BenhVien] SET ANSI_NULLS OFF
GO
ALTER DATABASE [BenhVien] SET ANSI_PADDING OFF
GO
ALTER DATABASE [BenhVien] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [BenhVien] SET ARITHABORT OFF
GO
ALTER DATABASE [BenhVien] SET AUTO_CLOSE ON
GO
ALTER DATABASE [BenhVien] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [BenhVien] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [BenhVien] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [BenhVien] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [BenhVien] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [BenhVien] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [BenhVien] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [BenhVien] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [BenhVien] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [BenhVien] SET  ENABLE_BROKER
GO
ALTER DATABASE [BenhVien] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [BenhVien] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [BenhVien] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [BenhVien] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [BenhVien] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [BenhVien] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [BenhVien] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [BenhVien] SET  READ_WRITE
GO
ALTER DATABASE [BenhVien] SET RECOVERY SIMPLE
GO
ALTER DATABASE [BenhVien] SET  MULTI_USER
GO
ALTER DATABASE [BenhVien] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [BenhVien] SET DB_CHAINING OFF
GO
USE [BenhVien]
GO
/****** Object:  Table [dbo].[DataSetTemp]    Script Date: 03/21/2013 18:12:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataSetTemp](
	[ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[MaBN] [decimal](18, 0) NULL,
	[Tuoi] [nvarchar](max) NULL,
	[GioiTinh] [nvarchar](max) NULL,
	[Cholesterol] [nvarchar](max) NULL,
	[HDL_Cholesterol] [nvarchar](max) NULL,
	[Triglyceride] [nvarchar](max) NULL,
	[LDL_Cholesterol] [nvarchar](max) NULL,
	[Glucose] [nvarchar](max) NULL,
	[SGOT] [nvarchar](max) NULL,
	[SGPT] [nvarchar](max) NULL,
	[Urea] [nvarchar](max) NULL,
	[WBC] [nvarchar](max) NULL,
	[LYM] [nvarchar](max) NULL,
	[MONO] [nvarchar](max) NULL,
	[GRAN] [nvarchar](max) NULL,
	[TyLeLYM] [nvarchar](max) NULL,
	[TyLeMONO] [nvarchar](max) NULL,
	[TyLeGRAN] [nvarchar](max) NULL,
	[HGB] [nvarchar](max) NULL,
	[RBC] [nvarchar](max) NULL,
	[HTC] [nvarchar](max) NULL,
	[MCV] [nvarchar](max) NULL,
	[MCH] [nvarchar](max) NULL,
	[MCHC] [nvarchar](max) NULL,
	[RDW_CV] [nvarchar](max) NULL,
	[PLT] [nvarchar](max) NULL,
	[MPV] [nvarchar](max) NULL,
	[PDW] [nvarchar](max) NULL,
	[PCT] [nvarchar](max) NULL,
	[Na] [nvarchar](max) NULL,
	[K] [nvarchar](max) NULL,
	[Cl] [nvarchar](max) NULL,
	[Ca] [nvarchar](max) NULL,
	[TieuDuong] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_DataSetTemp_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DataSet]    Script Date: 03/21/2013 18:12:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataSet](
	[ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[MaBn] [numeric](18, 0) NOT NULL,
	[HoTen] [nvarchar](max) NULL,
	[NamSinh] [numeric](18, 0) NULL,
	[NgayKham] [datetime] NULL,
	[GioiTinh] [nvarchar](max) NULL,
	[Cholesterol] [numeric](18, 0) NULL,
	[HDL_Cholesterol] [numeric](18, 0) NULL,
	[Triglyceride] [numeric](18, 0) NULL,
	[LDL_Cholesterol] [numeric](18, 0) NULL,
	[Glucose] [numeric](18, 0) NULL,
	[SGOT] [numeric](18, 0) NULL,
	[SGPT] [numeric](18, 0) NULL,
	[Urea] [numeric](18, 0) NULL,
	[WBC] [numeric](18, 1) NULL,
	[LYM] [numeric](18, 1) NULL,
	[MONO] [numeric](18, 1) NULL,
	[GRAN] [numeric](18, 1) NULL,
	[TyLeLYM] [numeric](18, 1) NULL,
	[TyLeMONO] [numeric](18, 1) NULL,
	[TyLeGRAN] [numeric](18, 1) NULL,
	[HGB] [numeric](18, 1) NULL,
	[RBC] [numeric](18, 2) NULL,
	[HTC] [numeric](18, 1) NULL,
	[MCV] [numeric](18, 0) NULL,
	[MCH] [numeric](18, 1) NULL,
	[MCHC] [numeric](18, 1) NULL,
	[RDW_CV] [numeric](18, 1) NULL,
	[PLT] [numeric](18, 0) NULL,
	[MPV] [numeric](18, 1) NULL,
	[PDW] [numeric](18, 1) NULL,
	[PCT] [numeric](18, 3) NULL,
	[Na] [numeric](18, 0) NULL,
	[K] [numeric](18, 1) NULL,
	[Cl] [numeric](18, 0) NULL,
	[Ca] [numeric](18, 2) NULL,
	[TieuDuong] [nvarchar](max) NULL,
 CONSTRAINT [PK_DataSet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BayesObject]    Script Date: 03/21/2013 18:12:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BayesObject](
	[ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[TenThuocTinh] [nvarchar](max) NULL,
	[KhoangRoiRac] [nvarchar](max) NULL,
	[GiaTri] [numeric](18, 3) NULL,
	[TieuDuong] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_BayesObject] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
