:r UseDb.sql
BEGIN TRAN
-- Dispositivos
Insert into EstadosEstudiante Values('Inscripto',0);
Insert into EstadosEstudiante Values('Cursando',1);
Insert into EstadosEstudiante Values('Egresado',0);
Insert into EstadosEstudiante Values('Suspendido por pago atrasado',0);
Insert into EstadosEstudiante Values('Suspendido por razón académica.',0);
Insert into EstadosEstudiante Values('Abandonó',0);
Insert into EstadosEstudiante Values('Expulsado',0);
COMMIT
GO


