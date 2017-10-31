:r UseDb.sql
BEGIN TRAN
-- Coordinaciones
update Coordinaciones set DispositivoID='Operativo y Taller' where ModoID='A Distancia';

update Coordinaciones set DispositivoID='Operativo'  from Coordinaciones C,
(Select CarreraID,ModoID,AnioInicio,MesInicio,AnioLectivo,NMestreLectivo,TurnoID,DivisionID, MIN(CoordinadorID) CoordID 
 from Coordinaciones where ModoID='Presencial'
group by CarreraID,ModoID,AnioInicio,MesInicio,AnioLectivo,NMestreLectivo,TurnoID,DivisionID) C2
where c.CarreraID = c2.CarreraID and
c.ModoID = c2.ModoID and
c.AnioInicio = c2.AnioInicio and
c.MesInicio = c2.MesInicio and
c.AnioLectivo = c2.AnioLectivo and
c.NMestreLectivo = c2.NMestreLectivo and
c.TurnoID = c2.TurnoID and
c.DivisionID = c2.DivisionID and
c.CoordinadorID = c2.CoordID;

update Coordinaciones set DispositivoID='Taller'  from Coordinaciones C,
(Select CarreraID,ModoID,AnioInicio,MesInicio,AnioLectivo,NMestreLectivo,TurnoID,DivisionID, MAX(CoordinadorID) CoordID 
 from Coordinaciones where ModoID='Presencial'
group by CarreraID,ModoID,AnioInicio,MesInicio,AnioLectivo,NMestreLectivo,TurnoID,DivisionID) C2
where c.CarreraID = c2.CarreraID and
c.ModoID = c2.ModoID and
c.AnioInicio = c2.AnioInicio and
c.MesInicio = c2.MesInicio and
c.AnioLectivo = c2.AnioLectivo and
c.NMestreLectivo = c2.NMestreLectivo and
c.TurnoID = c2.TurnoID and
c.DivisionID = c2.DivisionID and
c.CoordinadorID = c2.CoordID and
c.DispositivoID is Null;

COMMIT
GO
