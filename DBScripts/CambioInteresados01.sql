/*
   lunes, 5 de junio de 2017 20:53:09
   Base de datos: escuelapsdelsur
   Aplicación: EPSS
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
ALTER TABLE dbo.interesados ADD
	CarreraID int NULL,
	AnioACursar int NULL,
	NMestreACursar int NULL,
	Turno varchar(6) NULL,
	Seguimiento bit NOT NULL CONSTRAINT DF_interesados_Seguimiento DEFAULT 0
GO
ALTER TABLE dbo.interesados SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
