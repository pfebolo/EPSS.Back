/*
   sábado, 17 de junio de 201721:55:06
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
ALTER TABLE dbo.eventos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.interesados_eventos ADD CONSTRAINT
	FK_interesados_eventos_eventos FOREIGN KEY
	(
	evento_id
	) REFERENCES dbo.eventos
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.interesados_eventos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
