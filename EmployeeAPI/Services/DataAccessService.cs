using Dapper;
using EmployeeAPI.Interface;
using EmployeeAPI.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Services
{
    public class DataAccessService : IDataAccessService
    {
        private IDbConnection _connection;
        public DataAccessService(IConfiguration configuration)
        {
            _connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public List<Employee> GetAllEmployee()
        {
            List<Employee> empList;
            try
            {

                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();
                empList = _connection.Query<Employee>("spGetAllEmployees").ToList();
                _connection.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return empList;
        }
        public int SaveEmployee(Employee employee)
        {
            try
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name", employee.Name);
                parameters.Add("@City", employee.City);
                parameters.Add("@Department", employee.Department);
                parameters.Add("@Gender", employee.Gender);
                _connection.Close();
                return _connection.Execute("spAddEmployee", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        public int UpdateEmployee(Employee employee, string empId)
        {
            try
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmpId", empId);
                parameters.Add("@Name", employee.Name);
                parameters.Add("@City", employee.City);
                parameters.Add("@Department", employee.Department);
                parameters.Add("@Gender", employee.Gender);
                return _connection.Execute("spUpdateEmployee", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int DeleteEmployee(string empId)
        {
            try
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmpId", empId);
                return _connection.Execute("spDeleteEmployee", parameters, commandType: CommandType.StoredProcedure);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
