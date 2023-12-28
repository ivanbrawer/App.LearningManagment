
namespace Library.LearningManagment.Models
{
	public class Course
	{
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string Desc { get; set; }
        public int CreditHours { get; set; }
        public List<Person> RosterList { get; set; }
        public List<Assignment> AssignmentList { get; set; }
        public List<Module> ModulesList { get; set; }
        public List<Announcement> AnnouncementList { get; set; }

        public Course()
		{
            CourseName = string.Empty;
            CourseCode = string.Empty;
            Desc = string.Empty;
            RosterList = new List<Person>();
            AssignmentList = new List<Assignment>();
            ModulesList = new List<Module>();
            AnnouncementList = new List<Announcement>();
        }

        public override string ToString()
        {
            return $"{CourseName}({CreditHours}) - {CourseCode}";
        }

        public string DetailDisplay
        {
            get
            {
                return $"{ToString()}\n\t{Desc}\n\nRoster:\n{string.Join("\n\t", RosterList.Select(x => x.ToString()).ToArray())}\n" +
                    $"\nAssignments\n\t{string.Join("\n\t", AssignmentList.Select(y => y.ToString()).ToArray())}\n" +
                    $"\nModules\n\t{string.Join("\n\t", ModulesList.Select(z => z.ToString()).ToArray())}\n" +
                    $"\nAnnouncements\n\t{string.Join("\n\t", AnnouncementList.Select(a => a.ToString()).ToArray())}";
            }
        }
    }
}

