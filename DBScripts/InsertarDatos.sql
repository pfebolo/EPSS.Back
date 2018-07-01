:r UseDb.sql
BEGIN TRAN
Update Paises Set Nacionalidad='Argentina/o' where PaisId =  'Argentina';

Insert into Paises Values ('México',null,null,null,'Mexicana/o');
Insert into Paises Values ('España',null,null,null,'Español(a)');
Insert into Paises Values ('Cuba',null,null,null,'Cubana/o');
Insert into Paises Values ('Colombia',null,null,null,'Colombiana/o');
Insert into Paises Values ('Perú',null,null,null,'Peruana/o');
Insert into Paises Values ('Venezuela',null,null,null,'Venezolana/o');
Insert into Paises Values ('Bolivia',null,null,null,'Boliviana/o');
Insert into Paises Values ('Ecuador',null,null,null,'Ecuatoriana/o');
Insert into Paises Values ('Chile',null,null,null,'Chilena/o');
Insert into Paises Values ('Uruguay',null,null,null,'Uruguaya/o');
Insert into Paises Values ('Paraguay',null,null,null,'Paraguaya/o');
Insert into Paises Values ('Panama',null,null,null,'Panameña/o');
Insert into Paises Values ('Brasil',null,null,null,'Brasileña/o');

COMMIT
GO
