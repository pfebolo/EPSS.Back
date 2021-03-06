# Changelog
Todos los cambios notables del proyecto serán documentados en este archivo.

El formato está basado en la especificación [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
y este proyecto adhiere a [Versionamiento Semántico 2.x.x](http://semver.org/spec/v2.0.0.html).

## [Unreleased] - 2017-09-19
### Added
- Se crea API DELETE /alumnos

## [.012] - 2017-08-22
### Added
- Se actualizan versiones de dependencias.
- Se agrega dependencia Serilog.Extensions.Logging.File.
- Se agrega dependencia NETCore.MailKit.
- Se agrega log en archivos de texto .log.
- Se actualiza net core a versión 1.1.0-preview1-005077.
- Se mejora administración de configuración.
- Se agrega configuración de tiempos para la actualización de los datos de cuestionario de inscripción.
- Se agrega envío de e-mail a los inscriptos.
- Se agrega e-mail de bienvenida y completado de cuestionario, configurable, para los inscriptos.
- Se agrega 'ModoTest' pare el envío de e-mails.


## [0.11] - 2017-08-02
### Added
- Se agrega el campo observación a los eventos.
- Se agrega el campo MedioDeContacto a los interesados.

## [0.10.] - 2017-07-12
### Added
- API DELETE /interesados/{id}

## [0.9.1] - 2017-07-05
### Added
- Archivo CHANGELOG.md que se usará para documentar el historial de cambios, basado en el proyecto de código abierto CHANGELOG.
### Fixed
- Se sincroniza el tipo de datos del atributo _FechaNacimiento_ de legajos entre la base de datos y la entidad.
- Se corrige la fecha de Nacimiento por Omisión para asignar 1/1/1900 (y no 1/1/0000).
- Se corrige proceso de Rollback cuando una entrada del archivo con los datos de inscripción no puede procesarse, lo cual impedia que se procesaran todos los registros posteriores correctos.

## [0.9.0] - 2017-06-27
### Added

### Changed

### Removed

### Fixed
