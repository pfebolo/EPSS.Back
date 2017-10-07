chcp 65001
rem Borra Tablas
sqlcmd -f 65001 -i BorrarTablaGrupos.sql
sqlcmd -f 65001 -i BorrarTablaCoordinaciones.sql
sqlcmd -f 65001 -i BorrarTablaDivisiones.sql
sqlcmd -f 65001 -i BorrarTablaCursos.sql



Rem Crea Tablas
sqlcmd -f 65001 -i TablaCursos.sql
sqlcmd -f 65001 -i TablaDivisiones.sql
sqlcmd -f 65001 -i TablaCoordinaciones.sql
sqlcmd -f 65001 -i TablaGrupos.sql


Rem Llena Datos Iniciales
sqlcmd -f 65001 -i InsertDatos.1.sql
