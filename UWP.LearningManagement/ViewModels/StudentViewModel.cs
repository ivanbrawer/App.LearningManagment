using Library.LearningManagment.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Library.LearningManagment.Models.Person;

namespace UWP.LearningManagement.ViewModels
{
    public class StudentViewModel
    {
        private Student Student{ get; set; }
        private ObservableCollection<Student> students;
        public string Name
        {
            get
            {
                return Student.Name;
            }
            set
            {
                Student.Name = value;
            }
        }

        public PersonType Classification
        {
            get
            {
                return Student.Classification;
            }
            set
            {
                Student.Classification = value;
            }
        }
        public StudentViewModel(ObservableCollection<Student> students)
        {
          /*
            Student = new Student();
            InstructorViewModel.allPeople.Add(Student);
            this.students = students;
           */
        }
        public StudentViewModel()
        {

        }

        public void AddStudent()
        {
            students.Add(Student);
        }
    }
}
