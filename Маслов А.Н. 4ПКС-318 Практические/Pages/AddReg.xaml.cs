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
using Маслов_А.Н._4ПКС_318_Практические;

namespace Маслов_А.Н._4ПКС_318_Практические.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddReg.xaml
    /// </summary>
    public partial class AddReg : Page
    {

        private Employees _currentEmp = new Employees();
        public AddReg()
        {
            InitializeComponent();
            DataContext = _currentEmp;
        }
       
        private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
        {

            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentEmp.FirstName))
                errors.AppendLine("Укажите имя!");
            if (string.IsNullOrWhiteSpace(_currentEmp.LastName))
                errors.AppendLine("Укажите фамилию!");
            if (string.IsNullOrWhiteSpace(_currentEmp.Position))
                errors.AppendLine("Укажите должность!");
            if (string.IsNullOrWhiteSpace(_currentEmp.Phone_number))
                errors.AppendLine("Укажите номер телефона");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentEmp.ID_Employer == 0)
                Entities.GetContext().Employees.Add(_currentEmp);
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
