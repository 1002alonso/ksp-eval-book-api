USE [master]
GO
/****** Object:  Database [KSP-CONTROL-LIBRO-BD]    Script Date: 05/06/2024 09:01:05 a. m. ******/
CREATE DATABASE [KSP-CONTROL-LIBRO-BD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'KSP-CONTROL-LIBRO-BD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\KSP-CONTROL-LIBRO-BD.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'KSP-CONTROL-LIBRO-BD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\KSP-CONTROL-LIBRO-BD_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [KSP-CONTROL-LIBRO-BD] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KSP-CONTROL-LIBRO-BD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KSP-CONTROL-LIBRO-BD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KSP-CONTROL-LIBRO-BD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KSP-CONTROL-LIBRO-BD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KSP-CONTROL-LIBRO-BD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KSP-CONTROL-LIBRO-BD] SET ARITHABORT OFF 
GO
ALTER DATABASE [KSP-CONTROL-LIBRO-BD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [KSP-CONTROL-LIBRO-BD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KSP-CONTROL-LIBRO-BD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KSP-CONTROL-LIBRO-BD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KSP-CONTROL-LIBRO-BD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KSP-CONTROL-LIBRO-BD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KSP-CONTROL-LIBRO-BD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KSP-CONTROL-LIBRO-BD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KSP-CONTROL-LIBRO-BD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KSP-CONTROL-LIBRO-BD] SET  DISABLE_BROKER 
GO
ALTER DATABASE [KSP-CONTROL-LIBRO-BD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KSP-CONTROL-LIBRO-BD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KSP-CONTROL-LIBRO-BD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KSP-CONTROL-LIBRO-BD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KSP-CONTROL-LIBRO-BD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KSP-CONTROL-LIBRO-BD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [KSP-CONTROL-LIBRO-BD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [KSP-CONTROL-LIBRO-BD] SET RECOVERY FULL 
GO
ALTER DATABASE [KSP-CONTROL-LIBRO-BD] SET  MULTI_USER 
GO
ALTER DATABASE [KSP-CONTROL-LIBRO-BD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KSP-CONTROL-LIBRO-BD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [KSP-CONTROL-LIBRO-BD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [KSP-CONTROL-LIBRO-BD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [KSP-CONTROL-LIBRO-BD] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'KSP-CONTROL-LIBRO-BD', N'ON'
GO
ALTER DATABASE [KSP-CONTROL-LIBRO-BD] SET QUERY_STORE = OFF
GO
USE [KSP-CONTROL-LIBRO-BD]
GO
/****** Object:  Table [dbo].[CB_CAT_EDITORIAL]    Script Date: 05/06/2024 09:01:06 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CB_CAT_EDITORIAL](
	[ID_EDITORIAL] [uniqueidentifier] NULL,
	[NOMBRE] [varchar](250) NULL,
	[DT_ALTA] [datetime] NULL,
	[DT_ACTUALIZA] [datetime] NULL,
	[USUARIO_ALTA] [varchar](18) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CB_TAB_LIBRO]    Script Date: 05/06/2024 09:01:06 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CB_TAB_LIBRO](
	[ID_LIBRO] [uniqueidentifier] NOT NULL,
	[FOLIO] [varchar](12) NULL,
	[TITULO] [varchar](250) NULL,
	[DESCRIPCION] [varchar](350) NULL,
	[AUTOR] [varchar](250) NULL,
	[FK_EDITORIAL] [uniqueidentifier] NULL,
	[ANIO] [int] NULL,
	[NUM_COPIAS] [int] NULL,
	[DT_ALTA] [datetime] NULL,
	[DT_ACTUALIZA] [datetime] NULL,
	[USUARIO_ALTA] [varchar](18) NULL,
 CONSTRAINT [PK_CB_TAB_LIBRO] PRIMARY KEY CLUSTERED 
(
	[ID_LIBRO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CB_TAB_LIBRO_PRESTAMO]    Script Date: 05/06/2024 09:01:06 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CB_TAB_LIBRO_PRESTAMO](
	[ID_PRESTAMO] [uniqueidentifier] NOT NULL,
	[FK_LIBRO] [uniqueidentifier] NULL,
	[FK_LIBRO_USUARIO] [uniqueidentifier] NULL,
	[FECHA_PRESTAMO] [date] NULL,
	[FECHA_DEVOLUCION] [date] NULL,
	[DT_ALTA] [datetime] NULL,
	[DT_ACTUALIZA] [datetime] NULL,
	[USUARIO_ALTA] [varchar](10) NULL,
 CONSTRAINT [PK_CB_TAB_LIBRO _PRESTAMO] PRIMARY KEY CLUSTERED 
(
	[ID_PRESTAMO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CB_TAB_LIBRO_USUARIO]    Script Date: 05/06/2024 09:01:06 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CB_TAB_LIBRO_USUARIO](
	[ID_LIBRO_USUARIO] [uniqueidentifier] NULL,
	[CLAVE_USUARIO] [varchar](12) NULL,
	[NOMBRE] [varchar](250) NULL,
	[DIRECCION] [varchar](250) NULL,
	[TELEFONO] [varchar](10) NULL,
	[DT_ALTA] [datetime] NULL,
	[DT_ACTUALIZA] [datetime] NULL,
	[USUARIO_ALTA] [varchar](18) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CB_TAB_USUARIO]    Script Date: 05/06/2024 09:01:06 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CB_TAB_USUARIO](
	[ID_USUARIO] [uniqueidentifier] NOT NULL,
	[NOMBRE_USUARIO] [varchar](50) NULL,
	[PASSWORD_HASH] [varchar](250) NULL,
	[EMAIL] [varchar](100) NULL,
	[DT_ALTA] [datetime] NULL,
	[DT_ACTUALIZA] [datetime] NULL,
	[USUARIO_ALTA] [varchar](18) NULL,
 CONSTRAINT [PK_CB_TAB_USUARIO] PRIMARY KEY CLUSTERED 
(
	[ID_USUARIO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CB_CAT_EDITORIAL] ([ID_EDITORIAL], [NOMBRE], [DT_ALTA], [DT_ACTUALIZA], [USUARIO_ALTA]) VALUES (N'b30e13a0-7dd3-4867-8620-f2c1b6f0e261', N'Bambú', CAST(N'2024-05-28T00:07:09.303' AS DateTime), CAST(N'2024-05-28T00:07:09.303' AS DateTime), N'System')
INSERT [dbo].[CB_CAT_EDITORIAL] ([ID_EDITORIAL], [NOMBRE], [DT_ALTA], [DT_ACTUALIZA], [USUARIO_ALTA]) VALUES (N'a3d0efc3-8820-4ca4-a6c7-e99bf8e4a81b', N'Epson', CAST(N'2024-06-02T16:58:39.460' AS DateTime), CAST(N'2024-06-02T16:58:39.460' AS DateTime), N'System')
INSERT [dbo].[CB_CAT_EDITORIAL] ([ID_EDITORIAL], [NOMBRE], [DT_ALTA], [DT_ACTUALIZA], [USUARIO_ALTA]) VALUES (N'f6b05507-d259-489d-9b6b-b9408d9b9e3a', N'Satori', CAST(N'2024-05-26T16:43:56.237' AS DateTime), CAST(N'2024-05-26T16:43:56.237' AS DateTime), N'System')
INSERT [dbo].[CB_CAT_EDITORIAL] ([ID_EDITORIAL], [NOMBRE], [DT_ALTA], [DT_ACTUALIZA], [USUARIO_ALTA]) VALUES (N'ed0d5c79-a265-4c7c-85ff-b59b9b363572', N'Planeta', CAST(N'2024-06-02T20:06:13.930' AS DateTime), CAST(N'2024-06-02T20:06:13.930' AS DateTime), N'System')
INSERT [dbo].[CB_CAT_EDITORIAL] ([ID_EDITORIAL], [NOMBRE], [DT_ALTA], [DT_ACTUALIZA], [USUARIO_ALTA]) VALUES (N'897bd92b-7eaf-46b9-9db4-3e25f1e7e26e', N'Siglo XXI', CAST(N'2024-06-02T20:06:30.567' AS DateTime), CAST(N'2024-06-02T20:06:30.567' AS DateTime), N'System')
INSERT [dbo].[CB_CAT_EDITORIAL] ([ID_EDITORIAL], [NOMBRE], [DT_ALTA], [DT_ACTUALIZA], [USUARIO_ALTA]) VALUES (N'724ce930-9580-45a3-9cb5-2262dca9799d', N'Valdemar', CAST(N'2024-06-02T20:07:01.547' AS DateTime), CAST(N'2024-06-02T20:07:01.547' AS DateTime), N'System')
INSERT [dbo].[CB_CAT_EDITORIAL] ([ID_EDITORIAL], [NOMBRE], [DT_ALTA], [DT_ACTUALIZA], [USUARIO_ALTA]) VALUES (N'a19273c5-1af5-490d-baa5-b6d4ae9ef154', N'O''REILLY', CAST(N'2024-06-04T16:56:03.827' AS DateTime), CAST(N'2024-06-04T16:56:03.827' AS DateTime), N'System')
INSERT [dbo].[CB_CAT_EDITORIAL] ([ID_EDITORIAL], [NOMBRE], [DT_ALTA], [DT_ACTUALIZA], [USUARIO_ALTA]) VALUES (N'a11bd7b6-092a-46ec-b06d-447b8c0cd8c1', N'San Francisco', CAST(N'2024-06-04T16:57:21.783' AS DateTime), CAST(N'2024-06-04T16:57:21.783' AS DateTime), N'System')
INSERT [dbo].[CB_TAB_LIBRO] ([ID_LIBRO], [FOLIO], [TITULO], [DESCRIPCION], [AUTOR], [FK_EDITORIAL], [ANIO], [NUM_COPIAS], [DT_ALTA], [DT_ACTUALIZA], [USUARIO_ALTA]) VALUES (N'0c1babc0-29f3-47ac-b75d-2f5b4321aa3a', N'LB-0001', N'Eloquent Javascript', N' A lo largo de más de 900 páginas, el autor ahonda en las mejores prácticas de programación y en cómo estas influyen en el éxito del proyecto.', N'Marjin Haverbeke', N'a11bd7b6-092a-46ec-b06d-447b8c0cd8c1', 2019, 5, CAST(N'2024-06-04T17:00:10.620' AS DateTime), CAST(N'2024-06-05T14:51:34.423' AS DateTime), N'System')
INSERT [dbo].[CB_TAB_LIBRO] ([ID_LIBRO], [FOLIO], [TITULO], [DESCRIPCION], [AUTOR], [FK_EDITORIAL], [ANIO], [NUM_COPIAS], [DT_ALTA], [DT_ACTUALIZA], [USUARIO_ALTA]) VALUES (N'd819011b-369c-4919-8e63-3f61c1f485b7', N'LB-0004', N'Libro de prueba 23', N'Este es otro Libro de prueba', N'Autor anonimo x', N'897bd92b-7eaf-46b9-9db4-3e25f1e7e26e', 2019, 5, CAST(N'2024-06-04T20:34:40.527' AS DateTime), CAST(N'2024-06-04T20:34:40.527' AS DateTime), N'System')
INSERT [dbo].[CB_TAB_LIBRO] ([ID_LIBRO], [FOLIO], [TITULO], [DESCRIPCION], [AUTOR], [FK_EDITORIAL], [ANIO], [NUM_COPIAS], [DT_ALTA], [DT_ACTUALIZA], [USUARIO_ALTA]) VALUES (N'9d748e3e-fd9c-479c-979b-56e15144b0b7', N'LB-0002', N'Python Cookbook', N' A lo largo de más de 900 páginas, el autor ahonda en las mejores prácticas de programación y en cómo estas influyen en el éxito del proyecto.', N'David Beazley & Brian K. Jones', N'a19273c5-1af5-490d-baa5-b6d4ae9ef154', 2014, 5, CAST(N'2024-06-04T17:06:39.330' AS DateTime), CAST(N'2024-06-04T17:06:39.330' AS DateTime), N'System')
INSERT [dbo].[CB_TAB_LIBRO] ([ID_LIBRO], [FOLIO], [TITULO], [DESCRIPCION], [AUTOR], [FK_EDITORIAL], [ANIO], [NUM_COPIAS], [DT_ALTA], [DT_ACTUALIZA], [USUARIO_ALTA]) VALUES (N'292b3376-86e4-4d22-a565-e226dbcc7f30', N'LB-0006', N'Code Complete', N' A lo largo de más de 900 páginas, el autor ahonda en las mejores prácticas de programación y en cómo estas influyen en el éxito del proyecto.', N'Steve McConell', N'b30e13a0-7dd3-4867-8620-f2c1b6f0e261', 2004, 4, CAST(N'2024-06-04T12:36:24.980' AS DateTime), CAST(N'2024-06-04T22:02:10.020' AS DateTime), N'System')
INSERT [dbo].[CB_TAB_LIBRO_PRESTAMO] ([ID_PRESTAMO], [FK_LIBRO], [FK_LIBRO_USUARIO], [FECHA_PRESTAMO], [FECHA_DEVOLUCION], [DT_ALTA], [DT_ACTUALIZA], [USUARIO_ALTA]) VALUES (N'7f7a2f93-924b-42be-879a-0e0e592a517d', N'9d748e3e-fd9c-479c-979b-56e15144b0b7', N'903343c6-e9ca-44da-8b12-fc31031c2558', CAST(N'2024-06-05' AS Date), CAST(N'2024-06-05' AS Date), CAST(N'2024-06-05T12:07:53.257' AS DateTime), CAST(N'2024-06-05T13:38:09.357' AS DateTime), N'System')
INSERT [dbo].[CB_TAB_LIBRO_PRESTAMO] ([ID_PRESTAMO], [FK_LIBRO], [FK_LIBRO_USUARIO], [FECHA_PRESTAMO], [FECHA_DEVOLUCION], [DT_ALTA], [DT_ACTUALIZA], [USUARIO_ALTA]) VALUES (N'102c6b38-08a2-43a0-849d-120137f6ba0e', N'292b3376-86e4-4d22-a565-e226dbcc7f30', N'903343c6-e9ca-44da-8b12-fc31031c2558', CAST(N'2024-06-05' AS Date), NULL, CAST(N'2024-06-05T14:41:47.910' AS DateTime), CAST(N'2024-06-05T14:41:47.910' AS DateTime), N'System')
INSERT [dbo].[CB_TAB_LIBRO_PRESTAMO] ([ID_PRESTAMO], [FK_LIBRO], [FK_LIBRO_USUARIO], [FECHA_PRESTAMO], [FECHA_DEVOLUCION], [DT_ALTA], [DT_ACTUALIZA], [USUARIO_ALTA]) VALUES (N'1824e935-7372-472d-b6a4-134b22ff2ff0', N'0c1babc0-29f3-47ac-b75d-2f5b4321aa3a', N'903343c6-e9ca-44da-8b12-fc31031c2558', CAST(N'2024-06-05' AS Date), CAST(N'2024-06-05' AS Date), CAST(N'2024-06-05T14:20:59.063' AS DateTime), CAST(N'2024-06-05T14:21:17.147' AS DateTime), N'System')
INSERT [dbo].[CB_TAB_LIBRO_PRESTAMO] ([ID_PRESTAMO], [FK_LIBRO], [FK_LIBRO_USUARIO], [FECHA_PRESTAMO], [FECHA_DEVOLUCION], [DT_ALTA], [DT_ACTUALIZA], [USUARIO_ALTA]) VALUES (N'daf7b180-be69-4cee-acb9-213fae3485a7', N'292b3376-86e4-4d22-a565-e226dbcc7f30', N'903343c6-e9ca-44da-8b12-fc31031c2558', CAST(N'2024-06-05' AS Date), CAST(N'2024-06-05' AS Date), CAST(N'2024-06-05T14:26:29.227' AS DateTime), CAST(N'2024-06-05T14:30:41.353' AS DateTime), N'System')
INSERT [dbo].[CB_TAB_LIBRO_PRESTAMO] ([ID_PRESTAMO], [FK_LIBRO], [FK_LIBRO_USUARIO], [FECHA_PRESTAMO], [FECHA_DEVOLUCION], [DT_ALTA], [DT_ACTUALIZA], [USUARIO_ALTA]) VALUES (N'f0539fc1-d98b-4068-a448-3a81c5374af3', N'd819011b-369c-4919-8e63-3f61c1f485b7', N'6ff8d48f-d67b-41eb-a003-ee606da6cc4e', CAST(N'2024-06-05' AS Date), NULL, CAST(N'2024-06-05T14:58:32.057' AS DateTime), CAST(N'2024-06-05T14:58:32.057' AS DateTime), N'System')
INSERT [dbo].[CB_TAB_LIBRO_PRESTAMO] ([ID_PRESTAMO], [FK_LIBRO], [FK_LIBRO_USUARIO], [FECHA_PRESTAMO], [FECHA_DEVOLUCION], [DT_ALTA], [DT_ACTUALIZA], [USUARIO_ALTA]) VALUES (N'a0d2203d-0233-4a20-ab68-5d50d59266b6', N'292b3376-86e4-4d22-a565-e226dbcc7f30', N'903343c6-e9ca-44da-8b12-fc31031c2558', CAST(N'2024-06-05' AS Date), CAST(N'2024-06-05' AS Date), CAST(N'2024-06-05T14:34:14.113' AS DateTime), CAST(N'2024-06-05T14:41:39.253' AS DateTime), N'System')
INSERT [dbo].[CB_TAB_LIBRO_PRESTAMO] ([ID_PRESTAMO], [FK_LIBRO], [FK_LIBRO_USUARIO], [FECHA_PRESTAMO], [FECHA_DEVOLUCION], [DT_ALTA], [DT_ACTUALIZA], [USUARIO_ALTA]) VALUES (N'00b84b2f-7d71-4d00-ae91-694eb6e932e2', N'0c1babc0-29f3-47ac-b75d-2f5b4321aa3a', N'7d854483-db5b-4527-bedb-a1088f9d2462', CAST(N'2024-06-05' AS Date), NULL, CAST(N'2024-06-05T12:22:57.173' AS DateTime), CAST(N'2024-06-05T12:22:57.173' AS DateTime), N'System')
INSERT [dbo].[CB_TAB_LIBRO_PRESTAMO] ([ID_PRESTAMO], [FK_LIBRO], [FK_LIBRO_USUARIO], [FECHA_PRESTAMO], [FECHA_DEVOLUCION], [DT_ALTA], [DT_ACTUALIZA], [USUARIO_ALTA]) VALUES (N'1b66f3b4-3c45-4a60-9392-6ff0ab9fc8ef', N'0c1babc0-29f3-47ac-b75d-2f5b4321aa3a', N'903343c6-e9ca-44da-8b12-fc31031c2558', CAST(N'2024-06-05' AS Date), CAST(N'2024-06-05' AS Date), CAST(N'2024-06-05T14:24:08.690' AS DateTime), CAST(N'2024-06-05T14:30:51.360' AS DateTime), N'System')
INSERT [dbo].[CB_TAB_LIBRO_PRESTAMO] ([ID_PRESTAMO], [FK_LIBRO], [FK_LIBRO_USUARIO], [FECHA_PRESTAMO], [FECHA_DEVOLUCION], [DT_ALTA], [DT_ACTUALIZA], [USUARIO_ALTA]) VALUES (N'd92c9dea-ef32-49ca-bd7c-74f056952b52', N'd819011b-369c-4919-8e63-3f61c1f485b7', N'903343c6-e9ca-44da-8b12-fc31031c2558', CAST(N'2024-06-05' AS Date), CAST(N'2024-06-05' AS Date), CAST(N'2024-06-05T02:04:32.433' AS DateTime), CAST(N'2024-06-05T14:33:53.667' AS DateTime), N'System')
INSERT [dbo].[CB_TAB_LIBRO_PRESTAMO] ([ID_PRESTAMO], [FK_LIBRO], [FK_LIBRO_USUARIO], [FECHA_PRESTAMO], [FECHA_DEVOLUCION], [DT_ALTA], [DT_ACTUALIZA], [USUARIO_ALTA]) VALUES (N'78c24790-12af-4eed-ba97-901706d84ffa', N'9d748e3e-fd9c-479c-979b-56e15144b0b7', N'c57f34cd-61d8-4989-abf3-eb32ecf02884', CAST(N'2024-06-05' AS Date), NULL, CAST(N'2024-06-05T14:54:41.570' AS DateTime), CAST(N'2024-06-05T14:54:41.570' AS DateTime), N'System')
INSERT [dbo].[CB_TAB_LIBRO_PRESTAMO] ([ID_PRESTAMO], [FK_LIBRO], [FK_LIBRO_USUARIO], [FECHA_PRESTAMO], [FECHA_DEVOLUCION], [DT_ALTA], [DT_ACTUALIZA], [USUARIO_ALTA]) VALUES (N'd1b6ea1f-ce3a-43fa-9573-913648be351c', N'292b3376-86e4-4d22-a565-e226dbcc7f30', N'1f23c066-e1a8-45e4-8824-80c4915cd150', CAST(N'2024-06-05' AS Date), NULL, CAST(N'2024-06-05T12:36:22.630' AS DateTime), CAST(N'2024-06-05T12:36:22.630' AS DateTime), N'System')
INSERT [dbo].[CB_TAB_LIBRO_PRESTAMO] ([ID_PRESTAMO], [FK_LIBRO], [FK_LIBRO_USUARIO], [FECHA_PRESTAMO], [FECHA_DEVOLUCION], [DT_ALTA], [DT_ACTUALIZA], [USUARIO_ALTA]) VALUES (N'7d5c915f-a245-4c67-97f1-b815818e9d51', N'0c1babc0-29f3-47ac-b75d-2f5b4321aa3a', N'6ff8d48f-d67b-41eb-a003-ee606da6cc4e', CAST(N'2024-06-05' AS Date), NULL, CAST(N'2024-06-05T12:24:27.880' AS DateTime), CAST(N'2024-06-05T12:24:27.880' AS DateTime), N'System')
INSERT [dbo].[CB_TAB_LIBRO_PRESTAMO] ([ID_PRESTAMO], [FK_LIBRO], [FK_LIBRO_USUARIO], [FECHA_PRESTAMO], [FECHA_DEVOLUCION], [DT_ALTA], [DT_ACTUALIZA], [USUARIO_ALTA]) VALUES (N'9f45362c-ef07-4f2c-bea5-c549d82570f2', N'0c1babc0-29f3-47ac-b75d-2f5b4321aa3a', N'903343c6-e9ca-44da-8b12-fc31031c2558', CAST(N'2024-06-05' AS Date), NULL, CAST(N'2024-06-05T14:33:39.117' AS DateTime), CAST(N'2024-06-05T14:33:39.117' AS DateTime), N'System')
INSERT [dbo].[CB_TAB_LIBRO_PRESTAMO] ([ID_PRESTAMO], [FK_LIBRO], [FK_LIBRO_USUARIO], [FECHA_PRESTAMO], [FECHA_DEVOLUCION], [DT_ALTA], [DT_ACTUALIZA], [USUARIO_ALTA]) VALUES (N'b623d8fa-8a72-480e-9110-d93b1ae9496a', N'292b3376-86e4-4d22-a565-e226dbcc7f30', N'903343c6-e9ca-44da-8b12-fc31031c2558', CAST(N'2024-06-05' AS Date), CAST(N'2024-06-05' AS Date), CAST(N'2024-06-05T12:20:19.187' AS DateTime), CAST(N'2024-06-05T14:16:15.737' AS DateTime), N'System')
INSERT [dbo].[CB_TAB_LIBRO_PRESTAMO] ([ID_PRESTAMO], [FK_LIBRO], [FK_LIBRO_USUARIO], [FECHA_PRESTAMO], [FECHA_DEVOLUCION], [DT_ALTA], [DT_ACTUALIZA], [USUARIO_ALTA]) VALUES (N'5c58e0b9-9092-4f7c-a781-e889bdef9c02', N'9d748e3e-fd9c-479c-979b-56e15144b0b7', N'903343c6-e9ca-44da-8b12-fc31031c2558', CAST(N'2024-06-05' AS Date), NULL, CAST(N'2024-06-05T14:23:11.230' AS DateTime), CAST(N'2024-06-05T14:23:11.230' AS DateTime), N'System')
INSERT [dbo].[CB_TAB_LIBRO_PRESTAMO] ([ID_PRESTAMO], [FK_LIBRO], [FK_LIBRO_USUARIO], [FECHA_PRESTAMO], [FECHA_DEVOLUCION], [DT_ALTA], [DT_ACTUALIZA], [USUARIO_ALTA]) VALUES (N'cf2468f5-6fdc-42f2-b37c-eda7ce9daf39', N'd819011b-369c-4919-8e63-3f61c1f485b7', N'1f23c066-e1a8-45e4-8824-80c4915cd150', CAST(N'2024-06-05' AS Date), NULL, CAST(N'2024-06-05T12:36:09.750' AS DateTime), CAST(N'2024-06-05T12:36:09.750' AS DateTime), N'System')
INSERT [dbo].[CB_TAB_LIBRO_PRESTAMO] ([ID_PRESTAMO], [FK_LIBRO], [FK_LIBRO_USUARIO], [FECHA_PRESTAMO], [FECHA_DEVOLUCION], [DT_ALTA], [DT_ACTUALIZA], [USUARIO_ALTA]) VALUES (N'e5866d6a-b610-47c4-b7e9-f49b7802846a', N'0c1babc0-29f3-47ac-b75d-2f5b4321aa3a', N'903343c6-e9ca-44da-8b12-fc31031c2558', CAST(N'2024-06-05' AS Date), CAST(N'2024-06-05' AS Date), CAST(N'2024-06-05T01:43:11.590' AS DateTime), CAST(N'2024-06-05T14:23:23.923' AS DateTime), N'System')
INSERT [dbo].[CB_TAB_LIBRO_USUARIO] ([ID_LIBRO_USUARIO], [CLAVE_USUARIO], [NOMBRE], [DIRECCION], [TELEFONO], [DT_ALTA], [DT_ACTUALIZA], [USUARIO_ALTA]) VALUES (N'903343c6-e9ca-44da-8b12-fc31031c2558', N'CB-0004', N'Flor del Carmen De La Cruz', N'Av. Greorio Mendez ', N'9933596269', CAST(N'2024-06-03T23:00:21.490' AS DateTime), CAST(N'2024-06-04T03:08:25.380' AS DateTime), N'System')
INSERT [dbo].[CB_TAB_LIBRO_USUARIO] ([ID_LIBRO_USUARIO], [CLAVE_USUARIO], [NOMBRE], [DIRECCION], [TELEFONO], [DT_ALTA], [DT_ACTUALIZA], [USUARIO_ALTA]) VALUES (N'7d854483-db5b-4527-bedb-a1088f9d2462', N'CB-0002', N'Aldo Sanchez Cruz', N'Aldama 69', N'0000000', CAST(N'2024-06-03T17:22:28.003' AS DateTime), CAST(N'2024-06-03T17:22:28.003' AS DateTime), N'System')
INSERT [dbo].[CB_TAB_LIBRO_USUARIO] ([ID_LIBRO_USUARIO], [CLAVE_USUARIO], [NOMBRE], [DIRECCION], [TELEFONO], [DT_ALTA], [DT_ACTUALIZA], [USUARIO_ALTA]) VALUES (N'6ff8d48f-d67b-41eb-a003-ee606da6cc4e', N'CB-0003', N'Luz Maria Cruz', N'Quintin Arauz', N'0000000', CAST(N'2024-06-03T17:23:13.317' AS DateTime), CAST(N'2024-06-03T17:23:13.317' AS DateTime), N'System')
INSERT [dbo].[CB_TAB_LIBRO_USUARIO] ([ID_LIBRO_USUARIO], [CLAVE_USUARIO], [NOMBRE], [DIRECCION], [TELEFONO], [DT_ALTA], [DT_ACTUALIZA], [USUARIO_ALTA]) VALUES (N'c57f34cd-61d8-4989-abf3-eb32ecf02884', N'CB-0005', N'Alejandro Perez Sanchez', N'Calle Gregorio Mendez No. 48', N'9933596211', CAST(N'2024-06-03T23:02:55.223' AS DateTime), CAST(N'2024-06-03T23:02:55.223' AS DateTime), N'System')
INSERT [dbo].[CB_TAB_LIBRO_USUARIO] ([ID_LIBRO_USUARIO], [CLAVE_USUARIO], [NOMBRE], [DIRECCION], [TELEFONO], [DT_ALTA], [DT_ACTUALIZA], [USUARIO_ALTA]) VALUES (N'1f23c066-e1a8-45e4-8824-80c4915cd150', N'CB-0004', N'Kareli Sanchez', N'Av. Greorio Mendez ', N'9933596240', CAST(N'2024-06-04T03:01:09.017' AS DateTime), CAST(N'2024-06-04T03:09:01.717' AS DateTime), N'System')
USE [master]
GO
ALTER DATABASE [KSP-CONTROL-LIBRO-BD] SET  READ_WRITE 
GO
