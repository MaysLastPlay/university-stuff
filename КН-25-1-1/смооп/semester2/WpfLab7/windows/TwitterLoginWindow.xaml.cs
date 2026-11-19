using System.Windows;

namespace WpfLab7.windows
{
    public partial class TwitterLoginWindow : Window
    {
        public string SocialEmail { get; private set; } = "";
        public string SocialName { get; private set; } = "";

        public TwitterLoginWindow()
        {
            InitializeComponent();
        }

        private void BtnAccept_Click(object sender, RoutedEventArgs e)
        {
            SocialEmail = "arguer_pro@x.com";
            SocialName = "Диванний Експерт";
            this.DialogResult = true;
        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}