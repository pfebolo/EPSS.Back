chcp 65001
rem Borra Tablas

Rem Crea Tablas
sqlcmd -f 65001 -i TablaDispositivos.sql

Rem Datos
sqlcmd -f 65001 -i InsertDatos.1.sql

Rem Modifica Tablas
sqlcmd -f 65001 -i CambioCoordinaciones.sql

Rem Datos
sqlcmd -f 65001 -i InsertDatos.2.sql

Rem Modifica Tablas
sqlcmd -f 65001 -i CambioCoordinaciones.2.sql
