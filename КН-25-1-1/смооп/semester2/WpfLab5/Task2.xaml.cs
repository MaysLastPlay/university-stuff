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
    /// Interaction logic for Task2.xaml
    /// </summary>
    public partial class Task2 : Window
    {
        public Task2()
        {
            InitializeComponent();
        }

        private void BtnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnShowMessage_Click(object sender, RoutedEventArgs e)
        {
            Task2Text.Visibility = Visibility.Visible;
        }

        private void BtnHideMessage_Click(object sender, RoutedEventArgs e)
        {
            Task2Text.Visibility = Visibility.Collapsed;
        }

        }
    }
