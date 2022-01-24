using System;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RhythmsGonnaGetYou
{
    class Program
    {


        static void DisplayMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("PLEASE MAKE A SELECTION: ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("☆━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━☆");
            Console.ForegroundColor = ConsoleColor.White;
            // Add a new band
            // Add an album for a band
            // Add a song to an album
            Console.WriteLine("[A]dd a new album, band, or song ");

            // View all the bands
            // Prompt for a band name and view all their albums
            // View all albums ordered by ReleaseDate
            // View all bands that are signed
            // View all bands that are not signed
            Console.WriteLine("[V]iew album and band info ");

            // Let a band go (update isSigned to false)
            // Resign a band (update isSigned to true)
            Console.WriteLine("[U]pdate signed status of a band ");

            // Quit the program
            Console.WriteLine("[Q]uit ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("☆━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━☆");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
        }

        public static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine().ToUpper();

            return userInput;
        }
        // public bool PromptForBoolean(string prompt)
        // {
        //     switch (prompt.ToUpper())
        //     {
        //         case "Y":
        //             return true;
        //         case "N":
        //             return false;
        //         default:
        //             Console.WriteLine("That is not a valid input. ");
        //             break;
        //     }
        // }
        public static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);

            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Sorry, that isn't a valid input, I'm using 0 as your answer. ");
                return 0;
            }
        }

        public static void NoMatchFound()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❗No match found❗");
        }

        static Band SearchForBandName(RhythmsGonnaGetYouContext context)
        {
            var bandName = PromptForString("What is the band name: \n").ToUpper();
            var foundBand = context.Bands.First(band => band.Name.ToUpper().Contains(bandName.ToUpper()));
            Console.WriteLine("");
            return foundBand;
        }

        static void Main(string[] args)
        {

            var context = new RhythmsGonnaGetYouContext();

            MusicDatabase.DisplayGreeting();

            var keepGoing = true;

            while (keepGoing)
            {
                DisplayMenu();

                var choice = Console.ReadLine().ToUpper();
                Console.WriteLine("");

                switch (choice)
                {
                    case "A":
                        Console.WriteLine("What would you like to add? ");
                        Console.WriteLine("[B]and");
                        Console.WriteLine("[A]lbum for a band ");
                        Console.WriteLine("[S]ong to an album ");
                        Console.WriteLine("");

                        var addChoice = Console.ReadLine().ToUpper();
                        // Add a new band
                        if (addChoice == "B")
                        {
                            // var isGoodName = true;
                            // do 
                            // {
                            var name = PromptForString("Name of new band: ");
                            // var bandNameTaken = context.Bands.Any(bandName => bandName.Name == name);
                            // if (bandNameTaken == true)
                            // {
                            //     Console.WriteLine($"{name} is already in the database. Please input a different band name. ");
                            // }
                            // else
                            // {
                            //     break;
                            // }
                            // }while (isGoodName != true);
                            var countryOfOrigin = PromptForString("Country of origin: ");
                            var numberOfMembers = PromptForInteger("Number of members in band: ");
                            var website = PromptForString("Website: ");
                            var genre = PromptForString("Genre: ");
                            var isSigned = (PromptForString("Is the band signed? [Y]es or [N]o? "));
                            if (isSigned == "Y")
                            {
                                isSigned = "true";
                            }
                            else if (isSigned == "N")
                            {
                                isSigned = "false";
                            }
                            var contactName = PromptForString("Contact name: ");
                            Console.WriteLine("");

                            var newBand = new Band
                            {
                                Name = name,
                                CountryOfOrigin = countryOfOrigin,
                                NumberOfMembers = numberOfMembers,
                                Website = website,
                                Genre = genre,
                                IsSigned = bool.Parse(isSigned),
                                ContactName = contactName
                            };

                            context.Bands.Add(newBand);
                            context.SaveChanges();
                        }
                        // Add an album for a band
                        else if (addChoice == "A")
                        {
                            var title = PromptForString("Title of new album: ");
                            var isExplicit = PromptForString("Is the album explicit? [Y]es or [N]o? ");
                            if (isExplicit == "Y")
                            {
                                isExplicit = "true";
                            }
                            else if (isExplicit == "N")
                            {
                                isExplicit = "false";
                            }
                            Console.WriteLine("Release date of the album (MM/DD/YYYY)");
                            DateTime releaseDate = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                            var bandId = PromptForInteger("Band Id: ");

                            var newAlbum = new Album
                            {
                                Title = title,
                                IsExplicit = bool.Parse(isExplicit),
                                ReleaseDate = releaseDate,
                                BandId = bandId
                            };
                        }

                        // Add a song to an album
                        break;

                    case "V":
                        Console.WriteLine("SELECT WHAT YOU'D LIKE TO VIEW: ");
                        Console.WriteLine("[B]ands ");
                        Console.WriteLine("[I]nsert band name and view all their albums ");
                        Console.WriteLine("[A]lbums ordered by release date ");
                        Console.WriteLine("[S]igned bands ");
                        Console.WriteLine("[U]nsigned bands ");
                        Console.WriteLine("");

                        var viewSelection = Console.ReadLine().ToUpper();
                        Console.WriteLine("");

                        // View all the bands
                        if (viewSelection == "B")
                        {
                            var bandCount = context.Bands.Count();
                            Console.WriteLine($"There are {bandCount} bands in the database: ");
                            Console.WriteLine("");
                            foreach (var band in context.Bands)
                            {
                                Console.WriteLine(band.Name);
                            }
                            Console.WriteLine("");
                        }
                        // Prompt for a band name and view all their albums
                        else if (viewSelection == "I")
                        {
                            // search for band name 
                            Band bandNameToViewAlbumsOf = SearchForBandName(context);
                            // search for albums of given band name
                            var albumsOfFoundBand = context.Albums.Include(album => album.Band).Where(album => album.Band == bandNameToViewAlbumsOf).OrderBy(album => album.Title);

                            if (bandNameToViewAlbumsOf == null)
                            {
                                NoMatchFound();
                            }
                            else
                            {
                                foreach (var album in albumsOfFoundBand)
                                {
                                    Console.WriteLine(album.Title);
                                }
                                Console.WriteLine("");
                            }
                        }
                        // View all albums ordered by ReleaseDate 
                        else if (viewSelection == "A")
                        {
                            var viewAlbumByReleaseDate = context.Albums.OrderBy(album => album.ReleaseDate);
                            Console.WriteLine("Albums by release date: ");
                            foreach (var album in viewAlbumByReleaseDate)
                            {
                                Console.WriteLine($"{album.ReleaseDate} — {album.Title}");
                            }
                        }
                        // View all bands that are signed SIGNED BANDS
                        else if (viewSelection == "S")
                        {
                            Console.WriteLine("Signed bands: ");
                            Console.WriteLine("");
                            foreach (var band in context.Bands)
                            {
                                if (band.IsSigned == true)
                                {
                                    Console.WriteLine(band.Name);
                                }
                            }
                            Console.WriteLine("");
                        }

                        // View all bands that are not signed UNSIGNED BANDS
                        else if (viewSelection == "U")
                        {
                            Console.WriteLine("Unsigned bands: ");
                            Console.WriteLine("");
                            foreach (var band in context.Bands)
                            {
                                if (band.IsSigned == false)
                                {
                                    Console.WriteLine(band.Name);
                                }
                            }
                            Console.WriteLine("");
                        }
                        else
                        {
                            NoMatchFound();
                        }
                        break;

                    case "U":
                        // Let a band go (update isSigned to false)
                        // Resign a band (update isSigned to true)
                        break;

                    case "Q":
                        keepGoing = false;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("");
                        Console.WriteLine("❗That is not a valid selection. Try again❗");
                        break;
                }

                break;
            }
        }
    }
}


