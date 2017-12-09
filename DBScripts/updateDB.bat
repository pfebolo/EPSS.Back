chcp 65001
Rem Crea Tablas
sqlcmd -f 65001 -i CrearTablaEstadosEstudiante.sql

Rem Insertar datos
sqlcmd -f 65001 -i InsertarDatos.sql

Rem Modifica Tablas
sqlcmd -f 65001 -i CambiarLegajos.sql



