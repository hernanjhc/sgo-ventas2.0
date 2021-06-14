USE [SGO-Ventas]
GO

/****** Object:  Table [dbo].[Movimientos]    Script Date: 04/10/2020 18:52:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Movimientos](
	[Id] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[IdVenta] [int] NULL,
	[IdCliente] [int] NULL,
	[IdCompra] [int] NULL,
	[IdProveedor] [int] NULL,
	[Cantidad] [decimal](18, 2) NOT NULL,
	[DescuentaStock] [int] NOT NULL,
 CONSTRAINT [PK_Movimientos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

