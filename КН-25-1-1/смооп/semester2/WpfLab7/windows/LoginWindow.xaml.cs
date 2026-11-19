using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Media;
using WpfLab7.data;
using WpfLab7.windows;

namespace WpfLab7.windows
{
    public partial class LoginWindow : Window
    {
        private readonly JsonSerializerOptions _jsonOptions;

        public LoginWindow()
        {
            InitializeComponent();

            _jsonOptions = new JsonSerializerOptions { WriteIndented = true };
            _jsonOptions.Converters.Add(new JsonStringEnumConverter());
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = pwdBox.Password;

            var validationRules = new List<Func<string?>>
            {
                () => string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)
                      ? "Будь ласка, введіть електронну пошту та пароль." : null,
            };

            string? firstError = validationRules
                .Select(rule => rule())
                .FirstOrDefault(error => !string.IsNullOrEmpty(error));

            if (firstError != null)
            {
                MessageBox.Show(firstError, "Помилка входу", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string filePath = "users.json";

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Користувачів не знайдено. Будь ласка, спочатку зареєструйтесь.", "Помилка входу", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string json = File.ReadAllText(filePath);
            List<User> users = string.IsNullOrWhiteSpace(json)
                ? new List<User>()
                : JsonSerializer.Deserialize<List<User>>(json, _jsonOptions) ?? new List<User>();

            User? loggedInUser = users.FirstOrDefault(u =>
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) &&
                u.Password == password);

            if (loggedInUser == null)
            {
                MessageBox.Show("Невірна електронна пошта або пароль.", "Помилка авторизації", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string successMessage = $"Вітаємо з поверненням, {loggedInUser.Name}!\n\n" +
                                  $"Ви успішно увійшли як:\n" +
                                  $"{loggedInUser.Email}\n" +
                                  $"Спосіб входу: {loggedInUser.loggedFrom}";

            MessageBox.Show(successMessage, "Успіх", MessageBoxButton.OK, MessageBoxImage.Information);

            this.Resources["AccentColor"] = new SolidColorBrush(Color.FromRgb(40, 167, 69));
            this.Resources["AccentColorHover"] = new SolidColorBrush(Color.FromRgb(33, 136, 56));

            btnLogin.Content = "Авторизовано!";
            btnLogin.IsEnabled = false;
        }

        private void BtnGoogle_Click(object sender, RoutedEventArgs e)
        {
            var googleWin = new GoogleLoginWindow { Owner = this };
            if (googleWin.ShowDialog() == true)
            {
                HandleSocialLogin(googleWin.SocialEmail, googleWin.SocialName, LogInfo.Google);
            }
        }

        private void BtnDiscord_Click(object sender, RoutedEventArgs e)
        {
            var discordWin = new DiscordLoginWindow { Owner = this };
            if (discordWin.ShowDialog() == true)
            {
                HandleSocialLogin(discordWin.SocialEmail, discordWin.SocialName, LogInfo.Discord);
            }
        }

        private void BtnTwitter_Click(object sender, RoutedEventArgs e)
        {
            var twitterWin = new TwitterLoginWindow { Owner = this };
            if (twitterWin.ShowDialog() == true)
            {
                HandleSocialLogin(twitterWin.SocialEmail, twitterWin.SocialName, LogInfo.Twitter);
            }
        }

        private void HandleSocialLogin(string email, string name, LogInfo loginMethod)
        {
            string filePath = "users.json";
            List<User> users = new List<User>();

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                if (!string.IsNullOrWhiteSpace(json))
                {
                    users = JsonSerializer.Deserialize<List<User>>(json, _jsonOptions) ?? new List<User>();
                }
            }

            User? existingUser = users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            if (existingUser == null)
            {
                existingUser = new User(
                    name,
                    email,
                    "SOCIAL_LOGIN_" + Guid.NewGuid().ToString().Substring(0, 8),
                    DateTime.Now.AddYears(-18),
                    "Інше",
                    loginMethod);

                users.Add(existingUser);
                File.WriteAllText(filePath, JsonSerializer.Serialize(users, _jsonOptions));
            }

            MessageBox.Show($"Вітаємо, {existingUser.Name}!\nВи успішно увійшли через {loginMethod}.", "Успіх", MessageBoxButton.OK, MessageBoxImage.Information);

            this.Resources["AccentColor"] = new SolidColorBrush(Color.FromRgb(40, 167, 69));
            this.Resources["AccentColorHover"] = new SolidColorBrush(Color.FromRgb(33, 136, 56));

            btnLogin.Content = "Авторизовано!";
            btnLogin.IsEnabled = false;
        }

        private void BtnGoToRegister_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow regWindow = new RegistrationWindow();
            regWindow.Show();
            this.Close();
        }

        private void BtnForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            ForgotPassword forgotPasswordWindow = new ForgotPassword();
            forgotPasswordWindow.Show();
            this.Close();
        }
    }
}