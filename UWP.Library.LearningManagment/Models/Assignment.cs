
using System;

namespace Library.LearningManagment.Models
{
	public class Assignment
	{
        public AssignmentType AssignType;
        private static int prevId = 0;
        private int id = 0;
        public int Id {
            get
            {
                if(id == 0)
                {
                    id = ++prevId;
                }
                return id;
            }
        }
        public string Name { get; set; }
        public string Desc { get; set; }
        public decimal TotalAvailPoints { get; set; }
        public DateTime Due{ get; set; }

        public enum AssignmentType
        {
            Quiz, Exam, Project, Homework
        }


        public override string ToString()
        {
            return $"\t{Id} - {AssignType} ({Due}) {Name}";
        }
    }
}

