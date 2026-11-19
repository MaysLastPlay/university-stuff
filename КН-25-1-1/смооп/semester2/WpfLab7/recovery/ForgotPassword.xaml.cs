using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using WpfLab7.data;
using WpfLab7.windows;

namespace WpfLab7
{
    public partial class ForgotPassword : Window
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void BtnSavePassword_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string newPassword = pwdNew.Password;
            string confirmPassword = pwdConfirm.Password;

            var validationRules = new List<Func<string?>>
            {
                () => string.IsNullOrEmpty(email) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword)
                      ? "Будь ласка, заповніть усі поля." : null,

                () => newPassword.Length < 8
                      ? "Новий пароль повинен містити мінімум 8 символів." : null,

                () => newPassword != confirmPassword
                      ? "Паролі не збігаються. Спробуйте ще раз." : null
            };

            string? firstError = validationRules
                .Select(rule => rule())
                .FirstOrDefault(error => !string.IsNullOrEmpty(error));

            if (firstError != null)
            {
                MessageBox.Show(firstError, "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string filePath = "users.json";

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Користувачів не знайдено. Будь ласка, зареєструйтесь.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string json = File.ReadAllText(filePath);
            List<User> users = string.IsNullOrWhiteSpace(json)
                ? new List<User>()
                : JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();

            User? user = users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            if (user == null)
            {
                MessageBox.Show("Користувача з такою електронною поштою не знайдено.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int userIndex = users.IndexOf(user);
            users[userIndex] = user with { Password = newPassword };

            string jsonToSave = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonToSave);

            MessageBox.Show("Ваш пароль було успішно змінено! Тепер ви можете увійти з новим паролем.", "Успіх", MessageBoxButton.OK, MessageBoxImage.Information);

            ReturnToLogin();
        }

        private void BtnGoToLogin_Click(object sender, RoutedEventArgs e)
        {
            ReturnToLogin();
        }

        private void ReturnToLogin()
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}