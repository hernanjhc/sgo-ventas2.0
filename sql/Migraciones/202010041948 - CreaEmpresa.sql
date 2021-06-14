USE [SGO-Ventas]
GO

/****** Object:  Table [dbo].[Empresa]    Script Date: 04/10/2020 19:48:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Empresa](
	[Id] [int] NOT NULL,
	[RazonSocial] [varchar](50) NULL,
	[Documento] [varchar](50) NULL,
	[Domicilio] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Telefono] [varchar](50) NULL,
 CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

