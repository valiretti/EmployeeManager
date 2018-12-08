using System.Collections.Generic;
using EmployeeManager.Entities;

namespace EmployeeManager.DAL.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        IEnumerable<EmployeeWithCompany> GetAll();
    }
}
