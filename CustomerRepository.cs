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
        public string DataFileName { get; }
        public List<Customer> Customers = new List<Customer>();

        public CustomerRepository()//constructor instantiating non-null property
        {
            DataFileName = "Customers.txt";
            LoadCustomers();//læser de kunder der allerede findes i filen ind
        }
        public void SaveCustomers()
        {
            string filename = DataFileName;
            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    foreach (var customer in Customers)
                    {
                        writer.WriteLine(customer.Serialize());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }           
        }
        public void LoadCustomers()
        {
            string filename = DataFileName;
            try
            {
                using(StreamReader reader = new StreamReader(filename))
                {
                    string line;
                 
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] c = line.Split(';');
                        Customer c2 = new Customer(c[0], c[1], c[2], c[3]);
                        Customers.Add(c2);                       
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public Customer FindCustomer()
        {
            Console.WriteLine("Tryk hvilken som helst tast efterfulgt af enter for at få kunder frem: ");
            string customer = Console.ReadLine();
            int i = 0;
            string filename = DataFileName;
            foreach (string line in File.ReadAllLines(filename))
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
        public Customer AddCustomer()//en public metode som tilfæjer en Customer fra konsolinput til repository og returnerer den
        {
            Console.Write("Indtast venligst fornavn: ");
            string firstname = Console.ReadLine();
            Console.Write("Indtast venligst efternavn: ");
            string lastname = Console.ReadLine();
            Console.Write("Indtast venligst emailadresse: ");
            string emailadress = Console.ReadLine();
            Console.Write("Indtast venligst telefonnummer: ");
            string phonenumber = Console.ReadLine();

            Customer customer = new Customer(firstname, lastname, emailadress, phonenumber);
            
            Customers.Add(customer);//tilføjer kunden til repositoriets liste

            return customer;//returnerer kunden så vi kan bruge den til vores request
        }

        public Customer? FindByName(string firstname, string lastname)
        {
            foreach (Customer customer in Customers)
            {
                if (firstname == customer.FirstName && lastname == customer.LastName)
                {
                    return customer;
                }
            }
            return null;
        }
    }
}
