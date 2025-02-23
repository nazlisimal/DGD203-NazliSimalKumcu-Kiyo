using System;
using System.Collections.Generic;
using System.IO;
//DGD203-NazlıŞimalKumcu-GameProgrammingFinal
//ChatGpt Kullanılmıştır

namespace Kiyo
{
    class Program
    {
        static string currentLocation = "";
        static List<string> inventory = new List<string>();
        static bool hasFoundArtifact = false;

        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Kiyo!");
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Load Game");
            Console.WriteLine("3. Exit");

            switch (Console.ReadLine())
            {
                case "1":
                    StartGame();
                    break;
                case "2":
                    LoadGame();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    MainMenu();
                    break;
            }
        }

        static void StartGame()
        {
            currentLocation = "The Alleyway Labyrinth";
            inventory.Clear();
            hasFoundArtifact = false;
            Console.WriteLine("Your adventure begins in the Alleyway Labyrinth...");
            Console.ReadKey();
            GameLoop();
        }

        static void GameLoop()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"You are at: {currentLocation}");

                switch (currentLocation)
                {
                    case "The Alleyway Labyrinth":
                        AlleywayLabyrinth();
                        break;
                    case "The Grand Library Rooftop":
                        LibraryRooftop();
                        break;
                    case "The Underground Market":
                        UndergroundMarket();
                        break;
                    default:
                        Console.WriteLine("Invalid location. Returning to the main menu.");
                        MainMenu();
                        break;
                }
            }
        }

        static void AlleywayLabyrinth()
        {
            Console.WriteLine("A maze of alleys filled with graffiti and lurking dangers.");
            Console.WriteLine("1. Search for items.");
            Console.WriteLine("2. Talk to Grizzle.");
            Console.WriteLine("3. Move to another location.");
            Console.WriteLine("4. Save the game.");
            Console.WriteLine("5. Exit to Main Menu.");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("You found a shiny token!");
                    inventory.Add("Shiny Token");
                    break;
                case "2":
                    Console.WriteLine("Grizzle offers advice: 'Seek the rooftop for answers.'");
                    break;
                case "3":
                    currentLocation = "The Grand Library Rooftop";
                    break;
                case "4":
                    SaveGame();
                    break;
                case "5":
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        static void LibraryRooftop()
        {
            Console.WriteLine("A high perch overlooking the bustling city.");
            Console.WriteLine("1. Solve the riddle.");
            Console.WriteLine("2. Talk to the pigeon.");
            Console.WriteLine("3. Move to another location.");
            Console.WriteLine("4. Save the game.");
            Console.WriteLine("5. Exit to Main Menu.");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("You solved the riddle and found the glowing collar!");
                    inventory.Add("Glowing Collar");
                    hasFoundArtifact = true;
                    break;
                case "2":
                    Console.WriteLine("The pigeon demands a shiny object in exchange for a clue.");
                    if (inventory.Contains("Shiny Token"))
                    {
                        Console.WriteLine("You gave the pigeon a shiny token. It reveals the Underground Market password: 'MeowMix.'");
                        inventory.Remove("Shiny Token");
                    }
                    else
                    {
                        Console.WriteLine("You don't have anything shiny to give.");
                    }
                    break;
                case "3":
                    currentLocation = "The Underground Market";
                    break;
                case "4":
                    SaveGame();
                    break;
                case "5":
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        static void UndergroundMarket()
        {
            Console.WriteLine("A hidden bazaar where animals trade and gossip.");
            Console.WriteLine("1. Help the merchant rat.");
            Console.WriteLine("2. Use the glowing collar.");
            Console.WriteLine("3. Return to another location.");
            Console.WriteLine("4. Save the game.");
            Console.WriteLine("5. Exit to Main Menu.");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("You helped the rat find their lost inventory and earned their trust.");
                    break;
                case "2":
                    if (hasFoundArtifact)
                    {
                        Console.WriteLine("The collar reveals a secret about the city, crowning you as its new guardian.");
                        EndGame();
                    }
                    else
                    {
                        Console.WriteLine("You don’t have the artifact yet.");
                    }
                    break;
                case "3":
                    currentLocation = "The Alleyway Labyrinth";
                    break;
                case "4":
                    SaveGame();
                    break;
                case "5":
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        static void LoadGame()
        {
            if (File.Exists("savefile.txt"))
            {
                try
                {
                    using (StreamReader reader = new StreamReader("savefile.txt"))
                    {
                        currentLocation = reader.ReadLine();
                        hasFoundArtifact = bool.Parse(reader.ReadLine());
                        inventory = new List<string>(reader.ReadLine().Split(','));
                    }
                    Console.WriteLine("Game loaded successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading game: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("No save file found. Starting a new game.");
                StartGame();
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        static void SaveGame()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("savefile.txt"))
                {
                    writer.WriteLine(currentLocation);
                    writer.WriteLine(hasFoundArtifact);
                    writer.WriteLine(string.Join(",", inventory));
                }
                Console.WriteLine("Game saved successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving game: {ex.Message}");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        static void EndGame()
        {
            Console.Clear();
            Console.WriteLine("Congratulations! You’ve uncovered the city’s secret and become its guardian.");
            Console.WriteLine("Summary of your adventure:");
            foreach (var item in inventory)
            {
                Console.WriteLine($"  * {item}");
            }
            Console.WriteLine("\nThanks for playing Kiyo!");
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
            MainMenu();
        }
    }
}

