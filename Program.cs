using System.Collections.Generic;


namespace Genspil
{
    public class Program
    {
        public static CustomerRepository customerRepository = new CustomerRepository();
        public static RequestRepository requestRepository = new RequestRepository(customerRepository); //starter med at kalde dem for at lave repositories som kan bruges i programmet
        public static GameRepository gameRepository = new GameRepository(); 

        static void Main(string[] args)
        {         
            bool keeprunning = true;
            do
            {
                Menu menu = new Menu("Velkommen til Genspils lagerbeholdning, du har nu følgende valgmulihgeder: ");
                menu.AddMenuItem("Søge efter et spil på lageret", " søge efter spil på lageret\n");
                menu.AddMenuItem("Tilføje nyt spil til lagerbeholdningen", " tilføje et nyt spil til lagerbeholdninen\n");
                menu.AddMenuItem("Lave vareoptælling", " lave vareoptælling\n");
                menu.AddMenuItem("Opret ny kunde", " oprette en ny kunde\n");
                menu.AddMenuItem("Opret ny forespørgsel på et spil", " opprette en ny forespørgsel på et spil\n");
                menu.AddMenuItem("Se hvilke forespørgsler på spil der ligger i systemet: ", " se hvilke forespørgsler på spil der ligger i systemet\n");
                menu.AddMenuItem("Se eksisterende kunder", " se eksisterende kunder\n");
                menu.Show();
                Console.WriteLine("  \nVælg noget fra menuen: ");
                int selection = menu.SelectMenuItem();
                Console.Write("\nDu har valgt at ");
                string answer = menu.GetAnswer(selection);
                Console.WriteLine(answer);

                switch (selection)
                { 
                    case 1:
                        {
                            Console.WriteLine("Hvilket spil vil du gerne søge efter? ");
                            string gameSearch = Console.ReadLine();
                            FindGame.Search(gameSearch, gameRepository.LoadGames());
                            break;
                        }
                    case 2:
                        //Tilføje nyt spil til lagerbeholdningen 
                        break; 
                    case 3:
                        //lave vareoptælling
                        break;
                    case 4:
                        customerRepository.AddCustomer();//opretter ny kunde
                        break;
                    case 5:
                        requestRepository.AddRequests();//opretter ny forespørgsel
                        break;
                    case 6:
                        
                        requestRepository.ShowRequests();//viser hvilke requests som allerede er opprettet
                        break;
                    case 7:
                        customerRepository.ShowCustomers();
                        break; 
                }

                
                Console.WriteLine("\nVil du fortsætte? Tryk på hvilket som helst tal efterfulgt af enter. Tryk 0 efterflygt af enter for at afslutte: ");
                int answer2 = int.Parse(Console.ReadLine());

                Console.Clear();

                if (answer2 == 0)
                {
                    keeprunning = false;
                }
                else if (answer2 == 1)
                {
                    Console.Write("Indtast navn på spillet, du søger: ");

                    string searchName = Console.ReadLine();
                    //FindGame.Search(searchName);

                    Console.Write("Søg igen (Nej: 1/Ja: 2): ");

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
                                Console.Write("Indtast navn på spillet, du søger: ");
                                searchName = Console.ReadLine();
                               // FindGame.Search(searchName);

                                Console.Write("Søg igen (Nej: 1/Ja: 2): ");
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
        }

       
        
        
    }
}
