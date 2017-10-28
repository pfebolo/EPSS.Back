:r UseDb.sql
ALTER TABLE dbo.Coordinaciones ADD
	DispositivoID nvarchar(50) NULL
GO
ALTER TABLE dbo.Coordinaciones ADD CONSTRAINT
	FK_Coordinaciones_Dispositivos FOREIGN KEY
	(
	ModoID,
	DispositivoID
	) REFERENCES dbo.Dispositivos
	(
	ModoID,
	DispositivoID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
GO
