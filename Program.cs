using System.Collections.Generic; 
namespace Genspil
{
    public class Program
    {
        //Mangler Vareoptælling
        //Class Game repository er der mange fejl. Ved ikke hvorfor.

        public static CustomerRepository customerRepository = new CustomerRepository();
        public static RequestRepository requestRepository = new RequestRepository(customerRepository); //starter med at kalde dem for at lave repositories som kan bruges i programmet
        public static DataHandler dataHandler = new DataHandler();


        static void Main(string[] args)
        {

            GameStorage.GameData gameData = new GameStorage.GameData();
                      
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
                menu.Show();

                string answer = GetUserInput("  \nVælg noget fra menuen: ");

                switch (answer)
                {
                    case "1":
                        string titel = GetUserInput("skriv titlen på det spil du søger efter. (Husk at skrive med stort forbogstav): ");
                        FindGame.Search(titel, gameData);
                        break;

                    case "2":
                        addNewGame();
                        break;

                    case "3":
                        //lave vareoptælling
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

                }


                //string answer = menu.GetAnswer(selection);

                Console.WriteLine(answer);
                int answer2 = int.Parse(GetUserInput("Søg igen? (1)Nej (2)Ja (3)Afslut"));

                Console.Clear();

                if (answer2 == 3)
                {
                    keeprunning = false;
                }
                else if (answer2 == 2)
                {
                    string titel = GetUserInput("skriv titlen på det spil du søger efter. (Husk at skrive med stort forbogstav): ");
                    FindGame.Search(titel, gameData);
                    

                    while (true)
                    {
                        try
                        {
                            int svar = int.Parse(GetUserInput("Søg igen? (1)Nej (2)Ja "));
                            if (svar == 1)
                            {
                                Console.WriteLine("Tryk på en vilkårlig tast for at gå tilbage til menuen.");

                                break;
                            }
                            else if (svar == 2)
                            {
                                string titel2 = GetUserInput("skriv titlen på det spil du søger efter. (Husk at skrive med stort forbogstav): ");
                                FindGame.Search(titel2, gameData);
                            }
                            else { Console.Write("Ugyldigt input. Prøv igen (Nej: 1/Ja: 2): "); }
                        }
                        catch (Exception ex) 
                        { 
                            Console.WriteLine("Error: " +  ex.Message);
                            Console.Write("Input er i et ugyldigt format. Prøv igen (Nej: 1/Ja: 2): "); 
                        }

                    }




                }
            }




            while (keeprunning);
            requestRepository.SaveRequests();
            customerRepository.SaveCustomers();
            Console.WriteLine("Farvel");

            //TILFØJE NYT SPIL//

            static void addNewGame()
            {
                GameStorage.GameManager gameManager = new GameStorage.GameManager();

                string title = GetUserInput("Titel: ");
                string edition = GetUserInput("Udgave: ");
                Console.WriteLine("Basepris: ");

                decimal basePrice;
                while (!decimal.TryParse(Console.ReadLine(), out basePrice))
                {
                    Console.WriteLine("Ugyldig input. Tast et nummer");
                }
                string genre = GetUserInput("Genre");

                Console.WriteLine("Antal spillere: ");
                int numberOfPlayers;
                while (!int.TryParse(Console.ReadLine(), out numberOfPlayers))
                {
                    Console.WriteLine("Ugyldig input. Tast et nummer");
                }

                Console.WriteLine("Antal spil: ");
                int numberOfGames;
                while (!int.TryParse(Console.ReadLine(), out numberOfGames))
                {
                    Console.WriteLine("Ugyldig input. Tast et nummer");
                }

                Console.WriteLine("Tilstand (tast et nummer): 1.New 2.Used, 3.Good, 4.Ok, 5.Damaged): ");
                int conditionChoice;

                //Tager det fra class "games", og gir condition for spillet ud fra det nummer man indtaster. 
                while (!int.TryParse(Console.ReadLine(), out conditionChoice) || conditionChoice < 1 || conditionChoice > 5)
                {
                    Console.WriteLine("Ugyldigt valg. Vælg venligst et gyldigt tilstand.");
                    Console.Write("Vælg tilstand (indtast nummer): ");
                }

                //Tager det fra class "games", og gir status for spillet ud fra det nummer man indtaster.

                Console.WriteLine("Status (tast et nummer): 1.Available, 2.Reserved, 3.OnItsWay, 4.WaitList ");
                int statusChoice;
                while (!int.TryParse(Console.ReadLine(), out statusChoice) || statusChoice < 1 || statusChoice > 4)
                {
                    Console.WriteLine("Ugyldigt valg. Vælg venligst et gyldigt status.");
                    Console.Write("Vælg status (indtast nummer): ");
                }

                // konverter conditionChoice til GameCondition enum
                GameStorage.GameCondition condition = (GameStorage.GameCondition)(conditionChoice - 1);

                // konverter statusChoice til GameStatus enum
                GameStorage.GameStatus status = (GameStorage.GameStatus)statusChoice - 1;

                // Tilføjer det nye spil ved at bruge GameManager
                GameStorage.GameManager.AddGame(title, edition, basePrice, genre, numberOfPlayers, numberOfGames, conditionChoice, status);

                // Viser det nye spil der er tilføjet. 
                GameStorage.GameManager.DisplayInventory();

                //Mullighed for at fortsætte med at tilføje spil eller vende tilbage til hovedemenu. 
                string answer = GetUserInput("Vælg: 1.Tilføj et nyt spil igen \n 2.Vende tilbage til hovedemenu. ");


            }
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
        public static string GetUserInput2()
        {
            string? result = Console.ReadLine();
            if (result != null)
            {
                return result;
            }
            else
            {
                Console.WriteLine("Ugyldigt input. Prøv igen: ");
                return GetUserInput2();
            }
        }


    }
}
