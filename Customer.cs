

namespace Genspil
{
    public class Customer
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }


        
        public Customer (string name, string emailAddress, string phoneNumber) 
        {
            this.Name = name;
            this.EmailAddress = emailAddress;   
            this.PhoneNumber = phoneNumber;
        }
        
    }
    
}
