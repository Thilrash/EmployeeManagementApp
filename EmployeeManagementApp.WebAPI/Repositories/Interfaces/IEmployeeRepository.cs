using EmployeeManagementApp.WebAPI.Models;

namespace EmployeeManagementApp.WebAPI.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        public Task<Employee?> GetEmployeeByIdAsync(int id);
        public Task<Employee> AddEmployeeAsync(Employee employee);
        public Task<Employee?> UpdateEmployeeAsync(int id, Employee employee);
        public Task<bool> DeleteEmployeeAsync(int id);
    }
}
