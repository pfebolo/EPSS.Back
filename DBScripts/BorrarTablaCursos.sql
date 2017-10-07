/*
   sábado, 7 de octubre de 201719:35:21
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
DROP TABLE dbo.Cursos
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Modos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Carreras SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
