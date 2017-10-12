:r UseDb.sql

-- CREATE FIELD "LibroMatriz" ----------------------------------
ALTER TABLE [dbo].[Legajos]
ADD [LibroMatriz] INT NULL
GO;
-- -------------------------------------------------------------

-- CREATE FIELD "Folio" ----------------------------------------
ALTER TABLE [dbo].[Legajos]
ADD [Folio] INT NULL
GO;
-- -------------------------------------------------------------

