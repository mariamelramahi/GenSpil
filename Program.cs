using System.Collections.Generic; 
namespace Genspil
{
    public class Program
    {
        public static CustomerRepository customerRepository = new CustomerRepository();
        public static RequestRepository requestRepository = new RequestRepository(customerRepository); //starter med at kalde dem for at lave repositories som kan bruges i programmet
       

        static void Main(string[] args)
        {

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
                int selection = menu.SelectMenuItem();
                Console.WriteLine("\n  Du har valgt at " + selection);



                string answer = menu.GetAnswer(selection);

                Console.WriteLine(answer);
                Console.WriteLine("\n  Vil du prøve igen? Tryk på hvilket som helst tal efterfulgt af enter. Tryk 0 for at afslutte");
                int answer2 = int.Parse(Console.ReadLine());

                Console.Clear();

                if (answer2 == 0)
                {
                    keeprunning = false;
                }
            }
            while (keeprunning);
            requestRepository.SaveRequests();
            customerRepository.SaveCustomers();
            Console.WriteLine("Farvel");
        }

       
        
        
    }
}
