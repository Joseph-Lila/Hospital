using System.Collections.Generic;
using System.Linq;
using Coursework.DAL.Interfaces;
using Coursework.DAL.Repositories;
using Coursework.Domain;

namespace Coursework.BLL.Services;

public class RoleManager
{
    private IRepository<Role> _repository;

    public RoleManager(string connectionString)
    {
        _repository = new RoleRepository(connectionString);
    }

    public List<Role> GetCollection()
    {
        return _repository.GetCollection();
    }
    
    public Role? GetByTitle(string title)
    {
        return GetCollection().FirstOrDefault(x => x.Title == title);
    }

    public Role GetById(int id)
    {
        return _repository.GetItem(id)!;
    }
}