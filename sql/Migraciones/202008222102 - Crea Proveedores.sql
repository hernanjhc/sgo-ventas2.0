USE [SGO-Ventas]
GO

/****** Object:  Table [dbo].[Proveedores]    Script Date: 22/08/2020 21:14:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Proveedores](
	[Id] [int] NOT NULL,
	[RazonSocial] [varchar](255) NOT NULL,
	[IdTipoDocumento] [int] NOT NULL,
	[NroDocumento] [decimal](18, 0) NOT NULL,
	[Direccion] [varchar](255) NULL,
	[Telefono] [varchar](255) NULL,
	[EMail] [varchar](255) NULL,
	[Observaciones] [varchar](255) NULL,
 CONSTRAINT [PK_Proveedores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Proveedores]  WITH CHECK ADD  CONSTRAINT [FK_Proveedores_TiposDocumento] FOREIGN KEY([IdTipoDocumento])
REFERENCES [dbo].[TiposDocumento] ([Id])
GO

ALTER TABLE [dbo].[Proveedores] CHECK CONSTRAINT [FK_Proveedores_TiposDocumento]
GO

