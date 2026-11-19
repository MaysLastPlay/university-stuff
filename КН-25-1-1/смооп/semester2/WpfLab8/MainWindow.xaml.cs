using System.Windows;
using WpfLab8.services;
using WpfLab8.windows;

namespace WpfLab8;

public partial class MainWindow : Window
{
    private readonly MainWindowService _service = new();

    public MainWindow()
    {
        InitializeComponent();
        DataContext = _service;
    }

    private void AddCandidate_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new CandidateWindow { Owner = this };
        if (dialog.ShowDialog() == true)
            _service.Add(dialog.ResultCandidate);
    }

    private void EditCandidate_Click(object sender, RoutedEventArgs e)
    {
        if (_service.SelectedCandidate is null)
        {
            MessageBox.Show("Оберіть кандидата зі списку для редагування.", "Увага", MessageBoxButton.OK, MessageBoxImage.Information);
            return;
        }

        var dialog = new CandidateWindow(_service.SelectedCandidate) { Owner = this };
        if (dialog.ShowDialog() == true)
            _service.UpdateSelected(dialog.ResultCandidate);
    }

    private void DeleteCandidate_Click(object sender, RoutedEventArgs e)
    {
        if (_service.SelectedCandidate is null)
        {
            MessageBox.Show("Оберіть кандидата зі списку для видалення.", "Увага", MessageBoxButton.OK, MessageBoxImage.Information);
            return;
        }

        if (MessageBox.Show($"Видалити заявку кандидата \"{_service.SelectedCandidate.FullName}\"?", "Підтвердження видалення", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            _service.DeleteSelected();
    }

    private void ResetFilters_Click(object sender, RoutedEventArgs e) => _service.ResetFilters();
}