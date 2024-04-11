﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    internal class FindGame
    {
        public static void Search(string searchName)
        {

            GameRepository gameRepository = new GameRepository();
            List<GameStorage.GameInfo> games = gameRepository.Games;

            var result = new List<GameStorage.GameInfo>();

            Console.WriteLine("\n\nSearch Result: \n");

            foreach (var game in games)
            {
                if (game.Title.Contains(searchName))
                {
                    result.Add(game);
                }
            }

            if (result.Count == 0)
            {
                Console.WriteLine("No games found with the provided title.");
                return;
            }

            foreach (var game in result)
            {
                Console.WriteLine($"Title: {game.Title}");
                Console.WriteLine($"Edition: {game.Edition}");
                Console.WriteLine($"Base Price: {game.BasePrice:C}");
                Console.WriteLine($"Genre: {game.Genre}");
                Console.WriteLine($"Number of Players: {game.NumberOfPlayers}");
                Console.WriteLine($"Number of Games: {game.NumberOfGames}");
                Console.WriteLine($"Condition: {game.Condition}");
                Console.WriteLine($"Status: {game.Status}");
                Console.WriteLine(); // Add a blank line for readability
            }
        }
    }

}
