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