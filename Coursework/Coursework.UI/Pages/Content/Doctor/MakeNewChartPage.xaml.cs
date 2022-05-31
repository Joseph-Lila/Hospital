using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Coursework.UI.Pages.Content.Doctor;

public partial class MakeNewChartPage : Page
{
    public ObservableCollection<int> Chambers;
    public ObservableCollection<int> Patients;
    public ObservableCollection<string> Illnesses;
    
    public MakeNewChartPage()
    {
        InitializeComponent();
        MainWindow window = (Application.Current.MainWindow as MainWindow)!;
        Chambers = window.manager.ChamberManager.GetNumbers();
        Patients = window.manager.UserManager.GetPatients();
        Illnesses = window.manager.IllnessManager.GetIllnesses();
        chambersList.ItemsSource = Chambers;
        patientsList.ItemsSource = Patients;
        illnessesList.ItemsSource = Illnesses;
        chambersList.SelectedItem = Chambers[0];
        patientsList.SelectedItem = Patients[0];
        illnessesList.SelectedItem = Illnesses[0];
    }

    private void AddButton_OnClick(object sender, RoutedEventArgs e)
    {
        AddButton.IsEnabled = false;
        MainWindow window = (Application.Current.MainWindow as MainWindow)!;
        window.manager.MakeNewChart((int)chambersList.SelectedItem, (int)patientsList.SelectedItem, (string)illnessesList.SelectedItem);
    }

    private void ChambersList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        AddButton.IsEnabled = true;
    }

    private void PatientsList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        AddButton.IsEnabled = true;
    }

    private void IllnessesList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        AddButton.IsEnabled = true;
    }
}