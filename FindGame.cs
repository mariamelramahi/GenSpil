using System;
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
            var result = new string[searchTerm.Length];
            var j = 0;

            Console.WriteLine("\n\nSøgeresultat: \n");

            for (int i = 0; i < searchTerm.Length; i++)
            {
                if (searchTerm[i].Contains(searchName))
                {
                    result[j] = searchTerm[i];
                    j++;

                    foreach (string term in result)
                    {
                        Console.WriteLine("Navn: {0}\nAntal spillere: {1}\nAntal på lager: {2}\nStand: {3}\n", name[i], players[i], amount[i], condition[i]);
                        break;
                    }
                }
                continue;
            }
        }
    }
}
