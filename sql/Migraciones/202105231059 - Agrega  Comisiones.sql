USE [sgo-ventas]
GO

/****** Object:  Table [dbo].[Comisiones]    Script Date: 23/05/2021 10:47:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Comisiones](
	[Id] [int] NOT NULL,
	[RazonSocial] [varchar](255) NOT NULL,
	[IdTipoDocumento] [int] NOT NULL,
	[NroDocumento] [decimal](18, 0) NOT NULL,
	[Direccion] [varchar](255) NULL,
	[Telefono] [varchar](50) NULL,
	[EMail] [varchar](50) NULL,
	[Observaciones] [varchar](255) NULL,
 CONSTRAINT [PK_Comisiones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

