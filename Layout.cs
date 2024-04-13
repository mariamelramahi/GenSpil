using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace Genspil
{
    public class ArrowMenu
    {
        private List<string> menuItems;
        private int selectedIndex;
        private string title;

        public ArrowMenu(string title, List<string> items)
        {
            this.title = title;
            menuItems = items;
            selectedIndex = 0;
        }

        public int ShowMenu()
        {
            while (true)
            {
                Console.Clear(); // Clear the console before displaying the menu
                AnsiConsole.Write(
                    new FigletText(title).LeftJustified().Color(Color.Aquamarine1));
                DisplayMenu(selectedIndex);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true); // Read key without displaying it

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = Math.Max(0, selectedIndex - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        selectedIndex = Math.Min(menuItems.Count - 1, selectedIndex + 1);
                        break;
                    case ConsoleKey.Enter:
                        return selectedIndex;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private void DisplayMenu(int selectedIndex)
        {
            Console.WriteLine($"Velkommen til {title}, du har nu følgende valgmuligheder: ");
            for (int i = 0; i < menuItems.Count; i++)
            {
                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine($"{i + 1}. {menuItems[i]}");
                Console.ResetColor();
            }
        }
    }
}
