using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    public class RequestRepository
    {
        
        private readonly string path = @"C:\temp\requests.txt";//betyder at ingen andre kan sætte en anden værdi på contenstringen
        //private string contents = "Hello\nWorld";
        public List<Request> Requests = new List<Request>();
    
        public void Write()
        {
            string content = "";
            foreach (var item in Requests)
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
        public void AddRequest(Request request)
        {
            Requests.Add(request);
        }
    }

}
