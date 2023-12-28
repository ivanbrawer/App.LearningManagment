using System;
namespace Library.LearningManagment.Models
{
	public class Student : Person
	{
        public PersonType Classification { get; set; }
        public Dictionary<int, double> Grades { get; set; }

        public Student()
        {
            Grades = new Dictionary<int, double>();

        }

        public override string ToString()
        {
            return $"[{Id}] {Name} - {Classification}";
        }

        
    }
}

