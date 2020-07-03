using EmployeeAPI.Models;
using System.Collections.Generic;

namespace EmployeeAPI.Interface
{
    public interface IEmployeeService
    {
        int CreateEmployee(Employee employee );
        int UpdateEmployee(Employee employee, string empId);
        int DeleteEmployee(string empId);
        IEnumerable<Employee> GetAllEmployee();


    }
}
