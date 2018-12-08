using System;
using System.Collections.Generic;
using System.Text;
using EmployeeManager.Entities;

namespace EmployeeManager.BLL.Interfaces
{
    public interface IEmployeeService
    {
        void Add(Employee employee);

        void Update(Employee employee);

        void Delete(int id);

        Employee Get(int id);

        IEnumerable<EmployeeWithCompany> GetAll();
    }
}
