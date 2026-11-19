using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Media;
using WpfLab7.data;

namespace WpfLab7
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = pwdBox.Password;
            DateTime? birthDate = dpBirthDate.SelectedDate;
            bool isAgreed = chkAgree.IsChecked ?? false;

            var validationRules = new List<Func<string?>>
            {
                () => string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)
                      ? "Будь ласка, заповніть усі текстові поля та пароль." : null,

                () => password.Length < 8
                      ? "Пароль повинен містити мінімум 8 символів." : null,

                () => !birthDate.HasValue
                      ? "Будь ласка, вкажіть дату народження." : null,

                () => birthDate.HasValue && birthDate.Value > DateTime.Now
                      ? "Дата народження не може бути в майбутньому." : null,

                () => !isAgreed
                      ? "Ви повинні погодитись з умовами використання для реєстрації." : null
            };

            string? firstError = validationRules
                .Select(rule => rule())
                .FirstOrDefault(error => !string.IsNullOrEmpty(error));

            if (firstError != null)
            {
                MessageBox.Show(firstError, "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string gender = rbMale.IsChecked == true ? "Чоловіча" :
                            rbFemale.IsChecked == true ? "Жіноча" :
                            "Інше";

            User newUser = new User(name, email, password, birthDate, gender, LogInfo.Email);

            string filePath = "users.json";
            List<User> users = new List<User>();

            if (File.Exists(filePath))
            {
                string existingJson = File.ReadAllText(filePath);
                if (!string.IsNullOrWhiteSpace(existingJson))
                {
                    users = JsonSerializer.Deserialize<List<User>>(existingJson) ?? new List<User>();
                }
            }

            if (users.Any(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Користувач з такою поштою вже існує!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            users.Add(newUser);
            string jsonToSave = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonToSave);

            string successMessage = $"Вітаємо, {name}!\n\n" +
                                  $"Ваш акаунт успішно створено та збережено.\n" +
                                  $"Email: {email}\n" +
                                  $"Стать: {gender}\n" +
                                  $"Дата народження: {birthDate.Value.ToShortDateString()}";

            MessageBox.Show(successMessage, "Успіх", MessageBoxButton.OK, MessageBoxImage.Information);

            this.Resources["AccentColor"] = new SolidColorBrush(Color.FromRgb(40, 167, 69));
            this.Resources["AccentColorHover"] = new SolidColorBrush(Color.FromRgb(33, 136, 56));

            btnRegister.Content = "Зареєстровано!";
            btnRegister.IsEnabled = false;
        }
    }
}