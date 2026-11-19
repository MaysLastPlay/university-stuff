using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace WpfLab6.task1
{
    /// <summary>
    /// Interaction logic for Calculator.xaml
    /// </summary>
    public partial class Calculator : Window
    {
        private double prevValue = 0;
        private string curOperation = "";
        private bool isClicked = false;
        private readonly string decimalSep = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

        public Calculator()
        {
            InitializeComponent();
        }

        private void BtnNumber_Click(object sender, RoutedEventArgs e)
        {
            string number = ((Button)sender).Content.ToString() ?? string.Empty;

            if (curText.Text == "0" || isClicked)
            {
                curText.Text = number;
                isClicked = false;
            }
            else
            {
                curText.Text += number;
            }
        }

        private void BtnDot_Click(object sender, RoutedEventArgs e)
        {
            if (isClicked)
            {
                curText.Text = "0" + decimalSep;
                isClicked = false;
            }
            else if (!curText.Text.Contains(decimalSep))
            {
                curText.Text += decimalSep;
            }
        }

        private void BtnOperation_Click(object sender, RoutedEventArgs e)
        {
            string newOperation = ((Button)sender).Tag.ToString() ?? string.Empty;

            if (prevValue != 0 && !isClicked && !string.IsNullOrEmpty(curOperation))
                CalculateResult();

            curOperation = newOperation;
            double.TryParse(curText.Text, out prevValue);
            prevText.Text = $"{prevValue} {curOperation}";
            isClicked = true;
        }

        private void BtnEqual_Click(object sender, RoutedEventArgs e)
        {
            CalculateResult();
            prevText.Text = "";
            curOperation = "";
        }

        private void CalculateResult()
        {
            if (string.IsNullOrEmpty(curOperation) || !double.TryParse(curText.Text, out double currentValue))
                return;

            double result = prevValue;

            switch (curOperation)
            {
                case "+": result = prevValue + currentValue; break;
                case "-": result = prevValue - currentValue; break;
                case "*": result = prevValue * currentValue; break;
                case "/":
                    if (currentValue == 0)
                    {
                        MessageBox.Show("Cannot divide by zero!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        BtnC_Click(null, null);
                        return;
                    }
                    result = prevValue / currentValue;
                    break;
            }

            curText.Text = result.ToString();
            prevValue = result;
            isClicked = true;
        }

        private void BtnCE_Click(object sender, RoutedEventArgs e) => curText.Text = "0";

        private void BtnC_Click(object sender, RoutedEventArgs e)
        {
            curText.Text = "0";
            prevText.Text = "";
            prevValue = 0;
            curOperation = "";
        }

        private void BtnBackspace_Click(object sender, RoutedEventArgs e)
        {
            if (curText.Text.Length > 1)
            {
                curText.Text = curText.Text.Substring(0, curText.Text.Length - 1);

                if (curText.Text == "-" || curText.Text == decimalSep)
                {
                    curText.Text = "0";
                }
            }
            else
            {
                curText.Text = "0";
            }
        }
    }
}