

namespace Genspil
{
    public class Request
    {
        public string GameName { get; set; }
        public Customer Customer {  get; set; }

        public Request(string Name, Customer Customer)
        {
            this.GameName = Name;
            this.Customer = Customer; 
            
        }

    }
}
