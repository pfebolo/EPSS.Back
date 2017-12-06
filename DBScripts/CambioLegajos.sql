:r UseDb.sql
ALTER TABLE dbo.Legajos ADD
	Seguimiento bit NOT NULL CONSTRAINT DF_Legajos_Seguimiento DEFAULT 0
GO
DECLARE @v sql_variant 
SET @v = N'Marca que indica que el estudiante tiene algún pendiente'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Legajos', N'COLUMN', N'Seguimiento'
GO

