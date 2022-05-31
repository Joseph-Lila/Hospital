using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Coursework.BLL.DtoModels;
using Coursework.BLL.Services;
using Coursework.Domain;

namespace Coursework.UI.Pages.Content.Doctor;

public partial class ShowDoctorsChartsPage : Page
{
    private ChartDto? _lastSelected { get; set; } = null;
    public ObservableCollection<ChartDto> ChartDtos { get; set; }
    public ShowDoctorsChartsPage()
    {
        InitializeComponent();
        MainWindow window = (Application.Current.MainWindow as MainWindow)!;
        ChartDtos = window.manager.GetDoctorsCharts(Identity.UserId);
        Charts.ItemsSource = ChartDtos;
    }

    private void Confirm_Changes(object sender, RoutedEventArgs e)
    {
        MainWindow window = (Application.Current.MainWindow as MainWindow)!;
        Chart old = window.manager.ChartManager.GetById(_lastSelected!.Id);
        Chart @new = new Chart
        {
            ChamberId = old.ChamberId,
            Content = TxtBoxContent.Text,
            DoctorId = old.DoctorId,
            Finish = old.Finish,
            Id = old.Id,
            IllnessId = old.IllnessId,
            PatientId = old.PatientId,
            Start = old.Start
        };
        window.manager.ChartManager.Update(old, @new);
    }

    private void Charts_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ConfirmButton.IsEnabled = true;
        _lastSelected = (ChartDto)Charts.SelectedItem;
        TxtBoxContent.Text = _lastSelected.Content;
    }
}