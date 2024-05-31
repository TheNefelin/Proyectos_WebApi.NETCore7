
-- Tablas -------------------------------------------------------
-- --------------------------------------------------------------

-- Data ---------------------------------------------------------
-- --------------------------------------------------------------
SET IDENTITY_INSERT F1Paises ON
GO
INSERT INTO F1Paises
	(Id, Nombre, UrlBandera)
VALUES
	(1, 'Finlandia', 'Finlandia.webp'),
	(2, 'China', 'China.webp'),
	(3, 'Francia', 'Francia.webp'),
	(4, 'Austria', 'Austria.webp'),
	(5, 'Japón', 'Japan.webp'),
	(6, 'Canadá', 'Canada.webp'),
	(7, 'España', 'España.webp'),
	(8, 'Mónaco', 'Monaco.webp'),
	(9, 'Dinamarca', 'Dinamarca.webp'),
	(10, 'Alemania', 'Alemania.webp'),
	(11, 'Reino Unido', 'ReinoUnido.webp'),
	(12, 'Australia', 'Australia.webp'),
	(13, 'Bélgica', 'Belgica.webp'),
	(14, 'México', 'Mexico.webp'),
	(15, 'Estados Unidos', 'EstadosUnidos.webp'),
	(16, 'Suiza', 'Suiza.webp'),
	(17, 'Italia ', 'Italia.webp'),
	(18, 'Bahréin', 'Bahrain.webp'),
	(19, 'Arabia Saudita', 'ArabiaSaudita.webp'),
	(20, 'Azerbaiyan', 'Azerbaiyan.webp'),
	(21, 'Hungria', 'Hungria.webp'),
	(22, 'Holanda', 'Holanda.webp'),
	(23, 'Singapore', 'Singapore.webp'),
	(24, 'Qatar', 'Qatar.webp'),
	(25, 'Brazil', 'Brazil.webp'),
	(26, 'AbuDhabi', 'AbuDhabi.webp')
GO
SET IDENTITY_INSERT F1Paises OFF
GO

SET IDENTITY_INSERT F1Escuderias ON
GO
INSERT INTO F1Escuderias
	(Id, Nombre, UrlAuto, IdPais)
VALUES
	(1, 'VCARB', '', 17),
	(2, 'Alpine', '', 3),
	(3, 'Stake F1 Team', '', 16),
	(4, 'Aston Martin', '', 11),
	(5, 'Ferrari', '', 17),
	(6, 'Haas', '', 15),
	(7, 'McLaren', '', 11),
	(8, 'Mercedes', '', 10),
	(9, 'Red Bull', '', 4),
	(10, 'Williams', '', 11)
GO
SET IDENTITY_INSERT F1Escuderias OFF
GO

SET IDENTITY_INSERT F1Pilotos ON
GO
INSERT INTO F1Pilotos
	(Id, Nombre, FechaNaci, Estatura, Peso, Dorsal, UrlPerfil, EstaVivo, Puntos, IdPais, IdEscuderia)
VALUES
	(1, 'Valtteri Bottas', '1989-08-28', 1.73, 70, 77, 'ValtteriBottas.webp', 1, 0, 1, 3),
	(2, 'Guanyu Zhou', '1999-05-30', 1.75, 63, 24, 'GuanyuZhou.webp', 1, 0, 2, 3),
	(3, 'Esteban Ocon', '1996-09-17', 1.86, 66, 31, 'EstebanOcon.webp', 1, 0, 3, 2),
	(4, 'Pierre Gasly', '1996-02-17', 1.77, 70, 10, 'PierreGasly.webp', 1, 0, 3, 2),
	(5, 'Nyck de Vries', '1989-07-01', 1.8, 71, 3, 'NyckDeVries.webp', 1, 0, 4, 1),
	(6, 'Yuki Tsunoda', '2000-05-11', 1.59, 54, 22, 'YukiTsunoda.webp', 1, 0, 5, 1),
	(7, 'Lance Stroll', '1998-10-29', 1.82, 70, 18, 'LanceStroll.webp', 1, 0, 6, 4),
	(8, 'Fernando Alonso', '1981-07-29', 1.71, 68, 14, 'FernandoAlonso.webp', 1, 0, 7, 4),
	(9, 'Charles Leclerc', '1997-10-16', 1.8, 65, 16, 'CharlesLeclerc.webp', 1, 0, 8, 5),
	(10, 'Carlos Sainz', '1994-09-01', 1.77, 66, 55, 'CarlosSainz.webp', 1, 0, 7, 5),
	(11, 'Kevin Magnussen', '1992-10-05', 1.74, 68, 20, 'KevinMagnussen.webp', 1, 0, 9, 6),
	(12, 'Nico Hulkenberg', '1987-08-19', 1.85, 74, 27, 'NicoHulkenberg.webp', 1, 0, 10, 6),
	(13, 'Lando Norris', '1999-11-13', 1.7, 68, 4, 'LandoNorris.webp', 1, 0, 11, 7),
	(14, 'Oscar Piastri', '2001-04-06', 1.78, 68, 81, 'OscarPiastri.webp', 1, 0, 12, 7),
	(15, 'Lewis Hamilton', '1985-01-07', 1.74, 68, 44, 'LewisHamilton.webp', 1, 0, 12, 8),
	(16, 'George Russell', '1998-02-15', 1.85, 70, 63, 'GeorgeRussell.webp', 1, 0, 11, 8),
	(17, 'Max Verstappen', '1997-09-30', 1.8, 67, 1, 'MaxVerstappen.webp', 1, 0, 13, 9),
	(18, 'Sergio Pérez', '1990-01-26', 1.73, 64, 11, 'SergioPerez.webp', 1, 0, 14, 9),
	(19, 'Alexander Albon', '1996-03-23', 1.86, 71, 23, 'AlexanderAlbon.webp', 1, 0, 11, 10),
	(20, 'Logan Sargeant', '2000-12-31', 1.81, 71, 2, 'LoganSargeant.webp', 1, 0, 15, 10)
