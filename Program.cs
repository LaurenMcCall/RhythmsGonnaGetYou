using System;
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
            var userInput = Console.ReadLine();

            return userInput;
        }

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

        static Band SearchForBandName(RhythmsGonnaGetYouContext context)
        {
            var bandName = PromptForString("Type a band name: \n").ToUpper();
            var foundBand = context.Bands.FirstOrDefault(band => band.Name.ToUpper().Contains(bandName.ToUpper()));
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



                        // Add a new band
                        // Add an album for a band
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
                            // var bandName = PromptForString("Type a band name: \n").ToUpper();
                            // var foundBand = context.Bands.FirstOrDefault(band => band.Name.ToUpper().Contains(bandName.ToUpper()));
                            Band bandNameToViewAlbumsOf = SearchForBandName(context);
                            var albumsOfFoundBand = context.Albums.Include(album => album.Band).Where(album => album.Band == bandNameToViewAlbumsOf);

                            if (bandNameToViewAlbumsOf == null)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("");
                                Console.WriteLine("❗No match found❗");
                            }
                            else
                            {
                                foreach (var album in albumsOfFoundBand)
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine(album.Title);
                                }
                            }

                        }
                        // View all albums ordered by ReleaseDate 
                        // View all bands that are signed SIGNED BANDS
                        // View all bands that are not signed UNSIGNED BANDS
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


