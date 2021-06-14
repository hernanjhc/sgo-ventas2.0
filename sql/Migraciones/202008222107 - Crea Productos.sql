USE [SGO-Ventas]
GO

/****** Object:  Table [dbo].[Productos]    Script Date: 22/08/2020 21:07:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Productos](
	[Id] [int] NOT NULL,
	[CodBarra] [varchar](50) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[IdMarca] [int] NULL,
	[IdRubro] [int] NULL,
	[IdProveedor] [int] NULL,
	[IdUnidad] [int] NULL,
	[Costo] [numeric](17, 2) NULL,
	[PrecioL1] [numeric](17, 2) NULL DEFAULT (NULL),
	[PrecioL2] [numeric](17, 2) NULL DEFAULT (NULL),
	[PrecioL3] [numeric](17, 2) NULL DEFAULT (NULL),
	[Stock] [numeric](17, 2) NULL DEFAULT (NULL),
	[StockMinimo] [numeric](17, 2) NOT NULL,
	[IVAVenta] [numeric](5, 2) NULL,
	[Observaciones] [varchar](100) NULL DEFAULT (NULL),
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Marcas] FOREIGN KEY([IdMarca])
REFERENCES [dbo].[Marcas] ([Id])
GO

ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Marcas]
GO

ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Rubros] FOREIGN KEY([IdRubro])
REFERENCES [dbo].[Rubros] ([Id])
GO

ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Rubros]
GO

ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Proveedores] FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedores] ([Id])
GO

ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Proveedores]
GO

ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Unidades] FOREIGN KEY([IdUnidad])
REFERENCES [dbo].[Unidades] ([Id])
GO

ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Unidades]
GO

