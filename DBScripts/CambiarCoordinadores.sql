:r UseDb.sql
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Coordinadores ADD
	Activo bit NOT NULL CONSTRAINT DF_Coordinadores_Activo DEFAULT 1
GO
DECLARE @v sql_variant 
SET @v = N'Indica si el coordinador esta activo (puede se arsognado a grupos) o no'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Coordinadores', N'COLUMN', N'Activo'
GO
ALTER TABLE dbo.Coordinadores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
