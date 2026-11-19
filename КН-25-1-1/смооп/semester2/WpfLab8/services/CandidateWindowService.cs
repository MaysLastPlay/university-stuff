using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace WpfLab8.services;

public class CandidateWindowService : INotifyPropertyChanged
{
    private const int MinAge = 18;
    private const int MaxAge = 75;
    private const int MinWorkingAge = 16;

    private string _fullName = string.Empty;
    private DateTime? _birthDate = new(1998, 1, 1);
    private string _education = "Вища";
    private int _experienceYears;
    private string _englishLevel = Candidate.LangNone;
    private string _germanLevel = Candidate.LangNone;
    private string _frenchLevel = Candidate.LangNone;
    private bool _hasComputerSkills = true;
    private bool _hasRecommendations;
    private string _validationError = string.Empty;

    public string WindowTitle { get; }
    public static IReadOnlyList<string> EducationOptions { get; } = new[] { "Середня", "Середня спеціальна", "Вища" };
    public static IReadOnlyList<string> LanguageLevelOptions { get; } = new[] { Candidate.LangNone, Candidate.LangDictionary, Candidate.LangFluent };

    public string FullName { get => _fullName; set => Set(ref _fullName, value, clearError: true); }
    public DateTime? BirthDate { get => _birthDate; set => Set(ref _birthDate, value, clearError: true); }
    public string Education { get => _education; set => Set(ref _education, value, clearError: true); }
    public int ExperienceYears { get => _experienceYears; set => Set(ref _experienceYears, value, clearError: true); }
    public string EnglishLevel { get => _englishLevel; set => Set(ref _englishLevel, value); }
    public string GermanLevel { get => _germanLevel; set => Set(ref _germanLevel, value); }
    public string FrenchLevel { get => _frenchLevel; set => Set(ref _frenchLevel, value); }
    public bool HasComputerSkills { get => _hasComputerSkills; set => Set(ref _hasComputerSkills, value); }
    public bool HasRecommendations { get => _hasRecommendations; set => Set(ref _hasRecommendations, value); }
    public string ValidationError { get => _validationError; set => Set(ref _validationError, value); }

    public CandidateWindowService(Candidate? existing = null)
    {
        WindowTitle = existing is null ? "Додавання нового кандидата" : "Редагування кандидата";
        if (existing is null) return;

        _fullName = existing.FullName;
        _birthDate = existing.BirthDate;
        _education = existing.Education;
        _experienceYears = existing.ExperienceYears;
        _englishLevel = existing.EnglishLevel;
        _germanLevel = existing.GermanLevel;
        _frenchLevel = existing.FrenchLevel;
        _hasComputerSkills = existing.HasComputerSkills;
        _hasRecommendations = existing.HasRecommendations;
    }

    public Candidate? TryBuildCandidate()
    {
        ValidationError = Validate() ?? string.Empty;
        return string.IsNullOrEmpty(ValidationError)
            ? new Candidate
            {
                FullName = FullName.Trim(),
                BirthDate = BirthDate,
                Education = Education,
                ExperienceYears = ExperienceYears,
                EnglishLevel = EnglishLevel,
                GermanLevel = GermanLevel,
                FrenchLevel = FrenchLevel,
                HasComputerSkills = HasComputerSkills,
                HasRecommendations = HasRecommendations
            }
            : null;
    }

    private string? Validate()
    {
        string name = (FullName ?? string.Empty).Trim();
        DateTime today = DateTime.Today;
        int? age = BirthDate.HasValue ? CalculateAge(BirthDate.Value.Date, today) : null;

        switch (name, BirthDate?.Date, age)
        {
            case ("", _, _):
                return "Введіть П.І.П. кандидата.";

            case (var n, _, _) when n.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length < 2:
                return "П.І.П. має містити щонайменше прізвище та ім'я.";

            case (var n, _, _) when n.Any(ch => !IsValidNameChar(ch)):
                return "П.І.П. може містити лише літери, пробіли, дефіс або апостроф.";

            case (_, null, _):
                return "Оберіть дату народження в календарі.";

            case (_, DateTime dob, _) when dob > today:
                return "Дата народження не може бути в майбутньому.";

            case (_, _, < MinAge or > MaxAge):
                return $"Вік кандидата для участі в конкурсі має становити від {MinAge} до {MaxAge} років.";

            case (_, _, int a) when ExperienceYears < 0 || ExperienceYears > a - MinWorkingAge:
                return $"Стаж роботи ({ExperienceYears} р.) не відповідає віку кандидата ({a} р.).";

            case (_, _, _) when string.IsNullOrWhiteSpace(Education):
                return "Оберіть рівень освіти.";

            default:
                return null;
        }
    }

    private static bool IsValidNameChar(char ch) =>
        char.IsLetter(ch) || ch is ' ' or '-' or '\'' or '’';

    private static int CalculateAge(DateTime dob, DateTime today) =>
        today.Year - dob.Year - (dob > today.AddYears(-(today.Year - dob.Year)) ? 1 : 0);

    public event PropertyChangedEventHandler? PropertyChanged;

    private void Set<T>(ref T field, T value, bool clearError = false, [CallerMemberName] string? propertyName = null)
    {
        if (Equals(field, value)) return;
        field = value;
        PropertyChanged?.Invoke(this, new(propertyName));
        if (clearError) ValidationError = "";
    }
}