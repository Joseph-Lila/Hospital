using System.Windows;
using System.Windows.Controls;

namespace Coursework.UI.Pages.Menus;

public partial class PatientMenu : Page
{
    public PatientMenu()
    {
        InitializeComponent();
    }

    private void Hyperlink_OnClick(object sender, RoutedEventArgs e)
    {
        MainWindow window = (Application.Current.MainWindow as MainWindow)!;
        window.ContentFrame.Source = window.pages["ShowPatientChartsPage"];
    }
}