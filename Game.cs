

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
            public string Title { get; set; }   // Title of the game
            public decimal BasePrice { get; set; }  // The original price of the game
            public string Genre { get; set; }  // Genre of the game
            public int NumberOfPlayers { get; set; }  // number of players 
            public GameCondition Condition { get; set; } // Condition of the game
            public GameStatus Status { get; set; }  // Status of availiblty in storage 

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

        // A list including All the games in storage
        public static List<Game> GetGamesList()
        {
            return new List<Game>
            {
            // Sequence
            new Game { Title = Sequence , Genre =  , BasePrice = 150m , Condition = GameCondition.Good, 2},
            new Game { Title = , Genre = , BasePrice = , Condition = GameCondition. },
            new Game { Title = , Genre = , BasePrice = , Condition = GameCondition. },
            new Game { Title = , Genre = , BasePrice = , Condition = GameCondition. },
            new Game { Title = , Genre = , BasePrice = , Condition = GameCondition. },
            new Game { Title = , Genre = , BasePrice = , Condition = GameCondition. },
            new Game { Title = , Genre = , BasePrice = , Condition = GameCondition. },

            }
        }
     
    

        public static void AddGame(List<Game> gamesList, string title, string genre, decimal price, GameCondition condition, int count, int numberofplayers)
        {
            for (int i = 0; i < count; i++)
            {
                gamesList.Add(new Game { Title = title, Genre = genre, BasePrice = price, Condition = condition, NumberOfPlayers = numberofplayers })
            }
        }


    }
}

