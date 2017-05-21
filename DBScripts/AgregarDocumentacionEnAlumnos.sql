/*
   domingo, 21 de mayo de 2017 13:19:53
   Base de datos: escuelapsdelsur
   Aplicación: 
*/

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
ALTER TABLE dbo.alumnos ADD
	FechaInteresadoOriginal date NULL,
	AnioACursar int NULL,
	NMestreACursar int NULL,
	DocTitulo date NULL,
	DocDNI date NULL,
	DocAptoFisico date NULL,
	DocFoto date NULL,
	DocCompromiso date NULL
GO
ALTER TABLE dbo.alumnos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
