
-- CREATE FIELD "AnioLectivo" ----------------------------------
ALTER TABLE [dbo].[Promociones]
ADD [AnioLectivo] INT DEFAULT 1 NOT NULL
GO;
-- -------------------------------------------------------------
select * from promociones
-- CREATE FIELD "nMestreLectivo" -------------------------------
ALTER TABLE [dbo].[Promociones]
ADD [nMestreLectivo] INT DEFAULT 1 NOT NULL
GO;
-- -------------------------------------------------------------

-- CREATE FIELD "MesFinal" -------------------------------------
ALTER TABLE [dbo].[Promociones]
ADD [MesFinal] INT DEFAULT 1 NOT NULL
GO;
-- -------------------------------------------------------------

-- ADD "COMMENT" OF "FIELD "PromocionID" -----------------------
EXEC sys.sp_addextendedproperty @name = N'comment', @value = N'Año Calendario en que se imparte el curso' ,
@level0type = N'SCHEMA', @level0name = 'dbo',
@level1type = N'TABLE', @level1name = 'Promociones',
@level2type = N'COLUMN', @level2name = 'PromocionID';
-- -------------------------------------------------------------

-- ADD "COMMENT" OF "FIELD "CuatrimestreID" -----------------------
EXEC sys.sp_addextendedproperty @name = N'comment', @value = N'Mes calendario en que se comienza a impartir el curso' ,
@level0type = N'SCHEMA', @level0name = 'dbo',
@level1type = N'TABLE', @level1name = 'Promociones',
@level2type = N'COLUMN', @level2name = 'CuatrimestreID';
-- -------------------------------------------------------------

-- ADD "COMMENT" OF "FIELD "MesFinal" -----------------------
EXEC sys.sp_addextendedproperty @name = N'comment', @value = N'Mes calendario en que se termina de impartir el curso' ,
@level0type = N'SCHEMA', @level0name = 'dbo',
@level1type = N'TABLE', @level1name = 'Promociones',
@level2type = N'COLUMN', @level2name = 'MesFinal';
-- -------------------------------------------------------------
