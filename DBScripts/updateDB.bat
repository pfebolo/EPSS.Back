chcp 65001
Rem Crea Tablas
sqlcmd -f 65001 -i CambioCarreras.1.sql
sqlcmd -f 65001 -i TablaEstadosDivision.sql
sqlcmd -f 65001 -i TablaCursos.sql
sqlcmd -f 65001 -i TablaDivisiones.sql
sqlcmd -f 65001 -i TablaGrupos.sql
sqlcmd -f 65001 -i TablaCoordinaciones.sql


Rem Llena Datos Iniciales
sqlcmd -f 65001 -i InsertDatos.1.sql
