using System;
using Library.LearningManagment.Models;

namespace Library.LearningManagment.Services
{
	public class CourseService
	{
        public List<Course> courses;
        private static CourseService? inst;

        private CourseService()
        {
            courses = new List<Course>();
        }

        public static CourseService Curr
        {
            get
            {
                if (inst == null)
                {
                    inst = new CourseService();
                }
                return inst;
            }
        }

        public void Add(Course c)
        {
            courses.Add(c);
        }

        public List<Course> Courses
        {
            get
            {
                return courses;
            }
        }

        public IEnumerable<Course> Search(string query)
        {
            return courses.Where(x => x.CourseCode.ToUpper().Contains(query.ToUpper())
                || x.CourseName.ToUpper().Contains(query.ToUpper())
                || x.Desc.ToUpper().Contains(query.ToUpper()));
        }
    }
}

