:r UseDb.sql
ALTER TABLE dbo.Cursos
	DROP CONSTRAINT FK_Cursos_EstadosCurso
GO
DROP TABLE dbo.EstadosCurso
GO
