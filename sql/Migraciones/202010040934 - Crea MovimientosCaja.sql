USE [SGO-Ventas]
GO

/****** Object:  Table [dbo].[MovimientosCaja]    Script Date: 04/10/2020 9:34:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[MovimientosCaja](
	[Id] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[IdVenta] [int] NULL,
	[IdCliente] [int] NULL,
	[IdCompra] [int] NULL,
	[idProveedor] [int] NULL,
	[Ingreso] [numeric](18, 2) NULL,
	[Egreso] [numeric](18, 2) NULL,
	[Descripcion] [varchar](50) NULL,
	[Contrasiento] [int] NULL,
 CONSTRAINT [PK_MovimientosCaja] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

