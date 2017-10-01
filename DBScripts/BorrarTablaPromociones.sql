:r UseDb.sql
ALTER TABLE dbo.Cursos
	DROP CONSTRAINT FK_Cursos_Promociones
GO
DROP TABLE dbo.Promociones
GO
