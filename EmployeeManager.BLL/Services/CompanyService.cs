using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using EmployeeManager.BLL.Interfaces;
using EmployeeManager.DAL.Interfaces;
using EmployeeManager.Entities;

namespace EmployeeManager.BLL.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _repository;

        public CompanyService(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public void Add(Company company)
        {
            if (company != null)
            {
                _repository.Create(company);
            }
        }

        public void Update(Company company)
        {
            _repository.Update(company);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Company Get(int id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Company> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
