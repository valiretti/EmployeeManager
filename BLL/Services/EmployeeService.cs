using System;
using System.Collections.Generic;
using System.Text;
using EmployeeManager.BLL.Interfaces;
using EmployeeManager.DAL.Interfaces;
using EmployeeManager.Entities;

namespace EmployeeManager.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public void Add(Employee employee)
        {
            if (employee != null)
            {
                _repository.Create(employee);
            }
        }

        public void Update(Employee employee)
        {
            _repository.Update(employee);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Employee Get(int id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<EmployeeWithCompany> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
