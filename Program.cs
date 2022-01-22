using System;

namespace RhythmsGonnaGetYou
{
    class Program
    {
        static void DisplayGreeting()
        {
            Console.WriteLine("");
            Console.WriteLine("🥁🎤🎸🎹🥁🎤🎸🎹🥁🎤🎸🎹🥁🎤🎸🎹🥁🎤🎸🎹");
            Console.WriteLine("     Welcome to the Music Database   ");
            Console.WriteLine("🥁🎤🎸🎹🥁🎤🎸🎹🥁🎤🎸🎹🥁🎤🎸🎹🥁🎤🎸🎹");
            Console.WriteLine("");
        }

        static void DisplayMenu()
        {
            // Add a new band
            // View all the bands
            // Add an album for a band
            // Add a song to an album
            // Let a band go(update isSigned to false)
            // Resign a band(update isSigned to true)
            // Prompt for a band name and view all their albums
            // View all albums ordered by ReleaseDate
            // View all bands that are signed
            // View all bands that are not signed
            // Quit the program
        }

        static void Main(string[] args)
        {

            var context = new RhythmsGonnaGetYouContext();

            DisplayGreeting();
        }
    }
}