GO
SET IDENTITY_INSERT F1Pilotos OFF
GO

SET IDENTITY_INSERT F1Circuitos ON
GO
INSERT INTO F1Circuitos
	(Id, Nombre, IdPais)
VALUES
	(1, 'Gulf Air Bahrain GP, Bahrain International Circuit', 18),
	(2, 'STC Saudi Arabian GP, Jeddah Street Circuit', 19),
	(3, 'Rolex Australian GP, Circuito Grand Prix Melbourne', 4),
	(4, 'GP de Azerbaiyán, Baku City Circuit', 20),
	(5, 'Crypto.com Miami GP, Miami International Autodrome', 15),
	(6, 'Made in Italy Emilia Romagna GP, Autodromo Enzo e Dino Ferrari', 17),
	(7, 'GP de Mónaco, Circuit de Monaco', 8),
	(8, 'AWS Spanish GP, Circuit de Barcelona-Catalunya', 7),
	(9, 'Pirelli Canada GP, Circuit Gilles-Villeneuve', 6),
	(10, 'GP de Austria, Red Bull Ring', 12),
	(11, 'Aramco British GP, Silverstone Circuit', 11),
	(12, 'GP de Hungría, Hungaroring', 21),
	(13, 'GP de Bélgica, Circuit de Spa-Francorchamps', 13),
	(14, 'Heineken Dutch GP, Circuit Park Zandvoort', 22),
	(15, 'Pirelli Italian GP, Autodromo Nazionale Monza', 17),
	(16, 'Singapore Airlines Singapore GP, Marina Bay Street Circuit', 23),
	(17, 'Lenovo Japanese GP, Suzuka International Racing Course', 5),
	(18, 'Qatar GP, Losail International Circuit', 24),
	(19, 'Lenovo United States GP, Circuit of the Americas', 15),
	(20, 'Mexico GP, Autodromo Hermanos Rodriguez', 14),
	(21, 'Rolex Brazil GP, Autodromo Jose Carlos Pace', 25),
	(22, 'Heineken Las Vegas GP, Las Vegas Street Circuit', 15),
	(23, 'Etihad Airways Abu Dhabi GP, Yas Marina Circuit', 26)
SET IDENTITY_INSERT F1Circuitos OFF
GO

-- Query --------------------------------------------------------
-- --------------------------------------------------------------
SELECT * FROM F1Carreras
SELECT * FROM F1Pilotos
SELECT * FROM F1Circuitos
SELECT * FROM F1Escuderias
SELECT * FROM F1Paises

--Tabla de Posiciones
SELECT
	a.Nombre AS NomEscuderia,
	c.Nombre AS NomPais,
	c.UrlBandera,
	a.UrlAuto,
	SUM(b.Puntos) AS Puntaje
FROM F1Escuderias a
	INNER JOIN F1Pilotos b ON a.Id = b.IdEscuderia
	INNER JOIN F1Paises c ON a.IdPais = c.Id
GROUP BY
	a.Nombre,
	a.UrlAuto,
	c.Nombre,
	c.UrlBandera
ORDER BY
	SUM(b.Puntos) ASC,
	c.Nombre ASC,
	a.Nombre ASC

--Accidentados, Fallecidos Abandonos
SELECT
	a.Nombre,
	a.EstaVivo
FROM F1Pilotos a
	INNER JOIN F1Paises b ON a.IdPais = b.Id

--Tabla Posiciones
EXECUTE sp_tabla_posiciones

-- --------------------------------------------------------------
-- --------------------------------------------------------------
