/*
   sábado, 13 de mayo de 201719:39:37
   Base de datos: escuelapsdelsur
   Aplicación: EPSS
*/

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
ALTER TABLE dbo.Legajos
	DROP CONSTRAINT FK_Legajos_Localidades
GO
ALTER TABLE dbo.Localidades SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Legajos
	DROP CONSTRAINT FK_Legajos_alumnos
GO
ALTER TABLE dbo.alumnos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_Legajos
	(
	AlumnoID int NOT NULL,
	LegajoNro int NOT NULL,
	Sexo char(9) NOT NULL,
	FechaNacimiento smalldatetime NULL,
	LugarNacimiento nvarchar(50) NULL,
	DNI int NOT NULL,
	CUIT decimal(11, 0) NULL,
	DireccionCalle nvarchar(255),
	DireccionNro nvarchar(255),
	DireccionCoordenadaInterna nvarchar(255) NULL,
	DireccionLocalidadID int NULL,
	DireccionPartidoID int NULL,
	DireccionProvinciaID nvarchar(50) NULL,
	DireccionPaisID nvarchar(50) NULL,
	SecundarioCompletoOLey25 bit NULL,
	Comentarios nvarchar(255) NULL,
	CodigoPostalBase int NULL,
	LocalidadBase nvarchar(255) NULL,
	FechaIngreso datetime NULL,
	PagoIniFecha datetime NULL,
	PagoIniMonto varchar(50) NULL,
	ModalidadBase nvarchar(50) NULL,
	Turno nvarchar(50) NULL,
	Cuestionario datetime NULL,
	DocAptoFisico datetime NULL,
	DocTitulo datetime NULL,
	DocDNI datetime NULL,
	DocFoto datetime NULL,
	DocCompromiso datetime NULL,
	DocAptoFisicoValido datetime NULL,
	DocTituloValido datetime NULL,
	DocDNIValido datetime NULL,
	DocFotoValido datetime NULL,
	PathFoto nvarchar(1024) NULL,
	Historia varchar(8000) NULL,
	Definicion varchar(8000) NULL,
	Situacion varchar(8000) NULL,
	Expectativas varchar(8000) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Legajos SET (LOCK_ESCALATION = TABLE)
GO
DECLARE @v sql_variant 
SET @v = N'Id de la tabla Alumnos'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Legajos', N'COLUMN', N'AlumnoID'
GO
DECLARE @v sql_variant 
SET @v = N'Nro de Legajo Asignado'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Legajos', N'COLUMN', N'LegajoNro'
GO
IF EXISTS(SELECT * FROM dbo.Legajos)
	 EXEC('INSERT INTO dbo.Tmp_Legajos (AlumnoID, LegajoNro, Sexo, FechaNacimiento, LugarNacimiento, DNI, CUIT, DireccionCalle, DireccionNro, DireccionCoordenadaInterna, DireccionLocalidadID, DireccionPartidoID, DireccionProvinciaID, DireccionPaisID, SecundarioCompletoOLey25, Comentarios, CodigoPostalBase, LocalidadBase, FechaIngreso, PagoIniFecha, PagoIniMonto, ModalidadBase, Turno, Cuestionario, DocAptoFisico, DocTitulo, DocDNI, DocFoto, Historia, Definicion, Situacion, Expectativas)
		SELECT AlumnoID, LegajoNro, Sexo, FechaNacimiento, LugarNacimiento, DNI, CUIT, DireccionCalle, DireccionNro, DireccionCoordenadaInterna, DireccionLocalidadID, DireccionPartidoID, DireccionProvinciaID, DireccionPaisID, SecundarioCompletoOLey25, Comentarios, CodigoPostalBase, LocalidadBase, FechaIngreso, PagoIniFecha, PagoIniMonto, ModalidadBase, Turno, Cuestionario, DocAptoFisico, DocTitulo, DocDNI, DocFoto, Historia, Definicion, Situacion, Expectativas FROM dbo.Legajos WITH (HOLDLOCK TABLOCKX)')
GO
ALTER TABLE dbo.Trabajos
	DROP CONSTRAINT FK_Trabajos_Legajos
GO
ALTER TABLE dbo.Estudios
	DROP CONSTRAINT FK_Estudios_Legajos
GO
ALTER TABLE dbo.Grupos
	DROP CONSTRAINT FK_Grupos_Legajos
GO
DROP TABLE dbo.Legajos
GO
EXECUTE sp_rename N'dbo.Tmp_Legajos', N'Legajos', 'OBJECT' 
GO
ALTER TABLE dbo.Legajos ADD CONSTRAINT
	PK_Legajos PRIMARY KEY CLUSTERED 
	(
	AlumnoID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
CREATE UNIQUE NONCLUSTERED INDEX IX_Legajos ON dbo.Legajos
	(
	LegajoNro
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_Localidad ON dbo.Legajos
	(
	DireccionLocalidadID,
	DireccionPartidoID,
	DireccionProvinciaID,
	DireccionPaisID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE dbo.Legajos ADD CONSTRAINT
	FK_Legajos_alumnos FOREIGN KEY
	(
	AlumnoID
	) REFERENCES dbo.alumnos
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Legajos ADD CONSTRAINT
	FK_Legajos_Localidades FOREIGN KEY
	(
	DireccionPaisID,
	DireccionProvinciaID,
	DireccionPartidoID,
	DireccionLocalidadID
	) REFERENCES dbo.Localidades
	(
	PaisID,
	ProvinciaID,
	PartidoD,
	LocalidadID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Grupos ADD CONSTRAINT
	FK_Grupos_Legajos FOREIGN KEY
	(
	AlumnoID
	) REFERENCES dbo.Legajos
	(
	AlumnoID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Grupos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Estudios ADD CONSTRAINT
	FK_Estudios_Legajos FOREIGN KEY
	(
	AlumnoID
	) REFERENCES dbo.Legajos
	(
	AlumnoID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Estudios SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
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
