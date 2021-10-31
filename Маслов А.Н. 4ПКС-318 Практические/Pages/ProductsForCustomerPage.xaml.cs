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
    /// Логика взаимодействия для Supplies.xaml
    /// </summary>
    public partial class ProductsForCustomerPage : Page
    {
        public ProductsForCustomerPage()
        {
            InitializeComponent();
            SortPrice.SelectedIndex = 0;
            OnlyGPU.IsChecked = false;
            OnlyRAM.IsChecked = false;
            OnlyProcessors.IsChecked = false;

            var currentUsers = Entities.GetContext().Products.ToList();
            ListUser.ItemsSource = currentUsers;
            UpdateUsers();
        }

        private void SearchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateUsers();
        }


  

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
        }

        private void UpdateUsers()
        {

            var currentUsers = Entities.GetContext().Products.ToList();


            currentUsers = currentUsers.Where(x => x.Name.ToLower().Contains(SearchText.Text.ToLower())).ToList();

            if (OnlyRAM.IsChecked.Value)
                currentUsers = currentUsers.Where(x => x.Name.Contains("ОЗУ")).ToList();
            if (OnlyGPU.IsChecked.Value)
                currentUsers = currentUsers.Where(x => x.Name.Contains("Видеокарта")).ToList();
            if (OnlyProcessors.IsChecked.Value)
                currentUsers = currentUsers.Where(x => x.Name.Contains("Процессор")).ToList();

            if (SortPrice.SelectedIndex == 1)
                ListUser.ItemsSource = currentUsers.OrderBy(x => x.Price).ToList();
            else ListUser.ItemsSource = currentUsers.OrderByDescending(x => x.Price).ToList();
        }

        private void ClearAll()
        {
            SearchText.Text = "";
            SortPrice.SelectedIndex = 0;
            OnlyGPU.IsChecked = false;
            OnlyRAM.IsChecked = false;
            OnlyProcessors.IsChecked = false;
            UpdateUsers();
        }


    

        private void OnlyRAM_Checked(object sender, RoutedEventArgs e)
        {
            UpdateUsers();
        }

        private void OnlyRAM_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateUsers();
        }

        private void OnlyGPU_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateUsers();
        }

        private void OnlyGPU_Checked(object sender, RoutedEventArgs e)
        {
            UpdateUsers();
        }

        private void OnlyProcessors_Checked(object sender, RoutedEventArgs e)
        {
            UpdateUsers();
        }

        private void OnlyProcessors_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateUsers();
        }

        private void SortPrice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateUsers();
        }
    }
       
}
