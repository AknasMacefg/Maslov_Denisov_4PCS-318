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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        
            
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AuthPage());
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            bool warn = false;
            if (string.IsNullOrEmpty(TextBoxLogin.Text))
            {
                WarningLog.Visibility = Visibility.Visible;
                warn = true;
            }
            else
                WarningLog.Visibility = Visibility.Hidden;

            if (string.IsNullOrEmpty(PasswordBox.Password))
            {
                WarningPass.Visibility = Visibility.Visible;
            }
            else
            {
                if (PasswordBox.Password.Length >= 6)
                {

                    bool en = true; // английская раскладка
                    bool symbol = false; // символ
                    bool number = false; // цифра

                    for (int i = 0; i < PasswordBox.Password.Length; i++) // перебираем символы
                    {
                        if (PasswordBox.Password[i] >= 'А' && PasswordBox.Password[i] <= 'Я') en = false; // если русская раскладка
                        if (PasswordBox.Password[i] >= '0' && PasswordBox.Password[i] <= '9') number = true; // если цифры
                        if (PasswordBox.Password[i] == '_' || PasswordBox.Password[i] == '-') symbol = true; // если символ
                    }
                    if (!en || !symbol || !number)
                    {
                        warn = true;
                        WarningPass.Visibility = Visibility.Visible;

                    }
                    else
                        WarningPass.Visibility = Visibility.Hidden;
                }
                else
                {
                    warn = true;
                    WarningPass.Visibility = Visibility.Visible;
                }
            }
            


            if (RepPasswordBox.Password != PasswordBox.Password)
                {
                warn = true;
                WarningRepPass.Visibility = Visibility.Visible;
                }
            else
                WarningRepPass.Visibility = Visibility.Hidden;

            if (string.IsNullOrEmpty(FIO.Text))
                {
                warn = true;
                WarningFIO.Visibility = Visibility.Visible;
                }
            else
                WarningFIO.Visibility = Visibility.Hidden;
            if (warn != true)
            {
                Entities db = new Entities();
                User userObject = new User
                {
                    ID = Convert.ToInt32(db.User.Count()),
                    FIO = FIO.Text,
                    Login = TextBoxLogin.Text,
                    Password = PasswordBox.Password,
                    Role = Role.Text
                   
                };
               
                db.User.Add(userObject);
                db.SaveChanges();
                MessageBox.Show("Пользователь успешно зарегистрирован!");
                NavigationService?.Navigate(new AuthPage());

            }
            else
                MessageBox.Show("Не все поля заполнены правильно!");
            
        }
    }
}
