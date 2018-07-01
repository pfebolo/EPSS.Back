:r UseDb.sql
ALTER TABLE dbo.Paises ADD
	Nacionalidad nvarchar(50) NULL
GO
ALTER TABLE dbo.Paises SET (LOCK_ESCALATION = TABLE)
GO
