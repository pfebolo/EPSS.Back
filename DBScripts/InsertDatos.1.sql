:r UseDb.sql
BEGIN TRAN
-- Dispositivos
Insert into Dispositivos Values('Presencial','Operativo');
Insert into Dispositivos Values('Presencial','Taller');
Insert into Dispositivos Values('A Distancia','Operativo y Taller');
COMMIT
GO
