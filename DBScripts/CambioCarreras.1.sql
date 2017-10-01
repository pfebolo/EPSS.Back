:r UseDb.sql
CREATE TABLE dbo.Tmp_Carreras
	(
	CarreraID int NOT NULL,
	Descripcion nvarchar(255) NOT NULL,
	Resolucion nvarchar(255) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Carreras SET (LOCK_ESCALATION = TABLE)
GO
IF EXISTS(SELECT * FROM dbo.Carreras)
	 EXEC('INSERT INTO dbo.Tmp_Carreras (CarreraID, Descripcion)
		SELECT CarreraID, CONVERT(nvarchar(255), Descripcion) FROM dbo.Carreras WITH (HOLDLOCK TABLOCKX)')
GO
ALTER TABLE dbo.interesados
	DROP CONSTRAINT FK_interesados_Carreras
GO
DROP TABLE dbo.Carreras
GO
EXECUTE sp_rename N'dbo.Tmp_Carreras', N'Carreras', 'OBJECT' 
GO
ALTER TABLE dbo.Carreras ADD CONSTRAINT
	PK_Carreras PRIMARY KEY CLUSTERED 
	(
	CarreraID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.interesados ADD CONSTRAINT
	FK_interesados_Carreras FOREIGN KEY
	(
	CarreraID
	) REFERENCES dbo.Carreras
	(
	CarreraID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.interesados SET (LOCK_ESCALATION = TABLE)
GO