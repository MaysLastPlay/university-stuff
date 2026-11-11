using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfLab5
{
    /// <summary>
    /// Interaction logic for Task3.xaml
    /// </summary>
    public partial class Task3 : Window
    {
        public Task3()
        {
            InitializeComponent();
        }

        private void BtnShowInput_Click(object sender, RoutedEventArgs e)
        {
            Task3Input.Visibility = Visibility.Visible;
        }

        private void BtnHideInput_Click(object sender, RoutedEventArgs e)
        {
            Task3Input.Visibility = Visibility.Collapsed;
        }

        private void BtnClearInput_Click(object sender, RoutedEventArgs e)
        {
           Task3Input.Clear();
        }

        private void BtnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
