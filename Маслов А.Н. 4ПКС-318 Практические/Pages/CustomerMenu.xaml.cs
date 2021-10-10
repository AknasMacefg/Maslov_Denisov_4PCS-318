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
using Маслов_А.Н._4ПКС_318_Практические.Pages.UserPages;

namespace Маслов_А.Н._4ПКС_318_Практические.Pages
{
    /// <summary>
    /// Логика взаимодействия для CustomerMenu.xaml
    /// </summary>
    public partial class CustomerMenu : Page
    {
        public CustomerMenu()
        {
            InitializeComponent();
            
        }

        private void ButtonPage1_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Employees());
        }

        private void ButtonPage2_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Clients());
        }

        private void ButtonPage3_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Products());
        }
    }
}
