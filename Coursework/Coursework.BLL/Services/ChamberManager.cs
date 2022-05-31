using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Coursework.BLL.DtoModels;
using Coursework.DAL.Interfaces;
using Coursework.DAL.Repositories;
using Coursework.Domain;

namespace Coursework.BLL.Services;

public class ChamberManager
{
    private IRepository<Chamber> _repository;

    public ChamberManager(string connectionString)
    {
        _repository = new ChamberRepository(connectionString);
    }

    public List<Chamber> GetCollection()
    {
        return _repository.GetCollection();
    }

    public int Create(Chamber chamber)
    {
        _repository.Create(chamber);
        return GetCollection().FirstOrDefault(x =>
            x.ChamberNumber == chamber.ChamberNumber && x.HospitalNumber == chamber.HospitalNumber)!.Id;
    }

    public ObservableCollection<int> GetNumbers()
    {
        ObservableCollection<int> numbers = new ObservableCollection<int>();
        foreach (var chamber in GetCollection())
        {
            numbers.Add(chamber.ChamberNumber);
        }

        return numbers;
    }
    public Chamber GetById(int id)
    {
        return GetCollection().FirstOrDefault(x => x.Id == id)!;
    }
}