using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    public class Program
    {
        public static string userInput;
        public static Random rng = new Random();
        public static bool cont = true;
        public static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        public static void Main(string[] args)
        {
            Console.Write("Hello, welcome to the random activity generator!\n\nWould you like to generate a random activity? yes/no: ");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() != "yes")
            {
                Console.WriteLine("Thank you - have a great day!");
                return; // This exits us out of the program
            }
            Console.WriteLine();

            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();
            Console.WriteLine();
        //below - Using Try Parse so user does not ender anything other than an int
            int userAge = 0;
            bool verifyAge = false;
            do
            {
            Console.Write("What is your age? ");
            verifyAge = int.TryParse(Console.ReadLine(), out userAge);

            } while (!verifyAge);
        // end of Try Parse
            Console.WriteLine();
            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
            string userInput2 = Console.ReadLine();
            if (userInput2.ToLower() == "sure")
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }
            }

            Console.WriteLine();
            Console.Write("Would you like to add any activities before we generate one? yes/no: ");
            string addToList = Console.ReadLine();

            while (addToList.ToLower() == "yes")
            {
                Console.WriteLine();
                Console.Write("What would you like to add? ");
                string userAddition = Console.ReadLine();
                activities.Add(userAddition);
                foreach (string activity in activities)
                {
                    Console.Write($"{activity}, ");
                    Thread.Sleep(250);
                }
                Console.WriteLine();
                Console.WriteLine("Would you like to add more? yes/no: ");
                addToList = Console.ReadLine();
            }

            do
	        {
                 Console.Write("Connecting to the database");
                 for (int i = 0; i < 10; i++)
                 {
                     Console.Write(". ");
                     Thread.Sleep(100);
                 }
                 Console.WriteLine();
                 Console.Write("Choosing your random activity");
                 for (int i = 0; i < 9; i++)
                 {
                     Console.Write(". ");
                     Thread.Sleep(100);
                 }
                 Console.WriteLine();
                 int randomNumber = rng.Next(activities.Count);
                 string randomActivity = activities[randomNumber];

                 if (userAge < 21 && randomActivity == "Wine Tasting")
                 {
                     Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                     Console.WriteLine("Pick something else!");
                     randomNumber = rng.Next(activities.Count);
                     randomActivity = activities[randomNumber];
                     activities.Remove(randomActivity);
                    cont = true;
                    continue;
                 }
                 Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                string userInput3 = Console.ReadLine();
                if (userInput3.ToLower() != "redo")
                {
                    cont = false;
                }
            } while (cont);
        }
    }
}