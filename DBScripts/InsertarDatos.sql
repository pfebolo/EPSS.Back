:r UseDb.sql
BEGIN TRAN
-- Dispositivos
Insert into EstadosEstudiante Values('Activo',1);
Insert into EstadosEstudiante Values('Egresado',0);
Insert into EstadosEstudiante Values('Suspendido',0);
Insert into EstadosEstudiante Values('Abandonó',0);
Insert into EstadosEstudiante Values('Expulsado',0);
COMMIT
GO


