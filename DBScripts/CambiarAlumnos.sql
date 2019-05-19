:r UseDb.sql
USE [escuelapsdelsur]
GO
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Alumnos ADD
	EstaBorrado bit NOT NULL CONSTRAINT DF_Alumnos_EstaBorrado DEFAULT 0
GO
DECLARE @v sql_variant 
SET @v = N'Borrado lógico del registro'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Alumnos', N'COLUMN', N'EstaBorrado'
GO
ALTER TABLE dbo.Alumnos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
