using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DatingApp
{
    // Енумерації та моделі залишаються без змін
    public enum Gender { Чоловіча, Жіноча }
    public enum ClientStatus { Active, Archived, Deleted }
    public enum MeetingStatus { Pending, Accepted, Rejected }

    public class PartnerRequirements
    {
        public Gender PreferredGender { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public string CriteriaDescription { get; set; }
    }


    public partial class MainWindow : Window
    {
        private ObservableCollection<Client> _allClients = new ObservableCollection<Client>();
        private List<MeetingInvitation> _meetings = new List<MeetingInvitation>();
        private Client _currentActiveClient;

        public MainWindow()
        {
            InitializeComponent();
            LoadInitialData();
            InitializeAppLogic();
        }

        private void LoadInitialData()
        {
            _allClients.Add(new Client { RegNumber = "REG-001", FullName = "Олександр Петренко", Gender = Gender.Чоловіча, Age = 28, RegDate = new DateTime(2025, 1, 10), Requirements = new PartnerRequirements { PreferredGender = Gender.Жіноча, MinAge = 22, MaxAge = 30 } });
            _allClients.Add(new Client { RegNumber = "REG-002", FullName = "Марія Коваленко", Gender = Gender.Жіноча, Age = 25, RegDate = new DateTime(2025, 2, 5), Requirements = new PartnerRequirements { PreferredGender = Gender.Чоловіча, MinAge = 25, MaxAge = 35 } });
            _allClients.Add(new Client { RegNumber = "REG-003", FullName = "Анна Шевченко", Gender = Gender.Жіноча, Age = 27, RegDate = new DateTime(2025, 2, 12), Requirements = new PartnerRequirements { PreferredGender = Gender.Чоловіча, MinAge = 26, MaxAge = 36 } });
        }

        private void InitializeAppLogic()
        {
            CurrentClientComboBox.SelectionChanged += CurrentClientComboBox_SelectionChanged;
            UpdateClientDropdown();
        }

        private void UpdateClientDropdown()
        {
            var activeClients = _allClients.Where(c => c.Status == ClientStatus.Active).ToList();
            CurrentClientComboBox.ItemsSource = activeClients;

            if (activeClients.Any())
                CurrentClientComboBox.SelectedIndex = 0;
        }

        private void CurrentClientComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CurrentClientComboBox.SelectedItem is Client selectedClient)
            {
                _currentActiveClient = selectedClient;
                CandidatesDataGrid.ItemsSource = RunMatchingAlgorithm(_currentActiveClient);
            }
        }

        public bool RegisterNewClient(Client newClient)
        {
            if (_allClients.Any(c => c.RegNumber.Equals(newClient.RegNumber, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Помилка: Клієнт із таким реєстраційним номером вже існує!", "Дублікат", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(newClient.FullName) || newClient.Age < 18)
            {
                MessageBox.Show("Помилка валідації: ПІБ не може бути порожнім, а вік має бути від 18 років.", "Валідація", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            newClient.RegDate = DateTime.Now;
            _allClients.Add(newClient);

            UpdateClientDropdown();
            return true;
        }

        public List<Client> RunMatchingAlgorithm(Client client)
        {
            if (client?.Requirements == null) return new List<Client>();

            var req = client.Requirements;
            return _allClients.Where(c =>
                c.Status == ClientStatus.Active &&
                c.RegNumber != client.RegNumber &&
                c.Gender == req.PreferredGender &&
                c.Age >= req.MinAge &&
                c.Age <= req.MaxAge).ToList();
        }

        public void CreateMeetingInvitation(Client target)
        {
            if (_currentActiveClient == null || target == null)
            {
                MessageBox.Show("Оберіть обох учасників для зустрічі.", "Увага", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _meetings.Add(new MeetingInvitation
            {
                Initiator = _currentActiveClient,
                Target = target,
                MeetingDate = DateTime.Now.AddDays(3)
            });

            MessageBox.Show($"Запрошення між {_currentActiveClient.FullName} та {target.FullName} надіслано!", "Зустріч створена", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void MoveCoupleToArchive(Client client1, Client client2)
        {
            if (client1 != null) client1.Status = ClientStatus.Archived;
            if (client2 != null) client2.Status = ClientStatus.Archived;

            UpdateClientDropdown();
        }

        public void DeleteClient(string regNumber)
        {
            var client = _allClients.FirstOrDefault(c => c.RegNumber == regNumber);
            if (client != null)
            {
                client.Status = ClientStatus.Deleted;
                UpdateClientDropdown();
            }
        }
    }
}