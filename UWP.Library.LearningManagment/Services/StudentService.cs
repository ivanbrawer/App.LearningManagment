using Library.LearningManagment.Models;
using System.Collections.Generic;
using System.Linq;

namespace Library.LearningManagment.Services
{
    public class StudentService     //This is really like person service
    {
        public List<Person> personList;
        public List<Student> studentList;
        public List<Instructor> instructorList;
        public List<TeachingAssistant> teachingAssistantList;

        private static StudentService inst;

        public StudentService()
        {
            personList = new List<Person>();
        }

        public static StudentService Curr
        {
            get
            {
                if (inst == null)
                {
                    inst = new StudentService();
                }
                return inst;
            }
        }

        public void Remove(Person p)
        {
            personList.Remove(p);
            if(p is Student)
            {
               
            }
            else if(p is Instructor)
            {

            }
            else if(p is TeachingAssistant)
            {

            }
        }

        public void Add(Person person)
        {
            personList.Add(person);
        }

        public List<Person> People
        {
            get
            {
                return personList;
            }
        }

        public IEnumerable<Person> Search(string query)
        {
            return personList.Where(s => s.Name.ToUpper().Contains(query.ToUpper()));
        }

    }
}

