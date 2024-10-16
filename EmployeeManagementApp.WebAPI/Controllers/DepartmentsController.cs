using EmployeeManagementApp.WebAPI.Models;
using EmployeeManagementApp.WebAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentsRepository;

        public DepartmentsController(IDepartmentRepository departmentsRepository)
        {
            _departmentsRepository = departmentsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            var department = await _departmentsRepository.GetAllDepartmentAsync();

            return Ok(department);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            var department = await _departmentsRepository.GetDepartmentByIdAsync(id);

            if (department is null) { return NotFound(); }

            return Ok(department);
        }

        [HttpPost]
        public async Task<ActionResult<Department>> AddDepartment(Department department)
        {
            var newDepartment = await _departmentsRepository.AddDepartmentAsync(department);

            return CreatedAtAction(nameof(GetDepartment), new { id = newDepartment.DepartmentId }, newDepartment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, Department department)
        {
            var updatedDepartment = await _departmentsRepository.UpdateDepartmentAsync(id, department);

            if (updatedDepartment is null) { return NotFound(); }

            return Ok(updatedDepartment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var deleted = await _departmentsRepository.DeleteDepartmentAsync(id);

            if (!deleted) { return NotFound(); }

            return Ok(deleted);
        }
    }
}
