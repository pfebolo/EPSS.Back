:r UseDb.sql
CREATE TABLE dbo.Cursos
	(
	CarreraID int NOT NULL,
	ModoID nvarchar(25) NOT NULL,
	AnioInicio int NOT NULL,
	MesInicio int NOT NULL,
	MesFinal int NOT NULL,
	AnioLectivo int NOT NULL,
	NMestreLectivo int NOT NULL,
	Comentario nvarchar(255) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Cursos ADD CONSTRAINT
	PK_Cursos PRIMARY KEY CLUSTERED 
	(
	CarreraID,
	ModoID,
	AnioInicio,
	MesInicio,
	AnioLectivo,
	NMestreLectivo
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Cursos ADD CONSTRAINT
	FK_Cursos_Carreras FOREIGN KEY
	(
	CarreraID
	) REFERENCES dbo.Carreras
	(
	CarreraID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Cursos ADD CONSTRAINT
	FK_Cursos_Modos FOREIGN KEY
	(
	ModoID
	) REFERENCES dbo.Modos
	(
	ModoID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO

