using System;
using System.Linq;

namespace RhythmsGonnaGetYou
{
    class Program
    {
        static void DisplayGreeting()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("～*～♪ ～*～♪ ～*～♪ ～*～♪ ～*～♪ ～*～♪ ～*～");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("         Welcome to the Music Database   ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("～*～♪ ～*～♪ ～*～♪ ～*～♪ ～*～♪ ～*～♪ ～*～");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
        }

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

        static void Main(string[] args)
        {

            var context = new RhythmsGonnaGetYouContext();

            DisplayGreeting();

            var bandCount = context.Bands.Count();
            Console.WriteLine($"There are {bandCount} bands. ");

            var keepGoing = true;

            while (keepGoing)
            {
                DisplayMenu();


                var choice = Console.ReadLine().ToUpper();
                Console.WriteLine("");

                switch (choice)
                {
                    case "A":
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
                            foreach (var band in context.Bands)
                            {
                                Console.WriteLine(band.Name);
                            }
                        }
                        // Prompt for a band name and view all their albums
                        else if (viewSelection == "I")
                        {
                            var insertBandNameToViewAlbums = PromptForString("Which band's albums would you like to view? ");

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


