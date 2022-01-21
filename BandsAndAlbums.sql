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

-- insert songs
INSERT INTO "Songs" ("TrackNumber", "Title", "Duration", "AlbumId")
VALUES (7, 'Cherry Lips','3:11', 9);

INSERT INTO "Songs" ("TrackNumber", "Title", "Duration", "AlbumId")
VALUES (1, 'Cherry Bomb', '2:18', 8);

INSERT INTO "Songs" ("TrackNumber", "Title", "Duration", "AlbumId")
VALUES (4, 'SOS', '3:22', 7);

INSERT INTO "Songs" ("TrackNumber", "Title", "Duration", "AlbumId")
VALUES (1, 'Mamma Mia', '3:33', 7);

INSERT INTO "Songs" ("TrackNumber", "Title", "Duration", "AlbumId")
VALUES (5, 'Knowing Me Knowing You', '4:01', 6);

INSERT INTO "Songs" ("TrackNumber", "Title", "Duration", "AlbumId")
VALUES (11, 'Fernando', '4:12', 6);

INSERT INTO "Songs" ("TrackNumber", "Title", "Duration", "AlbumId")
VALUES (1, 'Independent Women Pt 1', '3:41', 5);

INSERT INTO "Songs" ("TrackNumber", "Title", "Duration", "AlbumId")
VALUES (12, 'Say My Name', '4:31', 4);

INSERT INTO "Songs" ("TrackNumber", "Title", "Duration", "AlbumId")
VALUES (2, 'Creep', '4:28', 3);

INSERT INTO "Songs" ("TrackNumber", "Title", "Duration", "AlbumId")
VALUES (1, 'Wannabe', '2:53', 1);

INSERT INTO "Songs" ("TrackNumber", "Title", "Duration", "AlbumId")
VALUES (10, 'The Lady is a Vamp', '3:10', 2);

-- View all the bands
SELECT * FROM "Bands";

-- Let a band go (update isSigned to false)
UPDATE "Bands"
SET "IsSigned" = false
WHERE "Name" = 'Garbage';

-- Resign a band (update isSigned to true)
UPDATE "Bands"
SET "IsSigned" = true 
WHERE "Name" = 'TLC';

-- Given a band name, view all their albums
SELECT "Bands"."Name", "Albums"."Title"
FROM "Albums"
JOIN "Bands" ON "Albums"."BandId" = "Bands"."Id"
WHERE "Bands"."Name" = 'ABBA' OR "Bands"."Name" = 'Spice Girls';

-- View all albums (and their associated songs) ordered by ReleaseDate
SELECT "Albums"."ReleaseDate", "Albums"."Title", "Songs"."Title"
FROM "Songs"
JOIN "Albums" ON "Songs"."AlbumId"= "Albums"."Id"
ORDER BY "Albums"."ReleaseDate" ASC;

-- View all bands that are signed
SELECT "Bands"."Name", "Bands"."IsSigned"
FROM "Bands" WHERE "Bands"."IsSigned" = true;

-- View all bands that are not signed
SELECT "Bands"."Name", "Bands"."IsSigned"
FROM "Bands" WHERE "Bands"."IsSigned" = false;
