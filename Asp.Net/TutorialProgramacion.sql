USE [TutorialProgramacion]
GO
/****** Object:  Table [dbo].[Articulos]    Script Date: 16/10/2016 1:46:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Articulos](
	[ID_Articulos] [int] IDENTITY(1,1) NOT NULL,
	[Marca] [nvarchar](50) NULL,
	[Año] [int] NULL,
	[Descripción] [varchar](max) NULL,
	[Manual] [varbinary](max) NULL,
	[FIleName] [nvarchar](500) NULL,
	[ContentType] [nvarchar](500) NULL,
	[ID_Producto] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Articulos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 16/10/2016 1:46:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[ID_Categoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Categoria] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Producto]    Script Date: 16/10/2016 1:46:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[ID_Producto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Producto] [nvarchar](50) NULL,
	[ID_Categoria] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Articulos]  WITH CHECK ADD  CONSTRAINT [FK_Articulos_Producto] FOREIGN KEY([ID_Producto])
REFERENCES [dbo].[Producto] ([ID_Producto])
GO
ALTER TABLE [dbo].[Articulos] CHECK CONSTRAINT [FK_Articulos_Producto]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Categoria] FOREIGN KEY([ID_Categoria])
REFERENCES [dbo].[Categoria] ([ID_Categoria])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Categoria]
GO
/****** Object:  StoredProcedure [dbo].[BuscarProducto]    Script Date: 16/10/2016 1:46:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[BuscarProducto]
@NombreProducto nvarchar(50)
as
select * from Producto where Nombre_Producto like @NombreProducto
GO
/****** Object:  StoredProcedure [dbo].[BuscarProductoID]    Script Date: 16/10/2016 1:46:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[BuscarProductoID]
@ID_Producto int
as
select * from Producto where ID_Producto = @ID_Producto
GO
/****** Object:  StoredProcedure [dbo].[EliminarProducto]    Script Date: 16/10/2016 1:46:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[EliminarProducto]
@ID_Producto int
as
delete from Producto where ID_Producto = @ID_Producto
GO
/****** Object:  StoredProcedure [dbo].[ListarProducto]    Script Date: 16/10/2016 1:46:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ListarProducto]
as
select * from Producto
GO
/****** Object:  StoredProcedure [dbo].[ModificarProducto]    Script Date: 16/10/2016 1:46:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[ModificarProducto]
@ID_Producto int,
@NombreProducto nvarchar(50),
@ID_Categoria int
as
Update Producto set Nombre_Producto = @NombreProducto, ID_Categoria = @ID_Categoria where ID_Producto = @ID_Producto
GO
/****** Object:  StoredProcedure [dbo].[RegistrarProducto]    Script Date: 16/10/2016 1:46:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[RegistrarProducto]
@NombreProducto nvarchar(50),
@ID_Categoria int
as
insert into Producto(Nombre_Producto, ID_Categoria) values (@NombreProducto, @ID_Categoria)
GO
