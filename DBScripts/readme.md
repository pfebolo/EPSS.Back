# Normas uso de carpeta

# General
* Verbos en infinitivo
* Tipo de nomenclatura: Pascal
* Codificación de archivos: UTF-8 (sin BOM)
  * Cuidado: EL MS SQL Server Management Studio lo graba en UTF-16, es necesario convertir luego a la codificación definida.

## Nomenclatura Archivos

* Nueva tabla: Crear[_Nombre de Tabla_].sql
* Actualizacion tabla: Cambiar[_Nombre de Tabla_].sql
* Borrar una tabla: Borrar[_Nombre de Tabla_].sql
* Actualizar datos:
  * Un único archivo: ActualizarDatos.sql
  * Dos o mas archivos: ActualizarDatos[_XX_].sql  --> _XX_ sequencia desde 01 a 99