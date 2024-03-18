
namespace Genspil
{
    public class Menu
    {
        public string Title;
        private MenuItem[] MenuItems = new MenuItem[0];
        private int ItemCount = 0;

        public Menu(string title)
        {
            this.Title = title;
        }

        public void Show()
        {
            Console.WriteLine($"{Title} \n");

            for (int i = 0; i < MenuItems.Length; i++)
            {
                Console.WriteLine($"  {i + 1}. {MenuItems[i].Title}");
            }
        }

        public string GetAnswer(int selection)
        {
            MenuItem menuItem = MenuItems[selection - 1];
            return menuItem.Answer;
        }
        public void AddMenuItem(string title, string Answer)
        {
            MenuItem menuItem = new MenuItem(title, Answer);
            MenuItems = MenuItems.Concat(new MenuItem[] { menuItem }).ToArray();
            ItemCount = MenuItems.Length;
        }

        public int SelectMenuItem()
        {
            while (true)
            {
                try
                {
                    int choice = int.Parse(Console.ReadLine());
                    if (choice <= ItemCount && choice >= 0)
                    {
                        return choice;
                    }
                    else
                    {
                        Console.WriteLine("Dette er vidst ikke på menuen, prøv igen: ");
                        return SelectMenuItem();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ugyldigt input, prøv igen: ");
                    return SelectMenuItem();
                }

            }
        }


    }
}
