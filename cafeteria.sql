USE [master]
GO
/****** Object:  Database [cafeteria]    Script Date: 14/12/2021 19:41:43 ******/
CREATE DATABASE [cafeteria]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'cafeteria', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\cafeteria.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'cafeteria_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\cafeteria_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [cafeteria] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [cafeteria].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [cafeteria] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [cafeteria] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [cafeteria] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [cafeteria] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [cafeteria] SET ARITHABORT OFF 
GO
ALTER DATABASE [cafeteria] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [cafeteria] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [cafeteria] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [cafeteria] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [cafeteria] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [cafeteria] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [cafeteria] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [cafeteria] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [cafeteria] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [cafeteria] SET  DISABLE_BROKER 
GO
ALTER DATABASE [cafeteria] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [cafeteria] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [cafeteria] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [cafeteria] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [cafeteria] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [cafeteria] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [cafeteria] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [cafeteria] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [cafeteria] SET  MULTI_USER 
GO
ALTER DATABASE [cafeteria] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [cafeteria] SET DB_CHAINING OFF 
GO
ALTER DATABASE [cafeteria] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [cafeteria] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [cafeteria] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [cafeteria] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [cafeteria] SET QUERY_STORE = OFF
GO
USE [cafeteria]
GO
/****** Object:  Table [dbo].[categorias]    Script Date: 14/12/2021 19:41:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categorias](
	[codigo] [int] NOT NULL,
	[nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_categorias] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[clientes]    Script Date: 14/12/2021 19:41:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientes](
	[celular] [varchar](20) NOT NULL,
	[nombre] [varchar](250) NULL,
	[email] [varchar](150) NULL,
	[direccion] [varchar](250) NULL,
	[referencia] [varchar](250) NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[celular] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalle_pedido]    Script Date: 14/12/2021 19:41:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_pedido](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_pedido] [int] NULL,
	[codigo_producto] [int] NULL,
	[cantidad] [int] NULL,
	[precio] [int] NULL,
 CONSTRAINT [PK_detalle_pedido] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 14/12/2021 19:41:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[rut_trabajador] [varchar](15) NULL,
	[id_cliente] [varchar](20) NULL,
	[codigo_usuario] [varchar](50) NULL,
	[estado] [varchar](50) NULL,
	[fecha] [datetime] NULL,
	[fecha_modificacion] [datetime] NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[productos]    Script Date: 14/12/2021 19:41:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productos](
	[codigo] [int] NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[cod_categoria] [int] NOT NULL,
	[cod_proveedor] [int] NOT NULL,
	[precio] [int] NOT NULL,
 CONSTRAINT [PK_productos] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proveedores]    Script Date: 14/12/2021 19:41:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proveedores](
	[codigo] [int] NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[telefono] [varchar](20) NOT NULL,
 CONSTRAINT [PK_proveedores] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[trabajadores]    Script Date: 14/12/2021 19:41:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[trabajadores](
	[rut] [varchar](15) NOT NULL,
	[nombre] [varchar](150) NULL,
	[apellido] [varchar](150) NULL,
	[direccion] [varchar](150) NULL,
	[celular] [varchar](20) NULL,
	[email] [varchar](250) NULL,
 CONSTRAINT [PK_trabajadores] PRIMARY KEY CLUSTERED 
(
	[rut] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 14/12/2021 19:41:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios](
	[codigo] [varchar](50) NOT NULL,
	[nombre] [varchar](100) NULL,
	[clave] [varchar](20) NULL,
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[categorias] ([codigo], [nombre]) VALUES (1, N'reposteria')
GO
INSERT [dbo].[clientes] ([celular], [nombre], [email], [direccion], [referencia]) VALUES (N'987654321', N'hulk', N'hulk@mail.com', N'los angeles', N'estudiante ipvg')
INSERT [dbo].[clientes] ([celular], [nombre], [email], [direccion], [referencia]) VALUES (N'987705939', N'gustavo', N'gustavo@email.cl', N'los angeles', N'estudiante ipvg')
GO
SET IDENTITY_INSERT [dbo].[detalle_pedido] ON 

INSERT [dbo].[detalle_pedido] ([id], [id_pedido], [codigo_producto], [cantidad], [precio]) VALUES (1, 2, 1, 2, 1000)
INSERT [dbo].[detalle_pedido] ([id], [id_pedido], [codigo_producto], [cantidad], [precio]) VALUES (2, 4, 1, 8, 1000)
INSERT [dbo].[detalle_pedido] ([id], [id_pedido], [codigo_producto], [cantidad], [precio]) VALUES (3, 5, 1, 2, 1000)
INSERT [dbo].[detalle_pedido] ([id], [id_pedido], [codigo_producto], [cantidad], [precio]) VALUES (4, 6, 1, 1, 1000)
INSERT [dbo].[detalle_pedido] ([id], [id_pedido], [codigo_producto], [cantidad], [precio]) VALUES (5, 7, 1, 10, 1000)
SET IDENTITY_INSERT [dbo].[detalle_pedido] OFF
GO
SET IDENTITY_INSERT [dbo].[Pedido] ON 

INSERT [dbo].[Pedido] ([id], [rut_trabajador], [id_cliente], [codigo_usuario], [estado], [fecha], [fecha_modificacion]) VALUES (1, N'123456789', N'987705939', N'g', N'creado', CAST(N'2021-12-14T15:08:57.000' AS DateTime), NULL)
INSERT [dbo].[Pedido] ([id], [rut_trabajador], [id_cliente], [codigo_usuario], [estado], [fecha], [fecha_modificacion]) VALUES (2, N'123456789', N'987705939', N'g', N'creado', CAST(N'2021-12-14T15:09:02.000' AS DateTime), NULL)
INSERT [dbo].[Pedido] ([id], [rut_trabajador], [id_cliente], [codigo_usuario], [estado], [fecha], [fecha_modificacion]) VALUES (3, N'123456789', N'987705939', N'g', N'creado', CAST(N'2021-12-14T15:09:25.000' AS DateTime), NULL)
INSERT [dbo].[Pedido] ([id], [rut_trabajador], [id_cliente], [codigo_usuario], [estado], [fecha], [fecha_modificacion]) VALUES (4, N'123456789', N'987654321', N'g', N'creado', CAST(N'2021-12-14T15:10:52.000' AS DateTime), NULL)
INSERT [dbo].[Pedido] ([id], [rut_trabajador], [id_cliente], [codigo_usuario], [estado], [fecha], [fecha_modificacion]) VALUES (5, N'123456789', N'987705939', N'g', N'creado', CAST(N'2021-12-14T15:25:18.000' AS DateTime), NULL)
INSERT [dbo].[Pedido] ([id], [rut_trabajador], [id_cliente], [codigo_usuario], [estado], [fecha], [fecha_modificacion]) VALUES (6, N'123456789', N'987705939', N'g', N'creado', CAST(N'2021-12-14T15:26:10.000' AS DateTime), NULL)
INSERT [dbo].[Pedido] ([id], [rut_trabajador], [id_cliente], [codigo_usuario], [estado], [fecha], [fecha_modificacion]) VALUES (7, N'123456789', N'987705939', N'g', N'creado', CAST(N'2021-12-14T17:17:05.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Pedido] OFF
GO
INSERT [dbo].[productos] ([codigo], [nombre], [cod_categoria], [cod_proveedor], [precio]) VALUES (1, N'dona', 1, 1, 1000)
GO
INSERT [dbo].[proveedores] ([codigo], [nombre], [telefono]) VALUES (1, N'dunkin ', N'987123654')
GO
INSERT [dbo].[trabajadores] ([rut], [nombre], [apellido], [direccion], [celular], [email]) VALUES (N'123456789', N'adolfo', N'acuña', N'los angeles', N'987654321', N'adolfo@mail.com')
GO
INSERT [dbo].[usuarios] ([codigo], [nombre], [clave]) VALUES (N'g', N'g', N'1')
GO
ALTER TABLE [dbo].[detalle_pedido]  WITH CHECK ADD  CONSTRAINT [FK_detalle_pedido_Pedido] FOREIGN KEY([id_pedido])
REFERENCES [dbo].[Pedido] ([id])
GO
ALTER TABLE [dbo].[detalle_pedido] CHECK CONSTRAINT [FK_detalle_pedido_Pedido]
GO
ALTER TABLE [dbo].[detalle_pedido]  WITH CHECK ADD  CONSTRAINT [FK_detalle_pedido_productos] FOREIGN KEY([codigo_producto])
REFERENCES [dbo].[productos] ([codigo])
GO
ALTER TABLE [dbo].[detalle_pedido] CHECK CONSTRAINT [FK_detalle_pedido_productos]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_clientes] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[clientes] ([celular])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_clientes]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_trabajadores] FOREIGN KEY([rut_trabajador])
REFERENCES [dbo].[trabajadores] ([rut])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_trabajadores]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_usuarios] FOREIGN KEY([codigo_usuario])
REFERENCES [dbo].[usuarios] ([codigo])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_usuarios]
GO
ALTER TABLE [dbo].[productos]  WITH CHECK ADD  CONSTRAINT [FK_productos_categorias] FOREIGN KEY([cod_categoria])
REFERENCES [dbo].[categorias] ([codigo])
GO
ALTER TABLE [dbo].[productos] CHECK CONSTRAINT [FK_productos_categorias]
GO
ALTER TABLE [dbo].[productos]  WITH CHECK ADD  CONSTRAINT [FK_productos_proveedores] FOREIGN KEY([cod_proveedor])
REFERENCES [dbo].[proveedores] ([codigo])
GO
ALTER TABLE [dbo].[productos] CHECK CONSTRAINT [FK_productos_proveedores]
GO
USE [master]
GO
ALTER DATABASE [cafeteria] SET  READ_WRITE 
GO
