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

    public Illness GetById(int id)
    {
        return _repository.GetItem(id)!;
    }
}