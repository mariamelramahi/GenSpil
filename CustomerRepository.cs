using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    public class CustomerRepository
    {
        private readonly string path = @"C:\temp\customers1.txt";//betyder at ingen andre kan sætte en anden værdi på contenstringen
        //private string contents = "Hello\nWorld";
        public List<Customer> Customers = new List<Customer>();

        public void Write()
        {
            string content = "";
            foreach (var item in Customers)
            {
                content += item.Serialize() + "\n";
            }
            if (!File.Exists(path))
            {
                File.WriteAllText(path, content);//laver en ny fil og skrive listeelementerne op, alt på en ny linje
            }
            else
            {
                Console.WriteLine($"The file {path} already exists");
            }
        }
        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }
    }
}
