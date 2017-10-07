:r UseDb.sql
CREATE TABLE dbo.Coordinaciones
	(
	CarreraID int NOT NULL,
	ModoID nvarchar(25) NOT NULL,
	CursoID int NOT NULL,
	TurnoID nvarchar(25) NOT NULL,
	DivisionID nvarchar(2) NOT NULL,
	CoordinadorID int NOT NULL,
	Comentario nvarchar(255) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Coordinaciones ADD CONSTRAINT
	PK_Coordinaciones PRIMARY KEY CLUSTERED 
	(
	CarreraID,
	ModoID,
	CursoID,
	TurnoID,
	DivisionID,
	CoordinadorID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Coordinaciones ADD CONSTRAINT
	FK_Coordinaciones_Divisiones FOREIGN KEY
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
ALTER TABLE dbo.Coordinaciones ADD CONSTRAINT
	FK_Coordinaciones_Coordinadores FOREIGN KEY
	(
	CoordinadorID
	) REFERENCES dbo.Coordinadores
	(
	CoordinadorID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
