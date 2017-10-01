:r UseDb.sql
ALTER TABLE dbo.Coordinacion
	DROP CONSTRAINT FK_Coordinacion_Cursos
GO
ALTER TABLE dbo.Grupos
	DROP CONSTRAINT FK_Grupos_Cursos
GO
DROP TABLE dbo.Cursos
GO
