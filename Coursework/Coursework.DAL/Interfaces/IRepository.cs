using System.Collections.Generic;
using Coursework.Domain.Interfaces;


namespace Coursework.DAL.Interfaces;

public interface IRepository<T>
    where T : IHaveId
{
    List<T> GetCollection();
    T? GetItem(int id);
    void Create(T item);
    void Update(T old, T @new);
    void Delete(int id);
}