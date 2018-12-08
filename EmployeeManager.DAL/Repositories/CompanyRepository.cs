using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using EmployeeManager.DAL.Interfaces;
using EmployeeManager.Entities;
using EmployeeManager.Entities.Exceptions;

namespace EmployeeManager.DAL.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly string _connectionString;

        public CompanyRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Company> GetAll()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Company>("SELECT * FROM Company").ToList();
            }
        }

        public Company Get(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Company>("SELECT * FROM Company WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public void Create(Company company)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var sqlQuery = "INSERT INTO Company (Name, Size, LegalForm) " +
                                   "VALUES(@Name, @Size, @LegalForm)";
                    db.Execute(sqlQuery, company);
                }
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                throw new UniquenessViolationException($"The company with the name {company.Name} already exists.", ex);
            }
        }

        public void Update(Company company)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var sqlQuery = "UPDATE Company SET Name = @Name, Size = @Size, LegalForm = @LegalForm WHERE Id = @Id";
                    db.Execute(sqlQuery, company);
                }
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                throw new UniquenessViolationException($"The company with the name {company.Name} already exists.", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var sqlQuery = "DELETE FROM Company WHERE Id = @id";
                    db.Execute(sqlQuery, new { id });
                }
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                throw new RelatedEntitiesExistException($"Cannot delete company with employees.", ex);
            }
        }
    }
}
