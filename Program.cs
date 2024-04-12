using System.Collections.Generic;


namespace Genspil
{
    public class Program
    {
        //starter med at kalde dem for at lave repositories som kan bruges i programmet
        public static CustomerRepository customerRepository = new CustomerRepository();
        public static RequestRepository requestRepository = new RequestRepository(customerRepository); 
        public static GameRepository gameRepository = new GameRepository();


        static void Main(string[] args)
        {
            
            
            GameRepository gameRepository = new GameRepository();
            // spil som vi kan søge efter
            gameRepository.AddGame("Chess", "Standard Edition", 80m, "Board", 2, 3, GameStorage.GameCondition.New, GameStorage.GameStatus.Available);
            gameRepository.AddGame("Monopoly", "Limited Edition", 90m, "Board", 4, 2, GameStorage.GameCondition.Used, GameStorage.GameStatus.OnItsWay);
            gameRepository.AddGame("Monopoly", "German Edition", 70m, "Board", 4, 1, GameStorage.GameCondition.Damaged, GameStorage.GameStatus.Reserved);
            gameRepository.AddGame("Bad People", "Standard Edition", 40m, "Card", 3, 4, GameStorage.GameCondition.Ok, GameStorage.GameStatus.Available);

            bool keeprunning = true;
            do
            {

                Menu menu = new Menu("Velkommen til Genspils lagerbeholdning, du har nu følgende valgmuligheder: ");
                menu.AddMenuItem("Søge efter et spil på lageret");
                menu.AddMenuItem("Tilføje nyt spil til lagerbeholdningen");
                menu.AddMenuItem("Lave vareoptælling");
                menu.AddMenuItem("Opret ny kunde");
                menu.AddMenuItem("Opret ny forespørgsel på et spil");
                menu.AddMenuItem("Se hvilke forespørgsler på spil der ligger i systemet: ");
                menu.AddMenuItem("Se eksisterende kunder");
                menu.AddMenuItem("Afslutte programmet");
                menu.Show();

                string answer = GetUserInput("  \nVælg noget fra menuen: ");

                switch (answer)
                {
                    case "1":
                        int simpel = Int32.Parse(GetUserInput("Vil du lave en simpel søgning eller avanceret? \n For simpel søgning tast 1, for avanceret søgning tast 2: "));
                        if (simpel == 1) 
                        {                   
                            gameRepository.Search();
                            break;
                        }
                        else if (simpel == 2)
                        {
                            gameRepository.AdvancedSearch();
                        }
                        break; 

                    case "2":
                        {

                            string title = GetUserInput("Indtast venligst titel: ");
                            string edition = GetUserInput("Indtast venligst edition: ");
                            string genre = GetUserInput("Indtast venligst genre: ");
                            Console.Write("Indtast venligst pris: ");
                            decimal basePrice;
                            decimal.TryParse(Console.ReadLine(), out basePrice);
                            Console.Write("Indtast venligst antal spillere: ");
                            int numberOfPlayers;
                            int.TryParse(Console.ReadLine(), out numberOfPlayers);
                            Console.Write("Indtast venligst hvor mange spil der er: ");
                            int numberOfGames;
                            int.TryParse(Console.ReadLine(), out numberOfGames);
                            Console.Write("Vælg condition: 0 = new, 1 = used, 2 = good, 3 = okay, 4 = damaged");
                            GameStorage.GameCondition condition;
                            Enum.TryParse(Console.ReadLine(), out condition);
                            Console.Write("Vælg gamestatus: 0 = Available, 1 = Reserved, 2 = On its way, 3 = Waitlist");
                            GameStorage.GameStatus status;
                            Enum.TryParse(Console.ReadLine(), out status);
                            gameRepository.AddGame(title, edition, basePrice, genre, numberOfPlayers, numberOfGames, condition, status);
                        }
                        break;

                    case "3":
                        {
                            Console.WriteLine("Enter the sorting criteria (title or genre):");
                            string sortBy = GetUserInput(Console.ReadLine().ToLower());

                            gameRepository.DisplaySortedGames(sortBy);                           
                           
                        }
                        break; 
                    case "4":
                        customerRepository.AddCustomer();
                        break;
                    case "5":
                        requestRepository.AddRequests();//opretter ny forespørgsel
                        break;
                    case "6":

                        requestRepository.ShowRequests();//viser hvilke requests som allerede er opprettet
                        break;
                    case "7":
                        customerRepository.ShowCustomers();
                        break;
                    case "8":
                        keeprunning = false;
                        break; 
                }              
            }

            while (keeprunning);
            requestRepository.SaveRequests();
            customerRepository.SaveCustomers();
            Console.WriteLine("Farvel");

        }

        public static string GetUserInput(string initialGreeting)
        {
            Console.Write(initialGreeting);
            string? result;
            while (true)
            {
                result = Console.ReadLine();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Ugyldigt input. Prøv igen: ");
                }
            }

        }
        public static string? GetUserInputNullable(string initialGreeting)
        {
            Console.Write(initialGreeting);
            return Console.ReadLine(); 
        }

    }
}
