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
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();
            SortType.SelectedIndex = 0;
            Customers.IsChecked = false;
            Sellers.IsChecked = false;
            Admins.IsChecked = false;
            var currentUsers = Entities.GetContext().User.ToList();
            ListUser.ItemsSource = currentUsers;
            UpdateUsers();
        }

        private void SearchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateUsers();
        }

        private void SortType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateUsers();
        }

        

        private void Customers_Checked(object sender, RoutedEventArgs e)
        {
          
            UpdateUsers();
        }

        private void Sellers_Checked(object sender, RoutedEventArgs e)
        {
           
            UpdateUsers();
        }

        private void Admins_Checked(object sender, RoutedEventArgs e)
        {
            
            UpdateUsers();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
        }

        private void UpdateUsers()
        {

            var currentUsers = Entities.GetContext().User.ToList();


            currentUsers = currentUsers.Where(x => x.FIO.ToLower().Contains(SearchText.Text.ToLower())).ToList();

            if (Customers.IsChecked.Value)
                currentUsers = currentUsers.Where(x => x.Role.Contains("Customer")).ToList();
            if (Sellers.IsChecked.Value)
                currentUsers = currentUsers.Where(x => x.Role.Contains("Seller")).ToList();
            if (Admins.IsChecked.Value)
                currentUsers = currentUsers.Where(x => x.Role.Contains("Director")).ToList();


            if (SortType.SelectedIndex == 0)
                ListUser.ItemsSource = currentUsers.OrderBy(x => x.FIO).ToList();
            else ListUser.ItemsSource = currentUsers.OrderByDescending(x => x.FIO).ToList();
        }

        private void ClearAll()
        {
            SearchText.Text = "";
            SortType.SelectedIndex = 0;
            Customers.IsChecked = false;
            Sellers.IsChecked = false;
            Admins.IsChecked = false;
            UpdateUsers();
        }

        private void Admins_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateUsers();
        }

        private void Sellers_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateUsers();
        }

        private void Customers_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateUsers();
        }
    }
    }
