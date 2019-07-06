﻿:r UseDb.sql
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Coordinadores
	DROP CONSTRAINT DF_Coordinadores_Activo
GO
CREATE TABLE dbo.Tmp_Coordinadores
	(
	CoordinadorID int NOT NULL IDENTITY (1, 1),
	Nombre nvarchar(255) NOT NULL,
	FotoPath nvarchar(MAX) NULL,
	TelefonoFijo decimal(10, 0) NULL,
	TelefonoCelular decimal(10, 0) NULL,
	Email nvarchar(255) NULL,
	Comentarios nvarchar(255) NULL,
	Activo bit NOT NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Coordinadores SET (LOCK_ESCALATION = TABLE)
GO
DECLARE @v sql_variant 
SET @v = N'Identificador univoco del coordinador'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Coordinadores', N'COLUMN', N'CoordinadorID'
GO
DECLARE @v sql_variant 
SET @v = N'Indica si el coordinador esta activo (puede se arsognado a grupos) o no'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Coordinadores', N'COLUMN', N'Activo'
GO
ALTER TABLE dbo.Tmp_Coordinadores ADD CONSTRAINT
	DF_Coordinadores_Activo DEFAULT ((1)) FOR Activo
GO
SET IDENTITY_INSERT dbo.Tmp_Coordinadores ON
GO
IF EXISTS(SELECT * FROM dbo.Coordinadores)
	 EXEC('INSERT INTO dbo.Tmp_Coordinadores (CoordinadorID, Nombre, FotoPath, TelefonoFijo, TelefonoCelular, Email, Comentarios, Activo)
		SELECT CoordinadorID, Nombre, FotoPath, TelefonoFijo, TelefonoCelular, Email, Comentarios, Activo FROM dbo.Coordinadores WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Coordinadores OFF
GO
ALTER TABLE dbo.Coordinaciones
	DROP CONSTRAINT FK_Coordinaciones_Coordinadores
GO
DROP TABLE dbo.Coordinadores
GO
EXECUTE sp_rename N'dbo.Tmp_Coordinadores', N'Coordinadores', 'OBJECT' 
GO
ALTER TABLE dbo.Coordinadores ADD CONSTRAINT
	PK_Coordinadores PRIMARY KEY CLUSTERED 
	(
	CoordinadorID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Coordinaciones ADD CONSTRAINT
	FK_Coordinaciones_Coordinadores FOREIGN KEY
	(
	CoordinadorID
	) REFERENCES dbo.Coordinadores
	(
	CoordinadorID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Coordinaciones SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
