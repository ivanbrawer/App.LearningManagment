using System;
using Library.LearningManagment.Models;
using Library.LearningManagment.Services;
using static Library.LearningManagment.Models.Person;

namespace App.LearningManagment.Helpers
{
	public class StudentHelper
	{
        private StudentService studentService;
        private CourseService courseService;
        private ListNavigator<Person> studentNav;

        public StudentHelper()
        {
            studentService = StudentService.Curr;
            courseService = CourseService.Curr;
            studentNav = new ListNavigator<Person>(studentService.studentList, 2);
        }

        public void createStudent(Person? studentSelected = null)
        {

            bool newStudent = false;
            if (studentSelected == null)
            {
                newStudent = true;
                Console.WriteLine("What is this persons role?\n" +
                    "S - Student\n" +
                    "T - TA\n" +
                    "I - Instructor");

                var choice = Console.ReadLine();
                if (string.IsNullOrEmpty(choice))
                {
                    return;
                }

                if(choice.Equals("s", StringComparison.InvariantCultureIgnoreCase))
                {
                    studentSelected = new Student();
                }
                else if(choice.Equals("t", StringComparison.InvariantCultureIgnoreCase))
                {
                    studentSelected = new TeachingAssistant();
                }
                else if(choice.Equals("i", StringComparison.InvariantCultureIgnoreCase))
                {
                    studentSelected = new Instructor();
                }
          
            }

            Console.WriteLine("Name: ");
            var name = Console.ReadLine();

            if(studentSelected is Student)
            {
                Console.WriteLine("Classification: [(F)reshman, S(O)phomore, (J)unior, (S)enior ");
                var classification = Console.ReadLine() ?? string.Empty;
                PersonType year = PersonType.Freshman;


                if (classification.Equals("O", StringComparison.InvariantCultureIgnoreCase))
                {
                    year = PersonType.Sophomore;
                }
                else if (classification.Equals("J", StringComparison.InvariantCultureIgnoreCase))
                {
                    year = PersonType.Junior;
                }
                else if (classification.Equals("S", StringComparison.InvariantCultureIgnoreCase))
                {
                    year = PersonType.Senior;
                }

                var studentRec = studentSelected as Student;
                if(studentRec != null)
                {
                    studentRec.Classification = year;
                    //studentRec.Id = int.Parse(id ?? "0");
                    studentRec.Name = name ?? string.Empty;

                    if (newStudent)
                    {
                        studentService.Add(studentSelected);
                    }

                    Console.WriteLine("Student Added");
                }   
            }
            else if(studentSelected is TeachingAssistant || studentSelected is Instructor)
            {
                //studentSelected.Id = int.Parse(id ?? "0");
                studentSelected.Name = name ?? string.Empty;

                if (newStudent)
                {
                    studentService.Add(studentSelected);
                }

            }
            
         
            
        }

        public void ListStudents()
        {
            NavigateStudentList();
        }

        private void NavigateStudentList(string? query = null)
        {
            ListNavigator<Person>? currentNav = null;
            if (query == null)
            {
                currentNav = studentNav;
            }
            else
            {
                currentNav = new ListNavigator<Person>(studentService.Search(query).ToList(), 2);
            }
            bool run = true;
            while(run)
            {
                foreach (var pair in currentNav.GetCurrentPage())
                {
                    Console.WriteLine($"{pair.Key}. {pair.Value}");
                }
                if (currentNav.HasPreviousPage)
                {
                    Console.WriteLine("P. Previous Page");
                }
                if (currentNav.HasNextPage)
                {
                    Console.WriteLine("N. Next Page");
                }


                Console.Write("Selection:\n");
                var choice = Console.ReadLine();
                if ((choice?.Equals("P", StringComparison.InvariantCultureIgnoreCase) ?? false)
                    || (choice?.Equals("N", StringComparison.InvariantCultureIgnoreCase) ?? false))
                {
                    if(choice.Equals("P", StringComparison.InvariantCultureIgnoreCase))
                    {
                        currentNav.GoBackward();
                        continue;
                    }
                    if(choice.Equals("N", StringComparison.InvariantCultureIgnoreCase))
                    {
                        currentNav.GoForward();
                        continue;
                    }

                }
                else
                {
                    var intChoice = int.Parse(choice ?? "0");
                    Console.WriteLine("Courses for person with ID " + intChoice);
                    courseService.Courses.Where(x => x.RosterList.Any(z => z.Id == intChoice)).ToList().ForEach(Console.WriteLine);
                    run = false;
                }
            }
         

        }

        public void SearchForStudents()
        {
            Console.Write("Enter query: \n");
            var q = Console.ReadLine() ?? string.Empty;
            //studentService.Search(q).ToList().ForEach(Console.WriteLine);

            //var choice = Console.ReadLine();
            //var intChoice = int.Parse(choice ?? "0");

            //Console.WriteLine("Courses for student with ID " + intChoice);
            //courseService.Courses.Where(x => x.RosterList.Any(z => z.Id == intChoice)).ToList().ForEach(Console.WriteLine);

            NavigateStudentList(q);
        }

        public void EditStudent()
        {
            Console.WriteLine("Which person do you want to edit? [ID]");
            studentService.Students.ForEach(Console.WriteLine);

            var select = Console.ReadLine();

            if(int.TryParse(select, out int result))
            {
                var studentSelected = studentService.Students.FirstOrDefault(s => s.Id == result);
                if(studentSelected != null)
                {
                    createStudent(studentSelected);
                }
            }
        }

        public void GradeStudentAssignment()
        {
            courseService.Courses.ForEach(Console.WriteLine);
            Console.WriteLine("Enter the course [Course Code]: ");
            var choice = Console.ReadLine() ?? string.Empty;
            var course = courseService.Courses.FirstOrDefault(s => s.CourseCode.Equals(choice));
            if (course is Course)
            {
                course.AssignmentList.ForEach(Console.WriteLine);
                Console.WriteLine("Select assignment: ");
                choice = Console.ReadLine() ?? string.Empty;
                var choiceInt = int.Parse(choice);
                var assignment = course.AssignmentList.FirstOrDefault(a => a.Id == choiceInt);
                if(assignment is Assignment)
                {
                    course.RosterList.ForEach(Console.WriteLine);
                    Console.WriteLine("Select Student [ID]: ");
                    choice = Console.ReadLine() ?? string.Empty;
                    var idChoice = int.Parse(choice);
                    var student = course.RosterList.FirstOrDefault(s => s.Id == idChoice);
                    if(student is Student)
                    {
                        Console.WriteLine("Enter grade scored out of " + assignment.TotalAvailPoints + ": ");
                        var selection = Console.ReadLine() ?? string.Empty;
                        var points = double.Parse(selection);
                        ((Student)student).Grades[assignment.Id] = points;
                        //Console.WriteLine(((Student)student).Grades[assignment.Id]);
                    }
                }
            }

        }

	}
}

