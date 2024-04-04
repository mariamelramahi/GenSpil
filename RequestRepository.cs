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
        public CustomerRepository CustomerRepository;
        
        public RequestRepository(CustomerRepository customerRepository) 
        {
            this.CustomerRepository = customerRepository;
            LoadRequests();
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
        
        public void LoadRequests()
        {
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line; 
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] data = line.Split(';');
                        Customer customer = CustomerRepository.FindByName(data[1], data[2]);
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
        public Request AddRequests()
        {
            Console.WriteLine("Vil du søge efter eksisterende kunde (1), eller oprette en ny kunde? (2): ");
            int answer = int.Parse(Console.ReadLine());
            Customer customer; //findes en variabel af typen Customer som vi kalder for customer. Den har foreløpig ingen værdi, så den har værdien null implicit. 
            if (answer == 1)
            {
                Console.Write("Indtast fornavn: ");
                string firstname = Console.ReadLine();
                Console.Write("Indtast efternavn: ");
                string lastname = Console.ReadLine();
                customer = CustomerRepository.FindByName(firstname, lastname);
                if (customer == null)
                {
                    Console.WriteLine("Kunde ikke fundet");
                    return AddRequests();
                }
            }
            else if (answer == 2)
            {
                customer = CustomerRepository.AddCustomer();
            }
            else
            {
                Console.WriteLine("Ugyldigt input, prøv igen: ");
                return AddRequests();//rekursivt kald 
            }
            Console.Write("Indtast navn på spil: ");
            string title = Console.ReadLine();
            Request request = new Request(title, customer);

            Requests.Add(request);

            return request;
        }
        public void ShowRequests()
        {
            Request.PrintToUserHeader();
            foreach (Request request in Requests)
            {
                Console.WriteLine(request.PrintToUser());
            }
        }

    }

}
