using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Data;

namespace WpfLab8.services;

public class MainWindowService : INotifyPropertyChanged
{
    private readonly ObservableCollection<Candidate> _candidates = new();
    private Candidate? _selectedCandidate;
    private string _searchQuery = "";
    private string _selectedEducationFilter = "Усі";
    private string _selectedLanguageFilter = "Будь-яка";
    private int _minExperienceFilter;
    private bool _onlyWithComputerSkills;
    private bool _onlyWithRecommendations;

    public ICollectionView CandidatesView { get; }

    public string[] EducationFilterOptions { get; } = { "Усі", "Середня", "Середня спеціальна", "Вища" };
    public string[] LanguageFilterOptions { get; } =
    {
        "Будь-яка",
        "Англійська (будь-який рівень)", "Англійська (вільно)",
        "Німецька (будь-який рівень)", "Німецька (вільно)",
        "Французька (будь-який рівень)", "Французька (вільно)"
    };

    public Candidate? SelectedCandidate { get => _selectedCandidate; set => Set(ref _selectedCandidate, value, refresh: false); }
    public string SearchQuery { get => _searchQuery; set => Set(ref _searchQuery, value); }
    public string SelectedEducationFilter { get => _selectedEducationFilter; set => Set(ref _selectedEducationFilter, value); }
    public string SelectedLanguageFilter { get => _selectedLanguageFilter; set => Set(ref _selectedLanguageFilter, value); }
    public int MinExperienceFilter { get => _minExperienceFilter; set => Set(ref _minExperienceFilter, value); }
    public bool OnlyWithComputerSkills { get => _onlyWithComputerSkills; set => Set(ref _onlyWithComputerSkills, value); }
    public bool OnlyWithRecommendations { get => _onlyWithRecommendations; set => Set(ref _onlyWithRecommendations, value); }

    public string CandidatesCountText => $"Показано: {CandidatesView.Cast<object>().Count()} з {_candidates.Count}";

    public MainWindowService()
    {
        LoadSampleCandidates();
        CandidatesView = CollectionViewSource.GetDefaultView(_candidates);
        CandidatesView.Filter = MatchesFilters;
    }

    public void Add(Candidate candidate)
    {
        _candidates.Add(candidate);
        Refresh();
        SelectedCandidate = candidate;
    }

    public void UpdateSelected(Candidate updated)
    {
        SelectedCandidate?.CopyFrom(updated);
        Refresh();
    }

    public void DeleteSelected()
    {
        if (SelectedCandidate == null) return;
        _candidates.Remove(SelectedCandidate);
        SelectedCandidate = null;
        Refresh();
    }

    public void ResetFilters()
    {
        SearchQuery = "";
        SelectedEducationFilter = "Усі";
        SelectedLanguageFilter = "Будь-яка";
        MinExperienceFilter = 0;
        OnlyWithComputerSkills = false;
        OnlyWithRecommendations = false;
    }

    private void Refresh()
    {
        CandidatesView.Refresh();
        OnPropertyChanged(nameof(CandidatesCountText));
    }

    private bool MatchesFilters(object item)
    {
        if (item is not Candidate c) return false;

        bool matchesBasic =
            c.FullName.Contains(_searchQuery.Trim(), StringComparison.OrdinalIgnoreCase) &&
            (_selectedEducationFilter == "Усі" || c.Education == _selectedEducationFilter) &&
            c.ExperienceYears >= _minExperienceFilter &&
            (!_onlyWithComputerSkills || c.HasComputerSkills) &&
            (!_onlyWithRecommendations || c.HasRecommendations);

        return matchesBasic && MatchesLanguage(c);
    }

    private bool MatchesLanguage(Candidate c)
    {
        switch (_selectedLanguageFilter)
        {
            case "Англійська (будь-який рівень)":
                return c.EnglishLevel != Candidate.LangNone;
            case "Англійська (вільно)":
                return c.EnglishLevel == Candidate.LangFluent;
            case "Німецька (будь-який рівень)":
                return c.GermanLevel != Candidate.LangNone;
            case "Німецька (вільно)":
                return c.GermanLevel == Candidate.LangFluent;
            case "Французька (будь-який рівень)":
                return c.FrenchLevel != Candidate.LangNone;
            case "Французька (вільно)":
                return c.FrenchLevel == Candidate.LangFluent;
            default:
                return true;
        }
    }

    private void LoadSampleCandidates()
    {
        _candidates.Add(new Candidate
        {
            FullName = "Коваленко Олександр Сергійович",
            BirthDate = new DateTime(1995, 4, 12),
            Education = "Вища",
            ExperienceYears = 6,
            EnglishLevel = Candidate.LangFluent,
            GermanLevel = Candidate.LangDictionary,
            FrenchLevel = Candidate.LangNone,
            HasComputerSkills = true,
            HasRecommendations = true
        });
        _candidates.Add(new Candidate
        {
            FullName = "Мельник Ірина Володимирівна",
            BirthDate = new DateTime(1999, 9, 23),
            Education = "Вища",
            ExperienceYears = 3,
            EnglishLevel = Candidate.LangDictionary,
            GermanLevel = Candidate.LangNone,
            FrenchLevel = Candidate.LangFluent,
            HasComputerSkills = true,
            HasRecommendations = false
        });
        _candidates.Add(new Candidate
        {
            FullName = "Бондаренко Дмитро Петрович",
            BirthDate = new DateTime(1991, 11, 5),
            Education = "Середня спеціальна",
            ExperienceYears = 10,
            EnglishLevel = Candidate.LangNone,
            GermanLevel = Candidate.LangDictionary,
            FrenchLevel = Candidate.LangNone,
            HasComputerSkills = false,
            HasRecommendations = true
        });
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    private void Set<T>(ref T field, T value, bool refresh = true, [CallerMemberName] string? name = null)
    {
        if (Equals(field, value)) return;
        field = value;
        OnPropertyChanged(name);
        if (refresh) Refresh();
    }
}