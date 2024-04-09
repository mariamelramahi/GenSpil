

namespace Genspil
{
    public class Customer
    {
        private string firstName { get; set; }
        private string lastName { get; set; }
        private string emailAddress { get; set; }
        private string phoneNumber { get; set; }

        public string FirstName
        {
            get 
            { 
                return this.firstName; 
            }
            set 
            {
                if (value != null)
                {
                    this.firstName = value;           
                }
                else
                {
                    Console.WriteLine("Fornavn må bestå af en eller flere karakterer: ");
                }
            }
        }

        public string? LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (value != null)
                {
                    this.lastName = value;
                }
                else
                {               
                    Console.WriteLine("Efternavn må bestå af en eller flere karakterer");
                }
            }
        }
        public string? EmailAdress
        {
            get
            {
                return this.emailAddress;
            }
            set
            {
                if (value != null)
                {
                    this.emailAddress = value;
                }
                else
                {     
                    Console.WriteLine("Mailadresse må bestå af en eller flere karakterer");
                }
            }
        }
        public string? PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
            set
            {
                if (value != null)
                {
                    this.phoneNumber = value;
                }
                else
                {
                    Console.WriteLine("Telefonnummer må bestå af en eller flere tal");           
                }
            }
        }

        public Customer (string firstName, string lastName, string emailAddress, string phoneNumber) 
        {
            this.firstName = firstName;
            this.lastName = lastName; 
            this.emailAddress = emailAddress;   
            this.phoneNumber = phoneNumber;
        }
        
        public string Serialize()
        {
            return firstName + ";" + lastName + ";" + emailAddress + ";" + phoneNumber;
        }
        //lave et loop over mit customer liste og skrive linjer
        public override string ToString()
        {
            return Serialize();
        }
        public string PrintToUser()
        {
            return firstName + " " + lastName + " \t\t " + emailAddress + " \t\t " + phoneNumber;
        }
        public static void PrintToUserHeader()
        {
            Console.WriteLine("Kundens navn\t\tEmailadresse\t\t\t Telefonnummer\n");
        }

    }
    
}
