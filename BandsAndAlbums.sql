-- create the tables
CREATE TABLE "Bands"(
"Id" SERIAL PRIMARY KEY,
"Name" TEXT,
"CountryOfOrigin" TEXT,
"NumberOfMembers" INTEGER,
"Website" TEXT,
"Genre" TEXT,
"IsSigned" BOOLEAN,
"ContactName" TEXT
);

CREATE TABLE "Albums"(
"Id" SERIAL PRIMARY KEY,
"Title" TEXT,
"IsExplicit" BOOLEAN,
"ReleaseDate" DATE, 
"BandId" INTEGER REFERENCES "Bands" ("Id")
);

CREATE TABLE "Songs"(
 "Id" SERIAL PRIMARY KEY,
"TrackNumber" INTEGER,
"Title" TEXT,
"Duration" TEXT,
"AlbumId" INTEGER REFERENCES "Albums" ("Id")
);

-- insert bands
INSERT INTO "Bands" ("Name", "CountryOfOrigin", "NumberOfMembers", "Website", "Genre", "IsSigned", "ContactName")
VALUES ('ABBA', 'Sweden', 4, 'abba.com', 'pop', true, 'Tina' );

INSERT INTO "Bands" ("Name", "CountryOfOrigin", "NumberOfMembers", "Website", "Genre", "IsSigned", "ContactName")
VALUES ('Spice Girls', 'England', 5, 'spiceupyourlife.com', 'pop', false, 'Gina' );

INSERT INTO "Bands" ("Name", "CountryOfOrigin", "NumberOfMembers", "Website", "Genre", "IsSigned", "ContactName")
VALUES ('TLC', 'US', 3, 'waterfalls.com', 'r&b', false, 'Liz' );

INSERT INTO "Bands" ("Name", "CountryOfOrigin", "NumberOfMembers", "Website", "Genre", "IsSigned", "ContactName")
VALUES ('Destinys Child', 'US', 4, 'destinyschild.com', 'r&b', false, 'Tina' );

INSERT INTO "Bands" ("Name", "CountryOfOrigin", "NumberOfMembers", "Website", "Genre", "IsSigned", "ContactName")
VALUES ('Garbage', 'US', 4, 'garbage.com', 'rock', true, 'Barb' );

INSERT INTO "Bands" ("Name", "CountryOfOrigin", "NumberOfMembers", "Website", "Genre", "IsSigned", "ContactName")
VALUES ('The Runaways', 'US', 9 , 'runaways.com', 'rock', false, 'Barb' );

-- insert albums
INSERT INTO "Albums" ("Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES ('Spice', false, '1996-09-19', 8);

INSERT INTO "Albums" ("Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES ('Spiceworld', false, '1997-11-01', 8);

INSERT INTO "Albums" ("Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES ('CrazySexyCool', false, '1994-11-15', 9);

INSERT INTO "Albums" ("Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES ('The Writings on the Wall', false, '1999-07-27', 11);

INSERT INTO "Albums" ("Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES ('Survivor', false, '2001-04-25', 11);

INSERT INTO "Albums" ("Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES ('Arrival', false, '1976-10-11', 10);

INSERT INTO "Albums" ("Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES ('ABBA', false, '1975-04-21', 10);

INSERT INTO "Albums" ("Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES ('The Runaways', false, '1976-06-01', 13);

INSERT INTO "Albums" ("Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES ('Beautiful Garbage', false, '2001-10-01', 12);




