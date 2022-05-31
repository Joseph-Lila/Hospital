using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Coursework.Domain;

namespace Coursework.UI.Pages.Content.Admin;

public partial class ShowIllnessPage : Page
{
    public ObservableCollection<Illness> Illnesses { get; set; }
    public ShowIllnessPage()
    {
        InitializeComponent();
        MainWindow window = (Application.Current.MainWindow as MainWindow)!;
        List<Illness> illnessesList = window.manager.IllnessManager.GetCollection();
        Illnesses = new ObservableCollection<Illness>();
        foreach (var item in illnessesList)
        {
            Illnesses.Add(item);
        }

        IllnessListBox.ItemsSource = Illnesses;
    }
    
    private void AddButton_OnClick(object sender, RoutedEventArgs e)
    {
        Illness illness = new Illness
        {
            Title = TxtTitle.Text,
            Treatment = TxtTreatment.Text,
            Description = TxtDescription.Text
        };
        MainWindow window = (Application.Current.MainWindow as MainWindow)!;
        int illnessId = window.manager.IllnessManager.Create(illness);
        illness.Id = illnessId;
        Illnesses.Add(illness);
    }
}