# Changelog
Todos los cambios notables del proyecto serán documentados en este archivo.

El formato está basado en la especificación [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
y este proyecto adhiere a [Versionamiento Semántico 2.x.x](http://semver.org/spec/v2.0.0.html).

## [Unreleased]
### Added
- Archivo CHANGELOG.md que se usará para documentar el historial de cambios, basado en el proyecto de código abierto CHANGELOG.

### Fixed
- Se sincroniza tupo de datos del atributo _FechaNacimiento_ de legajos entre la base de datos y la entidad.
- Se corrige la fecha de Nacimiento por Omisión para asignar 1/1/1900 (y no 1/1/0000).
- Se corrige proceso de Rollback cuando una entrada del archivo con los datos de inscripción no puede procesarse, lo cual impedia que se procesaran todos los registros posteriores correctos.

## [0.9.0] - 2017-06-27
### Added
- En la vista de eventos se exponen los eventos pasados, presentes (del día) y futuros con diferentes colores.
- No se permite editar eventos con más de 7 días de vencidos.
- No se permite borrar eventos vencidos.
- No se permite borrar invitados a los eventos, si el evento está vencido.
- No se permite cambiar el estado de asistencia de un interesado, luego de 7 días de vencido el evento.
- No se permite cambiar el estado de asistencia de un interesado, en los eventos futuros.

### Changed
- Se cambia la forma de búsqueda de interesados, permitiendo la búsqueda en el universo completo de datos.
- Se mejora la velocidad de búsqueda de interesados en la vista de interesados.

### Removed
- Se elimina la búsqueda por rango de fechas en la vista de Interesados.

### Fixed
- Se corrige la forma de determinar el tipo de número de teléfono, fijo o Celular, al inscibir a un interesado.

