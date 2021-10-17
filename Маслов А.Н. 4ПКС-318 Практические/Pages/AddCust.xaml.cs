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
    /// Логика взаимодействия для AddCust.xaml
    /// </summary>
    public partial class AddCust : Page
    {
        private Customers _currentCust = new Customers();
        public AddCust(Customers selectedCust)
        {
            InitializeComponent();
            if (selectedCust != null)
                _currentCust = selectedCust;
            DataContext = _currentCust;
        }

        private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentCust.FirstName))
                errors.AppendLine("Укажите имя!");
            if (string.IsNullOrWhiteSpace(_currentCust.LastName))
                errors.AppendLine("Укажите фамилию!");
            if (string.IsNullOrWhiteSpace(_currentCust.Phone_number))
                errors.AppendLine("Укажите номер телефона");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentCust.ID_customer == 0)
                Entities.GetContext().Customers.Add(_currentCust);
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
