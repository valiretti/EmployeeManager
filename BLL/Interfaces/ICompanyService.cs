using System;
using System.Collections.Generic;
using System.Text;
using EmployeeManager.Entities;

namespace EmployeeManager.BLL.Interfaces
{
    public interface ICompanyService
    {
        void Add(Company company);

        void Update(Company company);

        void Delete(int id);

        Company Get(int id);

        IEnumerable<Company> GetAll();
    }
}
