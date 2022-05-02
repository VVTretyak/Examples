using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_MySql.Model;
using WPF_MySql.ViewModel;

namespace WPF_MySql.View
{
    /// <summary>
    /// Логика взаимодействия для EditPerson.xaml
    /// </summary>
    public partial class EditPerson : Window
    {
        public EditPerson(Person personToEdit)
        {
            InitializeComponent();
            DataContext = new PersonViewModel();
            PersonViewModel.SelectedPerson = personToEdit;
            PersonViewModel.PersonName=personToEdit.Name;
            PersonViewModel.PersonPhone=personToEdit.Phone;

        }
    }
}
