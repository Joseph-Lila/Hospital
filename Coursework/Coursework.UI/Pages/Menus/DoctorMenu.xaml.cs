using System.Windows;
using System.Windows.Controls;

namespace Coursework.UI.Pages.Menus;

public partial class DoctorMenu : Page
{
    public DoctorMenu()
    {
        InitializeComponent();
    }

    private void ShowCharts(object sender, RoutedEventArgs e)
    {
        MainWindow window = (Application.Current.MainWindow as MainWindow)!;
        window.ContentFrame.Source = window.pages["ShowDoctorsChartsPage"];
    }

    private void MakeNewChart(object sender, RoutedEventArgs e)
    {
        MainWindow window = (Application.Current.MainWindow as MainWindow)!;
        window.ContentFrame.Source = window.pages["MakeNewChartPage"];
    }

    private void CloseChart(object sender, RoutedEventArgs e)
    {
        MainWindow window = (Application.Current.MainWindow as MainWindow)!;
        window.ContentFrame.Source = window.pages["CloseChartPage"];
    }
}