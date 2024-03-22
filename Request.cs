

using System.Net.Mail;

namespace Genspil
{
    public class Request
    {
        public string GameName { get; set; }
        public Customer Customer {  get; set; }

        public Request(string name, Customer customer)
        {
            this.GameName = name;
            this.Customer = customer; 
            
        }
        public string Serialize()
        {
            return GameName + ";" + Customer.FirstName;
        }
    }
}
