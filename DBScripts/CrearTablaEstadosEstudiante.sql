:r UseDb.sql
CREATE TABLE dbo.EstadosEstudiante
	(
	EstadoEstudianteID nvarchar(255) NOT NULL,
	ActaVolante bit NOT NULL
	)  ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'Contiene los Estados que un estudiante puede tener en su ciclo de Vida'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'EstadosEstudiante', NULL, NULL
GO
DECLARE @v sql_variant 
SET @v = N'Indica si un estudiante con este estado se incorpora (o no) asl Acta Volante'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'EstadosEstudiante', N'COLUMN', N'ActaVolante'
GO
ALTER TABLE dbo.EstadosEstudiante ADD CONSTRAINT
	DF_EstadosEstudiante_ActaVolante DEFAULT 0 FOR ActaVolante
GO
ALTER TABLE dbo.EstadosEstudiante ADD CONSTRAINT
	PK_EstadosEstudiante PRIMARY KEY CLUSTERED 
	(
	EstadoEstudianteID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
