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
    public sealed partial class AddCourseDialog : ContentDialog
    {
        public AddCourseDialog(ObservableCollection<Course> courses)
        {
            this.InitializeComponent();
            DataContext = new CourseViewModel(courses);
        }

        private void AddCourse_Click(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            (DataContext as CourseViewModel).AddCourse();
        }

        private void Cancel_Click(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
