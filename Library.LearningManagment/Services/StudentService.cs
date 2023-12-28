using System;
using System.Collections.ObjectModel;
using Library.LearningManagment.Models;

namespace Library.LearningManagment.Services
{
	public class StudentService
	{
		public ObservableCollection<Person> studentList;
		public static StudentService? inst;

		public StudentService()
		{
			studentList = new ObservableCollection<Person>();
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
		
		public void Add(Person student)
		{
			studentList.Add(student);
		}

		public ObservableCollection<Person> Students
		{
			get
			{
				return studentList;
			}
		}

		public IEnumerable<Person> Search(string query)
		{
			return studentList.Where(s => s.Name.ToUpper().Contains(query.ToUpper()));
		}
     
	}
}

