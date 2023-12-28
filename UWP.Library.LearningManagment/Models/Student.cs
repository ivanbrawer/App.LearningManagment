using System;
using System.Collections.Generic;

namespace Library.LearningManagment.Models
{
	public class Student : Person
	{
       
        public Dictionary<int, double> Grades { get; set; }
        PersonType classification;
        public Student(PersonType cls)
        {
            Grades = new Dictionary<int, double>();
            classification = cls;          
        }

        public override string ToString()
        {
            return $"[{Id}] {Name} - {Classification}";
        }

        
    }
}

