:r UseDb.sql
CREATE TABLE dbo.Interacciones
	(
	AlumnoID int NOT NULL,
	InteraccionId int NOT NULL,
	Fecha datetime NOT NULL,
	Comentario nvarchar(MAX) NULL,
	PadreID int NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Interacciones ADD CONSTRAINT
	PK_Interacciones PRIMARY KEY CLUSTERED 
	(
	AlumnoID,
	InteraccionId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Interacciones ADD CONSTRAINT
	FK_Interacciones_Legajos FOREIGN KEY
	(
	AlumnoID
	) REFERENCES dbo.Legajos
	(
	AlumnoID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Interacciones ADD CONSTRAINT
	FK_Interacciones_Interacciones FOREIGN KEY
	(
	AlumnoID,
	PadreID
	) REFERENCES dbo.Interacciones
	(
	AlumnoID,
	InteraccionId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Interacciones SET (LOCK_ESCALATION = TABLE)
GO
