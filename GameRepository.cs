using System;
using System.IO;
using System.Threading.Tasks;
using static Genspil.GameStorage;

namespace Genspil
{
    public class GameRepository
    {
        // File name to store game data
        public string DataFileName { get; }
        public List<GameInfo> Games { get; } = new List<GameInfo>();


        // Constructor to intialize DataFileName
        public GameRepository()
        {
            DataFileName = "GameStorage.txt";
            LoadGames();
        }


        // Method to save games to a file 
        public void SaveGames()
        {
            string filename = DataFileName;
            try
            {
                // Open a StreamWriter to write to the file
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    // Iterate trough each game and write its properties to a line in the file
                    foreach (var game in Games)
                    {
                        // Format of the properties
                        string line = $"{game.Title};{game.Edition};{game.BasePrice};{game.Genre};{game.NumberOfPlayers};{game.NumberOfGames};{game.Condition};{game.Status}";
                        // write the formatted line to the file 
                        writer.WriteLine(line);
                    }
                }
            }

            catch (Exception exp)
            {
                // if an exception occurs during writing, print the error message 
                Console.WriteLine($"Error while saving games: {exp.Message}");
            }
        }

        // Method to load games from a file 
        public List<GameInfo>? LoadGames()
        {
            string filename = DataFileName;
            try
            {
                // Check if the file exists 
                if (!File.Exists(filename))
                {
                    throw new FileNotFoundException("Data File does not exist.");
                }

                var games = new List<GameStorage.GameInfo>();

                // Open a streamreader to read from the file
                using (StreamReader reader = new StreamReader(filename))
                {
                    string? line;
                    // read each line from the file
                    while ((line = reader.ReadLine()) != null)
                    {
                        // spilts the line by semicolons to extract game properties
                        string[] parts = line.Split(';');
                        // create a new gameinfo object using the extracted properties
                        var game = new GameInfo(
                            parts[0],   // Title
                            parts[1],   // Edition
                            decimal.Parse(parts[2]),  // BasePrice 
                            parts[3],   // Genre
                            int.Parse(parts[4]),   // NumberOfPlayers
                            int.Parse(parts[5]),
                            (GameStorage.GameCondition)Enum.Parse(typeof(GameStorage.GameCondition), parts[6]),  //  GameConditon
                            (GameStorage.GameStatus)Enum.Parse(typeof(GameStorage.GameStatus), parts[7])  // GameStatus
                        );

                        // Add the game to the list of games 
                        games.Add(game);
                    }
                }
                // return
                return games;

            }

            catch (Exception exp)
            {
                // if an exception occurs during loading, print the error message 
                Console.WriteLine($"Error while loading games: {exp.Message}");
            }

            return null; // return null if an exception occurs 
        }


        public void AddGame(string title, string edition, decimal basePrice, string genre, int numberOfPlayers, int numberOfGames, GameCondition condition, GameStatus status)
        {

            try
            {
                // create a new game
                var newGame = new GameInfo(title, edition, basePrice, genre, numberOfPlayers, numberOfGames, condition, status);
                // Add the new game to the list 
                Games.Add(newGame);
            }

            catch (Exception exp)
            {
                Console.WriteLine($"Error while adding game: {exp.Message}");
            }
        }

   

