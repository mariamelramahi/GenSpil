using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    public class RequestRepository
    {
        
        private readonly string path = @"C:\temp\requests.txt";//betyder at ingen andre kan sætte en anden værdi på contenstringen
        //private string contents = "Hello\nWorld";
        public List<Request> Requests = new List<Request>();
    
        public void Write()
        {
            string content = "";

            foreach (var item in Requests)
            {
                content += item.Serialize() + "\n";
            }
            if (!File.Exists(path))
            {
                File.WriteAllText(path, content);//laver en ny fil og skrive listeelementerne op, alt på en ny linje
            }
            else
            {
                File.AppendAllText(path, content);
            }
        }
        public void AddRequest(Request request)
        {
            Requests.Add(request);
        }
        public void RequestToArray()
        {
            string[] requestArray = File.ReadLines(@"C:\temp\requests.txt").ToArray();

            foreach (var request in requestArray)
            {
                Console.WriteLine("Dette er en forespørgsel: " + request);

            }
        }
        public Request AddRequest(CustomerRepository cr)
        {
            Console.WriteLine("Vil du søge efter eksisterende kunde (1), eller oprette en ny kunde? (2): ");
            int answer = int.Parse(Console.ReadLine());
            Customer customer; //findes en variabel af typen Customer som vi kalder for customer. Den har foreløpig ingen værdi, så den har værdien null implicit. 
            if (answer == 1)
            {
                customer = cr.AddCustomer();
            }
            else if (answer == 2)
            {
                customer = cr.AddCustomer();
            }
            else
            {
                Console.WriteLine("Ugyldigt input, prøv igen: ");
                return AddRequest(cr);//rekursivt kald 
            }
            Console.WriteLine("Indtast navn på spil: ");
            string gamename = Console.ReadLine();
            Request Request = new Request(gamename, customer);

            AddRequest(Request);

            return Request;
        }
    }

}
