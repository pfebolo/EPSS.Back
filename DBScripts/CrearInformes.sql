:r UseDb.sql
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
ALTER TABLE dbo.Legajos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Coordinadores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Informes
	(
	AlumnoID int NOT NULL,
	InformeID int NOT NULL,
	AnioLectivo smallint NOT NULL,
	CoordinadorID int NOT NULL,
	Informe nvarchar(MAX) NOT NULL,
	FechaCreacion datetimeoffset(7) NOT NULL,
	FechaActualizacion datetimeoffset(7) NOT NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'Año lectivo que el estudiante cursaba al momento del informe'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Informes', N'COLUMN', N'AnioLectivo'
GO
DECLARE @v sql_variant 
SET @v = N'Informe propiamente dicho'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Informes', N'COLUMN', N'Informe'
GO
ALTER TABLE dbo.Informes ADD CONSTRAINT
	DF_Informes_AnioLectivo DEFAULT 1 FOR AnioLectivo
GO
ALTER TABLE dbo.Informes ADD CONSTRAINT
	PK_Informes PRIMARY KEY CLUSTERED 
	(
	AlumnoID,
	InformeID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Informes ADD CONSTRAINT
	FK_Informes_Legajos FOREIGN KEY
	(
	AlumnoID
	) REFERENCES dbo.Legajos
	(
	AlumnoID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Informes ADD CONSTRAINT
	FK_Informes_Coordinadores FOREIGN KEY
	(
	CoordinadorID
	) REFERENCES dbo.Coordinadores
	(
	CoordinadorID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Informes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
