using System;

namespace RhythmsGonnaGetYou
{
    class Program
    {
        static void DisplayGreeting()
        {
            Console.WriteLine("");
            Console.WriteLine("～*～♪ ～*～♪ ～*～♪ ～*～♪ ～*～♪ ～*～♪ ～*～");
            Console.WriteLine("         Welcome to the Music Database   ");
            Console.WriteLine("～*～♪ ～*～♪ ～*～♪ ～*～♪ ～*～♪ ～*～♪ ～*～");
            Console.WriteLine("");
        }

        static void DisplayMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("Please make a selection: ");
            Console.WriteLine("☆━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━☆");

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

            // Let a band go(update isSigned to false)
            // Resign a band(update isSigned to true)
            Console.WriteLine("[U]pdate signed status of a band ");

            // Quit the program
            Console.WriteLine("[Q]uit ");
            Console.WriteLine("☆━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━☆");
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

            DisplayMenu();
        }
    }
}


