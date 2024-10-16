using EmployeeManagementApp.WebAPI.Models;

namespace EmployeeManagementApp.WebAPI.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        public Task<IEnumerable<Department>> GetAllDepartmentAsync();
        public Task<Department?> GetDepartmentByIdAsync(int id);
        public Task<Department> AddDepartmentAsync(Department department);
        public Task<Department?> UpdateDepartmentAsync(int id, Department department);
        public Task<bool> DeleteDepartmentAsync(int id);
    }
}
