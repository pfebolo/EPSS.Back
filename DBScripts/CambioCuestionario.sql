/*
   sábado, 29 de abril de 201711:05:43
   Usuario: sa
   Servidor: 192.168.1.41
   Base de datos: escuelapsdelsur
   Aplicación: 
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
ALTER TABLE dbo.Legajos ADD
	Historia varchar(8000) NULL,
	Definicion varchar(8000) NULL,
	Situacion varchar(8000) NULL,
	Expectativas varchar(8000) NULL
GO
ALTER TABLE dbo.Legajos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
