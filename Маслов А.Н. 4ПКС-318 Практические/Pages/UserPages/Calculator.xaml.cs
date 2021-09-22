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

namespace Маслов_А.Н._4ПКС_318_Практические.Pages.UserPages
{
    /// <summary>
    /// Логика взаимодействия для Calculator.xaml
    /// </summary>
    /// 



    public partial class Calculator : Page
    {

        string leftOperand = ""; // Левый операнд
        string operation = ""; // Знак операции
        string rightOperand = ""; // Правый операнд


        public Calculator()
        {
            InitializeComponent();
            foreach (UIElement c in LayoutRoot.Children)
            {
                if (c is Button)
                {
                    ((Button)c).Click += Button_Click;
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Получаем текст кнопки
            string text = (string)((Button)e.OriginalSource).Content;
            // Добавляем его в текстовое поле
            textBlock.Text += text;
            int num;
            // Пытаемся преобразовать его в число
            bool IfNumber = Int32.TryParse(text, out num);

            // Если текст - это число
            if (IfNumber == true)
            {
                // Если операция не задана
                if (operation == "")
                {
                    // Добавляем к левому операнду
                    leftOperand += text;
                }
                else
                {
                    // Иначе к правому операнду
                    rightOperand += text;
                }
            }

            // Если было введено не число
            else
            {
                // Если равно, то выводим результат операции
                if (text == "=")
                {
                    CalculateRegularOperations();
                    textBlock.Text += rightOperand;
                    operation = "";
                }
                // Очищаем поле и переменные
                else if (text == "CLEAR")
                {
                    Clear();
                }
                // Получаем операцию
                else
                {
                    // Если правый операнд уже имеется, то присваиваем его значение левому
                    // операнду, а правый операнд очищаем
                    if (rightOperand != "")
                    {  
                        CalculateRegularOperations();
                        leftOperand = rightOperand;
                        rightOperand = "";
                    }        
                    operation = text;
                }
            }
        }


        // Обновляем значение правого операнда
        private void CalculateRegularOperations()
        {
            try
            {
                int num1 = Int32.Parse(leftOperand);


                int num2;
                // И выполняем операцию
                switch (operation)
                {
                    case "+":
                        num2 = Int32.Parse(rightOperand);
                        rightOperand = (num1 + num2).ToString();
                        break;
                    case "-":
                        num2 = Int32.Parse(rightOperand);
                        rightOperand = (num1 - num2).ToString();
                        break;
                    case "*":
                        num2 = Int32.Parse(rightOperand);
                        rightOperand = (num1 * num2).ToString();
                        break;
                    case "/":
                        num2 = Int32.Parse(rightOperand);
                        if (num2 == 0)
                        {
                            MessageBox.Show("На нуль делить нельзя!");
                        }
                        else
                            rightOperand = (num1 / num2).ToString();
                        break;
                    case "|x|":
                        rightOperand = Math.Abs(num1).ToString();
                        break;
                    case "ln":
                        rightOperand = Math.Log10(num1).ToString();
                        break;
                    case "n!":
                        rightOperand = Factorial(num1).ToString();
                        break;
                    case "1/x":
                        rightOperand = ((double)(Math.Pow(num1, -1))).ToString();
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Сначала нужно выбрать число!");
            }
        }

        private void Clear()
        {
            leftOperand = "";
            rightOperand = "";
            operation = "";
            textBlock.Text = "";
        }

        static int Factorial(int x)
        {
            if (x == 0)
            {
                return 1;
            }
            else
            {
                return x * Factorial(x - 1);
            }
        }
    }
}

