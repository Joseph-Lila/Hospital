using System;
using System.Windows;
using System.Windows.Controls;
using Coursework.Domain;

namespace Coursework.UI.Pages.Content.Admin;

public partial class AddDoctorPage : Page
{
    public AddDoctorPage()
    {
        InitializeComponent();
    }

    private bool CheckTheFields()
    {
        return !(String.IsNullOrWhiteSpace(TxtBoxName.Text) ||
                 String.IsNullOrWhiteSpace(TxtBoxSurname.Text) ||
                 String.IsNullOrWhiteSpace(TxtBoxLastname.Text) ||
                 String.IsNullOrWhiteSpace(TxtBoxPassport.Text) ||
                 String.IsNullOrWhiteSpace(TxtBoxCountry.Text) ||
                 String.IsNullOrWhiteSpace(TxtBoxCity.Text) ||
                 String.IsNullOrWhiteSpace(TxtBoxStreet.Text) ||
                 String.IsNullOrWhiteSpace(TxtBoxHomeNumber.Text) ||
                 String.IsNullOrWhiteSpace(TxtBoxFlatNumber.Text) ||
                 String.IsNullOrWhiteSpace(TxtBoxSex.Text) ||
                 String.IsNullOrWhiteSpace(TxtBoxExperience.Text) ||
                 String.IsNullOrWhiteSpace(TxtBoxSalary.Text) ||
                 String.IsNullOrWhiteSpace(TxtBoxLogin.Text) ||
                 String.IsNullOrWhiteSpace(TxtBoxPassword.Password) ||
                 String.IsNullOrWhiteSpace(TxtBoxAge.Text));
    }
    private void AddDoctor(object sender, RoutedEventArgs e)
    {
        if (CheckTheFields())
        {
            MainWindow window = (Application.Current.MainWindow as MainWindow)!;
            if (window.manager.UserManager.IsExists(TxtBoxLogin.Text))
            {
                MessageBox.Show("Пользователь с таким логином уже существует!");
                return;
            }
            Role? role = window.manager.RoleManager.GetByTitle("Врач");
            if (role != null)
            {
                UserInfo userInfo = new UserInfo
                {
                    Age = Convert.ToInt32(TxtBoxAge.Text),
                    City = TxtBoxCity.Text,
                    Country = TxtBoxCountry.Text,
                    Experience = Int32.Parse(TxtBoxExperience.Text),
                    FlatNumber = TxtBoxFlatNumber.Text,
                    HomeNumber = TxtBoxHomeNumber.Text,
                    Lastname = TxtBoxLastname.Text,
                    Name = TxtBoxName.Text,
                    PassportData = TxtBoxPassport.Text,
                    Street = TxtBoxStreet.Text,
                    Surname = TxtBoxSurname.Text,
                    Sex = TxtBoxSex.Text,
                    Salary = Int32.Parse(TxtBoxSalary.Text)
                };
                int userInfoId = (int)window.manager.UserInfoManager.Create(userInfo)!;
                User user = new User
                {
                    Login = TxtBoxLogin.Text,
                    Password = TxtBoxPassword.Password,
                    RoleId = role.Id,
                    UserInfoId = userInfoId
                };
                window.manager.UserManager.Create(user);
                window.ContentFrame.Source = window.pages["HelloPage"];
            }
        }
        else
        {
            MessageBox.Show("Заполните все поля!");
        }
    }
}