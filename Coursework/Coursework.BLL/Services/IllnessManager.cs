using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Coursework.DAL.Interfaces;
using Coursework.DAL.Repositories;
using Coursework.Domain;

namespace Coursework.BLL.Services;

public class IllnessManager
{
    private IRepository<Illness> _repository;

    public IllnessManager(string connectionString)
    {
        _repository = new IllnessRepository(connectionString);
    }

    public List<Illness> GetCollection()
    {
        return _repository.GetCollection();
    }
    public Illness GetById(int id)
    {
        return _repository.GetItem(id)!;
    }

    public int Create(Illness illness)
    {
        _repository.Create(illness);
        return _repository.GetCollection().FirstOrDefault(x => x.Title == illness.Title)!.Id;
    }
    
    public ObservableCollection<string> GetIllnesses()
    {
        ObservableCollection<string> illnesses = new ObservableCollection<string>();
        foreach (var illness in GetCollection())
        {
            illnesses.Add(illness.Title);
        }

        return illnesses;
    }
}