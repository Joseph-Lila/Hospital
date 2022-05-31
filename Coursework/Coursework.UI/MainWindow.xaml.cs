using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Coursework.BLL.Services;

namespace Coursework.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _connectionString;
        public Dictionary<string, Uri> pages;
        public Manager manager;
        
        public MainWindow()
        {
            InitializeComponent();
            _connectionString = "Data Source=D:\\RiderProjects\\AndreyCW\\SQLite";
            manager = new Manager(_connectionString);
            AddPages();
            MenuFrame.NavigationService.Navigate(pages["GuestMenu"]);
            ContentFrame.NavigationService.Navigate(pages["HelloPage"]);
            MenuFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            ContentFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }
        
        private void AddPages()
        {
            pages = new Dictionary<string, Uri>();
            pages["GuestMenu"] = new Uri("Pages/Menus/GuestMenu.xaml", UriKind.Relative);
            pages["PatientMenu"] = new Uri("Pages/Menus/PatientMenu.xaml", UriKind.Relative);
            pages["DoctorMenu"] = new Uri("Pages/Menus/DoctorMenu.xaml", UriKind.Relative);
            pages["AdminMenu"] = new Uri("Pages/Menus/AdminMenu.xaml", UriKind.Relative);
            pages["HelloPage"] = new Uri("Pages/Content/Guest/HelloPage.xaml", UriKind.Relative);
            pages["SignUpPage"] = new Uri("Pages/Content/Common/SignUpPage.xaml", UriKind.Relative);
            pages["LoginPage"] = new Uri("Pages/Content/Common/LoginPage.xaml", UriKind.Relative);
            pages["ShowDoctorsListPage"] = new Uri("Pages/Content/Common/ShowDoctorsListPage.xaml", UriKind.Relative);
            pages["ShowPatientChartsPage"] = new Uri("Pages/Content/Patient/ShowPatientChartsPage.xaml", UriKind.Relative);
        }

        private void ButtonBase_GoToSignUp(object sender, RoutedEventArgs e)
        {
            ContentFrame.NavigationService.Navigate(pages["SignUpPage"]);
        }

        private void LoginButton_OnClick(object sender, RoutedEventArgs e)
        {
            if ((string)LoginButton.Content == "Log In")
            {
                Identity.IsAuthorized = false;
                Identity.Login = "";
                Identity.Role = "";
                Identity.UserId = 0;
                MenuFrame.NavigationService.Navigate(pages["GuestMenu"]);
                ContentFrame.NavigationService.Navigate(pages["LoginPage"]);
            }
            else
            {
                LoginButton.Content = "Log In";
                Identity.IsAuthorized = false;
                Identity.Login = "";
                Identity.Role = "";
                Identity.UserId = 0;
                MenuFrame.NavigationService.Navigate(pages["GuestMenu"]);
                ContentFrame.NavigationService.Navigate(pages["HelloPage"]);
            }
        }
    }
}