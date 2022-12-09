CREATE DATABASE JGonzalezPruebaTecnica

CREATE TABLE Autor(
	IdAutor INT PRIMARY KEY IDENTITY(1,1),
	Nombre VARCHAR(50)
)

INSERT INTO Autor (Nombre) VALUES ('Juan Alberto Gonzalez')
INSERT INTO Autor (Nombre) VALUES ('Leonardo Escogido')
INSERT INTO Autor (Nombre) VALUES ('Isaac Espinoza')
INSERT INTO Autor (Nombre) VALUES ('Uriel Tapia')
INSERT INTO Autor (Nombre) VALUES ('Francisco Gutierrez')

SELECT * FROM Autor

CREATE TABLE Editorial(
	IdEditorial INT PRIMARY KEY IDENTITY(1,1),
	Nombre VARCHAR(50)
)

INSERT INTO Editorial (Nombre) VALUES ('Editorial Digis')
INSERT INTO Editorial (Nombre) VALUES ('E. Aguilar')
INSERT INTO Editorial (Nombre) VALUES ('Miranda L.')
INSERT INTO Editorial (Nombre) VALUES ('Digis')
INSERT INTO Editorial (Nombre) VALUES ('Hernandez Publicaciones')

SELECT * FROM Editorial

CREATE TABLE Genero(
	IdGenero INT PRIMARY KEY IDENTITY(1,1),
	Nombre VARCHAR(50)
)

INSERT INTO Genero(Nombre) VALUES ('Romance')
INSERT INTO Genero(Nombre) VALUES ('Terror')
INSERT INTO Genero(Nombre) VALUES ('Ciencia')
INSERT INTO Genero(Nombre) VALUES ('Fantasía')
INSERT INTO Genero(Nombre) VALUES ('Tecnología')

SELECT * FROM Genero

CREATE TABLE Libro(
	IdLibro INT PRIMARY KEY IDENTITY(1,1),
	Nombre VARCHAR(50),
	IdAutor INT REFERENCES Autor(IdAutor),
	NumeroPaginas INT,
	FechaPublicacion DATE,
	IdEditorial INT REFERENCES Editorial(IdEditorial),
	Edicion VARCHAR(50),
	IdGenero INT REFERENCES Genero(IdGenero)
)


ALTER PROCEDURE LibroAdd
@Nombre VARCHAR(50),
@IdAutor INT,
@NumeroPaginas INT,
@FechaPublicacion VARCHAR(10),
@IdEditorial INT,
@Edicion VARCHAR(50),
@IdGenero INT
AS
INSERT INTO Libro(Nombre,
					IdAutor,
					NumeroPaginas,
					FechaPublicacion,
					IdEditorial,
					Edicion,
					IdGenero)
			VALUES(@Nombre,
					@IdAutor,
					@NumeroPaginas,
					CONVERT(DATE,@FechaPublicacion,105),
					@IdEditorial,
					@Edicion,
					@IdGenero
			)

LibroAdd 'Don Quijote', 2, 200,'01-04-1605', 2, '4ta. Edición', 4

SELECT * FROM Libro

CREATE PROCEDURE LibroUpdate
@IdLibro INT,
@Nombre VARCHAR(50),
@IdAutor INT,
@NumeroPaginas INT,
@FechaPublicacion VARCHAR(10),
@IdEditorial INT,
@Edicion VARCHAR(50),
@IdGenero INT
AS
UPDATE Libro SET Nombre=@Nombre,
					IdAutor=@IdAutor,
					NumeroPaginas=@NumeroPaginas,
					FechaPublicacion=CONVERT(DATE,@FechaPublicacion,105),
					IdEditorial=@IdEditorial,
					Edicion=@Edicion,
					IdGenero=@IdGenero
WHERE IdLibro=@IdLibro

LibroUpdate 3, 'Don Quijote', 2, 177,'01-04-1605', 2, '4ta. Edición', 4

CREATE PROCEDURE LibroDelete
@IdLibro INT
AS
DELETE FROM Libro WHERE IdLibro=@IdLibro

LibroDelete 2


CREATE PROCEDURE LibroGetAll
AS
SELECT Libro.IdLibro,
		Libro.Nombre,
		Libro.IdAutor,
		Autor.Nombre AS AutorNombre,
		Libro.NumeroPaginas,
		Libro.FechaPublicacion,
		Libro.IdEditorial,
		Editorial.Nombre AS EditorialNombre,
		Libro.Edicion,
		Libro.IdGenero,
		Genero.Nombre AS GeneroNombre
FROM Libro
INNER JOIN Autor ON Autor.IdAutor=Libro.IdAutor
INNER JOIN Editorial ON Editorial.IdEditorial=Libro.IdEditorial
INNER JOIN Genero ON Genero.IdGenero=Libro.IdGenero

LibroGetAll

CREATE PROCEDURE LibroGetById
@IdLibro INT
AS
SELECT Libro.IdLibro,
		Libro.Nombre,
		Libro.IdAutor,
		Autor.Nombre AS AutorNombre,
		Libro.NumeroPaginas,
		Libro.FechaPublicacion,
		Libro.IdEditorial,
		Editorial.Nombre AS EditorialNombre,
		Libro.Edicion,
		Libro.IdGenero,
		Genero.Nombre AS GeneroNombre
FROM Libro
INNER JOIN Autor ON Autor.IdAutor=Libro.IdAutor
INNER JOIN Editorial ON Editorial.IdEditorial=Libro.IdEditorial
INNER JOIN Genero ON Genero.IdGenero=Libro.IdGenero
WHERE Libro.IdLibro = @IdLibro

LibroGetById 3