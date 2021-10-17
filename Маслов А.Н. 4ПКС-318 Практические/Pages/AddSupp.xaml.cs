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
    /// Логика взаимодействия для AddSupp.xaml
    /// </summary>
    public partial class AddSupp : Page
    {
        private Products _currentProd = new Products();
        public AddSupp(Products selectedProduct)
        {
            InitializeComponent();
            if (selectedProduct != null)
                _currentProd = selectedProduct;
            DataContext = _currentProd;
        }

        private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentProd.Name))
                errors.AppendLine("Укажите имя!");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentProd.Price)))
                errors.AppendLine("Укажите цену!");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentProd.Count)))
                errors.AppendLine("Укажите должность!");
            if (DPDate.SelectedDate == null)
                errors.AppendLine("Укажите дату выпуска автомобиля!");
            else _currentProd.Guarantee = DPDate.SelectedDate;
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentProd.ID_product == 0)
                Entities.GetContext().Products.Add(_currentProd);
            try
            {
                Entities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно сохранены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
