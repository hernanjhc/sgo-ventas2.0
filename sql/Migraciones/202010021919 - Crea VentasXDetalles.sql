USE [SGO-Ventas]
GO

/****** Object:  Table [dbo].[VentasXDetalles]    Script Date: 02/10/2020 19:19:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VentasXDetalles](
	[Id] [int] NOT NULL,
	[IdVenta] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Precio] [numeric](18, 2) NOT NULL,
	[Cantidad] [numeric](18, 2) NOT NULL,
	[Descuento] [numeric](18, 2) NOT NULL,
	[Importe] [numeric](17, 2) NOT NULL,
 CONSTRAINT [PK_VentasXDetalles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[VentasXDetalles]  WITH CHECK ADD  CONSTRAINT [FK_VentasXDetalles_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([Id])
GO

ALTER TABLE [dbo].[VentasXDetalles] CHECK CONSTRAINT [FK_VentasXDetalles_Productos]
GO

ALTER TABLE [dbo].[VentasXDetalles]  WITH CHECK ADD  CONSTRAINT [FK_VentasXDetalles_VentasX] FOREIGN KEY([IdVenta])
REFERENCES [dbo].[VentasX] ([Id])
GO

ALTER TABLE [dbo].[VentasXDetalles] CHECK CONSTRAINT [FK_VentasXDetalles_VentasX]
GO

