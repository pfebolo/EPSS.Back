:r UseDb.sql
CREATE TABLE dbo.EstadosDivision
	(
	EstadoDivisionID nvarchar(25) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.EstadosDivision ADD CONSTRAINT
	PK_EstadosDivision PRIMARY KEY CLUSTERED 
	(
	EstadoDivisionID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
