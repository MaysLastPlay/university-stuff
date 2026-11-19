using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WpfLab6.task2
{
    public partial class OilyOil : Window
    {
        /// <summary>
        /// Interaction logic for OilyOil.xaml
        /// </summary>
        private readonly Dictionary<string, double> fuelPrices = new Dictionary<string, double>()
        {
            { "А-95 Преміум", 58.50 }, { "А-95", 55.40 }, { "А-92", 52.30 }, { "ДП", 54.00 }, { "Газ", 28.50 }
        };
        private double dailyRevenue = 0;

        public OilyOil()
        {
            InitializeComponent();
            foreach (var f in fuelPrices.Keys) cmbFuel.Items.Add(f);
            cmbFuel.SelectedIndex = 0;
            this.Closing += (s, e) => { if (dailyRevenue > 0) MessageBox.Show($"Виручка за день: {dailyRevenue:F2} грн", "Звіт"); };
        }

        private void CmbFuel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtFuelPrice.Text = fuelPrices[cmbFuel.SelectedItem.ToString() ?? string.Empty].ToString("F2");
            CalculateFuel(null, null);
        }

        private void RbFuelMode_Checked(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded) return;
            bool isLiters = rbLiters.IsChecked == true;

            txtLiters.IsEnabled = isLiters;
            txtMoney.IsEnabled = !isLiters;
            txtLiters.Text = txtMoney.Text = "";

            gbFuelResult.Header = isLiters ? "До оплати:" : "До видачі (л):";
            CalculateFuel(null, null);
        }

        private void CalculateFuel(object sender, TextChangedEventArgs e)
        {
            if (!IsLoaded) return;
            double price = fuelPrices[cmbFuel.SelectedItem.ToString() ?? string.Empty];

            if (rbLiters.IsChecked == true && double.TryParse(txtLiters.Text, out double l))
                tbFuelResult.Text = (l * price).ToString("F2");
            else if (rbMoney.IsChecked == true && double.TryParse(txtMoney.Text, out double m))
                tbFuelResult.Text = (m / price).ToString("F2");
            else
                tbFuelResult.Text = "0.00";
        }

        private void CafeItem_Click(object sender, RoutedEventArgs e)
        {
            txtHotDogCnt.IsEnabled = chkHotDog.IsChecked == true;
            txtBurgerCnt.IsEnabled = chkBurger.IsChecked == true;
            txtColaCnt.IsEnabled = chkCola.IsChecked == true;

            if (chkHotDog.IsChecked == false) txtHotDogCnt.Text = "";
            if (chkBurger.IsChecked == false) txtBurgerCnt.Text = "";
            if (chkCola.IsChecked == false) txtColaCnt.Text = "";
        }

        private void CalculateCafe(object sender, TextChangedEventArgs e)
        {
            if (!IsLoaded) return;
            double total = 0;

            if (chkHotDog.IsChecked == true && int.TryParse(txtHotDogCnt.Text, out int h)) total += h * double.Parse(txtHotDogPrc.Text);
            if (chkBurger.IsChecked == true && int.TryParse(txtBurgerCnt.Text, out int b)) total += b * double.Parse(txtBurgerPrc.Text);
            if (chkCola.IsChecked == true && int.TryParse(txtColaCnt.Text, out int c)) total += c * double.Parse(txtColaPrc.Text);

            tbCafeResult.Text = total.ToString("F2");
        }

        private void BtnCalculateTotal_Click(object sender, RoutedEventArgs e)
        {
            double fuelTotal = 0;
            if (rbLiters.IsChecked == true) double.TryParse(tbFuelResult.Text, out fuelTotal);
            else if (rbMoney.IsChecked == true) double.TryParse(txtMoney.Text, out fuelTotal);

            double.TryParse(tbCafeResult.Text, out double cafeTotal);

            double finalTotal = fuelTotal + cafeTotal;
            tbTotal.Text = finalTotal.ToString("F2");
            dailyRevenue += finalTotal;
        }
    }
}