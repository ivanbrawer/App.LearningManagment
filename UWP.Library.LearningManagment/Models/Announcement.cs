using System;
using System.Xml.Linq;

namespace Library.LearningManagment.Models
{
	public class Announcement
	{
        private static int prevId = 0;
        private int id = 0;
        public int Id
        {
            get
            {
                if (id == 0)
                {
                    id = ++prevId;
                }
                return id;
            }
        }
        public string Title { get; set; }
		public string Desc { get; set; }
		public Announcement()
		{

		}

        public override string ToString()
        {
            return $"{Id}. {Title} - {Desc}";
        }
    }
}

