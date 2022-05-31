using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Coursework.BLL.DtoModels;
using Coursework.BLL.Services;

namespace Coursework.UI.Pages.Content.Patient;

public partial class ShowPatientChartsPage : Page
{
    public ObservableCollection<ChartDto> ChartDtos { get; set; }
    public ShowPatientChartsPage()
    {
        InitializeComponent();
        MainWindow window = (Application.Current.MainWindow as MainWindow)!;
        ChartDtos = window.manager.GetPatientsCharts(Identity.UserId);
        Charts.ItemsSource = ChartDtos;
    }
}