using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace WpfLab8.services
{
        public class Candidate : INotifyPropertyChanged
        {
            public const string LangNone = "Не володію";
            public const string LangDictionary = "Читаю та перекладаю зі словником";
            public const string LangFluent = "Володію вільно";

            private string _fullName = string.Empty;
            private DateTime? _birthDate = new DateTime(1998, 1, 1);
            private string _education = "Вища";
            private int _experienceYears = 0;
            private string _englishLevel = LangNone;
            private string _germanLevel = LangNone;
            private string _frenchLevel = LangNone;
            private bool _hasComputerSkills = true;
            private bool _hasRecommendations = false;

            public string FullName
            {
                get { return _fullName; }
                set
                {
                    if (_fullName != value)
                    {
                        _fullName = value;
                        OnPropertyChanged();
                    }
                }
            }

            public DateTime? BirthDate
            {
                get { return _birthDate; }
                set
                {
                    if (_birthDate != value)
                    {
                        _birthDate = value;
                        OnPropertyChanged();
                    }
                }
            }

            public string Education
            {
                get { return _education; }
                set
                {
                    if (_education != value)
                    {
                        _education = value;
                        OnPropertyChanged();
                        OnPropertyChanged(nameof(EducationDisplay));
                    }
                }
            }

            public string EducationDisplay
            {
                get { return _education; }
            }

            public int ExperienceYears
            {
                get { return _experienceYears; }
                set
                {
                    if (_experienceYears != value)
                    {
                        _experienceYears = value;
                        OnPropertyChanged();
                    }
                }
            }

            public string EnglishLevel
            {
                get { return _englishLevel; }
                set
                {
                    if (_englishLevel != value)
                    {
                        _englishLevel = value;
                        OnPropertyChanged();
                        OnPropertyChanged(nameof(LanguagesSummary));
                    }
                }
            }

            public string GermanLevel
            {
                get { return _germanLevel; }
                set
                {
                    if (_germanLevel != value)
                    {
                        _germanLevel = value;
                        OnPropertyChanged();
                        OnPropertyChanged(nameof(LanguagesSummary));
                    }
                }
            }

            public string FrenchLevel
            {
                get { return _frenchLevel; }
                set
                {
                    if (_frenchLevel != value)
                    {
                        _frenchLevel = value;
                        OnPropertyChanged();
                        OnPropertyChanged(nameof(LanguagesSummary));
                    }
                }
            }

            public bool HasComputerSkills
            {
                get { return _hasComputerSkills; }
                set
                {
                    if (_hasComputerSkills != value)
                    {
                        _hasComputerSkills = value;
                        OnPropertyChanged();
                        OnPropertyChanged(nameof(AdditionalInfoSummary));
                    }
                }
            }

            public bool HasRecommendations
            {
                get { return _hasRecommendations; }
                set
                {
                    if (_hasRecommendations != value)
                    {
                        _hasRecommendations = value;
                        OnPropertyChanged();
                        OnPropertyChanged(nameof(AdditionalInfoSummary));
                    }
                }
            }

            public string LanguagesSummary
            {
                get
                {
                    List<string> parts = new List<string>();

                    if (_englishLevel != LangNone)
                    {
                        parts.Add("Англійська (" + _englishLevel.ToLower() + ")");
                    }
                    if (_germanLevel != LangNone)
                    {
                        parts.Add("Німецька (" + _germanLevel.ToLower() + ")");
                    }
                    if (_frenchLevel != LangNone)
                    {
                        parts.Add("Французька (" + _frenchLevel.ToLower() + ")");
                    }

                    if (parts.Count == 0)
                    {
                        return "Іноземні мови: не володіє";
                    }

                    return "Мови: " + string.Join("; ", parts);
                }
            }

            public string AdditionalInfoSummary
            {
                get
                {
                    string pcText = _hasComputerSkills ? "Володіє ПК" : "Без навичок ПК";
                    string recText = _hasRecommendations ? "Є рекомендації" : "Без рекомендацій";
                    return pcText + "  •  " + recText;
                }
            }

            public void CopyFrom(Candidate source)
            {
                FullName = source.FullName;
                BirthDate = source.BirthDate;
                Education = source.Education;
                ExperienceYears = source.ExperienceYears;
                EnglishLevel = source.EnglishLevel;
                GermanLevel = source.GermanLevel;
                FrenchLevel = source.FrenchLevel;
                HasComputerSkills = source.HasComputerSkills;
                HasRecommendations = source.HasRecommendations;
            }

            public event PropertyChangedEventHandler? PropertyChanged;

            protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }