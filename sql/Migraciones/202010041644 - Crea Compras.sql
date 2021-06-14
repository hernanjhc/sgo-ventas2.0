USE [SGO-Ventas]
GO

/****** Object:  Table [dbo].[Compras]    Script Date: 04/10/2020 16:44:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Compras](
	[Id] [int] NOT NULL,
	[IdProveedor] [int] NOT NULL,
	[IdTipoPago] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Total] [numeric](18, 2) NOT NULL,
	[IdUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Compras] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Compras]  WITH CHECK ADD  CONSTRAINT [FK_Compras_Proveedores] FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedores] ([Id])
GO

ALTER TABLE [dbo].[Compras] CHECK CONSTRAINT [FK_Compras_Proveedores]
GO

ALTER TABLE [dbo].[Compras]  WITH CHECK ADD  CONSTRAINT [FK_Compras_TiposPago] FOREIGN KEY([IdTipoPago])
REFERENCES [dbo].[TiposPago] ([Id])
GO

ALTER TABLE [dbo].[Compras] CHECK CONSTRAINT [FK_Compras_TiposPago]
GO

ALTER TABLE [dbo].[Compras]  WITH CHECK ADD  CONSTRAINT [FK_Compras_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[Compras] CHECK CONSTRAINT [FK_Compras_Usuarios]
GO

