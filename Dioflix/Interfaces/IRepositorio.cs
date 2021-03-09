using System.Collections.Generic;

namespace Dioflix.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> List();
        T ReturnByID(int id);
        void Add(T entity);
        void Delete(int id);
        void Update(int id, T entity);
        int NextId();
    }
}