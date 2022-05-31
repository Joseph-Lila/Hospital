using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Coursework.BLL.DtoModels;
using Coursework.BLL.Services;

namespace Coursework.UI.Pages.Content.Admin;

public partial class ShowChartsPage : Page
{
    public ObservableCollection<ChartDto> ChartDtos { get; set; }
    public ShowChartsPage()
    {
        InitializeComponent();
        MainWindow window = (Application.Current.MainWindow as MainWindow)!;
        ChartDtos = window.manager.GetCharts();
        Charts.ItemsSource = ChartDtos;
    }
}