USE [SGO-Ventas]
GO

/****** Object:  Table [dbo].[VentasX]    Script Date: 03/10/2020 19:20:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VentasX](
	[Id] [int] NOT NULL,
	[IdCliente] [int] NULL,
	[IdTipoPago] [int] NULL,
	[Fecha] [datetime] NULL,
	[Total] [numeric](17, 2) NULL,
	[IdUsuario] [int] NULL,
 CONSTRAINT [PK_VentasX] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[VentasX]  WITH CHECK ADD  CONSTRAINT [FK_VentasX_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([Id])
GO

ALTER TABLE [dbo].[VentasX] CHECK CONSTRAINT [FK_VentasX_Clientes]
GO

ALTER TABLE [dbo].[VentasX]  WITH CHECK ADD  CONSTRAINT [FK_VentasX_TiposPago] FOREIGN KEY([IdTipoPago])
REFERENCES [dbo].[TiposPago] ([Id])
GO

ALTER TABLE [dbo].[VentasX] CHECK CONSTRAINT [FK_VentasX_TiposPago]
GO

ALTER TABLE [dbo].[VentasX]  WITH CHECK ADD  CONSTRAINT [FK_VentasX_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[VentasX] CHECK CONSTRAINT [FK_VentasX_Usuarios]
GO

