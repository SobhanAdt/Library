using System.Collections.Generic;

namespace Library.Services
{
    public interface IRepository<T>
    {
        List<T> GetAll();

        T GetSingel(int id);

        void Insert(T item);

        T Update(T item);

        void Delete(int id);

        void Save();
    }
}