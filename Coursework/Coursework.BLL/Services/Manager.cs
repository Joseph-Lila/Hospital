using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
    public ObservableCollection<Patient> GetPatients()
    {
        int roleId = RoleManager.GetByTitle("Пациент")!.Id;
        List<User> doctors = UserManager.GetCollection().FindAll(x => x.RoleId == roleId);
        ObservableCollection<Patient> answer = new ObservableCollection<Patient>();
        foreach (var doc in doctors)
        {
            UserInfo userInfo = UserInfoManager.GetById(doc.UserInfoId);
            answer.Add(new Patient
            {
                Age = userInfo.Age,
                Country = userInfo.Country!,
                PassportData = userInfo.PassportData!,
                FIO = userInfo.Surname + ' ' + userInfo.Name + ' ' + userInfo.Lastname
            });
        }

        return answer;
    }

    public void MakeNewChart(int chamberNumber, int patientId, string illnessTitle)
    {
        Chamber chamber = ChamberManager.GetCollection().FirstOrDefault(x => x.ChamberNumber == chamberNumber)!;
        Illness illness = IllnessManager.GetCollection().FirstOrDefault(x => x.Title == illnessTitle)!;
        ChartManager.Create(new Chart
        {
            ChamberId = chamber.Id,
            Content = "Content",
            DoctorId = Identity.UserId,
            Finish = null,
            IllnessId = illness.Id,
            PatientId = patientId,
            Start = DateTime.Now
        });
    }
    public ObservableCollection<ChartDto> GetCharts()
    {
        List<Chart> charts = ChartManager.GetCollection();
        ObservableCollection<ChartDto> answer = new ObservableCollection<ChartDto>();
        foreach (var chart in charts)
        {
            User user = UserManager.GetById(chart.PatientId);
            UserInfo userInfo = UserInfoManager.GetById(user.UserInfoId);
            User doc = UserManager.GetById(chart.DoctorId);
            UserInfo docInfo = UserInfoManager.GetById(doc.UserInfoId);
            Chamber chamber = ChamberManager.GetById(chart.ChamberId);
            Illness illness = IllnessManager.GetById(chart.IllnessId);
            answer.Add(new ChartDto
            {
                Id = chart.Id,
                ChanberNumber = chamber.ChamberNumber,
                Content = chart.Content,
                Finish = chart.Finish,
                Start = chart.Start,
                IllnessTitle = illness.Title,
                DocFIO = docInfo.Surname + ' ' + docInfo.Name + ' ' + docInfo.Lastname,
                PatientFIO = userInfo.Surname + ' ' + userInfo.Name + ' ' + userInfo.Lastname
            });
        }
        return answer;
    }
    public ObservableCollection<ChartDto> GetPatientsCharts(int patientId)
    {
        List<Chart> charts = ChartManager.GetCollection().FindAll(x => x.PatientId == patientId);
        ObservableCollection<ChartDto> answer = new ObservableCollection<ChartDto>();
        User user = UserManager.GetById(patientId);
        UserInfo userInfo = UserInfoManager.GetById(user.UserInfoId);
        foreach (var chart in charts)
        {
            User doc = UserManager.GetById(chart.DoctorId);
            UserInfo docInfo = UserInfoManager.GetById(doc.UserInfoId);
            Chamber chamber = ChamberManager.GetById(chart.ChamberId);
            Illness illness = IllnessManager.GetById(chart.IllnessId);
            answer.Add(new ChartDto
            {
                Id = chart.Id,
                ChanberNumber = chamber.ChamberNumber,
                Content = chart.Content,
                Finish = chart.Finish,
                Start = chart.Start,
                IllnessTitle = illness.Title,
                DocFIO = docInfo.Surname + ' ' + docInfo.Name + ' ' + docInfo.Lastname,
                PatientFIO = userInfo.Surname + ' ' + userInfo.Name + ' ' + userInfo.Lastname
            });
        }
        return answer;
    }

    public ObservableCollection<ChartDto> GetUnfinishedDoctorsCharts(int docId)
    {
        List<Chart> charts = ChartManager.GetCollection().FindAll(x => x.DoctorId == docId && x.Finish == null);
        User doc = UserManager.GetById(docId);
        UserInfo docInfo = UserInfoManager.GetById(doc.UserInfoId);
        ObservableCollection<ChartDto> answer = new ObservableCollection<ChartDto>();
        foreach (var chart in charts)
        {
            User user = UserManager.GetById(chart.PatientId);
            UserInfo userInfo = UserInfoManager.GetById(user.UserInfoId);
            Chamber chamber = ChamberManager.GetById(chart.ChamberId);
            Illness illness = IllnessManager.GetById(chart.IllnessId);
            answer.Add(new ChartDto
            {
                Id = chart.Id,
                ChanberNumber = chamber.ChamberNumber,
                Content = chart.Content,
                Finish = chart.Finish,
                Start = chart.Start,
                IllnessTitle = illness.Title,
                DocFIO = docInfo.Surname + ' ' + docInfo.Name + ' ' + docInfo.Lastname,
                PatientFIO = userInfo.Surname + ' ' + userInfo.Name + ' ' + userInfo.Lastname
            });
        }
        return answer;
    }
    public ObservableCollection<ChartDto> GetDoctorsCharts(int docId)
    {
        List<Chart> charts = ChartManager.GetCollection().FindAll(x => x.DoctorId == docId);
        User doc = UserManager.GetById(docId);
        UserInfo docInfo = UserInfoManager.GetById(doc.UserInfoId);
        ObservableCollection<ChartDto> answer = new ObservableCollection<ChartDto>();
        foreach (var chart in charts)
        {
            User user = UserManager.GetById(chart.PatientId);
            UserInfo userInfo = UserInfoManager.GetById(user.UserInfoId);
            Chamber chamber = ChamberManager.GetById(chart.ChamberId);
            Illness illness = IllnessManager.GetById(chart.IllnessId);
            answer.Add(new ChartDto
            {
                Id = chart.Id,
                ChanberNumber = chamber.ChamberNumber,
                Content = chart.Content,
                Finish = chart.Finish,
                Start = chart.Start,
                IllnessTitle = illness.Title,
                DocFIO = docInfo.Surname + ' ' + docInfo.Name + ' ' + docInfo.Lastname,
                PatientFIO = userInfo.Surname + ' ' + userInfo.Name + ' ' + userInfo.Lastname
            });
        }
        return answer;
    }
}