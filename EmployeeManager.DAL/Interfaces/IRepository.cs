using System.Collections.Generic;

namespace EmployeeManager.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);

        void Create(T item);

        void Update(T item);

        void Delete(int id);
    }
}
