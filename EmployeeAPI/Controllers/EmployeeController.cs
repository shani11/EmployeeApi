using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeAPI.Interface;
using EmployeeAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        [HttpPost("CreateEmployee")]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            int status = employeeService.CreateEmployee(employee);
            if (status > 0)
                return StatusCode(201);
            else
                return StatusCode(500, "Some error occurred");

        }
        [HttpPut("UpdateEmployee/{empId}")]
        public IActionResult UpdateEmployee([FromBody] Employee employee,string empId)
        {
            int status = employeeService.UpdateEmployee(employee,empId);
            if (status > 0)
                return StatusCode(201,"Details Updated Successfully");
            else
                return StatusCode(500, "Some error occurred while updating");

        }
        [HttpDelete("DeleteEmployee/{empId}")]
        public IActionResult DeleteEmployee(string emId)
        {
            int status = employeeService.DeleteEmployee(emId);
            if (status > 0)
                return Ok("Employee Delete Successfully");
            else
                return NoContent();
        }
        [HttpGet("GetAllEmployees")]
        public IActionResult GetAllEmployees()
        {
            IEnumerable<Employee> employees = employeeService.GetAllEmployee();
            return Ok(employees);

        }
    }
}
