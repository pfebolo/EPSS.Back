:r UseDb.sql
CREATE TABLE dbo.Dispositivos
	(
	ModoID nvarchar(25) NOT NULL,
	DispositivoID nvarchar(50) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Dispositivos ADD CONSTRAINT
	PK_Dispositivos PRIMARY KEY CLUSTERED 
	(
	ModoID,
	DispositivoID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Dispositivos ADD CONSTRAINT
	FK_Dispositivos_Modos FOREIGN KEY
	(
	ModoID
	) REFERENCES dbo.Modos
	(
	ModoID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
