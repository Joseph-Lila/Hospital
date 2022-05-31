using System.Collections.Generic;
using System.Linq;
using Coursework.DAL.Interfaces;
using Coursework.DAL.Repositories;
using Coursework.Domain;

namespace Coursework.BLL.Services;

public class UserManager
{
    private IRepository<User> _repository;

    public UserManager(string connectionString)
    {
        _repository = new UserRepository(connectionString);
    }

    public int? Create(User user)
    {
        _repository.Create(user);
        User it = _repository.GetCollection().Find(x => x.Login == user.Login)!;
        return it.Id;
    }

    public List<User> GetCollection()
    {
        return _repository.GetCollection();
    }

    public User GetById(int id)
    {
        return GetCollection().FirstOrDefault(x => x.Id == id)!;
    }
    public User GetByLogin(string login)
    {
        return _repository.GetCollection().FirstOrDefault(x => x.Login == login)!;
    }
    public bool IsExists(string login)
    {
        User? user = _repository.GetCollection().FirstOrDefault(x => x.Login == login);
        if (user == null)
            return false;
        return true;
    }
}