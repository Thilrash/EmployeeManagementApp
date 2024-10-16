using EmployeeManagementApp.WebAPI.Data;
using EmployeeManagementApp.WebAPI.Models;
using EmployeeManagementApp.WebAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _employeeRepository.GetAllEmployeesAsync();

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);

            if (employee is null) { return NotFound(); }

            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            var newEmployee = await _employeeRepository.AddEmployeeAsync(employee);

            return CreatedAtAction(nameof(GetEmployee), new { id = newEmployee.EmployeeId }, newEmployee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
        {
            var updatedEmployee = await _employeeRepository.UpdateEmployeeAsync(id, employee);

            if (updatedEmployee is null) { return NotFound(); };

            return Ok(updatedEmployee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var deleted = await _employeeRepository.DeleteEmployeeAsync(id);

            if (!deleted) { return NotFound(); }

            return Ok(deleted);
        }
    }
}
