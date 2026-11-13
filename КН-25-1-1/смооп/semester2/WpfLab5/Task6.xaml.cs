using System;
using System.Windows;
using System.Windows.Media;

namespace WpfLab5
{
    public partial class Task6 : Window
    {
        private byte targetR;
        private byte targetG;
        private byte targetB;

        private Random random = new Random();
        private bool isGameWon = false;

        public Task6()
        {
            InitializeComponent();
            GenerateRecipe();
        }
        private void GenerateRecipe()
        {
            targetR = (byte)random.Next(0, 256);
            targetG = (byte)random.Next(0, 256);
            targetB = (byte)random.Next(0, 256);

            RecipeText.Text = $"Recipe: R: {targetR}, G: {targetG}, B: {targetB}";
            isGameWon = false;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (SliderR == null || SliderG == null || SliderB == null) return;

            byte currentR = (byte)SliderR.Value;
            byte currentG = (byte)SliderG.Value;
            byte currentB = (byte)SliderB.Value;

            Color currentColor = Color.FromRgb(currentR, currentG, currentB);
            MagicCrystal.Fill = new SolidColorBrush(currentColor);

            if (!isGameWon && currentR == targetR && currentG == targetG && currentB == targetB)
            {
                isGameWon = true;
                MessageBox.Show("Potion is ready!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                GenerateRecipe();
            }
        }
        private void BtnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}