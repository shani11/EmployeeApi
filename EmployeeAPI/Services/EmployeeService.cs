using EmployeeAPI.Interface;
using EmployeeAPI.Models;
using System.Collections.Generic;

namespace EmployeeAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IDataAccessService dataAccessService;
        public EmployeeService(IDataAccessService dataAccessService)
        {
            this.dataAccessService = dataAccessService;
        }
        public int CreateEmployee(Employee employee)
        {
            return dataAccessService.SaveEmployee(employee);
        }

        public int DeleteEmployee(string empId)
        {
            return dataAccessService.DeleteEmployee(empId);
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            var emp = dataAccessService.GetAllEmployee();
            return emp;
        }

        public int UpdateEmployee(Employee employee, string empId)
        {
            return dataAccessService.UpdateEmployee(employee, empId);
        }
    }
}
