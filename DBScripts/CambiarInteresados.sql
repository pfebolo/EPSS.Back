:r UseDb.sql
BEGIN TRANSACTION
GO
ALTER TABLE dbo.interesados ADD
	FechaActualizacion datetimeoffset(7) NOT NULL CONSTRAINT DF_interesados_FechaActualizacion DEFAULT (getdate())
GO
DECLARE @v sql_variant 
SET @v = N'Fecha de última actualización'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'interesados', N'COLUMN', N'FechaActualizacion'
GO
ALTER TABLE dbo.interesados SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
