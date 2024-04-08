

using Genspil;
using System.Diagnostics;

namespace Genspil
{
    public class GameStorage
    {
        // Define enum for the condition of the game
        public enum GameCondition
        {
            New,
            Used,
            Good, 
            Ok,
            Damaged
        }

        // Define enum for the status of the game
        public enum GameStatus
        {
            Available,
            Reserved,
            OnItsWay,
            WaitList,
        }

        // A class representing a game
        public class GameInfo
        {
            // Properties of the game
            public string Title { get; set; } // Title of the game
            public string Edition { get; set; }   // edition of the game
            public decimal BasePrice { get; set; }  // The original price of the game
            public string Genre { get; set; }  // Genre of the game
            public int NumberOfPlayers { get; set; }  // number of players 
            public int NumberOfGames { get; set; } // number of games
            public GameCondition Condition { get; set; } // Condition of the game
            public GameStatus Status { get; set; }  // Status of availiblty in storage 

            //Constructor 
            public GameInfo(string title, string edition, decimal basePrice, string genre, int numberOfPlayers, int numberOfGames, GameCondition condition, GameStatus status)
            {
                Title = title;
                Edition = edition;
                BasePrice = basePrice;
                Genre = genre;
                NumberOfPlayers = numberOfPlayers;
                NumberOfGames = numberOfGames;
                Condition = condition;
                Status = status;
            }

            // Calculating the price after condition
            public decimal CalculatePrice()
            {
                // switch to the different conditions
                switch (Condition)
                {
                    case GameCondition.New:  // in case the game is new, return original price
                        return BasePrice;
                    case GameCondition.Used:  // if used take away 70% of the orignal price
                        return BasePrice * 0.7m;
                    case GameCondition.Good:
                        return BasePrice * 0.9m;
                    case GameCondition.Ok:
                        return BasePrice * 0.6m;
                    case GameCondition.Damaged:
                        return BasePrice * 0.4m;
                    default:
                        return BasePrice;
                }
            }

        }

       

        public class GameData
        {
            public GameInfo[] Games { get; set; } // array to store game information

            public GameData()
            {
                Games = new GameInfo[]
                {
                    new GameInfo("Chess", "Standard Edition", 80m, "Board", 2, 3, GameCondition.New, GameStatus.Available),
                    new GameInfo("Monopoly", "Limited Edition", 90m, "Board", 4, 2, GameCondition.Good, GameStatus.OnItsWay),
                    new GameInfo("Monopoly", "German Edition", 70m, "Board", 4, 1, GameCondition.Ok, GameStatus.Reserved),
                    new GameInfo("Bad People", "Standard Edition", 40m, "Card", 3-10, 4, GameCondition.Good, GameStatus.Available)
                };
            }
        }

        public class GameManager
        {
            // Array to store game information
            private static GameInfo[] gamesarray = new GameInfo[100]; //Assuming a maximum of 100 games
            private static int nextIndex = 0; // Keep track of the next available index in the array

            // Method to add a game directly into the array
            public static void AddGame(string title, string edition, decimal basePrice, string genre, int numberOfPlayers, int numberOfGames, int conditionChoice, GameStatus status)
            {
                if (nextIndex < gamesarray.Length)
                {
                    // Input bliver henvist til GameCondition enum
                    GameCondition condition = (GameCondition)(conditionChoice - 1);

                    // Ny spil bliver tilføjet bliver baseret udfra condition og status.
                    GameInfo newGame = new GameInfo(title, edition, basePrice, genre, numberOfPlayers, numberOfGames, condition, status);

                    // Nyt spil bliver tilføjet til array
                    gamesarray[nextIndex] = newGame;
                    nextIndex++;
                    Console.WriteLine("Game added successfully.");

                }
                else
                {
                    Console.WriteLine("Inventory is filled");
                }
            }

            public static void DisplayInventoryByGenre()
            {
                var sortedGames = gamesarray.OrderBy(g => g.Genre).ToList();
                DisplayInventory(sortedGames);
            }

            public static void DisplayInventoryByTitle()
            {
                var sortedGames = gamesarray.OrderBy(g =>g.Title).ToList();
                DisplayInventory(sortedGames);
            }

            public static void DisplayInventory(List<GameInfo> games )
            {
                
                Console.WriteLine("Lagerbeholdning:");
                Console.WriteLine("Lagerbeholdning:");
                foreach (var game in games) 
                {
                    Console.WriteLine($"Title: {game.Title}");
                    Console.WriteLine($"Edition: {game.Edition}");
                    Console.WriteLine($"Base Price: {game.BasePrice:C}"); // Display base price as currency
                    Console.WriteLine($"Genre: {game.Genre}");
                    Console.WriteLine($"Number of Players: {game.NumberOfPlayers}");
                    Console.WriteLine($"Condition: {game.Condition}");
                    Console.WriteLine($"Status: {game.Status}");
                    Console.WriteLine(); // Add a blank line for readability
                }
            }
            
            public static void DisplayInventoryByGenre()
            {
                var sortedGames = gamesarray.OrderBy(g => g.Genre);
                DisplayInventory(sortedGames);
            }

            public static void DisplayInventoryByTitle()
            {
                var sortedGames = gamesarray.OrderBy(g =>g.Title);
                DisplayInventory(sortedGames);
            }
        }

}   }

