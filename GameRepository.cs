﻿using System;
using System.IO;
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
        public void SaveGames(List<GameInfo> games)
        {
            string filename = DataFileName;

            try
            {
                // Open a StreamWriter to write to the file
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    // Iterate trough each game and write its properties to a line in the file
                    foreach (var game in games)
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
                // Save the updated game to the file
                SaveGames(Games);
            }

            catch (Exception exp)
            {
                Console.WriteLine($"Error while adding game: {exp.Message}");
            }
        }

   

        public void DisplaySortedGames(string sortBy)
        {
            var games = LoadGames();

            if (games != null && games.Any())
            {
                // sort the games based on the selected criteria
                switch (sortBy.ToLower())
                {
                    case "title":
                        games = games.OrderBy(g => g.Title).ToList();
                        break;
                    case "genre":
                        games = games.OrderBy(g => g.Genre).ToList();
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

    }

}