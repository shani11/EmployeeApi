using EmployeeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Interface
{
    public interface IDataAccessService
    {
         List<Employee> GetAllEmployee();
        int SaveEmployee(Employee employee);
        int UpdateEmployee(Employee employee, string empId);
        int DeleteEmployee(string empId);
    }
}
