using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;
using WpfLab9.classes.services;

namespace WpfLab9.classes
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private const string FilePath = "Students.xml";

        private Student? _selectedStudent;
        private string _lastName = "";
        private string _firstName = "";
        private string _age = "";
        private string _gender = "";

        public ObservableCollection<Student> Students { get; } = new();
        public string[] Genders { get; } = { "Чоловіча", "Жіноча" };

        public Student? SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                _selectedStudent = value;
                OnPropertyChanged();

                if (value != null)
                {
                    LastName = value.LastName;
                    FirstName = value.FirstName;
                    Age = value.Age.ToString();
                    Gender = value.Gender;
                }
            }
        }

        public string LastName { get => _lastName; set { _lastName = value; OnPropertyChanged(); } }
        public string FirstName { get => _firstName; set { _firstName = value; OnPropertyChanged(); } }
        public string Age { get => _age; set { _age = value; OnPropertyChanged(); } }
        public string Gender { get => _gender; set { _gender = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public MainViewModel()
        {
            LoadFromXml();

            AddCommand = new RelayCommand(_ => Add());
            EditCommand = new RelayCommand(_ => Edit(), _ => Students.Count > 0 && SelectedStudent != null);
            DeleteCommand = new RelayCommand(Delete, CanDelete);
        }

        private bool Validate(out int parsedAge)
        {
            var errors = new List<string>();
            parsedAge = 0;

            if (string.IsNullOrWhiteSpace(LastName))
                errors.Add("• Поле «Прізвище» обов'язкове.");
            if (string.IsNullOrWhiteSpace(FirstName))
                errors.Add("• Поле «Ім'я» обов'язкове.");
            if (string.IsNullOrWhiteSpace(Gender))
                errors.Add("• Поле «Стать» обов'язкове.");

            if (!int.TryParse(Age.Trim(), out parsedAge))
                errors.Add("• Поле «Вік» має бути цілим числом.");
            else if (parsedAge < 0)
                errors.Add("• Вік не може бути від'ємним.");
            else if (parsedAge < 16 || parsedAge > 100)
                errors.Add("• Вік повинен бути в діапазоні [16, 100].");

            if (errors.Count > 0)
            {
                MessageBox.Show(string.Join("\n", errors), "Помилка валідації",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        private void Add()
        {
            if (!Validate(out int age)) return;

            Students.Add(new Student
            {
                LastName = LastName.Trim(),
                FirstName = FirstName.Trim(),
                Age = age,
                Gender = Gender.Trim()
            });

            SaveToXml();
            ClearFields();
        }

        private void Edit()
        {
            if (SelectedStudent == null || !Validate(out int age)) return;

            SelectedStudent.LastName = LastName.Trim();
            SelectedStudent.FirstName = FirstName.Trim();
            SelectedStudent.Age = age;
            SelectedStudent.Gender = Gender.Trim();

            SaveToXml();
        }

        private bool CanDelete(object? parameter)
        {
            if (Students.Count == 0) return false;
            return parameter is IList list ? list.Count > 0 : SelectedStudent != null;
        }

        private void Delete(object? parameter)
        {
            var toDelete = parameter is IList list && list.Count > 0
                ? list.OfType<Student>().ToList()
                : SelectedStudent != null ? new List<Student> { SelectedStudent } : new List<Student>();

            if (toDelete.Count == 0) return;

            string msg = toDelete.Count == 1
                ? $"Видалити {toDelete[0].FullName}?"
                : $"Видалити вибраних студентів ({toDelete.Count})?";

            if (MessageBox.Show(msg, "Підтвердження", MessageBoxButton.YesNo, MessageBoxImage.Question)
                != MessageBoxResult.Yes)
                return;

            foreach (var s in toDelete)
                Students.Remove(s);

            SaveToXml();
            ClearFields();
        }

        private void LoadFromXml()
        {
            if (!File.Exists(FilePath)) return;

            var doc = XDocument.Load(FilePath);
            foreach (var el in doc.Root?.Elements("Student") ?? Enumerable.Empty<XElement>())
            {
                Students.Add(new Student
                {
                    LastName = (string?)el.Element("LastName") ?? "",
                    FirstName = (string?)el.Element("FirstName") ?? "",
                    Age = int.TryParse((string?)el.Element("Age"), out int a) ? a : 0,
                    Gender = (string?)el.Element("Gender") ?? ""
                });
            }
        }

        private void SaveToXml()
        {
            var doc = new XDocument(
                new XElement("Students",
                    Students.Select(s => new XElement("Student",
                        new XElement("LastName", s.LastName),
                        new XElement("FirstName", s.FirstName),
                        new XElement("Age", s.Age),
                        new XElement("Gender", s.Gender)))));
            doc.Save(FilePath);
        }

        private void ClearFields()
        {
            SelectedStudent = null;
            LastName = FirstName = Age = Gender = "";
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}