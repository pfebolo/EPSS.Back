:r UseDb.sql
:On Error exit
BEGIN TRAN
-- Cursos
Insert into Cursos Values(0,'Presencial',2017,8,12,3,1,'3ro1c');
Insert into Cursos Values(0,'A Distancia',2017,8,12,2,2,'2do2c');

-- Divisiones
Insert into Divisiones Values(0,'Presencial',2017,8,3,1,'Noche','A','Cursando','');
Insert into Divisiones Values(0,'A Distancia',2017,8,2,2,'Virtual','E','Cursando','');

-- Grupos
Insert into Grupos 
Select 0,'Presencial',2017,8,3,1,'Noche','A',AlumnoId,'' from Legajos where LegajoNro in (
'4194','4234','4238','4221','1868','4203','4170','4193','4092','4338','4279',
'4042','4196','4343','4251','4191','4199','4269','4331','4264','4278','4185',
'4210');
Insert into Grupos 
Select 0,'A Distancia',2017,8,2,2,'Virtual','E',AlumnoId,'' from Legajos where LegajoNro in (
'4410','4356','4545','4619','4474','4483','4459','4503','2829','4584','4502',
'4553','4550','4463','4369','4467','4605','4510');

-- Coordinaciones
Insert into Coordinaciones
Select 0,'Presencial',2017,8,3,1,'Noche','A',CoordinadorId,'' from Coordinadores where CoordinadorID in (1,3)
Insert into Coordinaciones
Select 0,'A Distancia',2017,8,2,2,'Virtual','E',CoordinadorId,'' from Coordinadores where CoordinadorID in (1,3)
GO
Update Modalidades Set nombre = 'Presencial' where id=1;
Update Modalidades Set nombre = 'A Distancia' where id=2;
GO
COMMIT
GO
