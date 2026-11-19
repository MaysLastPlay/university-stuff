using System.Windows;
using WpfLab8.services;

namespace WpfLab8.windows;

public partial class CandidateWindow : Window
{
    private readonly CandidateWindowService _vm;
    public Candidate ResultCandidate { get; private set; } = new();

    public CandidateWindow(Candidate? existing = null)
    {
        InitializeComponent();
        DataContext = _vm = new CandidateWindowService(existing);
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        if (_vm.TryBuildCandidate() is not Candidate candidate) return;
        ResultCandidate = candidate;
        DialogResult = true;
        Close();
    }
}