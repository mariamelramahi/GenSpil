

namespace Genspil
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

     
        
        public Customer (string firstName, string lastName, string emailAddress, string phoneNumber) 
        {
            this.FirstName = firstName;
            this.LastName = lastName; 
            this.EmailAddress = emailAddress;   
            this.PhoneNumber = phoneNumber;
        }
        //public void AddCustomerToList()
        //{
        // List <Customer> customers = new List <Customer> ();
        //    customers.Add(new Customer("Soren", "Ravn", "something@gmail.com", "+4512345678"));

        //    foreach (Customer customer in customers)
        //    {
        //        Console.WriteLine(customer.);
        //    }
        //}
       
        public string Serialize()
        {
            return FirstName + ";" + LastName + ";" + EmailAddress + ";" + PhoneNumber;
        }
        //lave et loop over mit customer liste og skrive linjer
        public override string ToString()
        {
            return Serialize();
        }

    }
    
}
