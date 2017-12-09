:r UseDb.sql
ALTER TABLE dbo.Legajos ADD
	Seguimiento bit NOT NULL CONSTRAINT DF_Legajos_Seguimiento DEFAULT 0
GO
DECLARE @v sql_variant 
SET @v = N'Marca que indica que el estudiante tiene algún pendiente'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Legajos', N'COLUMN', N'Seguimiento'
GO
ALTER TABLE dbo.Legajos ADD
	EstadoEstudianteID nvarchar(255) NOT NULL CONSTRAINT DF_Legajos_EstadoEstudianteID DEFAULT N'Inscripto'
GO
DECLARE @v sql_variant 
SET @v = N'Estado del Estudiante'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Legajos', N'COLUMN', N'EstadoEstudianteID'
GO
ALTER TABLE dbo.Legajos ADD CONSTRAINT
	FK_Legajos_EstadosEstudiante FOREIGN KEY
	(
	EstadoEstudianteID
	) REFERENCES dbo.EstadosEstudiante
	(
	EstadoEstudianteID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
GO
DECLARE @v sql_variant 
SET @v = N'Asegura que el valor de estado sea válido'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Legajos', N'CONSTRAINT', N'FK_Legajos_EstadosEstudiante'
GO


