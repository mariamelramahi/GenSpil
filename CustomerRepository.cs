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
        public void CustomerToArray()  
        {
            string[] customerArray = File.ReadLines(@"C:\temp\customers1.txt").ToArray();

            foreach (var customer in customerArray) 
            { 
            Console.WriteLine("Dette er en kunde: " + customer);
                
            }
        }
        public Customer FindCustomer()
        {
            Console.WriteLine("Tryk hvilken som helst tast efterfulgt af enter for at få kunder frem: ");
            string customer = Console.ReadLine();
            int i = 0;
            
            foreach (string line in File.ReadAllLines(path))
            {
                string[] parts = line.Split(';');
                foreach (string part in parts)
                {
                    Console.WriteLine("{0}:{1}", i, part);
                }
                i++; // For demonstration.
            }

            //if(customer== parts)
            //{Console.WriteLine(customer + " findes i systemet")
            return new Customer(customer, customer, customer, customer);//skal erstattes med rigitg søgekald fra kundeliste
        }
    }
}
