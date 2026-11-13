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
    /// Interaction logic for Task1.xaml
    /// </summary>
    public partial class Task1 : Window
    {
        public Task1()
        {
            InitializeComponent();
        }

        private void BtnHello_Click(object sender, RoutedEventArgs e)
        {
            Task1Text.Text = "Привіт";
        }

        private void BtnGoodbye_Click(object sender, RoutedEventArgs e)
        {
            Task1Text.Text = "До побачення";
        }

        private void BtnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
