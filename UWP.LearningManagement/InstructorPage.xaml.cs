using Library.LearningManagment.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWP.LearningManagement.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP.LearningManagement
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InstructorView : Page
    {

        public InstructorView()
        {
            InitializeComponent();
            DataContext = new InstructorViewModel();
        }

        private void SearchCourse_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as InstructorViewModel).SearchCourses();
        }

        private void SearchPerson_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as InstructorViewModel).SearchPeople();
        }

        private void AddCourse_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as InstructorViewModel).AddCourse();
        }

        private void AddInstructor_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as InstructorViewModel).AddPerson();
        }

        private void AddFreshman_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as InstructorViewModel).AddFreshman();
        }
        private void AddSophomore_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as InstructorViewModel).AddSophomore();
        }
        private void AddJunior_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as InstructorViewModel).AddJunior();
        }
        private void AddSenior_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as InstructorViewModel).AddSenior();
        }
        private void AddTA_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as InstructorViewModel).AddTA();
        }

        private void EditCourse_Click(Object sender, RoutedEventArgs e)
        {
            Course selectedCourse = CourseList.SelectedItem as Course;
            (DataContext as InstructorViewModel).EditCourse(selectedCourse);
        }
        
        private void RemoveCourse_Click(object sender, RoutedEventArgs e)
        {
            Course selectedCourse = CourseList.SelectedItem as Course;
            (DataContext as InstructorViewModel).RemoveCourse(selectedCourse);
        }

        private void RemovePerson_Click(Object sender, RoutedEventArgs e)
        {
            Person person = PersonList.SelectedItem as Person;
            (DataContext as InstructorViewModel).RemovePerson(person);
        }
    }
}
