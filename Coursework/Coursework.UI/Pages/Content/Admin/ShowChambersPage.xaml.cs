using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Coursework.Domain;

namespace Coursework.UI.Pages.Content.Admin;

public partial class ShowChambersPage : Page
{
    public ObservableCollection<Chamber> Chambers { get; set; }
    public ShowChambersPage()
    {
        InitializeComponent();
        MainWindow window = (Application.Current.MainWindow as MainWindow)!;
        List<Chamber> chambersList = window.manager.ChamberManager.GetCollection();
        Chambers = new ObservableCollection<Chamber>();
        foreach (var chamber in chambersList)
        {
            Chambers.Add(chamber);
        }

        ChamberListBox.ItemsSource = Chambers;
    }

    private void AddButton_OnClick(object sender, RoutedEventArgs e)
    {
        Chamber chamber = new Chamber
        {
            ChamberNumber = Convert.ToInt32(TxtChamberNumber.Text),
            Department = TxtDepartment.Text,
            HospitalNumber = Convert.ToInt32(TxtHospitalNumber.Text),
            IsFree = true
        };
        MainWindow window = (Application.Current.MainWindow as MainWindow)!;
        int chamberId = window.manager.ChamberManager.Create(chamber);
        chamber.Id = chamberId;
        Chambers.Add(chamber);
    }
}