using System.Collections.Generic;
using System.Linq;
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

    public Chamber GetById(int id)
    {
        return GetCollection().FirstOrDefault(x => x.Id == id)!;
    }
}