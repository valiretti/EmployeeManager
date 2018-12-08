using System;
using System.Collections.Generic;
using System.Text;
using EmployeeManager.Entities;

namespace EmployeeManager.DAL.Interfaces
{
    public interface ICompanyRepository : IRepository<Company>
    {
        IEnumerable<Company> GetAll();
    }
}
