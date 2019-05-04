:r UseDb.sql
USE [escuelapsdelsur]
GO

/****** Object:  Table [dbo].[InteraccionesInteresados]    Script Date: 05/04/2019 17:29:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[InteraccionesInteresados](
	[InteresadoId] [int] NOT NULL,
	[InteraccionInteresadoId] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Comentario] [nvarchar](max) NULL,
	[PadreId] [int] NULL,
 CONSTRAINT [PK_InteraccionesInteresados] PRIMARY KEY CLUSTERED 
(
	[InteresadoId] ASC,
	[InteraccionInteresadoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[InteraccionesInteresados]  WITH CHECK ADD  CONSTRAINT [FK_InteraccionesInteresados_InteraccionesInteresados] FOREIGN KEY([InteraccionInteresadoId], [PadreId])
REFERENCES [dbo].[InteraccionesInteresados] ([InteresadoId], [InteraccionInteresadoId])
GO

ALTER TABLE [dbo].[InteraccionesInteresados] CHECK CONSTRAINT [FK_InteraccionesInteresados_InteraccionesInteresados]
GO



