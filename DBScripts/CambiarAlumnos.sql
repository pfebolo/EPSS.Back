:r UseDb.sql
ALTER TABLE dbo.alumnos ADD
	MedioDeContactoId int NULL
GO
DECLARE @v sql_variant 
SET @v = N'Indica el medio de contacto que uso el estudiante al interesarse por la Escuela'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'alumnos', N'COLUMN', N'MedioDeContactoId'
GO
ALTER TABLE dbo.alumnos ADD CONSTRAINT
	FK_alumnos_MediosDeContacto FOREIGN KEY
	(
	MedioDeContactoId
	) REFERENCES dbo.MediosDeContacto
	(
	medioDeContactoId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
DECLARE @v sql_variant 
SET @v = N'Asegura la validez del Medio de Contacto'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'alumnos', N'CONSTRAINT', N'FK_alumnos_MediosDeContacto'
GO
