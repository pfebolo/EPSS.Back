chcp 65001
Rem Crea Tablas
sqlcmd -i CambioCarreras.1.sql
sqlcmd -i TablaEstadosDivision.sql
sqlcmd -i TablaCursos.sql
sqlcmd -i TablaDivisiones.sql
sqlcmd -i TablaGrupos.sql
sqlcmd -i TablaCoordinaciones.sql


Rem Llena Datos Iniciales
sqlcmd -i InsertDatos.1.sql
