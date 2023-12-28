using System;
namespace Library.LearningManagment.Models
{
	public class PageItem : ContentItem
	{
		public string? Html {get; set;}

        public override string ToString()
        {
            return $"{base.ToString()}\nPAGE";
        }
    }
}

