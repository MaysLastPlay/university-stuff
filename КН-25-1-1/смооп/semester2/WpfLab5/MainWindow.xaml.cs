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

namespace WpfLab5
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
            Task1 task1Window = new Task1();
            task1Window.ShowDialog();
        }

        private void BtnTask2_Click(object sender, RoutedEventArgs e)
        {
            Task2 task2Window = new Task2();
            task2Window.ShowDialog();
        }

        private void BtnTask3_Click(object sender, RoutedEventArgs e)
        {
            Task3 task3Window = new Task3();
            task3Window.ShowDialog();
        }

        private void BtnTask4_Click(object sender, RoutedEventArgs e)
        {
            Task4 task4Window = new Task4();
            task4Window.ShowDialog();
        }

        private void BtnTask5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnTask6_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    }