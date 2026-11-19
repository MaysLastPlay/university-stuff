using System.Windows;

namespace WpfLab7.windows
{
    public partial class GoogleLoginWindow : Window
    {
        public string SocialEmail { get; private set; } = "";
        public string SocialName { get; private set; } = "";

        public GoogleLoginWindow()
        {
            InitializeComponent();
        }

        private void BtnAccept_Click(object sender, RoutedEventArgs e)
        {
            SocialEmail = "data.donor@gmail.com";
            SocialName = "Свідок Алгоритму";
            this.DialogResult = true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}