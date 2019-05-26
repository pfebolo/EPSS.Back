chcp 65001
Rem Agrega campo FechaActualizacion
sqlcmd -f 65001 -i CambiarInteresados.sql
Rem Agrega campo Activo
sqlcmd -f 65001 -i CambiarCoordinadores.sql


Rem Inicializa campo FechaActualizacion
sqlcmd -f 65001 -i ActualizarDatos.sql

