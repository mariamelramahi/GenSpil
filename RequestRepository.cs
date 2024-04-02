using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    public class RequestRepository
    {
        
        private readonly string path = "Requests.txt";//betyder at ingen andre kan sætte en anden værdi på contenstringen
        //private string contents = "Hello\nWorld";
        public List<Request> Requests = new List<Request>();
        
        public RequestRepository(CustomerRepository customerRepository) 
        {
            LoadRequests(customerRepository);
        }
        public void SaveRequests()
        {
            try
            {
                using(StreamWriter writer = new StreamWriter(path))
                {
                    foreach(Request request in Requests)
                    {
                        writer.WriteLine(request.Serialize());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        public void LoadRequests(CustomerRepository customerRepository)
        {
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line; 
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] data = line.Split(';');
                        Customer customer = customerRepository.FindByName(data[1], data[2]);
                        Request request = new Request(data[0], customer);
                        Requests.Add(request);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public Request AddRequests(CustomerRepository cr)
        {
            Console.WriteLine("Vil du søge efter eksisterende kunde (1), eller oprette en ny kunde? (2): ");
            int answer = int.Parse(Console.ReadLine());
            Customer customer; //findes en variabel af typen Customer som vi kalder for customer. Den har foreløpig ingen værdi, så den har værdien null implicit. 
            if (answer == 1)
            {
                Console.WriteLine("Indtast fornavn: ");
                string firstname = Console.ReadLine();
                Console.WriteLine("Indtast efternavn: ");
                string lastname = Console.ReadLine();
                customer = cr.FindByName(firstname, lastname);
                if (customer == null)
                {
                    Console.WriteLine("Kunde ikke fundet");
                    return AddRequests(cr);
                }
            }
            else if (answer == 2)
            {
                customer = cr.AddCustomer();
            }
            else
            {
                Console.WriteLine("Ugyldigt input, prøv igen: ");
                return AddRequests(cr);//rekursivt kald 
            }
            Console.WriteLine("Indtast navn på spil: ");
            string title = Console.ReadLine();
            Request request = new Request(title, customer);

            Requests.Add(request);

            return request;
        }
    }

}
