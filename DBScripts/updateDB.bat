chcp 65001
rem Borra Tablas
sqlcmd -f 65001 -i BorrarTablaEstadosCurso.sql
sqlcmd -f 65001 -i BorrarTablaPromociones.sql
sqlcmd -f 65001 -i BorrarTablaCursos.sql
sqlcmd -f 65001 -i BorrarTablaGrupos.sql
sqlcmd -f 65001 -i BorrarTablaCoordinacion.sql


Rem Crea Tablas
sqlcmd -f 65001 -i CambioCarreras.1.sql
sqlcmd -f 65001 -i TablaEstadosDivision.sql
sqlcmd -f 65001 -i TablaCursos.sql
sqlcmd -f 65001 -i TablaDivisiones.sql
sqlcmd -f 65001 -i TablaGrupos.sql
sqlcmd -f 65001 -i TablaCoordinaciones.sql


Rem Llena Datos Iniciales
sqlcmd -f 65001 -i InsertDatos.1.sql
