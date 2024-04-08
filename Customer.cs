

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
                if (value == null)
                {
                    Console.WriteLine("Fornavn må bestå af en eller flere karakterer");
                }
                else
                {
                    this.firstName = value;
                }
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (value == null)
                {
                    Console.WriteLine("Efternavn må bestå af en eller flere karakterer");
                }
                else
                {
                    this.lastName = value;
                }
            }
        }
        public string EmailAdress
        {
            get
            {
                return this.emailAddress;
            }
            set
            {
                if (value == null)
                {
                    Console.WriteLine("Mailadresse må bestå af en eller flere karakterer");
                }
                else
                {
                    this.emailAddress = value;
                }
            }
        }
        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
            set
            {
                if (value == null)
                {
                    Console.WriteLine("Telefonnummer må bestå af en eller flere tal");
                }
                else
                {
                    this.phoneNumber = value;
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
