using Library.LearningManagment.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP.LearningManagement.Dialogs
{
    public sealed partial class EditCourseDialog : ContentDialog
    {
        public EditCourseDialog(Course course, ObservableCollection<Course> courses)
        {
            this.InitializeComponent();
            DataContext = new CourseViewModel(course, courses);
        }

       

        private void Confirm_Click(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            (DataContext as CourseViewModel).EditCourse();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
