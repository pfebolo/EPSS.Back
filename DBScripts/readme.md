# Normas uso de carpeta

## General

* Verbos en infinitivo
* Tipo de nomenclatura: Pascal
* Codificación de archivos: UTF-8 (sin BOM)
  * Cuidado: EL MS SQL Server Management Studio graba los archivos con codificación UTF-16, es necesario convertirlos a la codificación definida, preferentemente antes de 'commitearlos'

## Nomenclatura Archivos

* Nueva tabla: Crear[_Nombre de Tabla_].sql
* Actualizacion tabla: Cambiar[_Nombre de Tabla_].sql
* Borrar una tabla: Borrar[_Nombre de Tabla_].sql
* Actualizar datos:
  * Un único archivo: ActualizarDatos.sql
  * Dos o mas archivos: ActualizarDatos[_XX_].sql  --> _XX_ sequencia desde 01 a 99

---

> Mejorar Proceso usando DAC pack 
> ref: <https://docs.microsoft.com/en-us/sql/tools/sqlpackage?view=sql-server-ver15>
