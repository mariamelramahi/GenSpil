using System.Collections.Generic; 
namespace Genspil
{
    public class Program
    {
        //Mangler Vareoptælling
        //Class Game repository er der mange fejl. Ved ikke hvorfor.

        public static CustomerRepository customerRepository = new CustomerRepository();
        public static RequestRepository requestRepository = new RequestRepository(customerRepository); //starter med at kalde dem for at lave repositories som kan bruges i programmet
        


        static void Main(string[] args)
        {

            GameStorage.GameData gameData = new GameStorage.GameData();
            customerRepository.LoadCustomers(); //loader filen med kunder, således at vi har de eksisterende kunder i repositoriet
                      
            bool keeprunning = true;
            do
            {

                Menu menu = new Menu(" Velkommen til Genspils lagerbeholdning, du har nu følgende valgmulihgeder: ");
                menu.AddMenuItem("Søge efter et spil på lageret", "1");
                menu.AddMenuItem("Tilføje nyt spil til lagerbeholdningen", "2");
                menu.AddMenuItem("Lave vareoptælling", "3");
                menu.AddMenuItem("Opret ny kunde", "42");
                menu.Show();
                Console.WriteLine("  \nVælg noget fra menuen: ");
                string answer = Console.ReadLine();


                int selection = menu.SelectMenuItem();
                Console.WriteLine("Du har valgt " + selection);

                switch (answer)
                {
                    case "1":
                        Console.Write("skriv titlen på det spil du søger efter. (Husk at skrive med stort forbogstav): ");
                        string titel = Console.ReadLine();
                        FindGame.Search(titel, gameData);
                        break;

                    case "2":
                        addNewGame();
                        break;

                    case "3":

                    case "4":
                        Customer newCustomer = customerRepository.AddCustomer();
                        break;

                }


                //string answer = menu.GetAnswer(selection);

                Console.WriteLine(answer);
                Console.WriteLine("Søg igen? (1)Nej (2)Ja (3)Afslut");
                int answer2 = int.Parse(Console.ReadLine());

                Console.Clear();

                if (answer2 == 3)
                {
                    keeprunning = false;
                }
                else if (answer2 == 2)
                {
                    Console.Write("skriv titlen på det spil du søger efter. (Husk at skrive med stort forbogstav): ");
                    string titel = Console.ReadLine();
                    FindGame.Search(titel, gameData);
                    

                    Console.Write("Søg igen? (1)Nej (2)Ja ");

                    while (true)
                    {
                        try
                        {
                            int svar = int.Parse(Console.ReadLine());
                            if (svar == 1)
                            {
                                Console.WriteLine("Tryk på en vilkårlig tast for at gå tilbage til menuen.");
                                //menu.Show();
                                break;
                            }
                            else if (svar == 2)
                            {
                                Console.Write("skriv titlen på det spil du søger efter. (Husk at skrive med stort forbogstav): ");
                                string titel2 = Console.ReadLine();
                                FindGame.Search(titel2, gameData);
                                

                                Console.Write("Søg igen? (1)Nej (2)Ja: ");
                            }
                            else { Console.Write("Ugyldigt input. Prøv igen (Nej: 1/Ja: 2): "); }
                        }
                        catch (Exception ex) { Console.Write("Input er i et ugyldigt format. Prøv igen (Nej: 1/Ja: 2): "); }

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

                Console.WriteLine("Titel: ");
                string title = Console.ReadLine();

                Console.WriteLine("Udgave: ");
                string edition = Console.ReadLine();

                Console.WriteLine("Basepris: ");
                decimal basePrice;
                while (!decimal.TryParse(Console.ReadLine(), out basePrice))
                {
                    Console.WriteLine("Ugyldig input. Tast et nummer");
                }

                Console.WriteLine("Genre: ");
                string genre = Console.ReadLine();

                Console.WriteLine("Antal spillere: ");
                int numberOfPlayers;
                while (!int.TryParse(Console.ReadLine(), out numberOfPlayers))
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
                GameStorage.GameManager.AddGame(title, edition, basePrice, genre, numberOfPlayers, conditionChoice, status);

                // Viser det nye spil der er tilføjet. 
                GameStorage.GameManager.DisplayInventory();

                //Mullighed for at fortsætte med at tilføje spil eller vende tilbage til hovedemenu. 
                Console.WriteLine("Vælg: 1.Tilføj et nyt spil igen \n 2.Vende tilbage til hovedemenu. ");
                string answer = Console.ReadLine();


            }
        }

       
        
        
    }
}
