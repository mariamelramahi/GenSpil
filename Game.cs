

using Genspil;

namespace Genspil
{
    public class GameStorage
    {
        // Define enum for the condition of the game
        public enum GameCondition
        {
            New,
            Good,
            Used, 
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
                    new GameInfo("Bad People", "Standard Ediiton", 40m, "Card", 3 - 10, 4, GameCondition.Good, GameStatus.Available)
                };
            }
            }
        }

    }

