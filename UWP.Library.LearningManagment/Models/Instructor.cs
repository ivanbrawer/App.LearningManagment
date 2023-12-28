using System;
namespace Library.LearningManagment.Models
{
	public class Instructor : Person
	{
        
		public Instructor()
		{

		}
        

        public override string ToString()
        {
            return $"[{Id}] {Name} - Instructor";
        }
    }
}

