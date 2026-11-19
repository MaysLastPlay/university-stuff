using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfLab6.task1;
using WpfLab6.task2;

namespace WpfLab6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnTask1_Click(object sender, RoutedEventArgs e)
        {
            Calculator calculator = new Calculator();
            calculator.ShowDialog();
        }

        private void BtnTask2_Click(object sender, RoutedEventArgs e)
        {
            OilyOil task2 = new OilyOil();
            task2.ShowDialog();
        }
    }
}