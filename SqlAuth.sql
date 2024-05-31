DROP TABLE __EFMigrationsHistory

DROP TABLE F1Carreras
DROP TABLE F1Pilotos
DROP TABLE F1Circuitos
DROP TABLE F1Escuderias
DROP TABLE F1Paises

DROP TABLE GJAventurasImg
DROP TABLE GJAventurasUsuario
DROP TABLE GJAventuras
DROP TABLE GJGuiasUsuario
DROP TABLE GJGuias
DROP TABLE GJFondosImg
DROP TABLE GJFuentes
DROP TABLE GJPersonajes
DROP TABLE GJJuegos

DROP TABLE AuthUsuario
DROP TABLE AuthPerfil

DROP TABLE PassCore
DROP TABLE PassPlataforma

-- Tablas -------------------------------------------------------
-- --------------------------------------------------------------

-- Data ---------------------------------------------------------
-- --------------------------------------------------------------
SET IDENTITY_INSERT AuthPerfil ON
GO
INSERT INTO AuthPerfil
	(Id, Nombre)
VALUES
	(1, 'Admin'),
	(2, 'Usuario')
SET IDENTITY_INSERT AuthPerfil OFF
GO

-- Query --------------------------------------------------------
-- --------------------------------------------------------------
SELECT * FROM AuthPerfil
SELECT * FROM AuthUsuario

SELECT NEWID()


-- --------------------------------------------------------------
-- --------------------------------------------------------------
