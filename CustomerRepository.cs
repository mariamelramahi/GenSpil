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
        public List<Customer> Customers = new List<Customer>();

        public void Write()
        {
            string content = "";
            string content2 = "";
            foreach (var item in Customers)
            {
                content += item.Serialize() + "\n";
                content2 += item.Serialize() + "\n";
            }
            if (!File.Exists(path))
            {
                File.WriteAllText(path, content);//laver en ny fil og skrive listeelementerne op, alt på en ny linje
            }
            else
            {            
                File.AppendAllText(path, content2);
            }
                
            
        }
        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }
    }
}
