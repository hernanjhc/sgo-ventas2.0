USE [SGO-Ventas]
GO

/****** Object:  Table [dbo].[ComprasDetalle]    Script Date: 04/10/2020 16:48:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ComprasDetalle](
	[Id] [int] NOT NULL,
	[IdCompra] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Precio] [numeric](18, 2) NOT NULL,
	[Cantidad] [numeric](18, 2) NOT NULL,
	[Descuento] [numeric](18, 2) NOT NULL,
	[Importe] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_ComprasDetalle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

