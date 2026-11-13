using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfLab5
{
    public partial class Task4 : Window
    {
        public Task4()
        {
            InitializeComponent();
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;

            switch (clickedButton?.Name)
            {
                case "Btn1":
                    ToggleVisibility(Btn1);
                    ToggleVisibility(Btn2);
                    ToggleVisibility(Btn4);
                    break;

                case "Btn2":
                    ToggleVisibility(Btn2);
                    ToggleVisibility(Btn1);
                    ToggleVisibility(Btn3);
                    break;

                case "Btn3":
                    ToggleVisibility(Btn3);
                    ToggleVisibility(Btn2);
                    ToggleVisibility(Btn4);
                    break;

                case "Btn4":
                    ToggleVisibility(Btn4);
                    ToggleVisibility(Btn3);
                    ToggleVisibility(Btn5);
                    break;

                case "Btn5":
                    ToggleVisibility(Btn5);
                    ToggleVisibility(Btn4);
                    ToggleVisibility(Btn1);
                    break;
            }

            CheckWinner();
        }

        private void ToggleVisibility(Button btn)
        {
            if (btn.Visibility == Visibility.Visible)
            {
                btn.Visibility = Visibility.Hidden;
            }
            else
            {
                btn.Visibility = Visibility.Visible;
            }
        }

        private void CheckWinner()
        {
            if (Btn1.Visibility == Visibility.Hidden &&
                Btn2.Visibility == Visibility.Hidden &&
                Btn3.Visibility == Visibility.Hidden &&
                Btn4.Visibility == Visibility.Hidden &&
                Btn5.Visibility == Visibility.Hidden)
            {
                MessageBox.Show("Congratulations! You hid all buttons and won the game!", "Victory");

                Btn1.Visibility = Btn2.Visibility = Btn3.Visibility = Btn4.Visibility = Btn5.Visibility = Visibility.Visible;
            }
        }
        private void BtnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}