

using System.Collections.Generic;
using System.Linq;

namespace Library.LearningManagment.Models
{
	public class Module
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
        
        public string Name { get; set; }
        public string Desc { get; set; }
        public List<ContentItem> ContentList { get; set; }
        public Module()
		{
			ContentList = new List<ContentItem>();
		}

        public override string ToString()
        {
            return $"{Name}: {Desc}\n" +
                $"\t{string.Join("\n\t", ContentList.Select(z => z.ToString()).ToArray())}";
        }
    }
}

