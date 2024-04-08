

namespace Genspil
{
    public class MenuItem
    {
        public string Title { get; }
        public string Answer { get; }
       
        public MenuItem(string Title, string Answer)
        {
            this.Title = Title; 
            this.Answer = Answer;
        }
    }
}
