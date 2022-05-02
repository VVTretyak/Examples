using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WPF_MySql.ViewModel;

namespace WPF_MySql.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
  
    public partial class MainWindow : Window
    {
        public static ListView AllPerson;
        public static TextBlock StateConnection;
        public static DispatcherTimer timer;
            
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new PersonViewModel();
            AllPerson = ViewAllPersons;
            StateConnection = ViewStatusBar;
        }

       
    }
}
