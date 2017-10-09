:r UseDb.sql
ALTER TABLE [dbo].[alumnos]
ADD [CarreraID] INT DEFAULT '0' NOT NULL
GO;
ALTER TABLE [dbo].[alumnos]
	ADD CONSTRAINT [lnk_Carreras_alumnos]
	FOREIGN KEY ([CarreraID])
	REFERENCES [dbo].[Carreras]( [CarreraID] )
	ON DELETE No Action
	ON UPDATE No Action
GO;
