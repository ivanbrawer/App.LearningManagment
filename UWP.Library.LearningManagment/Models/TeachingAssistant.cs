using System;
namespace Library.LearningManagment.Models
{
	public class TeachingAssistant : Person
	{
		public TeachingAssistant()
		{
		}
        public override string ToString()
        {
            return $"[{Id}] {Name} - Teaching Assistant";
        }
    }
}

