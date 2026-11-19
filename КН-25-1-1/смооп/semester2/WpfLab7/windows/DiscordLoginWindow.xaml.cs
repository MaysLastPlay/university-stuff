using System.Windows;

namespace WpfLab7.windows
{
    public partial class DiscordLoginWindow : Window
    {
        public string SocialEmail { get; private set; } = "";
        public string SocialName { get; private set; } = "";

        public DiscordLoginWindow()
        {
            InitializeComponent();
        }

        private void BtnAccept_Click(object sender, RoutedEventArgs e)
        {
            SocialEmail = "gamer_without_sleep@discord.com";
            SocialName = "DarkSlayer99";
            this.DialogResult = true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
