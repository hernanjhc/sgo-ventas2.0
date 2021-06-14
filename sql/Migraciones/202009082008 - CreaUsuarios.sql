USE [SGO-Ventas]
GO

/****** Object:  Table [dbo].[Usuarios]    Script Date: 08/09/2020 20:19:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Usuarios](
	[Id] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Contraseña] [varchar](255) NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[Estado] [tinyint] NOT NULL,
	[FechaBaja] [datetime] NULL,
	[NombreCompleto] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

