PRAGMA foreign_keys = ON;

DROP TABLE IF EXISTS DISCOS;
DROP TABLE IF EXISTS ESTILOS;
DROP TABLE IF EXISTS TIPOSEDICION;

CREATE TABLE ESTILOS (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Descripcion TEXT
);

CREATE TABLE TIPOSEDICION (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Descripcion TEXT
);

CREATE TABLE DISCOS (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Titulo TEXT,
    FechaLanzamiento TEXT,
    CantidadCanciones INTEGER,
    UrlImagenTapa TEXT,
    IdEstilo INTEGER,
    IdTipoEdicion INTEGER,
    FOREIGN KEY (IdEstilo) REFERENCES ESTILOS (Id),
    FOREIGN KEY (IdTipoEdicion) REFERENCES TIPOSEDICION (Id)
);

INSERT INTO ESTILOS (Descripcion) VALUES ('Pop Punk');
INSERT INTO ESTILOS (Descripcion) VALUES ('Pop');
INSERT INTO ESTILOS (Descripcion) VALUES ('Rock');
INSERT INTO ESTILOS (Descripcion) VALUES ('Grunge');

INSERT INTO TIPOSEDICION (Descripcion) VALUES ('Vinilo');
INSERT INTO TIPOSEDICION (Descripcion) VALUES ('CD');
INSERT INTO TIPOSEDICION (Descripcion) VALUES ('Tape');

INSERT INTO DISCOS (Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, IdEstilo, IdTipoEdicion)
VALUES ('Pablo Honey', '1992-01-01', 12, 'https://cdns-images.dzcdn.net/images/cover/f08424290260e58c6d76275253b316fd/264x264.jpg', 2, 1);

INSERT INTO DISCOS (Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, IdEstilo, IdTipoEdicion)
VALUES ('Siempre es hoy', '2002-01-01', 17, 'https://www.cmtv.com.ar/tapas-cd/ceratisiempre.jpg', 3, 3);