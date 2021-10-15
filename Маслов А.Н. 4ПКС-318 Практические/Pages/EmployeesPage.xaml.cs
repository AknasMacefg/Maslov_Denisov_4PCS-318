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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Маслов_А.Н._4ПКС_318_Практические.Pages
{
    /// <summary>
    /// Логика взаимодействия для Employees.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        public EmployeesPage()
        {
            InitializeComponent();

            DataGridEmployees.ItemsSource = Entities.GetContext().Employees.ToList();
        }


        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDel_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AddReg());
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
             if (Visibility == Visibility.Visible)
                {
                    Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                    DataGridEmployees.ItemsSource = Entities.GetContext().Employees.ToList();
                }
            

        }
    }
}
