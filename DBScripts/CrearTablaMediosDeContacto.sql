/*
   Base de datos: escuelapsdelsur
   Aplicación: 
*/

/****** Object:  Table [dbo].[MediosDeContacto] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MediosDeContacto](
	[medioDeContactoId] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](500) NULL,
 CONSTRAINT [PK_medios_contacto] PRIMARY KEY CLUSTERED 
(
	[medioDeContactoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
Insert Into [dbo].[MediosDeContacto](nombre) VALUES ('Acaula')
GO
Insert Into [dbo].[MediosDeContacto](nombre) VALUES ('BuscoUniversidad')
GO
Insert Into [dbo].[MediosDeContacto](nombre) VALUES ('Zopin')
GO
Insert Into [dbo].[MediosDeContacto](nombre) VALUES ('E-Mail')
GO
Insert Into [dbo].[MediosDeContacto](nombre) VALUES ('FaceBook')
GO
Insert Into [dbo].[MediosDeContacto](nombre) VALUES ('Web')
GO
Insert Into [dbo].[MediosDeContacto](nombre) VALUES ('Guía del Estudiante')
GO
Insert Into [dbo].[MediosDeContacto](nombre) VALUES ('Goolge+')
GO
Insert Into [dbo].[MediosDeContacto](nombre) VALUES ('Presencial')
GO
Insert Into [dbo].[MediosDeContacto](nombre) VALUES ('Teléfono')
GO
Insert Into [dbo].[MediosDeContacto](nombre) VALUES ('Whastapp')
GO
Insert Into [dbo].[MediosDeContacto](nombre) VALUES ('Otro')
GO
