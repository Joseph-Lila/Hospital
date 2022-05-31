using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Coursework.BLL.DtoModels;

namespace Coursework.UI.Pages.Content.Common;

public partial class ShowDoctorsListPage : Page
{
    public ObservableCollection<BLL.DtoModels.Doctor> Docs { get; set; }
    public ShowDoctorsListPage()
    {
        InitializeComponent();
        MainWindow window = (Application.Current.MainWindow as MainWindow)!;
        Docs = window.manager.GetDoctors();
        Doctors.ItemsSource = Docs;
    }
}