using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfLab5
{
    public partial class Task5 : Window
    {
        private Random random = new Random();

        public Task5()
        {
            InitializeComponent();
        }

        private void CatchButton_MouseEnter(object sender, MouseEventArgs e)
        {
            double canvasWidth = MouseMoused.ActualWidth;
            double canvasHeight = MouseMoused.ActualHeight;

            if (canvasWidth == 0 || canvasHeight == 0) return;

            double maxX = canvasWidth - CatchButton.ActualWidth;
            double maxY = canvasHeight - CatchButton.ActualHeight;
            double newX = random.NextDouble() * maxX;
            double newY = random.NextDouble() * maxY;

            Canvas.SetLeft(CatchButton, newX);
            Canvas.SetTop(CatchButton, newY);
        }

        private void CatchButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Congrats! You are exceptionally quick and managed to catch the button!", "Victory");
        }

        private void BtnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}