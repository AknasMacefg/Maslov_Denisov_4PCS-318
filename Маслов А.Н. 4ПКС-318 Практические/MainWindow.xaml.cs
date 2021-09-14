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
using Маслов_А.Н._4ПКС_318_Практические.Pages;

namespace Маслов_А.Н._4ПКС_318_Практические
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

       public void  Func123()
        {
            using (var db = new Entities())
            {
                var users = db.User.AsNoTracking().FirstOrDefault(u => u.Login == "admin" && u.Password == "admin");
            }
            return;
        }

        private void MainFrame_OnNavigated (object sender, NavigationEventArgs e)
        {
            if (!(e.Content is Page page)) return;
            this.Title = $"LESSON - {page.Title}";

            if (page is AuthPage)
            {
                ButtonBack.Visibility = Visibility.Hidden;
            }
            else
            {
                ButtonBack.Visibility = Visibility.Visible;
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack) MainFrame.GoBack();
        }
    }
}
