using System.Collections.Generic; 
namespace Genspil
{
    public class Program
    {
        public static RequestRepository requestRepository = new RequestRepository();
        public static CustomerRepository customerRepository = new CustomerRepository();

        static void Main(string[] args)
        {
            customerRepository.CustomerToArray(); 
            customerRepository.FindCustomer();
            AddCustomer();
            customerRepository.Write();
            AddRequest();
            requestRepository.Write();
            Console.WriteLine("exit");
            Console.ReadKey();

            
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
            Console.WriteLine("Farvel");
        }

        public static Customer AddCustomer() 
        {
            Console.Write("Indtast venligst fornavn: ");
            string name1 = Console.ReadLine();
            Console.Write("Indtast venligst efternavn: ");
            string lastname = Console.ReadLine();
            Console.Write("Indtast venligst emailadresse: ");
            string emailadress1 = Console.ReadLine();
            Console.Write("Indtast venligst telefonnummer: ");
            string phonenumber1 = Console.ReadLine();
            
            Customer customer = new Customer(name1, lastname, emailadress1, phonenumber1);
            

            customerRepository.AddCustomer(customer);
            
            return customer;
        }
        public static Request AddRequest()
        {
            Console.WriteLine("Vil du søge efter eksisterende kunde (1), eller oprette en ny kunde? (2): ");
            int answer = int.Parse(Console.ReadLine());
            Customer customer; //findes en variabel af typen Customer som vi kalder for customer. Den har foreløpig ingen værdi, så den har værdien null implicit. 
            if (answer == 1)
            {
               customer = AddCustomer();
            }
            else if (answer == 2)
            {
                customer = AddCustomer();
            }
            else
            {
                Console.WriteLine("Ugyldigt input, prøv igen: ");
                return AddRequest();//rekursivt kald 
            }
            Console.WriteLine("Indtast navn på spil: ");
            string gamename = Console.ReadLine();
            Request Request = new Request(gamename, customer);

            requestRepository.AddRequest(Request);
          
            return Request;      
        }
        ////public Customer FindCustomer()
        ////{
        ////    Console.WriteLine("Indtast kundenavn du vil søge efter: ");
        ////    string customer = Console.ReadLine(); 


        ////    return new Customer(customer, customer, customer, customer);//skal erstattes med rigitg søgekald fra kundeliste
        ////}
    }
}
