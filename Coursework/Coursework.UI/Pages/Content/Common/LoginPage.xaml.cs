using System;
using System.Windows;
using System.Windows.Controls;
using Coursework.BLL.Services;
using Coursework.Domain;

namespace Coursework.UI.Pages.Content.Common;

public partial class LoginPage : Page
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private bool CheckTheFields()
    {
        return !(String.IsNullOrWhiteSpace(TxtBoxPassword.Password) || String.IsNullOrWhiteSpace(TxtBoxLogin.Text));
    }
    private void Button_Login(object sender, RoutedEventArgs e)
    {
        if (CheckTheFields())
        {
            MainWindow window = (Application.Current.MainWindow as MainWindow)!;
            User current = new User
            {
                Login = TxtBoxLogin.Text,
                Password = TxtBoxPassword.Password
            };
            if (window.manager.UserManager.IsExists(current.Login))
            {
                current = window.manager.UserManager.GetByLogin(current.Login);
                Identity.Login = current.Login;
                Identity.Role = window.manager.RoleManager.GetById(current.RoleId).Title;
                Identity.UserId = current.Id;
                Identity.IsAuthorized = true;
                window.LoginButton.Content = "Log Out";
                if (Identity.Role == "Пациент")
                {
                    window.MenuFrame.NavigationService.Navigate(window.pages["PatientMenu"]);
                    window.ContentFrame.NavigationService.Navigate(window.pages["HelloPage"]);
                }

                if (Identity.Role == "Врач")
                {
                    window.MenuFrame.NavigationService.Navigate(window.pages["DoctorMenu"]);
                    window.ContentFrame.NavigationService.Navigate(window.pages["HelloPage"]);
                }

                if (Identity.Role == "Администратор")
                {
                    window.MenuFrame.NavigationService.Navigate(window.pages["AdminMenu"]);
                    window.ContentFrame.NavigationService.Navigate(window.pages["HelloPage"]);
                }
            }
        }
    }
}