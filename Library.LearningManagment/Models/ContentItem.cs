
namespace Library.LearningManagment.Models
{
	public class ContentItem
	{
        public string? Name { get; set; }
        public string? Desc { get; set; }
        private static int prevId = 0;
        public int Id
        {
            get; private set;
        }

        public override string ToString()
        {
            return $"{Name}: {Desc}";
        }

        public ContentItem()
        {
            Id = ++prevId;
        }

    }
}

