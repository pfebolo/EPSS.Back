:r UseDb.sql
CREATE TABLE dbo.GruposXXX
	(
	CarreraID int NOT NULL,
	ModoID nvarchar(25) NOT NULL,
	CursoID int NOT NULL,
	TurnoID nvarchar(25) NOT NULL,
	DivisionID int NOT NULL,
	AlumnoID int NOT NULL,
	Comentario nvarchar(255) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.GruposXXX ADD CONSTRAINT
	PK_GruposXXX PRIMARY KEY CLUSTERED 
	(
	CarreraID,
	ModoID,
	CursoID,
	TurnoID,
	DivisionID,
	AlumnoID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.GruposXXX ADD CONSTRAINT
	FK_Grupos_Divisiones FOREIGN KEY
	(
	CarreraID,
	ModoID,
	CursoID,
	TurnoID,
	DivisionID
	) REFERENCES dbo.Divisiones
	(
	CarreraID,
	ModoID,
	CursoID,
	TurnoID,
	DivisionID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.GruposXXX ADD CONSTRAINT
	FK_Grupos_Legajos FOREIGN KEY
	(
	AlumnoID
	) REFERENCES dbo.Legajos
	(
	AlumnoID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
