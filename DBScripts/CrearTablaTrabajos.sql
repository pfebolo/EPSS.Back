/* Para evitar posibles problemas de pérdida de datos, debe revisar este script detalladamente antes de ejecutarlo fuera del contexto del diseñador de base de datos.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Legajos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Trabajos
	(
	AlumnoID int NOT NULL,
	TrabajoID int NOT NULL,
	RazonSocial varchar(255) NULL,
	Cargo varchar(255) NULL,
	Antiguedad varchar(255) NULL,
	Telefono varchar(255) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Trabajos ADD CONSTRAINT
	PK_Trabajos PRIMARY KEY CLUSTERED 
	(
	AlumnoID,
	TrabajoID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Trabajos ADD CONSTRAINT
	FK_Trabajos_Legajos FOREIGN KEY
	(
	AlumnoID
	) REFERENCES dbo.Legajos
	(
	AlumnoID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Trabajos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT