

namespace Genspil
{
    internal class Game
    {
        // Define enum for the condition of the game
        public enum GameCondition
        {
            New,
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
            WaitList
        }

        // A class representing a game
        public class Game
        {
            // Properties of the game
            public string Title { get; set; } // Title of the game
            public string Edition { get; set; }   // edition of the game
            public decimal BasePrice { get; set; }  // The original price of the game
            public string Genre { get; set; }  // Genre of the game
            public int NumberOfPlayers { get; set; }  // number of players 
            public GameCondition Condition { get; set; } // Condition of the game
            public GameStatus Status { get; set; }  // Status of availiblty in storage 

            //Constructor 
            public Game(string title, string edition, decimal basePrice, string genre, int numberOfPlayers, GameCondition condition, GameStatus status)
            {
                Title = title;
                Edition = edition;
                BasePrice = basePrice;
                Genre = genre;
                NumberOfPlayers = numberOfPlayers;
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
                        return BasePrice * 0.9m
                    case GameCondition.Ok:
                        return BasePrice * 0.6m
                    case GameCondition.Damaged:
                        return BasePrice * 0.4m;
                    default:
                        return BasePrice;
                }
            }

        }

    }
    // Array to store game information
    private static Gameinfo[] gamesarray = new Gameinfo[100]; //Assuming a maximum of 100 games
    private static int nextIndex = 0; // Keep track of the next available index in the array
    
    // Method to add a game directly into the array
    public static void AddGame (string )

    
}

