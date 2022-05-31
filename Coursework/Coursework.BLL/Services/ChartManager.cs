using System.Collections.Generic;
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
}