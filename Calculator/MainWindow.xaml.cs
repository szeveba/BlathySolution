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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum CalcButtons { Percent, Sqrt, Pow, Reciprocal, CE, C, Backspace, Divide, N7, N8, N9, Multiplication, N4, N5, N6, Minus, N1, N2, N3, Plus, PlusMinus, N0, Dot, Equal }
        public MainWindow()
        {
            InitializeComponent();
        }
        string firstOperand;
        string secondOperand;
        CalcButtons? @operator;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var key = (CalcButtons)button.Tag;
            switch (key)
            {
                case CalcButtons.N7:
                case CalcButtons.N8:
                case CalcButtons.N9:
                case CalcButtons.N4:
                case CalcButtons.N5:
                case CalcButtons.N6:
                case CalcButtons.N1:
                case CalcButtons.N2:
                case CalcButtons.N3:
                case CalcButtons.N0:
                    if (@operator == null)
                    {
                        if (firstOperand == "0") firstOperand = (string)button.Content;
                        else firstOperand += button.Content;
                        MainSceenLabel.Content = firstOperand;
                    }
                    else
                    {
                        if (secondOperand == "0") secondOperand = (string)button.Content;
                        else secondOperand += button.Content;
                        MainSceenLabel.Content = secondOperand;
                    }
                    break;
                case CalcButtons.Percent:
                case CalcButtons.Sqrt:
                case CalcButtons.Pow:
                case CalcButtons.Reciprocal:
                case CalcButtons.Divide:
                case CalcButtons.Multiplication:
                case CalcButtons.Minus:
                case CalcButtons.Plus:
                    @operator = key;
                    secondOperand = "0";
                    MainSceenLabel.Content = secondOperand;
                    break;
                case CalcButtons.PlusMinus:

                    break;
                    if (@operator == null)
                    {
                        @operator = key;
                    }
                    else
                    {
                    }
                    break;
                    break;
                    break;
                    break;
                case CalcButtons.CE:
                    firstOperand = "0";
                    secondOperand = "0";
                    @operator = null;
                    MainSceenLabel.Content = firstOperand;
                    break;
                case CalcButtons.C:
                    break;
                case CalcButtons.Backspace:
                    if (@operator == null)
                    {
                        if (firstOperand.Length == 1)
                        {
                            firstOperand = "0";
                        }
                        else
                        {
                            firstOperand = firstOperand.Substring(0, firstOperand.Length - 1);
                        }
                        MainSceenLabel.Content = firstOperand;
                    }


                    break;
                case CalcButtons.Dot:
                    break;
                case CalcButtons.Equal:
                    if (@operator != null)
                    {
                        Equal();
                    }
                    break;
                default:
                    break;
            }
        }

        private void Equal()
        {
            double result = 0;
            var first = double.Parse(firstOperand);
            var second = double.Parse(secondOperand);
            switch (@operator)
            {
                case CalcButtons.Plus:
                    result = first + second;

                    break;
                default:
                    break;
            }
            @operator = null;
            firstOperand = result.ToString();
            MainSceenLabel.Content = firstOperand;


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < ButtonGrid.Children.Count; i++)
            {
                var button = (Button)ButtonGrid.Children[i];
                button.Tag = (CalcButtons)i;
            }
        }
    }
}
