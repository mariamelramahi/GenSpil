
namespace Genspil
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Menu menu = new Menu(new MenuItem[] { new MenuItem("Gør dit"), new MenuItem("Gør dat"), new MenuItem("Gør noget"), new MenuItem("Få svaret på livet, universet og alting") });
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

        public Customer AddCustomer() 
        {
            Console.Write("Indtast venligst navn: ");
            string name1 = Console.ReadLine();
            Console.WriteLine("Indtast venligst emailadresse: ");
            string emailadress1 = Console.ReadLine();
            Console.WriteLine("Indtast venligst telefonnummer: ");
            string phonenumber1 = Console.ReadLine();


            Customer Customer = new Customer(name1, emailadress1, phonenumber1);
            return Customer;
        }
        public Request AddRequest()
        {
            Console.WriteLine("Vil du søge efter eksisterende kunde (1), eller oprette en ny kunde? (2): ");
            int answer = int.Parse(Console.ReadLine());
            if (answer == 1)
            {

            }
            else if (answer == 2)
            {
                AddCustomer();
            }
            else
            {
                Console.WriteLine("Ugyldigt input, prøv igen: ");
                AddRequest();
            }
            Console.WriteLine("Indtast navn på spil: ");
            string gamename = Console.ReadLine();


            Request Request = new Request(gamename, customer);
            return Request; 
        }
        public Customer FindCustomer(string name)
        {

        }
    }
}
