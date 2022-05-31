using System.Collections.Generic;
using System.Linq;
using Coursework.DAL.Interfaces;
using Coursework.DAL.Repositories;
using Coursework.Domain;

namespace Coursework.BLL.Services;

public class UserInfoManager
{
    private IRepository<UserInfo> _repository;

    public UserInfoManager(string connectionString)
    {
        _repository = new UserInfoRepository(connectionString);
    }

    public List<UserInfo> GetCollection()
    {
        return _repository.GetCollection();
    }

    public UserInfo GetById(int id)
    {
        return _repository.GetItem(id)!;
    }
    
    public int? Create(UserInfo userInfo)
    {
        _repository.Create(userInfo);
        UserInfo it = _repository.GetCollection().FirstOrDefault(x => x.PassportData == userInfo.PassportData)!;
        return it.Id;
    }
}