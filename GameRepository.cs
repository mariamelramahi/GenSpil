using System;
using System.IO;

namespace Genspil
{
    public class DataHandler
    {
        // File name to store game data
        public string DataFileName { get; }

        // Constructor to intialize DataFileName
        public DataHandler(string dataFileName)
        {
            DataFileName = dataFileName;
        }

        // Method to save games to a file 
        public void SaveGames(GameStorage.GameInfo[] games)
        {
            string filename = DataFileName;

            try
            {
                // Open a StreamWriter to write to the file
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    // Iterate trough each game and write its properties to a line in the file
                    foreach (var game in games )
                    {
                        // Format of the properties
                        string line = $"{game.Title};{game.Edition};{game.BasePrice};{game.Genre};{game.NumberOfPlayers};{game.Condition};{game.Status}" ;
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
        private GameStorage.GameInfo[] LoadGames()
        {
            string filename = DataFileName;
            try
            {
                // Check if the file exists 
                if (!filename.Exists(filename))
                {
                    throw new FileNotFoundException("Data File does not exist.");
                }

                var games = new List<GameStorage.GameInfo>();

                // Open a streamreader to read from the file
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    // read each line from the file
                    while ((line = reader.ReadLine()) != null)
                    {
                        // spilts the line by semicolons to extract game properties
                        string[] parts = line.Split(';');
                        // create a new gameinfo object using the extracted properties
                        var game = new GameStorage.GameInfo(
                            parts[0],   // Title
                            parts[1],   // Edition
                            decimal.Parse(parts[2]),  // BasePrice 
                            parts[3],   // Genre
                            int.Parse(parts[4],   // NumberOfPlayers
                            (GameStorage.GameCondition)Enum.Parse(typeof(GameStorage.GameCondition), parts[5]),  //  GameConditon
                            (GameStorage.GameStatus)Enum.Parse(typeof(GameStorage.GameStatus), parts[6])  // GameStatus
                        );

                        // Add the game to the list of games 
                        games.Add(game);
                    }
                }
                // convert to the list of games to an array and return
                return games.ToArray();

            }

            catch (Exception exp)
            {
                // if an exception occurs during loading, print the error message 
                Console.WriteLine($"Error while loading games: {exp.Message}");
            }

            return null; // return null if an exception occurs 
        }



    }
}
