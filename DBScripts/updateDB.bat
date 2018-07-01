chcp 65001
Rem Modifica  Tablas
sqlcmd -f 65001 -i CambiarPaises.sql
sqlcmd -f 65001 -i CambiarAlumnos.sql


Rem Insertar Naciones
sqlcmd -f 65001 -i InsertarDatos.sql

