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
using static Library.LearningManagment.Models.Person;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP.LearningManagement.Dialogs
{
    public sealed partial class AddPersonDialog : ContentDialog
    {
        public AddPersonDialog(ObservableCollection<Person> people)
        {
            this.InitializeComponent();
            //PersonType type = PersonType.Instructor;    //get type from check box maybe
            this.DataContext = new PersonViewModel(people, PersonType.Instructor);
        }

        private void AddPerson_Click(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            (DataContext as PersonViewModel).AddPerson();
        }

        private void Cancel_Click(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        
    }
}
