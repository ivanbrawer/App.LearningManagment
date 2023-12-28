using Library.LearningManagment.Models;
using Library.LearningManagment.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using UWP.LearningManagement.Dialogs;
using static Library.LearningManagment.Models.Person;

namespace UWP.LearningManagement.ViewModels
{

    public class InstructorViewModel
    {
        public StudentService studentService;
        public CourseService courseService;
        public static List<Course> allCourses;
        public static List<Person> allPeople;
        private ObservableCollection<Course> courses;
        private ObservableCollection<Person> people;

        private static Person currentPerson;
        private static Course currentCourse;
        
        public string Query { get; set; }


        public InstructorViewModel()
        {
            studentService = new StudentService();
            courseService = new CourseService();
            allCourses = courseService.courses;
            courses = new ObservableCollection<Course>(courseService.courses);
            allPeople = studentService.People;
            people = new ObservableCollection<Person>(studentService.People);
            
        }

        public Course SelectedCourse
        {
            get
            {
                return currentCourse;
            }
            set
            {
                currentCourse = value;
                NotifyPropertyChanged();
            }
        }

        public Person SelectedPerson
        {
            get
            {
                return currentPerson;
            }
            set
            {
                currentPerson = value; NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Course> Courses
        {
            get
            {
                return courses;
            }
            private set
            {
                courses = value;
            }
        }

        public ObservableCollection<Person> People
        {
            get
            {
                return people;
            }
            private set
            {
                people = value;
            }
        }

        public async void AddCourse()
        {
            var dialog = new AddCourseDialog(Courses);
            if (dialog != null)
            {
                await dialog.ShowAsync();
            }

            //NotifyPropertyChanged("Courses");
        }

        //Instructor
        public async void AddPerson()
        {
            var dialog = new AddPersonDialog(People);
            if (dialog != null)
            {
                await dialog.ShowAsync();
            }
        }

        public async void AddFreshman()
        {
            var dialog = new AddFreshmanDialog(People);
            if(dialog != null)
            {
                await dialog.ShowAsync();
            }
        }
        public async void AddSophomore()
        {
            var dialog = new AddSophomoreDialog(People);
            if (dialog != null)
            {
                await dialog.ShowAsync();
            }
        }
        public async void AddJunior()
        {
            var dialog = new AddJuniorDialog(People);
            if (dialog != null)
            {
                await dialog.ShowAsync();
            }
        }
        public async void AddSenior()
        {
            var dialog = new AddSeniorDialog(People);
            if (dialog != null)
            {
                await dialog.ShowAsync();
            }
        }
        public async void AddTA()
        {
            var dialog = new AddTADialog(People);
            if (dialog != null)
            {
                await dialog.ShowAsync();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SearchCourses()
        {
            var search = allCourses.Where(i => i.CourseCode.Contains(Query) || i.CourseName.Contains(Query)).ToList();              //allCOurses not getting updataed when i add a course
            Courses.Clear();
            foreach (var course in search)
            {
                Courses.Add(course);
            }
        }

        public void SearchPeople()
        {
            var search = allPeople.Where(i => i.Name.Contains(Query)).ToList();
            People.Clear();
            foreach (var person in search)
            {
                People.Add(person);
            }
        }

        public async void EditCourse(Course course)
        { 
            allCourses.Remove(course);
            Courses.Remove(course);
            var dialog = new EditCourseDialog(course, Courses);
            //allCourses.Remove(course);
            if (dialog != null)
            {
                await dialog.ShowAsync();
            }
        }

        public ICommand RemoveCourseCommand { get; set; }
        public void RemoveCourse(Course course)
        {
            courseService.Remove(course);
            Courses.Remove(course);
        }

        public void RemovePerson(Person person)
        {
            studentService.Remove(person);
            People.Remove(person);
        }
    }
}
