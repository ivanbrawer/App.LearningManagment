using System;
using Library.LearningManagment.Services;
using App.LearningManagment.Helpers;

namespace App.LearningManagment
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            var students = new StudentHelper();
            var courses = new CourseHelper();
            bool run = true;

            while (run)
            {
                Console.WriteLine("\n1. Person Mode\n" +
                           "2. Course Mode\n" +
                           "3. Exit\n");
             
                Console.Write(">");
                var input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                {
                    if (result == 1)
                    {
                        DisplayStudentMenu(students);
                    }
                    else if (result == 2)
                    {
                        DisplayCourseMenu(courses);
                    }
                    else if (result == 3)
                    {
                        run = false;
                    }
                   
                }
            }

        }

        static void DisplayStudentMenu(StudentHelper student)
        {
            Console.WriteLine("Choose an action:\n" +
                           "1. Add a new Person\n" +
                           "2. List all People\n" +
                           "3. Search for a Person\n" +
                           "4. Edit Person\n" +
                           "5. Grade an assignment");

            var input = Console.ReadLine();

            if (int.TryParse(input, out int result))
            {
                if (result == 1)
                {
                    student.createStudent();
                }
                else if (result == 2)
                {
                    student.ListStudents();
                }
                else if (result == 3)
                {
                    student.SearchForStudents();
                }
                else if (result == 4)
                {
                    student.EditStudent();
                }
                else if (result == 5)
                {
                    student.GradeStudentAssignment();
                }

            }
        }

        static void DisplayCourseMenu(CourseHelper course)
        {
            Console.WriteLine("Choose an action:\n" +
                          "1.  Add a course\n" +
                          "2.  List all courses\n" +
                          "3.  Edit a course\n" +
                          "4.  Search for a course\n" +
                          "5.  Add a student to a course\n" +
                          "6.  Remove a student from a course\n" +
                          "7.  Add an assignment to a course\n" +
                          "8.  Edit an assignment from a course\n" +
                          "9.  Remove an assignment from a course\n" +
                          "10. Add a module to a course\n" +
                          "11. Remove a module from a course\n" +
                          "12. Edit a module from a course\n" +
                          "13. Add an announcement to a course\n" +
                          "14. Edit an announcement from a course\n" +
                          "15. Remove announcement from a course");

            var input = Console.ReadLine();

            if (int.TryParse(input, out int result))
            {
                if (result == 1)
                {
                    course.CreateNewCourse();
                }
                else if (result == 2)
                {
                    course.SearchForCourse();
                }
                else if (result == 3)
                {
                    course.EditCourse();
                }
                else if (result == 4)
                {
                    Console.Write("Enter query: \n");
                    var q = Console.ReadLine() ?? string.Empty;
                    course.SearchForCourse(q);
                }
                else if (result == 5)
                {
                    course.AddStudentToCourse();
                }
                else if (result == 6)
                {
                    course.RemoveStudentFromCourse();
                }
                else if (result == 7)
                {
                    course.AddAssignmentToCourse();
                }
                else if(result == 8)
                {
                    course.EditAssignment();
                }
                else if(result == 9)
                {
                    course.RemoveAssignmentFromCourse();
                }
                else if(result == 10)
                {
                    course.AddModuleInProgram();
                }
                else if (result == 11)
                {
                    course.RemoveModuleInProgram();
                }
                else if(result == 12)
                {
                    course.EditModule();
                }
                else if(result == 13)
                {
                    //add announcement
                    course.AddAnnouncementToCourse();
                }
                else if(result == 14)
                {
                    course.EditAnnouncement();
                }
                else if(result == 15)
                {
                    course.RemoveAnnouncementFromCourse();
                }

            }

        }

    }
}