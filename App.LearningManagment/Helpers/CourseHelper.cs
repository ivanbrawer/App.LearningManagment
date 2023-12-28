using System;
using System.Linq;
using System.Text;
using Library.LearningManagment.Models;
using Library.LearningManagment.Services;
using static Library.LearningManagment.Models.Person;
using static Library.LearningManagment.Models.Assignment;

namespace App.LearningManagment.Helpers
{
    public class CourseHelper
    {
        private CourseService service;
        private StudentService helper;

        public CourseHelper()
        {
            helper = StudentService.Curr;
            service = CourseService.Curr;
        }

        public void CreateNewCourse(Course? selectedCourse = null)
        {
            bool newCourse = false;
            if (selectedCourse == null)
            {
                newCourse = true;
                selectedCourse = new Course();
            }

            var choice = "Y";
            if (!newCourse)
            {
                Console.WriteLine("Edit course code?[y/n]");
                choice = Console.ReadLine() ?? "N";
            }
            if (choice.Equals("y", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Course code: ");
                var selection = Console.ReadLine() ?? string.Empty;
                foreach(Course c in service.courses)
                {
                    if(c.CourseCode == selection)
                    {
                        Console.WriteLine("Course Code already exists, try again\n");
                        return;
                    }
                }
                selectedCourse.CourseCode = selection;
                
            }

            if (!newCourse)
            {
                Console.WriteLine("Edit name? [y/n]");
                choice = Console.ReadLine() ?? "N";
            }
            else choice = "Y";
            if (choice.Equals("y", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Course name: ");
                selectedCourse.CourseName = Console.ReadLine() ?? string.Empty;
            }

            if (!newCourse)
            {
                Console.WriteLine("Edit description? [y/n]");
                choice = Console.ReadLine() ?? "N";
            }
            else choice = "Y";
            if (choice.Equals("y", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Course description: ");
                selectedCourse.Desc = Console.ReadLine() ?? string.Empty;
            }

            if (!newCourse)
            {
                Console.WriteLine("Edit credit hourse? [y/n]");
                choice = Console.ReadLine() ?? "N";
            }
            else choice = "Y";
            if (choice.Equals("y", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Credit Hours: ");
                selectedCourse.CreditHours = int.Parse(Console.ReadLine() ?? string.Empty);
            }




            if (newCourse)
            {
                AddStudentsToCourse(selectedCourse);
                AddAssignmentToCourse(selectedCourse);
                AddModuleToCourse(selectedCourse);

            }


            if (newCourse)
            {
                service.Add(selectedCourse);
            }

            Console.WriteLine("Course Added");
        }

        public void EditCourse()
        {
            Console.WriteLine("Which course do you want to edit? [Course Code]");
            service.Courses.ForEach(Console.WriteLine);

            var select = Console.ReadLine();

            var courseSelected = service.Courses.FirstOrDefault(s => s.CourseCode.Equals(select));
            if (courseSelected != null) CreateNewCourse(courseSelected);
        }

        public void SearchForCourse(string? q = null)
        {
            if (string.IsNullOrEmpty(q))
            {
                service.Courses.ForEach(Console.WriteLine);
            }
            else
            {
                service.Search(q).ToList().ForEach(Console.WriteLine);
            }

            Console.WriteLine("Select course code: ");
            var courseCode = Console.ReadLine() ?? string.Empty;

            var select = service
                .Courses
                .FirstOrDefault(c => c.CourseCode.Equals(courseCode, StringComparison.InvariantCultureIgnoreCase));

            if (select != null) Console.WriteLine(select.DetailDisplay);
        }

        private void AddStudentsToCourse(Course course)
        {

            Console.WriteLine("Select students to enroll[q to quit]: ");
            bool run = true;

            while (run)
            {
                helper.Students.Where(x => !course.RosterList.Any(x2 => x2.Id == x.Id)).ToList().ForEach(Console.WriteLine);
                var student = Console.ReadLine() ?? string.Empty;

                if (student.Equals("q", StringComparison.InvariantCultureIgnoreCase))
                {
                    run = false;
                }
                else
                {
                    var id = int.Parse(student);
                    var studentSelected = helper.Students.FirstOrDefault(x => x.Id == id);
                    if (studentSelected != null)
                    {
                        course.RosterList.Add(studentSelected);
                    }
                }

            }
        }

        private void AddAssignmentToCourse(Course course)
        {
            Console.WriteLine("Add assignments? [y/n] ");
            var choice_ = Console.ReadLine() ?? "N";
            bool run = true;
            if (choice_.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
            {
                run = true;
                while (run)
                {
                    course.AssignmentList.Add(CreateNewAssignment());

                    Console.WriteLine("Add another assignment? [y/n] ");
                    choice_ = Console.ReadLine() ?? "N";
                    if (choice_.Equals("N", StringComparison.InvariantCultureIgnoreCase))
                        run = false;

                }
            }
        }

        public void AddStudentToCourse()
        {
            Console.WriteLine("Which course do you want to add a Student? [Course Code]");
            service.Courses.ForEach(Console.WriteLine);

            var select = Console.ReadLine();

            var courseSelected = service.Courses.FirstOrDefault(s => s.CourseCode.Equals(select));
            if (courseSelected != null)
            {
                Console.WriteLine("Select Student: ");
                helper.Students.Where(x => !courseSelected.RosterList.Any(x2 => x2.Id == x.Id)).ToList().ForEach(Console.WriteLine);

                if (helper.Students.Any(s => !courseSelected.RosterList.Any(s2 => s2.Id == s.Id)))
                {
                    select = Console.ReadLine() ?? string.Empty;
                }

                if (select != null)
                {
                    var id = int.Parse(select);
                    var studentSelected = helper.Students.FirstOrDefault(x => x.Id == id);
                    if (studentSelected != null)
                    {
                        courseSelected.RosterList.Add(studentSelected);

                    }
                }

            }
        }

        public void RemoveStudentFromCourse()
        {
            Console.WriteLine("From which course do you want to remove a Student? [Course Code]");
            service.Courses.ForEach(Console.WriteLine);

            var select = Console.ReadLine();

            var courseSelected = service.Courses.FirstOrDefault(s => s.CourseCode.Equals(select));
            if (courseSelected != null)
            {
                Console.WriteLine("Select Student: ");
                courseSelected.RosterList.ForEach(Console.WriteLine);

                if (courseSelected.RosterList.Any())
                {
                    select = Console.ReadLine() ?? string.Empty;
                }
                else select = null;

                if (select != null)
                {
                    var id = int.Parse(select);
                    var studentSelected = helper.Students.FirstOrDefault(x => x.Id == id);
                    if (studentSelected != null)
                    {
                        courseSelected.RosterList.Remove(studentSelected);

                    }
                }

            }
        }

        private Assignment CreateNewAssignment()
        {
            Console.WriteLine("Enter name: ");
            var aName = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Enter description: ");
            var aDesc = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Enter total available points: ");
            var points = decimal.Parse(Console.ReadLine() ?? "100");

            Console.WriteLine("Enter due date: ");
            var date = DateTime.Parse(Console.ReadLine() ?? "06/09/1969");

            Console.WriteLine("Assignment Group: [(Q)uiz, (E)xam, (P)roject, (H)omework]");
            var classification = Console.ReadLine() ?? string.Empty;
            AssignmentType type = AssignmentType.Homework;


            if (classification.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
            {
                type = AssignmentType.Quiz;
            }
            else if (classification.Equals("E", StringComparison.InvariantCultureIgnoreCase))
            {
                type = AssignmentType.Exam;
            }
            else if (classification.Equals("P", StringComparison.InvariantCultureIgnoreCase))
            {
                type = AssignmentType.Project;
            }
            else if (classification.Equals("H", StringComparison.InvariantCultureIgnoreCase))
            {
                type = AssignmentType.Homework;
            }

            return new Assignment
            {
                Name = aName,
                Desc = aDesc,
                TotalAvailPoints = points,
                Due = date,
                AssignType = type
            };
        }

        public void AddAssignmentToCourse()
        {
            Console.WriteLine("Which course do you want to add an Assignment? [Course Code]");
            service.Courses.ForEach(Console.WriteLine);

            var select = Console.ReadLine();

            var courseSelected = service.Courses.FirstOrDefault(s => s.CourseCode.Equals(select));
            if (courseSelected != null)
            {
                courseSelected.AssignmentList.Add(CreateNewAssignment());
            }
        }

        public void EditAssignment()
        {
            Console.WriteLine("Which course? [Course Code]");
            service.Courses.ForEach(Console.WriteLine);

            var select = Console.ReadLine();

            var courseSelected = service.Courses.FirstOrDefault(s => s.CourseCode.Equals(select));
            if (courseSelected != null)
            {
                Console.WriteLine("Which assignment would you like to edit?");
                courseSelected.AssignmentList.ForEach(Console.WriteLine);

                var choice = Console.ReadLine() ?? string.Empty;
                var intChoice = int.Parse(choice);
                var assignmentSelected = courseSelected.AssignmentList.FirstOrDefault(x => x.Id == intChoice);
                if (assignmentSelected != null)
                {
                    var index = courseSelected.AssignmentList.IndexOf(assignmentSelected);
                    //remove
                    courseSelected.AssignmentList.RemoveAt(index);
                    courseSelected.AssignmentList.Insert(index, CreateNewAssignment());
                }
            }
        }

        public void RemoveAssignmentFromCourse()
        {
            Console.WriteLine("Which course? [Course Code]");
            service.Courses.ForEach(Console.WriteLine);

            var select = Console.ReadLine();

            var courseSelected = service.Courses.FirstOrDefault(s => s.CourseCode.Equals(select));
            if (courseSelected != null)
            {
                Console.WriteLine("Which assignment would you like to remove?");
                courseSelected.AssignmentList.ForEach(Console.WriteLine);

                var choice = Console.ReadLine() ?? string.Empty;
                var intChoice = int.Parse(choice);
                var assignmentSelected = courseSelected.AssignmentList.FirstOrDefault(x => x.Id == intChoice);
                if (assignmentSelected != null)
                {
                    //remove
                    courseSelected.AssignmentList.Remove(assignmentSelected);
                }
            }
        }

        private void AddModuleToCourse(Course course)
        {
            Console.WriteLine("Add Modules? [y/n]");
            var response = Console.ReadLine() ?? "N";
            bool run;
            if(response.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
            {
                run = true;
                while(run)
                {
                    course.ModulesList.Add(CreateNewModule(course));
                    Console.WriteLine("Add another module? [y/n]");
                    response = Console.ReadLine() ?? "N";
                    if(response.Equals("N", StringComparison.InvariantCultureIgnoreCase))
                    {
                        run = false;
                    }
                }
            }
        }

        private Module CreateNewModule(Course course)
        {
            Console.WriteLine("Enter module item name: ");
            var aName = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Enter module item description: ");
            var aDesc = Console.ReadLine() ?? string.Empty;

            var mod = new Module()
            {
                Name = aName,
                Desc = aDesc
            };

            Console.WriteLine("Add content? [y/n]");
            var response = Console.ReadLine() ?? "N";
            while(response.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Select content type:\n" +
                    "1. File\n" +
                    "2. Assignment\n" +
                    "3. Page");
                var response2 = int.Parse(Console.ReadLine() ?? "0");

                if(response2 == 1)
                {
                    var newItem = CreateNewFileItem(course);
                    if (newItem != null)
                        mod.ContentList.Add(newItem);
                }
                else if(response2 == 2)
                {
                    var newItem = CreateNewAssignmentItem(course);
                    if (newItem != null)
                        mod.ContentList.Add(newItem);
                }
                else if(response2 == 3)
                {
                    var newItem = CreateNewPageItem(course);
                    if (newItem != null)
                        mod.ContentList.Add(newItem);
                }
                else
                {
                    Console.WriteLine("Unable to add content");
                }

                Console.WriteLine("Add more content? [y/n]");
                response = Console.ReadLine() ?? "N";

            }
            return mod;
        }

        private AssignmentItem? CreateNewAssignmentItem(Course course)
        {
            Console.WriteLine("Enter assignment item name: ");
            var aName = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Enter assignment item description: ");
            var aDesc = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Choose assignments to add [-1 to quit]: ");
            course.AssignmentList.ForEach(Console.WriteLine);
            var response = int.Parse(Console.ReadLine() ?? "-1");
            if (response > -1)
            {
                var chosenAssignment = course.AssignmentList.FirstOrDefault(x => x.Id == response);
                var newItem = new AssignmentItem
                {
                    Assignment = chosenAssignment,
                    Name = aName,
                    Desc = aDesc
                };

                return newItem;
            }
            return null;
        }

        private FileItem? CreateNewFileItem(Course course)
        {
            Console.WriteLine("Enter file item name: ");
            var aName = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Enter file item description: ");
            var aDesc = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Enter filepath: ");
            var filepath = Console.ReadLine() ?? string.Empty;
            var newFile = new FileItem
            {
                Path = filepath,
                Name = aName,
                Desc = aDesc
            };

            return newFile;
        }

        private PageItem? CreateNewPageItem(Course course)
        {
            Console.WriteLine("Enter page item name: ");
            var aName = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Enter page item description: ");
            var aDesc = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Enter page content: ");
            var html = Console.ReadLine() ?? string.Empty;
            var newPage = new PageItem
            {
                Name = aName,
                Desc = aDesc,
                Html = html
            };

            return newPage;
        }

        public void AddModuleInProgram()
        {
            Console.WriteLine("Which course do you want to add a Module? [Course Code]");
            service.Courses.ForEach(Console.WriteLine);

            var select = Console.ReadLine() ?? string.Empty;

            var courseSelected = service.Courses.FirstOrDefault(s => s.CourseCode.Equals(select));
            if (courseSelected != null)
            {
                courseSelected.ModulesList.Add(CreateNewModule(courseSelected));
            }
        }

        public void RemoveModuleInProgram()
        {
            Console.WriteLine("Which course? [Course Code]");
            service.Courses.ForEach(Console.WriteLine);
            var response = Console.ReadLine();
            var courseSelected = service.Courses.FirstOrDefault(s => s.CourseCode.Equals(response));

            if (courseSelected != null)
            {
                Console.WriteLine("Which module would you like to remove?");
                courseSelected.ModulesList.ForEach(Console.WriteLine);

                var choice = Console.ReadLine() ?? string.Empty;
                var intChoice = int.Parse(choice);
                var moduleSelected = courseSelected.ModulesList.FirstOrDefault(x => x.Id == intChoice);
                if (moduleSelected != null)
                {
                    //remove
                    courseSelected.ModulesList.Remove(moduleSelected);
                }
            }
        }

        public void EditModule()
        {
            Console.WriteLine("Which course? [Course Code]");
            service.Courses.ForEach(Console.WriteLine);
            var select = Console.ReadLine();
           
            var courseSelected = service.Courses.FirstOrDefault(s => s.CourseCode.Equals(select, StringComparison.InvariantCultureIgnoreCase));
            if(courseSelected != null && courseSelected.ModulesList.Any())
            {
                Console.WriteLine("Enter module ID: ");
                courseSelected.ModulesList.ForEach(Console.WriteLine);
                select = Console.ReadLine();
                var moduleSelected = courseSelected.ModulesList.FirstOrDefault(m => m.Id.ToString().Equals(select, StringComparison.InvariantCultureIgnoreCase));

                if(moduleSelected != null)
                {
                    Console.WriteLine("Edit module name?[y/n] ");
                    select = Console.ReadLine() ?? "N";
                    if (select.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Console.WriteLine("Enter new name: ");
                        moduleSelected.Name = Console.ReadLine();
                    }

                    Console.WriteLine("Edit module description?[y/n] ");
                    select = Console.ReadLine() ?? "N";
                    if (select.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Console.WriteLine("Enter new description: ");
                        moduleSelected.Desc = Console.ReadLine();
                    }

                    Console.WriteLine("Delete content from module?[y/n] ");
                    select = Console.ReadLine() ?? "N";
                    if (select.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                    {
                        var run = true;
                        while(run)
                        {
                            moduleSelected.ContentList.ForEach(Console.WriteLine);
                            select = Console.ReadLine();

                            var content = moduleSelected.ContentList.FirstOrDefault(x => x.Id.ToString().Equals(select, StringComparison.InvariantCultureIgnoreCase));
                            if (content != null)
                            {
                                moduleSelected.ContentList.Remove(content);
                            }

                            Console.WriteLine("Remove more content? [y/n]");
                            select = Console.ReadLine() ?? "N";
                            if(select.Equals("N", StringComparison.InvariantCultureIgnoreCase))
                            {
                                run = false;
                            }

                        }

                    }

                    Console.WriteLine("Add content? [y/n]");
                    var response = Console.ReadLine() ?? "N";
                    while (response.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Console.WriteLine("Select content type:\n" +
                            "1. File\n" +
                            "2. Assignment\n" +
                            "3. Page");
                        var response2 = int.Parse(Console.ReadLine() ?? "0");

                        if (response2 == 1)
                        {
                            var newItem = CreateNewFileItem(courseSelected);
                            if (newItem != null)
                                moduleSelected.ContentList.Add(newItem);
                        }
                        else if (response2 == 2)
                        {
                            var newItem = CreateNewAssignmentItem(courseSelected);
                            if (newItem != null)
                                moduleSelected.ContentList.Add(newItem);
                        }
                        else if (response2 == 3)
                        {
                            var newItem = CreateNewPageItem(courseSelected);
                            if (newItem != null)
                                moduleSelected.ContentList.Add(newItem);
                        }
                        else
                        {
                            Console.WriteLine("Unable to add content");
                        }

                        Console.WriteLine("Add more content? [y/n]");
                        response = Console.ReadLine() ?? "N";

                    }


                }
               
            }


        }

        private Announcement CreateNewAnnouncement()
        {
            Console.WriteLine("Enter announcement title: ");
            var aName = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Enter announcement description: ");
            var aDesc = Console.ReadLine() ?? string.Empty;

            var newAnnouncement = new Announcement()
            {
                Title = aName,
                Desc = aDesc
            };

            return newAnnouncement;
            
        }

        public void AddAnnouncementToCourse()
        {
            Console.WriteLine("Which course do you want to add an Announcement? [Course Code]");
            service.Courses.ForEach(Console.WriteLine);

            var select = Console.ReadLine();

            var courseSelected = service.Courses.FirstOrDefault(s => s.CourseCode.Equals(select));
            if (courseSelected != null)
            {
                courseSelected.AnnouncementList.Add(CreateNewAnnouncement());
            }
        }

        public void EditAnnouncement()
        {
            Console.WriteLine("Which course? [Course Code]");
            service.Courses.ForEach(Console.WriteLine);

            var select = Console.ReadLine();

            var courseSelected = service.Courses.FirstOrDefault(s => s.CourseCode.Equals(select));
            if (courseSelected != null)
            {
                Console.WriteLine("Which announcement would you like to edit?");
                courseSelected.AnnouncementList.ForEach(Console.WriteLine);

                var choice = Console.ReadLine() ?? string.Empty;
                var intChoice = int.Parse(choice);
                var announcementSelected = courseSelected.AnnouncementList.FirstOrDefault(x => x.Id == intChoice);
                if (announcementSelected != null)
                {
                    Console.WriteLine("Edit Title?[y/n] ");
                    select = Console.ReadLine() ?? "N";
                    if (select.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Console.WriteLine("Enter new name: ");
                        announcementSelected.Title = Console.ReadLine();
                    }

                    Console.WriteLine("Edit description?[y/n] ");
                    select = Console.ReadLine() ?? "N";
                    if (select.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Console.WriteLine("Enter new description: ");
                        announcementSelected.Desc = Console.ReadLine();
                    }


                }
            }
        }

        public void RemoveAnnouncementFromCourse()
        {
            Console.WriteLine("Which course? [Course Code]");
            service.Courses.ForEach(Console.WriteLine);
            var response = Console.ReadLine();
            var courseSelected = service.Courses.FirstOrDefault(s => s.CourseCode.Equals(response));

            if (courseSelected != null)
            {
                Console.WriteLine("Which announcement would you like to remove?");
                courseSelected.AnnouncementList.ForEach(Console.WriteLine);

                var choice = Console.ReadLine() ?? string.Empty;
                var intChoice = int.Parse(choice);
                var announcementSelected = courseSelected.AnnouncementList.FirstOrDefault(x => x.Id == intChoice);
                if (announcementSelected != null)
                {
                    //remove
                    courseSelected.AnnouncementList.Remove(announcementSelected);
                }
            }
        }

     
    }

}

