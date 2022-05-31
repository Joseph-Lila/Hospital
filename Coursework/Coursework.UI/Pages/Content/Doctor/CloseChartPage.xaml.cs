using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Coursework.BLL.DtoModels;
using Coursework.BLL.Services;
using Coursework.Domain;

namespace Coursework.UI.Pages.Content.Doctor;

public partial class CloseChartPage : Page
{
    private ChartDto? _lastSelected { get; set; } = null;
    public ObservableCollection<ChartDto> ChartDtos { get; set; }
    public CloseChartPage()
    {
        InitializeComponent();
        MainWindow window = (Application.Current.MainWindow as MainWindow)!;
        ChartDtos = window.manager.GetUnfinishedDoctorsCharts(Identity.UserId);
        Charts.ItemsSource = ChartDtos;
    }
    
    private void Charts_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        _lastSelected = (ChartDto)Charts.SelectedItem;
        Close.IsEnabled = true;
    }

    private void CloseButton(object sender, RoutedEventArgs e)
    {
        MainWindow window = (Application.Current.MainWindow as MainWindow)!;
        Chart chart = window.manager.ChartManager.GetById(_lastSelected!.Id);
        window.manager.ChartManager.CloseChart(chart);
        window.ContentFrame.Source = window.pages["CloseChartPage"];
    }
}