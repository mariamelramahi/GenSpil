using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Genspil
{
    internal class FindGame
    {
        public static void Search(string searchName, List<GameStorage.GameInfo> games )
        {
            List<GameStorage.GameInfo> results = new List<GameStorage.GameInfo>();
            Console.WriteLine("\n\nSearch Result: \n");
            for (int i = 0; i < games.Count; i++)
            {
                if (games[i].Title.Equals(searchName))
                {                    
                    results.Add(games[i]);                    
                }
            }

            foreach (var result in results)
            {
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
    }

}
