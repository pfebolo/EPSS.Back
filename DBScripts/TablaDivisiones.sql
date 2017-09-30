:r UseDb.sql
CREATE TABLE dbo.Divisiones
	(
	CarreraID int NOT NULL,
	ModoID nvarchar(25) NOT NULL,
	CursoID int NOT NULL,
	TurnoID  nvarchar(25) NOT NULL,
	DivisionID nvarchar(2) NOT NULL,
	EstadoCursoID nvarchar(25) NOT NULL,
	Comentario nvarchar(255) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Divisiones ADD CONSTRAINT
	PK_Divisiones PRIMARY KEY CLUSTERED 
	(
	CarreraID,
	ModoID,
	CursoID,
	TurnoID,
	DivisionID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Divisiones ADD CONSTRAINT
	FK_Divisiones_CursosXXX FOREIGN KEY
	(
	CarreraID,
	ModoID,
	CursoID
	) REFERENCES dbo.CursosXXX
	(
	CarreraID,
	ModoID,
	CursoID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Divisiones ADD CONSTRAINT
	FK_Divisiones_EstadosCurso FOREIGN KEY
	(
	EstadoCursoID
	) REFERENCES dbo.EstadosCursoXXX
	(
	EstadoCursoID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Divisiones ADD CONSTRAINT
	FK_Divisiones_Turnos FOREIGN KEY
	(
	TurnoID
	) REFERENCES dbo.Turnos
	(
	TurnoID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
