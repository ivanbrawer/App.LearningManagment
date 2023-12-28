

namespace Library.LearningManagment.Models
{
    public class Person
    {
        public string Name { get; set; }

        private static int prevId = 0;
        public int Id
        {
            get; private set;
        }
        public Person()
        {
            Name = string.Empty;
            Id = ++prevId;
        }

        public override string ToString()
        {
            return $"[{Id}] {Name}";
        }

        public enum PersonType
        {
            Freshman, Sophomore, Junior, Senior
        }

    }
    
}


