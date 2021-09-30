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
using Маслов_А.Н._4ПКС_318_Практические.Pages.UserPages;
using System.IO; //для осуществления чтения/записи в файл
using System.Diagnostics; //для запуска Блокнота
using Microsoft.Win32;

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

        public void Func123()
        {
            using (var db = new Entities())
            {
                var users = db.User.AsNoTracking().FirstOrDefault(u => u.Login == "admin" && u.Password == "admin");
            }
            return;
        }

        private void MainFrame_OnNavigated(object sender, NavigationEventArgs e)
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
            var uri = new Uri("Dictionary.xaml", UriKind.Relative);
            // загружаем словарь ресурсов
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            // очищаем коллекцию ресурсов приложения
            Application.Current.Resources.Clear();
            // добавляем загруженный словарь ресурсов          
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void ButtonBack_Copy_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Source = new Uri("Pages/UserPages/Calculator.xaml", UriKind.Relative);


        }
        private void ButtonExp_Click(object sender, RoutedEventArgs e)
        {
            Export();
        }

        void Export()
        {


            using (var db = new Entities())
            {
                var user = db.User
                    .AsNoTracking()
                    .FirstOrDefault();
                
                
                SaveFileDialog saveFile = new SaveFileDialog();

                saveFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

                if( saveFile.ShowDialog() == true)
                    {
                    
                        StreamWriter sw = new StreamWriter(saveFile.FileName);
                        
                        string IDline = ":" + String.Join(":", db.User.Select(x => x.ID));
                        sw.WriteLine(IDline);
                        string Loginline = ":" + String.Join(":", db.User.Select(x => x.Login));
                        sw.WriteLine(Loginline);
                        string Passwordline = ":" + String.Join(":", db.User.Select(x => x.Password));
                        sw.WriteLine(Passwordline);
                        string Roleline = ":" + String.Join(":", db.User.Select(x => x.Role));
                        sw.WriteLine(Roleline);
                        string FIOline = ":" + String.Join(":", db.User.Select(x => x.FIO));
                        sw.WriteLine(FIOline);
                        sw.Close();
                        
                        Process.Start("notepad.exe", saveFile.FileName);
                        
                    
                }
                
            }
        }

        private void ButtonImp_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            if (ofd.FileName != "") // проверка на выбор файла
            {
                StreamReader sr = new StreamReader(ofd.FileName); // открываем файл
                while (!sr.EndOfStream) // перебираем строки, пока они не закончены
                {
                    string[] lines = new string[5];// массив данных 
                    for (int i = 0; i < 5; i++) // читаем 5 строк 
                    {
                        string line = sr.ReadLine(); // читаем строку  
                        string[] data = line.Split(':');
                        line = ""; // обнуляем переменную    
                        if (data.Length >= 2) // проверяем на целостность данных  
                        {
                            for (int j = 1; j < data.Length; j++) // складываем данные      
                            {
                                line += data[j];
                                line += ":";// собираем строку  
                            }
                        }
                        lines[i] = line; // записываем значения в массив 
                    }
                    // выводим данные 
                    MessageBox.Show("Данные в файле: \nID: " + lines[0] + "\nЛогин: " + lines[1] + "\nПароль: " + lines[2] + "\nРоль: " + lines[3] + "\nФИо: " + lines[4]);
                }

            }
            else MessageBox.Show("Файл для импорта не выбран!");

        }
    }
}
