using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using Coursework.DAL.Interfaces;
using Coursework.DAL.Repositories;
using Coursework.Domain;

namespace Coursework.BLL.Services;

public class ChartManager
{
    private IRepository<Chart> _repository;

    public ChartManager(string connectionString)
    {
        _repository = new ChartRepository(connectionString);
    }

    public List<Chart> GetCollection()
    {
        return _repository.GetCollection();
    }

    public Chart GetById(int id)
    {
        return GetCollection().FirstOrDefault(x => x.Id == id)!;
    }
    
    public void CloseChart(Chart chart)
    {
        Update(chart, new Chart
        {
            ChamberId = chart.ChamberId,
            Content = chart.Content,
            DoctorId = chart.DoctorId,
            Finish = DateTime.Now,
            Id = chart.Id,
            IllnessId = chart.IllnessId,
            PatientId = chart.PatientId,
            Start = chart.Start
        });
    }

    public void Create(Chart chart)
    {
        _repository.Create(chart);
    }
    public void Update(Chart old, Chart @new)
    {
        _repository.Update(old, @new);
    }
}