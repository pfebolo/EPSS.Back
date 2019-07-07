:r UseDb.sql
Update interesados set FechaActualizacion=TODATETIMEOFFSET(fecha_interesado,-180)
GO