        public void DisplaySortedGames(string sortBy)
        {
            List<GameInfo> games;

            if (Games != null && Games.Any())
            {
                // sort the games based on the selected criteria
                switch (sortBy.ToLower())
                {
                    case "title":
                        games = Games.OrderBy(g => g.Title).ToList();
                        break;
                    case "genre":
                        games = Games.OrderBy(g => g.Genre).ToList();
                        break;
                    default:
                        Console.WriteLine("Invalid sorting criteria. Plrase choose title or genre. ");
                        return;
                }

                // Display the sorted games
                Console.WriteLine("Sorted Games:");
                foreach (var game in games)
                {
                    Console.WriteLine ($"Title: {game.Title}, Genre: {game.Genre}");
                }
            }

            else
            {
                Console.WriteLine("No games found.");
            }
            
           
        }
        public void Search()
        {
            bool keepRunning = true;
            do
            {
                string searchName = Program.GetUserInput("Simpel søgning \nDu kan søge efter titel, genre, pris, antal spillere, stand: ").ToLower();

                List<GameInfo> results = new List<GameStorage.GameInfo>();
                Console.WriteLine("\n\nSearch Result: \n");
            
                try
                {
                    for (int i = 0; i < Games.Count; i++)
                    {
                        if (Games[i].Title.ToLower().Contains(searchName) 
                            || Games[i].BasePrice.ToString().ToLower().Contains(searchName) 
                            || Games[i].Genre.Contains(searchName) 
                            || Games[i].NumberOfPlayers.ToString().ToLower().Contains(searchName) 
                            || Games[i].Condition.ToString().ToLower().Contains(searchName))
                        {
                            results.Add(Games[i]);
                        }
                    }
                    if (results.Count == 0)//tjekker om der faktisk er noget i listen ved at bruge count
                    {
                        string userInput = Program.GetUserInput("Det var desværre ingen spil der samsvarede med dit søg, tryk enter ");
                    }

                    foreach (var result in results)
                    { 
                        Console.WriteLine();
                        Console.WriteLine($"Title: {result.Title}");
                        Console.WriteLine($"Edition: {result.Edition}");
                        Console.WriteLine($"Base Price: {result.BasePrice:C}");
                        Console.WriteLine($"Genre: {result.Genre}");
                        Console.WriteLine($"Number of Players: {result.NumberOfPlayers}");
                        Console.WriteLine($"Number of Games: {result.NumberOfGames}");
                        Console.WriteLine($"Condition: {result.Condition}");
                        Console.WriteLine($"Status: {result.Status}");
                        Console.WriteLine(); // Add a blank line for readability
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Det er sket en fejl, prøv igen");
                    continue;
                }
                string answer = Program.GetUserInput("Vil du søge igen? (ja/nej): ");
                Console.WriteLine("---------------------------------------------------");
                Console.Clear();
                if (answer.ToLower() == "nej")
                {
                    keepRunning = false;
                }
            }
            while (keepRunning);

        }
        public void AdvancedSearch()
        {
            bool keepRunning = true;
            do
            {
                string? titel = Program.GetUserInputNullable("Avanceret søgning \nTast enter hvis du ikke ønsker at søge i pågældende felt \nIndtast titel: ");
                string? genre = Program.GetUserInputNullable("Indtast genre: ");
                string? price = Program.GetUserInputNullable("Indtast pris: ");
                string? numPlayers = Program.GetUserInputNullable("Indtast antal spillere: ");
                string? condition = Program.GetUserInputNullable("Indtast stand (New, Used, Good, Ok, Damaged): ");
            
                List<GameInfo> results = new List<GameInfo>();

                try
                {
                    for (int i = 0; i < Games.Count; i++)
                    {
                        //null betyder bare at det ikke er noget input fra brugeren og man vil ikke søge på dette felt
                        if ((titel == null || Games[i].Title.ToLower().Contains(titel.ToLower()))
                            && (genre == null || Games[i].BasePrice.ToString().ToLower().ToString().Contains(price.ToLower()))
                            && (price == null || Games[i].Genre.ToLower().Contains(genre.ToLower()))
                            && (numPlayers == null || Games[i].NumberOfPlayers.ToString().ToLower().Contains(numPlayers.ToLower()))
                            && (condition == null || Games[i].Condition.ToString().ToLower().Contains(condition.ToLower())))
                        {
                            results.Add(Games[i]);
                        }
                    }
                
                    if (results.Count == 0)
                    {
                        string userInput = Program.GetUserInput("Det var desværre ingen spil der samsvarede med dit søg, tryk enter");
                    }
                    foreach (var result in results)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Title: {result.Title}");
                        Console.WriteLine($"Edition: {result.Edition}");
                        Console.WriteLine($"Base Price: {result.BasePrice:C}");
                        Console.WriteLine($"Genre: {result.Genre}");
                        Console.WriteLine($"Number of Players: {result.NumberOfPlayers}");
                        Console.WriteLine($"Number of Games: {result.NumberOfGames}");
                        Console.WriteLine($"Condition: {result.Condition}");
                        Console.WriteLine($"Status: {result.Status}");
                        Console.WriteLine(); // Add a blank line for readability
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Det er sket en fejl, prøv igen");
                    continue;
                }
                string answer = Program.GetUserInput("Vil du søge igen? (ja/nej)");
                Console.WriteLine("---------------------------------------------------");
                Console.Clear();
                if (answer.ToLower() == "nej")
                {
                    keepRunning = false;
                }
               
            }
            while (keepRunning);
        }

    }

}