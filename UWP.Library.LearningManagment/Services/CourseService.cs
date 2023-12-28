using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Library.LearningManagment.Models;

namespace Library.LearningManagment.Services
{
	public class CourseService
	{
        public List<Course> courses;
        private static CourseService inst;
       
        public CourseService()
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

        public void Remove(Course c)
        {
            courses.Remove(c);
        }

        /*
        public List<Course> Courses
        {
            get
            {
                return courses;
            }
        }
        */


        public IEnumerable<Course> Search(string query)
        {
            return courses.Where(x => x.CourseCode.ToUpper().Contains(query.ToUpper())
                || x.CourseName.ToUpper().Contains(query.ToUpper())
                || x.Desc.ToUpper().Contains(query.ToUpper()));
        }
    }
}

