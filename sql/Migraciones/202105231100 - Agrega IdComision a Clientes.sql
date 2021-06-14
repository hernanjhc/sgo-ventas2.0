ALTER TABLE [dbo].[Clientes]
	add [IdComision] [int] NULL
GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Comisiones] FOREIGN KEY([IdComision])
REFERENCES [dbo].[Comisiones] ([Id])
GO
