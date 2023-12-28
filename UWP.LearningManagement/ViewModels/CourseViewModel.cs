using Library.LearningManagment.Models;
using Library.LearningManagment.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace UWP.LearningManagement.ViewModels
{
    public class CourseViewModel
    {
        private Course Course { get; set; }
        private ObservableCollection<Course> courses;
        public string CourseName
        {
            get
            {
                return Course.CourseName;
            }
            set
            {
                Course.CourseName = value;
            }
        }

        public string CourseCode
        {
            get
            {
                return Course.CourseCode;
            }
            set
            {
                Course.CourseCode = value;
            }
        }

        public string Desc
        {
            get
            {
                return Course.Desc;
            }
            set
            {
                Course.Desc = value;
            }
        }

        public int CreditHours
        {
            get
            {
                return Course.CreditHours;
            }
            set
            {
                Course.CreditHours = value;
            }
        }

        //new course constrcutor
        public CourseViewModel(ObservableCollection<Course> courses)
        {
            Course = new Course();
            InstructorViewModel.allCourses.Add(Course);
            this.courses = courses;
        }

        //edit course constructor
        public CourseViewModel(Course course, ObservableCollection<Course> courses)
        {
            this.courses = courses;
            Course = course;
        }

        public void AddCourse()
        {
            courses.Add(Course);
        }

        public void EditCourse()
        {
            courses.Add(Course);
        }
    }
}
