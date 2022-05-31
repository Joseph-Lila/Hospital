using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Coursework.UI.Pages.Content.Admin;

public partial class ShowPatientsListPage : Page
{
    public ObservableCollection<BLL.DtoModels.Patient> Patients { get; set; }
    public ShowPatientsListPage()
    {
        InitializeComponent();
        MainWindow window = (Application.Current.MainWindow as MainWindow)!;
        Patients = window.manager.GetPatients();
        patientsList.ItemsSource = Patients;
    }
}