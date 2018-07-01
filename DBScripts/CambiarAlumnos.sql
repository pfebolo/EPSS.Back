:r UseDb.sql
ALTER TABLE dbo.alumnos ADD
	NacionalidadId nvarchar(50) NOT NULL CONSTRAINT DF_alumnos_NacionalidadId DEFAULT N'Argentina'
GO
DECLARE @v sql_variant 
SET @v = N'Nacionalidad del Estudiante'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'alumnos', N'COLUMN', N'NacionalidadId'
GO
ALTER TABLE dbo.alumnos ADD CONSTRAINT
	FK_alumnos_Paises FOREIGN KEY
	(
	NacionalidadId
	) REFERENCES dbo.Paises
	(
	PaisID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.alumnos SET (LOCK_ESCALATION = TABLE)
GO

