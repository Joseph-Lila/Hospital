using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using Coursework.BLL.DtoModels;
using Coursework.Domain;

namespace Coursework.BLL.Services;

public class Manager
{
    public RoleManager RoleManager;
    public UserInfoManager UserInfoManager;
    public IllnessManager IllnessManager;
    public ChartManager ChartManager;
    public UserManager UserManager;
    public ChamberManager ChamberManager;
    public Manager(string connectionString)
    {
        RoleManager = new RoleManager(connectionString);
        UserInfoManager = new UserInfoManager(connectionString);
        UserManager = new UserManager(connectionString);
        ChamberManager = new ChamberManager(connectionString);
        IllnessManager = new IllnessManager(connectionString);
        ChartManager = new ChartManager(connectionString);
    }

    public ObservableCollection<Doctor> GetDoctors()
    {
        int roleId = RoleManager.GetByTitle("Врач")!.Id;
        List<User> doctors = UserManager.GetCollection().FindAll(x => x.RoleId == roleId);
        ObservableCollection<Doctor> answer = new ObservableCollection<Doctor>();
        foreach (var doc in doctors)
        {
            UserInfo userInfo = UserInfoManager.GetById(doc.UserInfoId);
            answer.Add(new Doctor
            {
                Age = userInfo.Age,
                Country = userInfo.Country!,
                Experience = (int)userInfo.Experience!,
                FIO = userInfo.Surname + ' ' + userInfo.Name + ' ' + userInfo.Lastname
            });
        }

        return answer;
    }

    public ObservableCollection<ChartDto> GetPatientsCharts(int patientId)
    {
        List<Chart> charts = ChartManager.GetCollection();
        ObservableCollection<ChartDto> answer = new ObservableCollection<ChartDto>();
        foreach (var chart in charts)
        {
            Chamber chamber = ChamberManager.GetById(chart.ChamberId);
            Illness illness = IllnessManager.GetById(chart.IllnessId);
            User user = UserManager.GetById(patientId);
            UserInfo userInfo = UserInfoManager.GetById(user.UserInfoId);
            answer.Add(new ChartDto
            {
                ChanberNumber = chamber.ChamberNumber,
                Content = chart.Content,
                Finish = chart.Finish,
                Start = chart.Start,
                IllnessTitle = illness.Title,
                DocFIO = userInfo.Surname + ' ' + userInfo.Name + ' ' + userInfo.Lastname
            });
        }
        return answer;
    }
}