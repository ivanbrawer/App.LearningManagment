

using System.Security.Cryptography;

namespace Library.LearningManagment.Models
{
    public class Person
    {
        public string Name { get; set; }
        public PersonType Classification { get; set; }
        /*
        {
            get
            {
                return Classification;
            }
            set
            {
                Classification = value;
            }
        }
        */
        private static int prevId = 0;
        public int Id
        {
            get; private set;
        }
        public Person(PersonType type = PersonType.Null)
        {
            Name = "PERSON_NAME";
            Id = ++prevId;
            Classification = type;
        }

        public override string ToString()
        {
            return $"[{Id}] {Name} - {Classification}";
        }

        public enum PersonType
        {
            Freshman, Sophomore, Junior, Senior, TeachingAssistant, Instructor, Null
        }

        public string DisplayPeople
        {
            get
            {
                return $"{ToString()}";
            }
        }

    }
    
}


