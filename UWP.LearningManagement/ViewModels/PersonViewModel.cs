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
    internal class PersonViewModel
    {
        //private Instructor Instructor { get; set; }
       // private Student Student { get; set; }

        private Person Person { get; set; }
        private ObservableCollection<Person> people;
        public PersonType personType = PersonType.Null;
        public string Name
        {
            get
            {
                return Person.Name;
            }
            set
            {
                Person.Name = value;
            }
        }

        public PersonType Classification
        {
            get
            {
                return personType;
            }
            set
            {
                personType = value;
            }
        }
        public PersonViewModel(ObservableCollection<Person> students, PersonType type)
        {

            Person = new Person(type);
            InstructorViewModel.allPeople.Add(Person);
            people= students;
        }

        public void AddPerson()
        {
            people.Add(Person);
        }

       
    }
}
