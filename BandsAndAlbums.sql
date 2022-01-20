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




