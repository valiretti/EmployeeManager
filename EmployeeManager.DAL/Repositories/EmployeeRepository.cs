using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using EmployeeManager.DAL.Interfaces;
using EmployeeManager.Entities;

namespace EmployeeManager.DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<EmployeeWithCompany> GetAll()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<EmployeeWithCompany, Company, EmployeeWithCompany>(
                    "SELECT * FROM Employee e JOIN Company c ON e.CompanyId = c.Id",
                    (e, c) =>
                    {
                        e.CompanyName = c.Name;
                        return e;
                    }).ToList();
            }
        }

        public Employee Get(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Employee>("SELECT * FROM Employee WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public void Create(Employee employee)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO Employee (FirstName, LastName, Patronymic, EmploymentDate, Position, CompanyId) " +
                               "VALUES(@FirstName, @LastName, @Patronymic, @EmploymentDate, @Position, @CompanyId)";
                db.Execute(sqlQuery, employee);
            }
        }

        public void Update(Employee employee)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "UPDATE Employee SET FirstName = @FirstName, LastName = @LastName, Patronymic = @Patronymic," +
                               "EmploymentDate = @EmploymentDate, Position = @Position, CompanyId = @CompanyId WHERE Id = @Id";
                db.Execute(sqlQuery, employee);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "DELETE FROM Employee WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}
